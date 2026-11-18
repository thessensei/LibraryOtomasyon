using System;
using System.Drawing;
using System.Windows.Forms;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    // Gişe ve rapor aynı tarih seçiciyi, yenileme davranışını ve liste düzenini kullanır.
    internal abstract class GunlukForm : Form
    {
        protected readonly SinemaDeposu Depo;
        protected readonly DateTimePicker Gun = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd.MM.yyyy", Width = 130 };
        protected readonly FlowLayoutPanel Filtreler = Satir();
        protected readonly FlowLayoutPanel Islemler = Satir();
        protected readonly Label Ozet = new Label { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(8) };
        protected readonly ListView Liste = new ListView { Dock = DockStyle.Fill, View = View.Details, FullRowSelect = true, MultiSelect = false, HideSelection = false };

        protected GunlukForm(SinemaDeposu depo, string baslik, string aciklama)
        {
            Depo = depo;
            Text = baslik;
            Font = new Font("Segoe UI", 10);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 470);
            MinimumSize = new Size(680, 400);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            var duzen = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(16), ColumnCount = 1, RowCount = 5 };
            duzen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            duzen.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            duzen.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            duzen.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            duzen.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            duzen.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            duzen.Controls.Add(new Label { Text = aciklama, Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(12),
                BackColor = Color.FromArgb(28, 62, 73), ForeColor = Color.White }, 0, 0);
            duzen.Controls.Add(Filtreler, 0, 1);
            duzen.Controls.Add(Ozet, 0, 2);
            duzen.Controls.Add(Liste, 0, 3);
            duzen.Controls.Add(Islemler, 0, 4);
            Controls.Add(duzen);
            Filtreler.Controls.Add(Etiket("Tarih:"));
            Filtreler.Controls.Add(Gun);
            var yenile = new Button { Text = "Yenile", AutoSize = true };
            Filtreler.Controls.Add(yenile);
            Ozet.BackColor = Color.FromArgb(235, 243, 241);
            Gun.ValueChanged += (s, e) => this.Dene(Yenile);
            yenile.Click += (s, e) => this.Dene(Yenile);
            Shown += (s, e) => this.Dene(Yenile);
        }

        private static FlowLayoutPanel Satir() => new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(0, 5, 0, 5) };
        protected static Label Etiket(string metin) => new Label { Text = metin, AutoSize = true, Margin = new Padding(3, 7, 3, 3) };
        protected abstract void Yenile();
    }
}
