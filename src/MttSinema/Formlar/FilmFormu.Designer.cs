namespace MttSinema.Formlar
{
    partial class FilmFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTur = new System.Windows.Forms.ComboBox();
            this.numUcret = new System.Windows.Forms.NumericUpDown();
            this.numSure = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilmAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.listViewFilmler = new System.Windows.Forms.ListView();
            this.colNumara = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFilm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUcret = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbTur);
            this.panel1.Controls.Add(this.numUcret);
            this.panel1.Controls.Add(this.numSure);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFilmAdi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 240);
            this.panel1.TabIndex = 1;
            //
            // cmbTur
            //
            this.cmbTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTur.FormattingEnabled = true;
            this.cmbTur.Items.AddRange(new object[] {
            "Aile",
            "Aksiyon",
            "Aşk",
            "Bilim Kurgu",
            "Dram",
            "Komedi",
            "Korku",
            "Romantik",
            "Suç",
            "Savaş"});
            this.cmbTur.Location = new System.Drawing.Point(120, 84);
            this.cmbTur.Name = "cmbTur";
            this.cmbTur.Size = new System.Drawing.Size(202, 28);
            this.cmbTur.TabIndex = 2;
            //
            // numUcret
            //
            this.numUcret.Location = new System.Drawing.Point(120, 181);
            this.numUcret.Name = "numUcret";
            this.numUcret.Minimum = 0;
            this.numUcret.DecimalPlaces = 2;
            this.numUcret.Maximum = 999999.99m;
            this.numUcret.Size = new System.Drawing.Size(110, 26);
            this.numUcret.TabIndex = 1;
            //
            // numSure
            //
            this.numSure.Location = new System.Drawing.Point(120, 135);
            this.numSure.Name = "numSure";
            this.numSure.Minimum = 30;
            this.numSure.Maximum = 1439;
            this.numSure.Size = new System.Drawing.Size(110, 26);
            this.numSure.TabIndex = 1;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fiyat (TL):";
            //
            // txtFilmAdi
            //
            this.txtFilmAdi.Location = new System.Drawing.Point(120, 31);
            this.txtFilmAdi.Name = "txtFilmAdi";
            this.txtFilmAdi.MaxLength = 120;
            this.txtFilmAdi.Size = new System.Drawing.Size(202, 26);
            this.txtFilmAdi.TabIndex = 1;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Süre (dk):";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tür:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Film adı:";
            //
            // panel2
            //
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnYeni = new System.Windows.Forms.Button();
            this.btnYeni.Text = "Seçimi kaldır";
            this.btnYeni.Location = new System.Drawing.Point(12, 176);
            this.btnYeni.Size = new System.Drawing.Size(202, 40);
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            this.panel2.Controls.Add(this.btnYeni);
            this.panel2.Controls.Add(this.btnGuncelle);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Location = new System.Drawing.Point(361, 231);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 240);
            this.panel2.TabIndex = 1;
            //
            // btnGuncelle
            //
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(221, 235, 241);
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnGuncelle.Location = new System.Drawing.Point(12, 72);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(202, 40);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            //
            // btnSil
            //
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(252, 236, 233);
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSil.Location = new System.Drawing.Point(12, 124);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(202, 40);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            //
            // btnEkle
            //
            this.btnEkle.BackColor = System.Drawing.Color.FromArgb(25, 99, 91);
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(12, 20);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(202, 40);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            //
            // listViewFilmler
            //
            this.listViewFilmler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumara,
            this.colFilm,
            this.colTur,
            this.colSure,
            this.colUcret});
            this.listViewFilmler.FullRowSelect = true;
            this.listViewFilmler.MultiSelect = false;
            this.listViewFilmler.GridLines = true;
            this.listViewFilmler.HideSelection = false;
            this.listViewFilmler.Location = new System.Drawing.Point(12, 12);
            this.listViewFilmler.Name = "listViewFilmler";
            this.listViewFilmler.Size = new System.Drawing.Size(575, 213);
            this.listViewFilmler.TabIndex = 2;
            this.listViewFilmler.UseCompatibleStateImageBehavior = false;
            this.listViewFilmler.View = System.Windows.Forms.View.Details;
            this.listViewFilmler.SelectedIndexChanged += new System.EventHandler(this.listViewFilmler_SelectedIndexChanged);
            //
            // colNumara
            //
            this.colNumara.Text = "No";
            //
            // colFilm
            //
            this.colFilm.Text = "Film Adı";
            this.colFilm.Width = 150;
            //
            // colTur
            //
            this.colTur.Text = "Tür";
            this.colTur.Width = 95;
            //
            // colSure
            //
            this.colSure.Text = "Süre (dk)";
            this.colSure.Width = 70;
            //
            // colUcret
            //
            this.colUcret.Text = "Fiyat (TL)";
            this.colUcret.Width = 90;
            //
            // FilmFormu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 240);
            this.ClientSize = new System.Drawing.Size(599, 486);
            this.Controls.Add(this.listViewFilmler);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FilmFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Film Kataloğu";
            this.Load += new System.EventHandler(this.FilmFormu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYeni;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ComboBox cmbTur;
        private System.Windows.Forms.NumericUpDown numUcret;
        private System.Windows.Forms.NumericUpDown numSure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilmAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.ListView listViewFilmler;
        private System.Windows.Forms.ColumnHeader colNumara;
        private System.Windows.Forms.ColumnHeader colFilm;
        private System.Windows.Forms.ColumnHeader colTur;
        private System.Windows.Forms.ColumnHeader colSure;
        private System.Windows.Forms.ColumnHeader colUcret;
    }
}
