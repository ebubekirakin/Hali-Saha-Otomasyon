namespace Otomasyon2
{
    partial class Form11
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGelirGider = new System.Windows.Forms.DataGridView();
            this.lblGelirGider = new System.Windows.Forms.Label();
            this.bilgilerDataSet = new Otomasyon2.BilgilerDataSet();
            this.rezervasyonlarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rezervasyonlarTableAdapter = new Otomasyon2.BilgilerDataSetTableAdapters.RezervasyonlarTableAdapter();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGelirGider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervasyonlarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gelir Gider Kayıt";
            // 
            // dgvGelirGider
            // 
            this.dgvGelirGider.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGelirGider.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGelirGider.Location = new System.Drawing.Point(149, 50);
            this.dgvGelirGider.Name = "dgvGelirGider";
            this.dgvGelirGider.ReadOnly = true;
            this.dgvGelirGider.RowTemplate.Height = 24;
            this.dgvGelirGider.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGelirGider.Size = new System.Drawing.Size(650, 350);
            this.dgvGelirGider.TabIndex = 2;
            // 
            // lblGelirGider
            // 
            this.lblGelirGider.AutoSize = true;
            this.lblGelirGider.Location = new System.Drawing.Point(426, 30);
            this.lblGelirGider.Name = "lblGelirGider";
            this.lblGelirGider.Size = new System.Drawing.Size(42, 17);
            this.lblGelirGider.TabIndex = 3;
            this.lblGelirGider.Text = "label2";
            // 
            // bilgilerDataSet
            // 
            this.bilgilerDataSet.DataSetName = "BilgilerDataSet";
            this.bilgilerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rezervasyonlarBindingSource
            // 
            this.rezervasyonlarBindingSource.DataMember = "Rezervasyonlar";
            this.rezervasyonlarBindingSource.DataSource = this.bilgilerDataSet;
            // 
            // rezervasyonlarTableAdapter
            // 
            this.rezervasyonlarTableAdapter.ClearBeforeFill = true;
            // 
            // btnYenile
            // 
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYenile.ImageOptions.SvgImage")));
            this.btnYenile.Location = new System.Drawing.Point(823, 50);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(139, 50);
            this.btnYenile.TabIndex = 19;
            this.btnYenile.Text = "sayfayı yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Otomasyon2.Properties.Resources.gelir_tablosu_nedir_gelir_tablosu_kalemleri_nelerdir_1703250028;
            this.ClientSize = new System.Drawing.Size(974, 422);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.lblGelirGider);
            this.Controls.Add(this.dgvGelirGider);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form11";
            this.Load += new System.EventHandler(this.Form11_Load);
            this.Resize += new System.EventHandler(this.Form11_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGelirGider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bilgilerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervasyonlarBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGelirGider;
        private System.Windows.Forms.Label lblGelirGider;
        private BilgilerDataSet bilgilerDataSet;
        private System.Windows.Forms.BindingSource rezervasyonlarBindingSource;
        private BilgilerDataSetTableAdapters.RezervasyonlarTableAdapter rezervasyonlarTableAdapter;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
    }
}
