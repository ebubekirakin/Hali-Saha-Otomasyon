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
    public partial class Form5 : DevExpress.XtraEditors.XtraForm
    {
        private int kullaniciId;

        public Form5(int id)
        {
            InitializeComponent();
            kullaniciId = id; // Kullanıcı ID'sini kaydediyoruz
        }

        private void btnOneri_Click(object sender, EventArgs e)
        {
            // Buradaki kullaniciId, form constructor'ından alınan değeri temsil ediyor
            if (kullaniciId <= 0)
            {
                MessageBox.Show("Kullanıcı oturumu doğrulanamadı. Lütfen tekrar giriş yapınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Öneri kutusundaki metni al
            string oneriMesaji = txbOneri.Text;
            DateTime tarih = dateTPOneri.Value;

            // Boş giriş kontrolü
            if (string.IsNullOrWhiteSpace(oneriMesaji))
            {
                MessageBox.Show("Lütfen öneri veya şikayetinizi yazınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Veritabanına kaydet
            string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Öneri metni ve tarih ile veritabanına kayıt ekleyelim
                    string query = "INSERT INTO OnerilerSikayetler (KullaniciID, OneriMetni, Tarih) VALUES (@KullaniciID, @OneriMetni, @Tarih)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri tanımla
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId); // Kullanıcı ID'sini formdan al
                        command.Parameters.AddWithValue("@OneriMetni", oneriMesaji); // Öneri metni
                        command.Parameters.AddWithValue("@Tarih", tarih); // Tarih

                        // Sorguyu çalıştır
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Öneriniz başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txbOneri.Clear(); // Alanı temizle
                        }
                        else
                        {
                            MessageBox.Show("Öneriniz kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // grbRezervasyon'un konumu
            grbOneri.Left = (formWidth - grbOneri.Width) / 2;
            grbOneri.Top = (formHeight - grbOneri.Height) / 2;
        }
    }


}
