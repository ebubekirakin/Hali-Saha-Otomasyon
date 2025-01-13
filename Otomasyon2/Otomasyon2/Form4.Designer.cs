namespace Otomasyon2
{
    partial class Form4
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.grbKantin = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIcecek = new DevExpress.XtraEditors.SimpleButton();
            this.cmbIcecekAdet = new System.Windows.Forms.ComboBox();
            this.cmbIcecek = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYiyecek = new DevExpress.XtraEditors.SimpleButton();
            this.cmbYiyecekAdet = new System.Windows.Forms.ComboBox();
            this.cmbYiyecek = new System.Windows.Forms.ComboBox();
            this.grbKantin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbKantin
            // 
            this.grbKantin.BackgroundImage = global::Otomasyon2.Properties.Resources.abur_cubur_gofret2;
            this.grbKantin.Controls.Add(this.groupBox2);
            this.grbKantin.Controls.Add(this.groupBox1);
            this.grbKantin.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grbKantin.Location = new System.Drawing.Point(164, 45);
            this.grbKantin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbKantin.Name = "grbKantin";
            this.grbKantin.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbKantin.Size = new System.Drawing.Size(886, 425);
            this.grbKantin.TabIndex = 12;
            this.grbKantin.TabStop = false;
            this.grbKantin.Text = "Kantin Alışverişi";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox2.Controls.Add(this.btnIcecek);
            this.groupBox2.Controls.Add(this.cmbIcecekAdet);
            this.groupBox2.Controls.Add(this.cmbIcecek);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(590, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(230, 223);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İçecekler";
            // 
            // btnIcecek
            // 
            this.btnIcecek.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIcecek.Appearance.Options.UseFont = true;
            this.btnIcecek.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIcecek.ImageOptions.SvgImage")));
            this.btnIcecek.Location = new System.Drawing.Point(58, 173);
            this.btnIcecek.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIcecek.Name = "btnIcecek";
            this.btnIcecek.Size = new System.Drawing.Size(121, 31);
            this.btnIcecek.TabIndex = 12;
            this.btnIcecek.Text = "seç";
            this.btnIcecek.Click += new System.EventHandler(this.btnIcecek_Click);
            // 
            // cmbIcecekAdet
            // 
            this.cmbIcecekAdet.BackColor = System.Drawing.Color.Salmon;
            this.cmbIcecekAdet.FormattingEnabled = true;
            this.cmbIcecekAdet.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbIcecekAdet.Location = new System.Drawing.Point(8, 123);
            this.cmbIcecekAdet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbIcecekAdet.Name = "cmbIcecekAdet";
            this.cmbIcecekAdet.Size = new System.Drawing.Size(212, 25);
            this.cmbIcecekAdet.TabIndex = 5;
            this.cmbIcecekAdet.Text = "Adet";
            // 
            // cmbIcecek
            // 
            this.cmbIcecek.BackColor = System.Drawing.Color.Salmon;
            this.cmbIcecek.FormattingEnabled = true;
            this.cmbIcecek.Items.AddRange(new object[] {
            "Su",
            "Çay",
            "Kahve",
            "Meyveli Soda",
            "Maden Suyu",
            "Kola"});
            this.cmbIcecek.Location = new System.Drawing.Point(8, 78);
            this.cmbIcecek.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbIcecek.Name = "cmbIcecek";
            this.cmbIcecek.Size = new System.Drawing.Size(212, 25);
            this.cmbIcecek.TabIndex = 4;
            this.cmbIcecek.Text = "İçecekler";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.btnYiyecek);
            this.groupBox1.Controls.Add(this.cmbYiyecekAdet);
            this.groupBox1.Controls.Add(this.cmbYiyecek);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(59, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(230, 223);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yiyecekler";
            // 
            // btnYiyecek
            // 
            this.btnYiyecek.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYiyecek.Appearance.Options.UseFont = true;
            this.btnYiyecek.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYiyecek.ImageOptions.SvgImage")));
            this.btnYiyecek.Location = new System.Drawing.Point(48, 173);
            this.btnYiyecek.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnYiyecek.Name = "btnYiyecek";
            this.btnYiyecek.Size = new System.Drawing.Size(121, 31);
            this.btnYiyecek.TabIndex = 11;
            this.btnYiyecek.Text = "seç";
            this.btnYiyecek.Click += new System.EventHandler(this.btnYiyecek_Click);
            // 
            // cmbYiyecekAdet
            // 
            this.cmbYiyecekAdet.BackColor = System.Drawing.Color.Salmon;
            this.cmbYiyecekAdet.FormattingEnabled = true;
            this.cmbYiyecekAdet.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbYiyecekAdet.Location = new System.Drawing.Point(9, 123);
            this.cmbYiyecekAdet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbYiyecekAdet.Name = "cmbYiyecekAdet";
            this.cmbYiyecekAdet.Size = new System.Drawing.Size(212, 25);
            this.cmbYiyecekAdet.TabIndex = 4;
            this.cmbYiyecekAdet.Text = "Adet";
            // 
            // cmbYiyecek
            // 
            this.cmbYiyecek.BackColor = System.Drawing.Color.Salmon;
            this.cmbYiyecek.FormattingEnabled = true;
            this.cmbYiyecek.Items.AddRange(new object[] {
            "Tuzlu Kraker",
            "Baharatlı Kraker",
            "Çikolata",
            "Fındıklı Bisküvi",
            "Kremalı Bisküvi"});
            this.cmbYiyecek.Location = new System.Drawing.Point(8, 78);
            this.cmbYiyecek.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbYiyecek.Name = "cmbYiyecek";
            this.cmbYiyecek.Size = new System.Drawing.Size(212, 25);
            this.cmbYiyecek.TabIndex = 3;
            this.cmbYiyecek.Text = "Yiyecekler";
            // 
            // Form4
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Otomasyon2.Properties.Resources.okul_kantinleri_aciliyor;
            this.ClientSize = new System.Drawing.Size(1252, 507);
            this.Controls.Add(this.grbKantin);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.Resize += new System.EventHandler(this.Form4_Resize);
            this.grbKantin.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbKantin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbIcecekAdet;
        private System.Windows.Forms.ComboBox cmbIcecek;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbYiyecekAdet;
        private System.Windows.Forms.ComboBox cmbYiyecek;
        private DevExpress.XtraEditors.SimpleButton btnIcecek;
        private DevExpress.XtraEditors.SimpleButton btnYiyecek;
    }
}
