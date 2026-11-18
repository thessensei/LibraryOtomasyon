using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MttSinema.Modeller;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal sealed class GiseFormu : GunlukForm
    {
        private readonly ComboBox seanslar = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 315 };
        private readonly NumericUpDown koltuk = new NumericUpDown { Minimum = 1, Width = 80 };
        private readonly Button sat = new Button { Text = "Bilet sat", AutoSize = true, Enabled = false };
        private readonly Button iptal = new Button { Text = "Seçili bileti iptal et", AutoSize = true, Enabled = false };
        private bool programYukleniyor;
        private SeansOzeti SeciliSeans => seanslar.SelectedItem as SeansOzeti;

        internal GiseFormu(SinemaDeposu depo) : base(depo, "Bilet Gişesi", "Bir seans seçin. Satış için koltuk numarasını, iptal için listedeki bileti seçin.")
        {
            Filtreler.Controls.Add(Etiket("Seans:"));
            Filtreler.Controls.Add(seanslar);
            Liste.Columns.Add("Bilet no", 120);
            Liste.Columns.Add("Koltuk no", 140);
            Liste.Columns.Add("Satış fiyatı", 165);
            Islemler.Controls.Add(Etiket("Koltuk no:"));
            Islemler.Controls.Add(koltuk);
            Islemler.Controls.Add(sat);
            Islemler.Controls.Add(iptal);
            seanslar.SelectedIndexChanged += (s, e) => { if (!programYukleniyor) this.Dene(BiletleriGoster); };
            Liste.SelectedIndexChanged += (s, e) => iptal.Enabled = Liste.Secili<Bilet>() != null;
            sat.Click += (s, e) => this.Dene(() =>
            {
                if (SeciliSeans == null) return;
                Depo.BiletSat(SeciliSeans.Id, (int)koltuk.Value);
                Yenile();
            });
            iptal.Click += (s, e) => this.Dene(() =>
            {
                var bilet = Liste.Secili<Bilet>();
                if (bilet == null || !this.Onayla($"{bilet.KoltukNo} numaralı koltuğun bileti iptal edilsin mi?")) return;
                Depo.BiletIptal(bilet.Id);
                Yenile();
            });
        }

        protected override void Yenile()
        {
            long? oncekiId = SeciliSeans?.Id;
            var program = Depo.SeansProgrami(Gun.Value);
            programYukleniyor = true;
            try
            {
                seanslar.DataSource = program;
                if (program.Count != 0) seanslar.SelectedIndex = Math.Max(0, program.FindIndex(s => s.Id == oncekiId));
            }
            finally { programYukleniyor = false; }
            BiletleriGoster();
        }

        private void BiletleriGoster()
        {
            iptal.Enabled = sat.Enabled = koltuk.Enabled = false;
            var seans = SeciliSeans;
            if (seans == null)
            {
                Liste.Items.Clear();
                Ozet.Text = "Bu gün için seans yok. Seans Programı ekranından bir gösterim ekleyebilirsiniz.";
                return;
            }
            var biletler = Depo.Biletler(seans.Id);
            Liste.Doldur(biletler, b => new[] { b.Id.ToString(), b.KoltukNo.ToString(), FormAraclari.Para(b.Ucret) });
            int kalan = seans.Kapasite - biletler.Count;
            Ozet.Text = $"{biletler.Count} satıldı   ·   {kalan} boş koltuk   ·   Bilet fiyatı: {FormAraclari.Para(seans.BiletFiyati)}";
            koltuk.Maximum = seans.Kapasite;
            sat.Enabled = koltuk.Enabled = kalan > 0;
            if (kalan > 0)
            {
                var dolu = new HashSet<int>(biletler.Select(b => b.KoltukNo));
                koltuk.Value = Enumerable.Range(1, seans.Kapasite).First(n => !dolu.Contains(n));
            }
        }
    }
}
