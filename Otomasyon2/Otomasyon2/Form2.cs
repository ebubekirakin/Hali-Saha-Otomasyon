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
    public partial class FrmKullanici : DevExpress.XtraEditors.XtraForm
    {
        private int kullaniciId;
        public FrmKullanici(int id)
        {
            InitializeComponent();
            kullaniciId = id; // Kullanıcı ID'sini kaydediyoruz
        }

        private void button1_Click(object sender, EventArgs e) //maç saati
        {
            Form3 form3 = new Form3(kullaniciId);
            form3.Show();
            // this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //kantin
        {
            Form4 form4 = new Form4(kullaniciId);
            form4.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //öneri şikayet
        {
            Form5 form5 = new Form5(kullaniciId);
            form5.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)  // Toplam tutar hesaplama
        {
            // Toplam tutarı hesaplamak için değişken
            decimal toplamTutar = 0;

            // SQL bağlantısı
            string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 1. Rezervasyonlar tablosundaki Tutar'ı çek
                    string rezervasyonQuery = @"
            SELECT SUM(Tutar) 
            FROM Rezervasyonlar 
            WHERE KullaniciID = @KullaniciID";
                    using (SqlCommand command = new SqlCommand(rezervasyonQuery, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            toplamTutar += Convert.ToDecimal(result); // Rezervasyonlardan alınan toplam tutar
                        }
                    }

                    // 2. Kantin Ücreti Hesaplama (Kantin masrafları)
                    string kantinQuery = @"
            SELECT SUM(ToplamTutar) 
            FROM Kantin 
            WHERE KullaniciID = @KullaniciID";
                    using (SqlCommand command = new SqlCommand(kantinQuery, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            decimal kantinMasrafi = Convert.ToDecimal(result);
                            toplamTutar += kantinMasrafi; // Kantin masraflarını ekle
                        }
                    }

                    // Toplam Tutarı label4'te göster
                    label4.Text = "Toplam Tutar: " + toplamTutar.ToString("C");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            // Form2 yüklendiğinde, kullanıcı ID'sini kullanabilirsiniz
            label5.Text = "Kullanıcı ID: " + kullaniciId.ToString();

            // Kullanıcı toplam tutarı her yüklemede yeniden hesaplanır
            decimal toplamTutar = 0;

            string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string kantinQuery = "SELECT SUM(ToplamTutar) FROM Kantin WHERE kullaniciID = @kullaniciId";
                using (SqlCommand command = new SqlCommand(kantinQuery, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                        toplamTutar += Convert.ToDecimal(result);
                }
            }

            label4.Text = "Toplam Tutar: " + toplamTutar.ToString("C");
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // grbKantin'in konumu
            grbKantin.Left = (formWidth - grbKantin.Width) / 2;
            grbKantin.Top = (formHeight - grbKantin.Height) / 2;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Mevcut FrmKullanici formunu kapat
            this.Close();

            // Yeni FrmKullanici formunu mevcut kullanıcı ID'si ile oluştur
            FrmKullanici frmKullanici = new FrmKullanici(kullaniciId);
            frmKullanici.Show();
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
