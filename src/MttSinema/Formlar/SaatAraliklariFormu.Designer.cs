namespace MttSinema.Formlar
{
    partial class SaatAraliklariFormu
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
            this.listViewSaatler = new System.Windows.Forms.ListView();
            this.colBaslangic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBitis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saatBitis = new System.Windows.Forms.DateTimePicker();
            this.saatBaslangic = new System.Windows.Forms.DateTimePicker();
            this.lblSure = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // listViewSaatler
            //
            this.listViewSaatler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBaslangic,
            this.colBitis,
            this.colSure});
            this.listViewSaatler.FullRowSelect = true;
            this.listViewSaatler.MultiSelect = false;
            this.listViewSaatler.GridLines = true;
            this.listViewSaatler.HideSelection = false;
            this.listViewSaatler.Location = new System.Drawing.Point(12, 12);
            this.listViewSaatler.Name = "listViewSaatler";
            this.listViewSaatler.Size = new System.Drawing.Size(237, 394);
            this.listViewSaatler.TabIndex = 0;
            this.listViewSaatler.UseCompatibleStateImageBehavior = false;
            this.listViewSaatler.View = System.Windows.Forms.View.Details;
            this.listViewSaatler.SelectedIndexChanged += new System.EventHandler(this.listViewSaatler_SelectedIndexChanged);
            //
            // colBaslangic
            //
            this.colBaslangic.Text = "Başlangıç";
            this.colBaslangic.Width = 83;
            //
            // colBitis
            //
            this.colBitis.Text = "Bitiş";
            this.colBitis.Width = 70;
            //
            // colSure
            //
            this.colSure.Text = "Süre (dk)";
            //
            // panel2
            //
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSil);
            this.panel2.Controls.Add(this.btnEkle);
            this.panel2.Location = new System.Drawing.Point(255, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 184);
            this.panel2.TabIndex = 4;
            //
            // btnSil
            //
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(252, 236, 233);
            this.btnSil.Enabled = false;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSil.Location = new System.Drawing.Point(12, 71);
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
            this.btnEkle.Location = new System.Drawing.Point(12, 16);
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
            this.panel1.Controls.Add(this.saatBitis);
            this.panel1.Controls.Add(this.saatBaslangic);
            this.panel1.Controls.Add(this.lblSure);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(255, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 204);
            this.panel1.TabIndex = 5;
            //
            // saatBitis
            //
            this.saatBitis.Location = new System.Drawing.Point(21, 105);
            this.saatBitis.Name = "saatBitis";
            this.saatBitis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saatBitis.CustomFormat = "HH:mm";
            this.saatBitis.ShowUpDown = true;
            this.saatBitis.Size = new System.Drawing.Size(110, 26);
            this.saatBitis.TabIndex = 1;
            //
            // saatBaslangic
            //
            this.saatBaslangic.Location = new System.Drawing.Point(21, 39);
            this.saatBaslangic.Name = "saatBaslangic";
            this.saatBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saatBaslangic.CustomFormat = "HH:mm";
            this.saatBaslangic.ShowUpDown = true;
            this.saatBaslangic.Size = new System.Drawing.Size(110, 26);
            this.saatBaslangic.TabIndex = 1;
            //
            // lblSure
            //
            this.lblSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSure.ForeColor = System.Drawing.Color.Crimson;
            this.lblSure.Location = new System.Drawing.Point(17, 166);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(128, 25);
            this.lblSure.TabIndex = 0;
            this.lblSure.Text = "0";
            this.lblSure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Süre (dk):";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bitiş saati:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç saati:";
            //
            // SaatAraliklariFormu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 240);
            this.ClientSize = new System.Drawing.Size(436, 415);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewSaatler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaatAraliklariFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saat Aralıkları";
            this.Load += new System.EventHandler(this.SaatAraliklariFormu_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSaatler;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker saatBaslangic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker saatBitis;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colBaslangic;
        private System.Windows.Forms.ColumnHeader colBitis;
        private System.Windows.Forms.ColumnHeader colSure;
    }
}
