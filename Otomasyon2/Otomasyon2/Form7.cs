using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Otomasyon2
{
    public partial class Form7 : DevExpress.XtraEditors.XtraForm
    {
        public Form7()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)//kantin
        {
            Form9 form9 = new Form9();
            form9.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)//servis krp
        {
            Form8 form8 = new Form8();
            form8.Show();
            //this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)//öneri
        {
            Form10 form10 = new Form10();
            form10.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)//gelir gider
        {
            Form11 form11 = new Form11();
            form11.Show();
            //this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)//saatler
        {
            Form12 form12 = new Form12();
            form12.Show();
            //this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Form7_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // grb konumu
            grbSecim.Left = (formWidth - grbSecim.Width) / 2;
            grbSecim.Top = (formHeight - grbSecim.Height) / 2;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Form7'yi kapat
            this.Close();

            // Yeni bir Form7 oluştur ve aç
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            // FrmKullanici formunu kapat
            this.Close();

            // FormGiris formunu aç
            FormGiris formGiris = new FormGiris();
            formGiris.Show();
        }
    }
}
