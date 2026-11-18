using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using MttSinema.Modeller;

namespace MttSinema.Veri
{
    internal sealed class KayitHatasi : Exception
    {
        internal KayitHatasi(string mesaj, Exception neden = null) : base(mesaj, neden) { }
    }

    internal sealed class SinemaDeposu : IDisposable
    {
        private readonly SQLiteConnection baglanti;
        private static readonly CultureInfo Turkce = CultureInfo.GetCultureInfo("tr-TR");

        private SinemaDeposu(SQLiteConnection baglanti) { this.baglanti = baglanti; }

        public static SinemaDeposu Ac(string dosyaYolu)
        {
            string yol = Path.GetFullPath(dosyaYolu);
            Directory.CreateDirectory(Path.GetDirectoryName(yol));
            var ayarlar = new SQLiteConnectionStringBuilder { DataSource = yol, ForeignKeys = true, Pooling = false };
            var depo = new SinemaDeposu(new SQLiteConnection(ayarlar.ConnectionString));
            try
            {
                depo.baglanti.Open();
                depo.SemayiHazirla();
                return depo;
            }
            catch
            {
                depo.Dispose();
                throw;
            }
        }

        private void SemayiHazirla()
        {
            using (var islem = baglanti.BeginTransaction(IsolationLevel.Serializable))
            using (var komut = baglanti.CreateCommand())
            {
                komut.Transaction = islem;
                komut.CommandText = "PRAGMA user_version";
                long surum = Convert.ToInt64(komut.ExecuteScalar());
                if (surum == 0)
                {
                    komut.CommandText = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'";
                    if (Convert.ToInt64(komut.ExecuteScalar()) != 0)
                        throw new KayitHatasi("Dosyada tanınmayan tablolar var. Veritabanı değiştirilmedi.");
                    using (var kaynak = typeof(SinemaDeposu).Assembly.GetManifestResourceStream("MttSinema.Veri.Sema.sql"))
                    using (var okuyucu = new StreamReader(kaynak))
                        komut.CommandText = okuyucu.ReadToEnd();
                    komut.ExecuteNonQuery();
                }
                else if (surum != 1)
                    throw new KayitHatasi($"Veritabanı sürümü ({surum}) desteklenmiyor. Dosya değiştirilmedi.");
                islem.Commit();
            }
        }

        public List<Film> Filmler() => Oku(
            "SELECT id, ad, tur, sure_dk, ucret_kr FROM film ORDER BY ad_anahtari",
            r => new Film { Id = r.GetInt64(0), Ad = r.GetString(1), Tur = r.GetString(2),
                SureDakika = r.GetInt32(3), Ucret = r.GetInt64(4) / 100m });

        public void FilmKaydet(long? id, string ad, string tur, int sure, decimal ucret)
        {
            ad = AdiDogrula(ad);
            if (string.IsNullOrWhiteSpace(tur)) throw new KayitHatasi("Bir film türü seçin.");
            if (sure < 30 || sure > 1439) throw new KayitHatasi("Film süresi 30–1439 dakika arasında olmalı.");
            if (ucret < 0 || ucret > 999999.99m || decimal.Round(ucret, 2) != ucret)
                throw new KayitHatasi("Fiyatı 0–999.999,99 TL arasında, en fazla iki ondalık basamakla girin.");
            Yaz(id.HasValue ? "UPDATE film SET ad=@ad, ad_anahtari=@anahtar, tur=@tur, sure_dk=@sure, ucret_kr=@ucret WHERE id=@id"
                : "INSERT INTO film(id, ad, ad_anahtari, tur, sure_dk, ucret_kr) VALUES (@id, @ad, @anahtar, @tur, @sure, @ucret)",
                "Bu adla kayıtlı bir film var.", P("@id", id), P("@ad", ad), P("@anahtar", ad.ToUpper(Turkce)),
                P("@tur", tur.Trim()), P("@sure", sure), P("@ucret", (long)(ucret * 100)));
        }

        public void FilmSil(long id) => Yaz("DELETE FROM film WHERE id=@id",
            "Bu film için planlanmış seans var. Önce seansı kaldırın.", P("@id", id));

        public List<Salon> Salonlar() => Oku("SELECT id, ad, kapasite FROM salon ORDER BY ad_anahtari",
            r => new Salon { Id = r.GetInt64(0), Ad = r.GetString(1), Kapasite = r.GetInt32(2) });

        public void SalonKaydet(long? id, string ad, int kapasite)
        {
            ad = AdiDogrula(ad);
            if (kapasite < 10 || kapasite > 9999) throw new KayitHatasi("Koltuk sayısı 10–9999 arasında olmalı.");
            Yaz(id.HasValue ? "UPDATE salon SET ad=@ad, ad_anahtari=@anahtar, kapasite=@kapasite WHERE id=@id"
                : "INSERT INTO salon(id, ad, ad_anahtari, kapasite) VALUES (@id, @ad, @anahtar, @kapasite)",
                "Bu adla kayıtlı bir salon var.", P("@id", id), P("@ad", ad), P("@anahtar", ad.ToUpper(Turkce)), P("@kapasite", kapasite));
        }

        public void SalonSil(long id) => Yaz("DELETE FROM salon WHERE id=@id",
            "Bu salonda planlanmış seans var. Önce seansı kaldırın.", P("@id", id));

        public List<SaatAraligi> Saatler() => Oku("SELECT id, baslangic_dk, bitis_dk FROM saat_araligi ORDER BY baslangic_dk, bitis_dk",
            r => new SaatAraligi { Id = r.GetInt64(0), BaslangicDakika = r.GetInt32(1), BitisDakika = r.GetInt32(2) });

        public void SaatEkle(int baslangic, int bitis)
        {
            if (baslangic < 0 || bitis > 1439 || baslangic >= bitis)
                throw new KayitHatasi("Bitiş saati aynı gün içinde ve başlangıçtan sonra olmalı.");
            Yaz("INSERT INTO saat_araligi(baslangic_dk, bitis_dk) VALUES (@basla, @bitir)", "Bu saat aralığı zaten kayıtlı.",
                P("@basla", baslangic), P("@bitir", bitis));
        }

        public void SaatSil(long id) => Yaz("DELETE FROM saat_araligi WHERE id=@id",
            "Bu saat aralığını kullanan seans var. Önce seansı kaldırın.", P("@id", id));

        public List<SeansOzeti> SeansProgrami(DateTime tarih) => Oku(@"
            SELECT id, film_adi, salon_adi, sure_dk, baslangic_dk, bitis_dk, kapasite, satilan, ucret_kr, gelir_kr
            FROM seans_ozeti WHERE tarih=@tarih ORDER BY baslangic_dk, salon_adi, id",
            r => new SeansOzeti { Id = r.GetInt64(0), FilmAdi = r.GetString(1), SalonAdi = r.GetString(2), FilmSuresi = r.GetInt32(3),
                Saat = new SaatAraligi { BaslangicDakika = r.GetInt32(4), BitisDakika = r.GetInt32(5) },
                Kapasite = r.GetInt32(6), Satilan = r.GetInt32(7), BiletFiyati = r.GetInt64(8) / 100m, Hasilat = r.GetInt64(9) / 100m },
            Tarih(tarih));

        public void SeansPlanla(DateTime tarih, long filmId, long salonId, long saatId) => Yaz(
            "INSERT INTO seans(tarih, film_id, salon_id, saat_id) VALUES (@tarih, @film, @salon, @saat)",
            "Film, salon veya saat aralığı artık kayıtlı değil. Seçenekleri yenileyin.",
            Tarih(tarih), P("@film", filmId), P("@salon", salonId), P("@saat", saatId));

        public void SeansSil(long id) => Yaz("DELETE FROM seans WHERE id=@id",
            "Bilet satılmış bir seans silinemez. Önce gişeden biletleri iptal edin.", P("@id", id));

        public List<Bilet> Biletler(long seansId) => Oku("SELECT id, koltuk_no, ucret_kr FROM bilet WHERE seans_id=@seans ORDER BY koltuk_no",
            r => new Bilet { Id = r.GetInt64(0), KoltukNo = r.GetInt32(1), Ucret = r.GetInt64(2) / 100m }, P("@seans", seansId));

        public void BiletSat(long seansId, int koltukNo)
        {
            if (koltukNo < 1) throw new KayitHatasi("Koltuk numarası en az 1 olmalı.");
            // Fiyatı okuma ve koltuğu ayırma tek SQL deyimi: iki gişe aynı koltuğu satamaz.
            Yaz(@"INSERT INTO bilet(seans_id, koltuk_no, ucret_kr)
                  SELECT s.id, @koltuk, f.ucret_kr FROM seans s JOIN film f ON f.id=s.film_id WHERE s.id=@seans",
                "Bu koltuk için zaten bilet satılmış.", P("@seans", seansId), P("@koltuk", koltukNo));
        }

        public void BiletIptal(long id) => Yaz("DELETE FROM bilet WHERE id=@id", "Bilet iptal edilemedi.", P("@id", id));

        private static string AdiDogrula(string ad)
        {
            ad = (ad ?? "").Trim().Normalize();
            if (ad.Length == 0 || ad.Length > 120) throw new KayitHatasi("Ad 1–120 karakter olmalı.");
            return ad;
        }

        private static SQLiteParameter P(string ad, object deger) => new SQLiteParameter(ad, deger ?? DBNull.Value);
        private static SQLiteParameter Tarih(DateTime gun) => P("@tarih", gun.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

        private List<T> Oku<T>(string sql, Func<SQLiteDataReader, T> donustur, params SQLiteParameter[] parametreler)
        {
            using (var komut = new SQLiteCommand(sql, baglanti))
            {
                komut.Parameters.AddRange(parametreler);
                using (var satir = komut.ExecuteReader())
                {
                    var sonuc = new List<T>();
                    while (satir.Read()) sonuc.Add(donustur(satir));
                    return sonuc;
                }
            }
        }

        private void Yaz(string sql, string kisitMesaji, params SQLiteParameter[] parametreler)
        {
            using (var komut = new SQLiteCommand(sql, baglanti))
            {
                komut.Parameters.AddRange(parametreler);
                try
                {
                    if (komut.ExecuteNonQuery() != 1) throw new KayitHatasi("Kayıt artık bulunamıyor. Listeyi yenileyin.");
                }
                catch (SQLiteException ex) when (((int)ex.ResultCode & 0xff) == (int)SQLiteErrorCode.Constraint)
                {
                    const string onEk = "Kural: ";
                    int konum = ex.Message.IndexOf(onEk, StringComparison.Ordinal);
                    throw new KayitHatasi(konum < 0 ? kisitMesaji : ex.Message.Substring(konum + onEk.Length).Trim(), ex);
                }
            }
        }

        public void Dispose() => baglanti.Dispose();
    }
}
