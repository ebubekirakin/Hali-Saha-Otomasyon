namespace Otomasyon2
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.lblDurum = new System.Windows.Forms.Label();
            this.gridViewOneri = new System.Windows.Forms.DataGridView();
            this.btnOkundu = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOneri)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(68, 241);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(54, 17);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.Text = "Öneriler";
            // 
            // gridViewOneri
            // 
            this.gridViewOneri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewOneri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewOneri.Location = new System.Drawing.Point(233, 4);
            this.gridViewOneri.Name = "gridViewOneri";
            this.gridViewOneri.ReadOnly = true;
            this.gridViewOneri.RowTemplate.Height = 24;
            this.gridViewOneri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewOneri.Size = new System.Drawing.Size(625, 439);
            this.gridViewOneri.TabIndex = 1;
            // 
            // btnOkundu
            // 
            this.btnOkundu.Location = new System.Drawing.Point(48, 261);
            this.btnOkundu.Name = "btnOkundu";
            this.btnOkundu.Size = new System.Drawing.Size(91, 31);
            this.btnOkundu.TabIndex = 2;
            this.btnOkundu.Text = "okundu";
            this.btnOkundu.Click += new System.EventHandler(this.btnOkundu_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(48, 313);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(91, 31);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYenile.ImageOptions.SvgImage")));
            this.btnYenile.Location = new System.Drawing.Point(29, 148);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(139, 50);
            this.btnYenile.TabIndex = 18;
            this.btnYenile.Text = "sayfayı yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(870, 455);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnOkundu);
            this.Controls.Add(this.gridViewOneri);
            this.Controls.Add(this.lblDurum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form10";
            this.Load += new System.EventHandler(this.Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOneri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.DataGridView gridViewOneri;
        private DevExpress.XtraEditors.SimpleButton btnOkundu;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
    }
}
