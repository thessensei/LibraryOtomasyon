using System;
using System.Windows.Forms;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal partial class AnaMenuFormu : Form
    {
        private readonly SinemaDeposu depo;

        internal AnaMenuFormu(SinemaDeposu depo)
        {
            this.depo = depo;
            InitializeComponent();
        }

        private void Ac(Form form) { using (form) form.ShowDialog(this); }
        private void btnFilmler_Click(object sender, EventArgs e) => Ac(new FilmFormu(depo));
        private void btnSalonlar_Click(object sender, EventArgs e) => Ac(new SalonFormu(depo));
        private void btnSaatAraliklari_Click(object sender, EventArgs e) => Ac(new SaatAraliklariFormu(depo));
        private void btnSeansProgrami_Click(object sender, EventArgs e) => Ac(new SeansProgramiFormu(depo));
        private void btnGise_Click(object sender, EventArgs e) => Ac(new GiseFormu(depo));
        private void btnRapor_Click(object sender, EventArgs e) => Ac(new GunlukRaporFormu(depo));
    }
}
