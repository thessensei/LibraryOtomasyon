using System;
using System.Windows.Forms;
using MttSinema.Modeller;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal partial class SalonFormu : Form
    {
        private readonly SinemaDeposu depo;
        private Salon SeciliSalon => listViewSalonlar.Secili<Salon>();

        internal SalonFormu(SinemaDeposu depo)
        {
            this.depo = depo;
            InitializeComponent();
        }

        private void SalonFormu_Load(object sender, EventArgs e) => this.Dene(Yenile);

        private void Yenile()
        {
            listViewSalonlar.Doldur(depo.Salonlar(), s => new[] { s.Ad, s.Kapasite.ToString() });
            SecimiGoster();
        }

        private void SecimiGoster()
        {
            var salon = SeciliSalon;
            btnEkle.Enabled = salon == null;
            btnGuncelle.Enabled = btnSil.Enabled = btnIptal.Enabled = salon != null;
            txtSalonAdi.Text = salon?.Ad ?? "";
            numKapasite.Value = salon?.Kapasite ?? 50;
        }

        private void listViewSalonlar_SelectedIndexChanged(object sender, EventArgs e) => SecimiGoster();
        private void btnIptal_Click(object sender, EventArgs e) => listViewSalonlar.SelectedItems.Clear();
        private void btnEkle_Click(object sender, EventArgs e) => Kaydet(null);
        private void btnGuncelle_Click(object sender, EventArgs e) { if (SeciliSalon != null) Kaydet(SeciliSalon.Id); }

        private void Kaydet(long? id) => this.Dene(() =>
        {
            depo.SalonKaydet(id, txtSalonAdi.Text, (int)numKapasite.Value);
            Yenile();
        });

        private void btnSil_Click(object sender, EventArgs e)
        {
            var salon = SeciliSalon;
            if (salon != null && this.Onayla($"“{salon.Ad}” silinsin mi?"))
                this.Dene(() => { depo.SalonSil(salon.Id); Yenile(); });
        }
    }
}
