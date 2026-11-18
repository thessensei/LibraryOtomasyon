using System.Linq;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal sealed class GunlukRaporFormu : GunlukForm
    {
        internal GunlukRaporFormu(SinemaDeposu depo) : base(depo, "Günlük Rapor", "Seçilen gösterim gününün bilet satışı, doluluk oranı ve hasılatı.")
        {
            Liste.Columns.Add("Saat", 95);
            Liste.Columns.Add("Film", 195);
            Liste.Columns.Add("Salon", 130);
            Liste.Columns.Add("Bilet", 65);
            Liste.Columns.Add("Kapasite", 85);
            Liste.Columns.Add("Hasılat", 130);
            Islemler.Controls.Add(Etiket("Hasılat satış anındaki fiyatla hesaplanır. İptal edilen biletler toplama dahil edilmez."));
        }

        protected override void Yenile()
        {
            var program = Depo.SeansProgrami(Gun.Value);
            Liste.Doldur(program, s => new[] { s.Saat.Baslangic, s.FilmAdi, s.SalonAdi, s.Satilan.ToString(),
                s.Kapasite.ToString(), FormAraclari.Para(s.Hasilat) });
            long kapasite = program.Sum(s => (long)s.Kapasite);
            long satilan = program.Sum(s => (long)s.Satilan);
            decimal doluluk = kapasite == 0 ? 0 : 100m * satilan / kapasite;
            Ozet.Text = program.Count == 0 ? "Seçilen gün için planlanmış seans yok." :
                $"{program.Count} seans   ·   {satilan} bilet   ·   %{doluluk:N1} doluluk   ·   {FormAraclari.Para(program.Sum(s => s.Hasilat))} hasılat";
        }
    }
}
