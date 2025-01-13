namespace Otomasyon2
{
    partial class FormGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGiris));
            this.grpBoxKullanici = new System.Windows.Forms.GroupBox();
            this.txbKullanSifre = new System.Windows.Forms.TextBox();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.txbKullanAdi = new System.Windows.Forms.TextBox();
            this.btnKayit = new System.Windows.Forms.Button();
            this.btnKulGiris = new System.Windows.Forms.Button();
            this.lblSifreKln = new System.Windows.Forms.Label();
            this.grpBoxAdmin = new System.Windows.Forms.GroupBox();
            this.txbAdminSifre = new System.Windows.Forms.TextBox();
            this.lblAdlmin = new System.Windows.Forms.Label();
            this.txbAdminAdi = new System.Windows.Forms.TextBox();
            this.btnAdmGiris = new System.Windows.Forms.Button();
            this.lblSifreAdm = new System.Windows.Forms.Label();
            this.grpBoxKullanici.SuspendLayout();
            this.grpBoxAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxKullanici
            // 
            this.grpBoxKullanici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grpBoxKullanici.BackgroundImage")));
            this.grpBoxKullanici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grpBoxKullanici.Controls.Add(this.txbKullanSifre);
            this.grpBoxKullanici.Controls.Add(this.lblKullanici);
            this.grpBoxKullanici.Controls.Add(this.txbKullanAdi);
            this.grpBoxKullanici.Controls.Add(this.btnKayit);
            this.grpBoxKullanici.Controls.Add(this.btnKulGiris);
            this.grpBoxKullanici.Controls.Add(this.lblSifreKln);
            this.grpBoxKullanici.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpBoxKullanici.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpBoxKullanici.Location = new System.Drawing.Point(86, 42);
            this.grpBoxKullanici.Margin = new System.Windows.Forms.Padding(5);
            this.grpBoxKullanici.Name = "grpBoxKullanici";
            this.grpBoxKullanici.Padding = new System.Windows.Forms.Padding(5);
            this.grpBoxKullanici.Size = new System.Drawing.Size(400, 450);
            this.grpBoxKullanici.TabIndex = 2;
            this.grpBoxKullanici.TabStop = false;
            this.grpBoxKullanici.Text = "Müşteri Giriş";
            // 
            // txbKullanSifre
            // 
            this.txbKullanSifre.Location = new System.Drawing.Point(69, 266);
            this.txbKullanSifre.Margin = new System.Windows.Forms.Padding(5);
            this.txbKullanSifre.Name = "txbKullanSifre";
            this.txbKullanSifre.Size = new System.Drawing.Size(249, 28);
            this.txbKullanSifre.TabIndex = 6;
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblKullanici.Location = new System.Drawing.Point(146, 108);
            this.lblKullanici.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(110, 22);
            this.lblKullanici.TabIndex = 0;
            this.lblKullanici.Text = "kullanıcı adı";
            // 
            // txbKullanAdi
            // 
            this.txbKullanAdi.Location = new System.Drawing.Point(69, 157);
            this.txbKullanAdi.Margin = new System.Windows.Forms.Padding(5);
            this.txbKullanAdi.Name = "txbKullanAdi";
            this.txbKullanAdi.Size = new System.Drawing.Size(249, 28);
            this.txbKullanAdi.TabIndex = 5;
            // 
            // btnKayit
            // 
            this.btnKayit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKayit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKayit.Location = new System.Drawing.Point(93, 394);
            this.btnKayit.Margin = new System.Windows.Forms.Padding(5);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(200, 46);
            this.btnKayit.TabIndex = 4;
            this.btnKayit.Text = "kayıt ol / kayıt sil";
            this.btnKayit.UseVisualStyleBackColor = false;
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // btnKulGiris
            // 
            this.btnKulGiris.BackColor = System.Drawing.Color.GreenYellow;
            this.btnKulGiris.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKulGiris.Location = new System.Drawing.Point(124, 327);
            this.btnKulGiris.Margin = new System.Windows.Forms.Padding(5);
            this.btnKulGiris.Name = "btnKulGiris";
            this.btnKulGiris.Size = new System.Drawing.Size(137, 52);
            this.btnKulGiris.TabIndex = 3;
            this.btnKulGiris.Text = "giriş";
            this.btnKulGiris.UseVisualStyleBackColor = false;
            this.btnKulGiris.Click += new System.EventHandler(this.btnKulGiris_Click);
            // 
            // lblSifreKln
            // 
            this.lblSifreKln.AutoSize = true;
            this.lblSifreKln.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSifreKln.Location = new System.Drawing.Point(177, 221);
            this.lblSifreKln.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSifreKln.Name = "lblSifreKln";
            this.lblSifreKln.Size = new System.Drawing.Size(46, 22);
            this.lblSifreKln.TabIndex = 1;
            this.lblSifreKln.Text = "şifre";
            // 
            // grpBoxAdmin
            // 
            this.grpBoxAdmin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grpBoxAdmin.BackgroundImage")));
            this.grpBoxAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grpBoxAdmin.Controls.Add(this.txbAdminSifre);
            this.grpBoxAdmin.Controls.Add(this.lblAdlmin);
            this.grpBoxAdmin.Controls.Add(this.txbAdminAdi);
            this.grpBoxAdmin.Controls.Add(this.btnAdmGiris);
            this.grpBoxAdmin.Controls.Add(this.lblSifreAdm);
            this.grpBoxAdmin.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpBoxAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpBoxAdmin.Location = new System.Drawing.Point(741, 42);
            this.grpBoxAdmin.Margin = new System.Windows.Forms.Padding(5);
            this.grpBoxAdmin.Name = "grpBoxAdmin";
            this.grpBoxAdmin.Padding = new System.Windows.Forms.Padding(5);
            this.grpBoxAdmin.Size = new System.Drawing.Size(400, 450);
            this.grpBoxAdmin.TabIndex = 3;
            this.grpBoxAdmin.TabStop = false;
            this.grpBoxAdmin.Text = "Admin Giriş";
            // 
            // txbAdminSifre
            // 
            this.txbAdminSifre.Location = new System.Drawing.Point(82, 278);
            this.txbAdminSifre.Margin = new System.Windows.Forms.Padding(5);
            this.txbAdminSifre.Name = "txbAdminSifre";
            this.txbAdminSifre.Size = new System.Drawing.Size(249, 28);
            this.txbAdminSifre.TabIndex = 6;
            // 
            // lblAdlmin
            // 
            this.lblAdlmin.AutoSize = true;
            this.lblAdlmin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAdlmin.Location = new System.Drawing.Point(154, 130);
            this.lblAdlmin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAdlmin.Name = "lblAdlmin";
            this.lblAdlmin.Size = new System.Drawing.Size(110, 22);
            this.lblAdlmin.TabIndex = 0;
            this.lblAdlmin.Text = "kullanıcı adı";
            // 
            // txbAdminAdi
            // 
            this.txbAdminAdi.Location = new System.Drawing.Point(82, 169);
            this.txbAdminAdi.Margin = new System.Windows.Forms.Padding(5);
            this.txbAdminAdi.Name = "txbAdminAdi";
            this.txbAdminAdi.Size = new System.Drawing.Size(249, 28);
            this.txbAdminAdi.TabIndex = 5;
            // 
            // btnAdmGiris
            // 
            this.btnAdmGiris.BackColor = System.Drawing.Color.GreenYellow;
            this.btnAdmGiris.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdmGiris.Location = new System.Drawing.Point(141, 327);
            this.btnAdmGiris.Margin = new System.Windows.Forms.Padding(5);
            this.btnAdmGiris.Name = "btnAdmGiris";
            this.btnAdmGiris.Size = new System.Drawing.Size(137, 52);
            this.btnAdmGiris.TabIndex = 3;
            this.btnAdmGiris.Text = "giriş";
            this.btnAdmGiris.UseVisualStyleBackColor = false;
            this.btnAdmGiris.Click += new System.EventHandler(this.btnAdmGiris_Click);
            // 
            // lblSifreAdm
            // 
            this.lblSifreAdm.AutoSize = true;
            this.lblSifreAdm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSifreAdm.Location = new System.Drawing.Point(187, 236);
            this.lblSifreAdm.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSifreAdm.Name = "lblSifreAdm";
            this.lblSifreAdm.Size = new System.Drawing.Size(46, 22);
            this.lblSifreAdm.TabIndex = 1;
            this.lblSifreAdm.Text = "şifre";
            // 
            // FormGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Otomasyon2.Properties.Resources.AcikZHaliZSahaZYapymi;
            this.ClientSize = new System.Drawing.Size(1198, 560);
            this.Controls.Add(this.grpBoxAdmin);
            this.Controls.Add(this.grpBoxKullanici);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGiris";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.grpBoxKullanici.ResumeLayout(false);
            this.grpBoxKullanici.PerformLayout();
            this.grpBoxAdmin.ResumeLayout(false);
            this.grpBoxAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxKullanici;
        private System.Windows.Forms.TextBox txbKullanSifre;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.TextBox txbKullanAdi;
        private System.Windows.Forms.Button btnKayit;
        private System.Windows.Forms.Label lblSifreKln;
        private System.Windows.Forms.GroupBox grpBoxAdmin;
        private System.Windows.Forms.TextBox txbAdminSifre;
        private System.Windows.Forms.Label lblAdlmin;
        private System.Windows.Forms.TextBox txbAdminAdi;
        private System.Windows.Forms.Label lblSifreAdm;
        private System.Windows.Forms.Button btnAdmGiris;
        private System.Windows.Forms.Button btnKulGiris;
    }
}

