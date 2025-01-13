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
    public partial class Form12 : DevExpress.XtraEditors.XtraForm
    {
        private string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"; // Veritabanı bağlantı bilgisi

        public Form12()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde yapılacak işlemler
        private void Form12_Load(object sender, EventArgs e)
        {            
            SaatleriAta(); // Saat butonlarına saat değerlerini ata    
        }

        private void SaatleriAta()
        {
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8 };
            int baslangicSaati = 16;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = $"{baslangicSaati + i}:00"; // Kullanıcıya gösterilecek saat
                buttons[i].Tag = $"{baslangicSaati + i}:00"; // Saat bilgisi
                buttons[i].BackColor = Color.White; // İlk açıldığında butonlar beyaz olacak
                buttons[i].Enabled = true; // Butonlar aktif olacak
            }
        }

        // Tarih değiştiğinde saatlerin doluluk durumunu kontrol et
        private void dTmPck_ValueChanged(object sender, EventArgs e)
        {
            DateTime tarih = dTmPck.Value.Date;

            // Veritabanından rezervasyonları kontrol et ve saatlerin doluluk durumlarını güncelle
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Saat FROM DolulukDurumu WHERE Tarih = @Tarih AND Doluluk = @Doluluk", conn); // Doluluk = true olan saatler
                cmd.Parameters.AddWithValue("@Tarih", tarih);
                cmd.Parameters.AddWithValue("@Doluluk", true); // True olan (dolu) saatler için

                SqlDataReader reader = cmd.ExecuteReader();
                HashSet<string> doluSaatler = new HashSet<string>();

                while (reader.Read())
                {
                    doluSaatler.Add(reader["Saat"].ToString());
                }

                // Saat butonlarının rengini doluluk durumuna göre ayarla
                Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8 };
                foreach (var button in buttons)
                {
                    if (doluSaatler.Contains(button.Text))
                    {
                        button.BackColor = Color.Red; // Dolu olan saatler kırmızı olur
                        button.Enabled = false; // Dolu saatler seçilemez
                    }
                    else
                    {
                        button.BackColor = Color.Green; // Boş saatler yeşil olur
                        button.Enabled = true; // Boş saatler seçilebilir
                    }
                }
            }
        }

        private void Form12_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // grb konumu
            grbSaatler.Left = (formWidth - grbSaatler.Width) / 2;
            grbSaatler.Top = (formHeight - grbSaatler.Height) / 2;
        }
    }
}