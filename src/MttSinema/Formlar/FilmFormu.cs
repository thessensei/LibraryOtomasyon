using System;
using System.Windows.Forms;
using MttSinema.Modeller;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal partial class FilmFormu : Form
    {
        private readonly SinemaDeposu depo;
        private Film SeciliFilm => listViewFilmler.Secili<Film>();

        internal FilmFormu(SinemaDeposu depo)
        {
            this.depo = depo;
            InitializeComponent();
        }

        private void FilmFormu_Load(object sender, EventArgs e) => this.Dene(Yenile);

        private void Yenile()
        {
            listViewFilmler.Doldur(depo.Filmler(), f => new[] { f.Id.ToString(), f.Ad, f.Tur, f.SureDakika.ToString(), f.Ucret.ToString("N2") });
            SecimiGoster();
        }

        private void SecimiGoster()
        {
            var film = SeciliFilm;
            btnEkle.Enabled = film == null;
            btnGuncelle.Enabled = btnSil.Enabled = btnYeni.Enabled = film != null;
            txtFilmAdi.Text = film?.Ad ?? "";
            cmbTur.SelectedItem = film?.Tur;
            numSure.Value = film?.SureDakika ?? 90;
            numUcret.Value = film?.Ucret ?? 0;
        }

        private void listViewFilmler_SelectedIndexChanged(object sender, EventArgs e) => SecimiGoster();
        private void btnYeni_Click(object sender, EventArgs e) => listViewFilmler.SelectedItems.Clear();
        private void btnEkle_Click(object sender, EventArgs e) => Kaydet(null);
        private void btnGuncelle_Click(object sender, EventArgs e) { if (SeciliFilm != null) Kaydet(SeciliFilm.Id); }

        private void Kaydet(long? id) => this.Dene(() =>
        {
            depo.FilmKaydet(id, txtFilmAdi.Text, cmbTur.Text, (int)numSure.Value, numUcret.Value);
            Yenile();
        });

        private void btnSil_Click(object sender, EventArgs e)
        {
            var film = SeciliFilm;
            if (film != null && this.Onayla($"“{film.Ad}” katalogdan silinsin mi?"))
                this.Dene(() => { depo.FilmSil(film.Id); Yenile(); });
        }
    }
}
