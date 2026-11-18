namespace MttSinema.Formlar
{
    partial class SalonFormu
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
            this.listViewSalonlar = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numKapasite = new System.Windows.Forms.NumericUpDown();
            this.txtSalonAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colSalon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKapasite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnIptal = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // listViewSalonlar
            //
            this.listViewSalonlar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSalon,
            this.colKapasite});
            this.listViewSalonlar.FullRowSelect = true;
            this.listViewSalonlar.MultiSelect = false;
            this.listViewSalonlar.GridLines = true;
            this.listViewSalonlar.HideSelection = false;
            this.listViewSalonlar.Location = new System.Drawing.Point(12, 12);
            this.listViewSalonlar.Name = "listViewSalonlar";
            this.listViewSalonlar.Size = new System.Drawing.Size(365, 158);
            this.listViewSalonlar.TabIndex = 0;
            this.listViewSalonlar.UseCompatibleStateImageBehavior = false;
            this.listViewSalonlar.View = System.Windows.Forms.View.Details;
            this.listViewSalonlar.SelectedIndexChanged += new System.EventHandler(this.listViewSalonlar_SelectedIndexChanged);
            //
            // panel2
            //
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnIptal);
            this.panel2.Controls.Add(this.btnGuncelle);
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Location = new System.Drawing.Point(205, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 235);
            this.panel2.TabIndex = 2;
            //
            // btnGuncelle
            //
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(221, 235, 241);
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnGuncelle.Location = new System.Drawing.Point(12, 127);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(142, 40);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            //
            // btnSil
            //
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(252, 236, 233);
            this.btnSil.Enabled = false;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSil.Location = new System.Drawing.Point(12, 72);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(142, 40);
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
            this.btnEkle.Location = new System.Drawing.Point(12, 17);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(142, 40);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numKapasite);
            this.panel1.Controls.Add(this.txtSalonAdi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 235);
            this.panel1.TabIndex = 3;
            //
            // numKapasite
            //
            this.numKapasite.Location = new System.Drawing.Point(21, 131);
            this.numKapasite.Name = "numKapasite";
            this.numKapasite.Minimum = 10;
            this.numKapasite.Maximum = 9999;
            this.numKapasite.Size = new System.Drawing.Size(102, 26);
            this.numKapasite.TabIndex = 1;
            //
            // txtSalonAdi
            //
            this.txtSalonAdi.Location = new System.Drawing.Point(21, 57);
            this.txtSalonAdi.Name = "txtSalonAdi";
            this.txtSalonAdi.MaxLength = 120;
            this.txtSalonAdi.Size = new System.Drawing.Size(145, 26);
            this.txtSalonAdi.TabIndex = 1;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Koltuk sayısı:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salon adı:";
            //
            // colSalon
            //
            this.colSalon.Text = "Salon Adı";
            this.colSalon.Width = 140;
            //
            // colKapasite
            //
            this.colKapasite.Text = "Koltuk sayısı";
            this.colKapasite.Width = 103;
            //
            // btnIptal
            //
            this.btnIptal.BackColor = System.Drawing.SystemColors.Control;
            this.btnIptal.Enabled = false;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnIptal.Location = new System.Drawing.Point(12, 180);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(142, 40);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "Seçimi kaldır";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            //
            // SalonFormu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 240);
            this.ClientSize = new System.Drawing.Size(387, 423);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewSalonlar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalonFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Salonlar";
            this.Load += new System.EventHandler(this.SalonFormu_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSalonlar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numKapasite;
        private System.Windows.Forms.TextBox txtSalonAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colSalon;
        private System.Windows.Forms.ColumnHeader colKapasite;
        private System.Windows.Forms.Button btnIptal;
    }
}
