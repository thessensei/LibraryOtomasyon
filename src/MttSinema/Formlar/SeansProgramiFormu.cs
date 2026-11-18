using System;
using System.Windows.Forms;
using MttSinema.Modeller;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal partial class SeansProgramiFormu : Form
    {
        private readonly SinemaDeposu depo;

        internal SeansProgramiFormu(SinemaDeposu depo)
        {
            this.depo = depo;
            InitializeComponent();
            programTarihi.ValueChanged += (s, e) => this.Dene(Yenile);
            listViewSeanslar.SelectedIndexChanged += (s, e) => btnSeansSil.Enabled = listViewSeanslar.SelectedItems.Count > 0;
        }

        private void SeansProgramiFormu_Load(object sender, EventArgs e) => this.Dene(() =>
        {
            cBoxFilmler.DataSource = depo.Filmler();
            cBoxSalonlar.DataSource = depo.Salonlar();
            cBoxSaatler.DataSource = depo.Saatler();
            Yenile();
        });

        private void Yenile()
        {
            var program = depo.SeansProgrami(programTarihi.Value);
            listViewSeanslar.Doldur(program, s => new[] { s.Id.ToString(), s.SalonAdi, s.Saat.Baslangic, s.Saat.Bitis,
                s.Saat.SureDakika.ToString(), s.FilmAdi, s.FilmSuresi.ToString() });
            btnSeansSil.Enabled = false;
            btnSeansEkle.Enabled = cBoxFilmler.Items.Count > 0 && cBoxSalonlar.Items.Count > 0 && cBoxSaatler.Items.Count > 0;
            lblDurum.Text = btnSeansEkle.Enabled ? $"Seçilen gün: {program.Count} seans" : "Önce film, salon ve saat aralığı ekleyin.";
        }

        private void btnSeansEkle_Click(object sender, EventArgs e) => this.Dene(() =>
        {
            var film = cBoxFilmler.SelectedItem as Film;
            var salon = cBoxSalonlar.SelectedItem as Salon;
            var saat = cBoxSaatler.SelectedItem as SaatAraligi;
            if (film == null || salon == null || saat == null) throw new KayitHatasi("Film, salon ve saat aralığı seçin.");
            depo.SeansPlanla(programTarihi.Value, film.Id, salon.Id, saat.Id);
            Yenile();
        });

        private void btnSeansSil_Click(object sender, EventArgs e)
        {
            var seans = listViewSeanslar.Secili<SeansOzeti>();
            if (seans != null && this.Onayla($"{seans} seansı programdan kaldırılsın mı?"))
                this.Dene(() => { depo.SeansSil(seans.Id); Yenile(); });
        }

        private void btnKapat_Click(object sender, EventArgs e) => Close();
    }
}
