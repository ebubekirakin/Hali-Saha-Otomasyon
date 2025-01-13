namespace Otomasyon2
{
    partial class Form5
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
            this.grbOneri = new System.Windows.Forms.GroupBox();
            this.dateTPOneri = new System.Windows.Forms.DateTimePicker();
            this.btnOneri = new System.Windows.Forms.Button();
            this.txbOneri = new System.Windows.Forms.TextBox();
            this.grbOneri.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbOneri
            // 
            this.grbOneri.BackColor = System.Drawing.Color.Gainsboro;
            this.grbOneri.Controls.Add(this.dateTPOneri);
            this.grbOneri.Controls.Add(this.btnOneri);
            this.grbOneri.Controls.Add(this.txbOneri);
            this.grbOneri.Location = new System.Drawing.Point(390, 47);
            this.grbOneri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbOneri.Name = "grbOneri";
            this.grbOneri.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbOneri.Size = new System.Drawing.Size(370, 429);
            this.grbOneri.TabIndex = 5;
            this.grbOneri.TabStop = false;
            this.grbOneri.Text = "Öneri ve Şikayetler";
            // 
            // dateTPOneri
            // 
            this.dateTPOneri.Location = new System.Drawing.Point(77, 196);
            this.dateTPOneri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTPOneri.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTPOneri.Name = "dateTPOneri";
            this.dateTPOneri.Size = new System.Drawing.Size(264, 25);
            this.dateTPOneri.TabIndex = 3;
            // 
            // btnOneri
            // 
            this.btnOneri.Location = new System.Drawing.Point(139, 318);
            this.btnOneri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOneri.Name = "btnOneri";
            this.btnOneri.Size = new System.Drawing.Size(158, 42);
            this.btnOneri.TabIndex = 2;
            this.btnOneri.Text = "Gönder";
            this.btnOneri.UseVisualStyleBackColor = true;
            this.btnOneri.Click += new System.EventHandler(this.btnOneri_Click);
            // 
            // txbOneri
            // 
            this.txbOneri.Location = new System.Drawing.Point(77, 249);
            this.txbOneri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txbOneri.Name = "txbOneri";
            this.txbOneri.Size = new System.Drawing.Size(264, 25);
            this.txbOneri.TabIndex = 1;
            // 
            // Form5
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Otomasyon2.Properties.Resources.k_20150623_22222;
            this.ClientSize = new System.Drawing.Size(1142, 506);
            this.Controls.Add(this.grbOneri);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.Resize += new System.EventHandler(this.Form5_Resize);
            this.grbOneri.ResumeLayout(false);
            this.grbOneri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbOneri;
        private System.Windows.Forms.DateTimePicker dateTPOneri;
        private System.Windows.Forms.Button btnOneri;
        private System.Windows.Forms.TextBox txbOneri;
    }
}
