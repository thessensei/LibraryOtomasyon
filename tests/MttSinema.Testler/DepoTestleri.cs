using System;
using System.IO;
using System.Linq;
using System.Data.SQLite;
using MttSinema.Veri;

namespace MttSinema.Testler
{
    internal static class DepoTestleri
    {
        private static int Main()
        {
            string klasor = Path.Combine(Path.GetTempPath(), "MttSinema-Test-" + Guid.NewGuid().ToString("N"));
            string yol = Path.Combine(klasor, "sinema.db");
            try
            {
                SatisDongusu(yol);
                BilinmeyenSurumuKoru(yol);
                Console.WriteLine("Kalıcı kayıt, planlama, gişe, hasılat ve sürüm denetimleri geçti.");
                return 0;
            }
            catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
            finally { if (Directory.Exists(klasor)) Directory.Delete(klasor, true); }
        }

        private static void SatisDongusu(string yol)
        {
            var gun = new DateTime(2026, 11, 18);
            long film, salon, saat, seans;
            using (var depo = SinemaDeposu.Ac(yol))
            {
                Dogrula(!depo.Filmler().Any(), "İlk açılış boş olmalı");
                depo.FilmKaydet(null, "  İz - O'Brien  ", "Dram", 90, 85.25m);
                var kayit = depo.Filmler().Single();
                film = kayit.Id;
                Dogrula(kayit.Ad == "İz - O'Brien", "Film adı korunmalı");
                Reddedilmeli(() => depo.FilmKaydet(null, "iz - o'brien", "Dram", 90, 85m), "Türkçe ad tekrarı");
                Reddedilmeli(() => depo.FilmKaydet(null, "Kısa", "Dram", 20, 1m), "Kısa film");
                Reddedilmeli(() => depo.FilmKaydet(film, kayit.Ad, "Dram", 90, 12.345m), "Kesirli kuruş");
                depo.SalonKaydet(null, "Mavi", 24);
                salon = depo.Salonlar().Single().Id;
                depo.SaatEkle(600, 690);
                saat = depo.Saatler().Single().Id;
                depo.SaatEkle(660, 780);
                var kesisen = depo.Saatler().Last().Id;
                depo.SeansPlanla(gun, film, salon, saat);
                seans = depo.SeansProgrami(gun).Single().Id;
                Reddedilmeli(() => depo.SeansPlanla(gun, film, salon, kesisen), "Kısmi çakışma");
                depo.SeansPlanla(gun.AddDays(1), film, salon, kesisen);
                Reddedilmeli(() => depo.FilmKaydet(film, kayit.Ad, "Dram", 91, 85m), "Programı bozan süre artışı");
                Reddedilmeli(() => depo.SaatSil(saat), "Seansın saatini silme");
                Reddedilmeli(() => depo.FilmSil(film), "Seansın filmini silme");
                Reddedilmeli(() => depo.SalonSil(salon), "Seansın salonunu silme");
                depo.BiletSat(seans, 24);
                using (var ikinciGise = SinemaDeposu.Ac(yol))
                    Reddedilmeli(() => ikinciGise.BiletSat(seans, 24), "Aynı koltuğa ikinci satış");
                Reddedilmeli(() => depo.BiletSat(seans, 25), "Kapasite dışı koltuk");
                Reddedilmeli(() => depo.SalonKaydet(salon, "Mavi", 23), "Satılmış koltuğu kaldırma");
                Reddedilmeli(() => depo.SeansSil(seans), "Biletli seansı silme");
                depo.FilmKaydet(film, kayit.Ad, "Dram", 90, 100.50m);
                depo.BiletSat(seans, 1);
            }
            using (var depo = SinemaDeposu.Ac(yol))
            {
                var ozet = depo.SeansProgrami(gun).Single();
                Dogrula(ozet.Id == seans && ozet.Satilan == 2 && ozet.Hasilat == 185.75m, "Yeniden açılışta satış fiyatı ve doluluk");
                Dogrula(depo.SeansProgrami(gun.AddDays(1)).Single().Hasilat == 0, "Günler ayrı raporlanmalı");
                var eskiBilet = depo.Biletler(seans).Single(b => b.KoltukNo == 24);
                depo.BiletIptal(eskiBilet.Id);
                Dogrula(depo.SeansProgrami(gun).Single().Hasilat == 100.50m, "İptal sonrası hasılat");
                depo.BiletSat(seans, 24);
                Dogrula(depo.SeansProgrami(gun).Single().Hasilat == 201m, "Boşalan koltuğa yeni fiyatla satış");
                foreach (var b in depo.Biletler(seans)) depo.BiletIptal(b.Id);
                depo.SeansSil(seans);
                depo.SeansSil(depo.SeansProgrami(gun.AddDays(1)).Single().Id);
                depo.FilmSil(film);
                depo.SalonSil(salon);
                depo.SaatSil(saat);
                Dogrula(!depo.Filmler().Any() && !depo.Salonlar().Any(), "Bağımlılıklar kalkınca silme");
            }
        }

        private static void BilinmeyenSurumuKoru(string yol)
        {
            using (var db = new SQLiteConnection(new SQLiteConnectionStringBuilder { DataSource = yol }.ConnectionString))
            {
                db.Open();
                using (var komut = new SQLiteCommand("PRAGMA user_version=99", db)) komut.ExecuteNonQuery();
                Reddedilmeli(() => { using (SinemaDeposu.Ac(yol)) { } }, "Bilinmeyen sürümü açma");
                using (var komut = new SQLiteCommand("PRAGMA user_version", db))
                    Dogrula(Convert.ToInt64(komut.ExecuteScalar()) == 99, "Bilinmeyen sürüm değişmemeli");
            }
        }

        private static void Dogrula(bool kosul, string ad)
        {
            if (!kosul) throw new Exception("Başarısız: " + ad);
        }

        private static void Reddedilmeli(Action islem, string ad)
        {
            try { islem(); }
            catch (KayitHatasi) { return; }
            throw new Exception("İşlem engellenmeliydi: " + ad);
        }
    }
}
