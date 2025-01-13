namespace Otomasyon2
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.btnEngelle = new DevExpress.XtraEditors.SimpleButton();
            this.txtKullaniciAra = new DevExpress.XtraEditors.TextEdit();
            this.engellemeyiKaldir = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAra.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Ara";
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(54, 109);
            this.dataGridViewUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowTemplate.Height = 24;
            this.dataGridViewUsers.Size = new System.Drawing.Size(482, 368);
            this.dataGridViewUsers.TabIndex = 1;
            // 
            // btnEngelle
            // 
            this.btnEngelle.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEngelle.Appearance.Options.UseFont = true;
            this.btnEngelle.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEngelle.ImageOptions.SvgImage")));
            this.btnEngelle.Location = new System.Drawing.Point(586, 285);
            this.btnEngelle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEngelle.Name = "btnEngelle";
            this.btnEngelle.Size = new System.Drawing.Size(172, 40);
            this.btnEngelle.TabIndex = 2;
            this.btnEngelle.Text = "engelle";
            this.btnEngelle.Click += new System.EventHandler(this.btnEngelle_Click);
            // 
            // txtKullaniciAra
            // 
            this.txtKullaniciAra.Location = new System.Drawing.Point(168, 43);
            this.txtKullaniciAra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtKullaniciAra.Name = "txtKullaniciAra";
            this.txtKullaniciAra.Size = new System.Drawing.Size(192, 22);
            this.txtKullaniciAra.TabIndex = 3;
            this.txtKullaniciAra.TextChanged += new System.EventHandler(this.txtKullaniciAra_TextChanged);
            // 
            // engellemeyiKaldir
            // 
            this.engellemeyiKaldir.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.engellemeyiKaldir.Appearance.Options.UseFont = true;
            this.engellemeyiKaldir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("engellemeyiKaldir.ImageOptions.SvgImage")));
            this.engellemeyiKaldir.Location = new System.Drawing.Point(586, 340);
            this.engellemeyiKaldir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.engellemeyiKaldir.Name = "engellemeyiKaldir";
            this.engellemeyiKaldir.Size = new System.Drawing.Size(172, 40);
            this.engellemeyiKaldir.TabIndex = 4;
            this.engellemeyiKaldir.Text = "engellemeyi kaldır";
            this.engellemeyiKaldir.Click += new System.EventHandler(this.engellemeyiKaldir_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYenile.ImageOptions.SvgImage")));
            this.btnYenile.Location = new System.Drawing.Point(619, 109);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(139, 50);
            this.btnYenile.TabIndex = 16;
            this.btnYenile.Text = "sayfayı yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // Form8
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Otomasyon2.Properties.Resources.Vesaik_Karsiligi_Odeme;
            this.ClientSize = new System.Drawing.Size(1027, 522);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.engellemeyiKaldir);
            this.Controls.Add(this.txtKullaniciAra);
            this.Controls.Add(this.btnEngelle);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form8";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAra.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private DevExpress.XtraEditors.SimpleButton btnEngelle;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAra;
        private DevExpress.XtraEditors.SimpleButton engellemeyiKaldir;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
    }
}
