namespace MttSinema.Formlar
{
    partial class AnaMenuFormu
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnRapor = new System.Windows.Forms.Button();
            this.btnGise = new System.Windows.Forms.Button();
            this.btnSalonlar = new System.Windows.Forms.Button();
            this.btnSeansProgrami = new System.Windows.Forms.Button();
            this.btnSaatAraliklari = new System.Windows.Forms.Button();
            this.btnFilmler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblBaslik
            //
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(28, 62, 73);
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(774, 89);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "MTT SİNEMA";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnRapor
            //
            this.btnRapor.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnRapor.FlatAppearance.BorderSize = 1;
            this.btnRapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRapor.ForeColor = System.Drawing.Color.FromArgb(28, 62, 73);
            this.btnRapor.Image = global::MttSinema.Properties.Resources.GunlukRapor;
            this.btnRapor.Location = new System.Drawing.Point(489, 340);
            this.btnRapor.Name = "btnRapor";
            this.btnRapor.Size = new System.Drawing.Size(165, 217);
            this.btnRapor.TabIndex = 6;
            this.btnRapor.Text = "Günlük Rapor";
            this.btnRapor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRapor.UseVisualStyleBackColor = true;
            this.btnRapor.Click += new System.EventHandler(this.btnRapor_Click);
            //
            // btnGise
            //
            this.btnGise.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnGise.FlatAppearance.BorderSize = 1;
            this.btnGise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGise.ForeColor = System.Drawing.Color.FromArgb(28, 62, 73);
            this.btnGise.Image = global::MttSinema.Properties.Resources.BiletGisesi;
            this.btnGise.Location = new System.Drawing.Point(302, 340);
            this.btnGise.Name = "btnGise";
            this.btnGise.Size = new System.Drawing.Size(165, 217);
            this.btnGise.TabIndex = 5;
            this.btnGise.Text = "Bilet Gişesi";
            this.btnGise.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGise.UseVisualStyleBackColor = true;
            this.btnGise.Click += new System.EventHandler(this.btnGise_Click);
            //
            // btnSalonlar
            //
            this.btnSalonlar.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSalonlar.FlatAppearance.BorderSize = 1;
            this.btnSalonlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalonlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSalonlar.ForeColor = System.Drawing.Color.FromArgb(28, 62, 73);
            this.btnSalonlar.Image = global::MttSinema.Properties.Resources.Salonlar;
            this.btnSalonlar.Location = new System.Drawing.Point(302, 101);
            this.btnSalonlar.Name = "btnSalonlar";
            this.btnSalonlar.Size = new System.Drawing.Size(165, 217);
            this.btnSalonlar.TabIndex = 2;
            this.btnSalonlar.Text = "Salonlar";
            this.btnSalonlar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalonlar.UseVisualStyleBackColor = true;
            this.btnSalonlar.Click += new System.EventHandler(this.btnSalonlar_Click);
            //
            // btnSeansProgrami
            //
            this.btnSeansProgrami.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSeansProgrami.FlatAppearance.BorderSize = 1;
            this.btnSeansProgrami.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeansProgrami.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSeansProgrami.ForeColor = System.Drawing.Color.FromArgb(28, 62, 73);
            this.btnSeansProgrami.Image = global::MttSinema.Properties.Resources.SeansProgrami;
            this.btnSeansProgrami.Location = new System.Drawing.Point(107, 340);
            this.btnSeansProgrami.Name = "btnSeansProgrami";
            this.btnSeansProgrami.Size = new System.Drawing.Size(165, 217);
            this.btnSeansProgrami.TabIndex = 4;
            this.btnSeansProgrami.Text = "Seans Programı";
            this.btnSeansProgrami.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeansProgrami.UseVisualStyleBackColor = true;
            this.btnSeansProgrami.Click += new System.EventHandler(this.btnSeansProgrami_Click);
            //
            // btnSaatAraliklari
            //
            this.btnSaatAraliklari.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSaatAraliklari.FlatAppearance.BorderSize = 1;
            this.btnSaatAraliklari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaatAraliklari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSaatAraliklari.ForeColor = System.Drawing.Color.FromArgb(28, 62, 73);
            this.btnSaatAraliklari.Image = global::MttSinema.Properties.Resources.SaatAraliklari;
            this.btnSaatAraliklari.Location = new System.Drawing.Point(489, 101);
            this.btnSaatAraliklari.Name = "btnSaatAraliklari";
            this.btnSaatAraliklari.Size = new System.Drawing.Size(165, 217);
            this.btnSaatAraliklari.TabIndex = 3;
            this.btnSaatAraliklari.Text = "Saat Aralıkları";
            this.btnSaatAraliklari.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaatAraliklari.UseVisualStyleBackColor = true;
            this.btnSaatAraliklari.Click += new System.EventHandler(this.btnSaatAraliklari_Click);
            //
            // btnFilmler
            //
            this.btnFilmler.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnFilmler.FlatAppearance.BorderSize = 1;
            this.btnFilmler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilmler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFilmler.ForeColor = System.Drawing.Color.FromArgb(28, 62, 73);
            this.btnFilmler.Image = global::MttSinema.Properties.Resources.FilmKatalogu;
            this.btnFilmler.Location = new System.Drawing.Point(107, 101);
            this.btnFilmler.Name = "btnFilmler";
            this.btnFilmler.Size = new System.Drawing.Size(165, 217);
            this.btnFilmler.TabIndex = 1;
            this.btnFilmler.Text = "Film Kataloğu";
            this.btnFilmler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFilmler.UseVisualStyleBackColor = true;
            this.btnFilmler.Click += new System.EventHandler(this.btnFilmler_Click);
            //
            // AnaMenuFormu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 592);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRapor);
            this.Controls.Add(this.btnGise);
            this.Controls.Add(this.btnSalonlar);
            this.Controls.Add(this.btnSeansProgrami);
            this.Controls.Add(this.btnSaatAraliklari);
            this.Controls.Add(this.btnFilmler);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AnaMenuFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTT Sinema · Ana Menü";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnFilmler;
        private System.Windows.Forms.Button btnSeansProgrami;
        private System.Windows.Forms.Button btnSalonlar;
        private System.Windows.Forms.Button btnGise;
        private System.Windows.Forms.Button btnSaatAraliklari;
        private System.Windows.Forms.Button btnRapor;
    }
}
