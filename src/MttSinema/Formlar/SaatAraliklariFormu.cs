using System;
using System.Windows.Forms;
using MttSinema.Modeller;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal partial class SaatAraliklariFormu : Form
    {
        private readonly SinemaDeposu depo;
        private int Baslangic => saatBaslangic.Value.Hour * 60 + saatBaslangic.Value.Minute;
        private int Bitis => saatBitis.Value.Hour * 60 + saatBitis.Value.Minute;

        internal SaatAraliklariFormu(SinemaDeposu depo)
        {
            this.depo = depo;
            InitializeComponent();
            saatBaslangic.Value = DateTime.Today.AddHours(10);
            saatBitis.Value = DateTime.Today.AddHours(12);
            saatBaslangic.ValueChanged += (s, e) => SureyiGoster();
            saatBitis.ValueChanged += (s, e) => SureyiGoster();
            SureyiGoster();
        }

        private void SureyiGoster() => lblSure.Text = Bitis > Baslangic ? (Bitis - Baslangic).ToString() : "—";
        private void SaatAraliklariFormu_Load(object sender, EventArgs e) => this.Dene(Yenile);

        private void Yenile()
        {
            listViewSaatler.Doldur(depo.Saatler(), a => new[] { a.Baslangic, a.Bitis, a.SureDakika.ToString() });
            btnSil.Enabled = false;
        }

        private void listViewSaatler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var aralik = listViewSaatler.Secili<SaatAraligi>();
            btnSil.Enabled = aralik != null;
            if (aralik == null) return;
            saatBaslangic.Value = DateTime.Today.AddMinutes(aralik.BaslangicDakika);
            saatBitis.Value = DateTime.Today.AddMinutes(aralik.BitisDakika);
        }

        private void btnEkle_Click(object sender, EventArgs e) => this.Dene(() => { depo.SaatEkle(Baslangic, Bitis); Yenile(); });

        private void btnSil_Click(object sender, EventArgs e)
        {
            var aralik = listViewSaatler.Secili<SaatAraligi>();
            if (aralik != null && this.Onayla($"{aralik} saat aralığı silinsin mi?"))
                this.Dene(() => { depo.SaatSil(aralik.Id); Yenile(); });
        }
    }
}
