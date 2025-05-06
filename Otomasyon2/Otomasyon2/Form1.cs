using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;



namespace Otomasyon2
{
    public partial class FormGiris : DevExpress.XtraEditors.XtraForm
    {
        // Veritabanı bağlantı dizesi
        private string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        // Kullanıcı ID'sini tutmak için bir değişken
        private int kullaniciId = -1;

        public FormGiris()
        {
            InitializeComponent();
        }
        // Kullanıcı Giriş Butonu

        private void btnKulGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txbKullanAdi.Text; // Giriş ekranındaki kullanıcı adı TextBox'ı
            string sifre = txbKullanSifre.Text;     // Giriş ekranındaki şifre TextBox'ı

            string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kullanıcı adı ve şifreye göre ID'yi ve Engellenen durumu sorgula
                    string query = "SELECT kullaniciID, Engellenen FROM Kullanici WHERE kullanici_adi = @kullanici_adi AND sifre = @sifre";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullanici_adi", kullaniciAdi);
                        command.Parameters.AddWithValue("@sifre", sifre);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // Eğer kullanıcı bulunduysa
                            {
                                // Kullanıcı ID'sini al
                                kullaniciId = Convert.ToInt32(reader["kullaniciID"]);
                                bool engellenen = Convert.ToBoolean(reader["Engellenen"]);

                                if (engellenen)
                                {
                                    // Eğer kullanıcı engellenmişse, giriş yapılamaz
                                    MessageBox.Show("Hesabınız engellenmiştir! ", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Giriş başarılı! Kullanıcı ID: " + kullaniciId);

                                    // Giriş sonrası işlem (Form değişimi gibi)
                                    this.Hide(); // Form1'i gizle
                                    FrmKullanici form2 = new FrmKullanici(kullaniciId); // Kullanıcı ID'sini Form2'ye gönder
                                    form2.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // Admin Giriş Butonu
        private void btnAdmGiris_Click(object sender, EventArgs e)
        {
            // Sabit admin adı ve şifre
            string sabitAdminAdi = "a";
            string sabitSifre = "a";

            // Kullanıcıdan alınan bilgiler
            string adminAdi = txbAdminAdi.Text.Trim();
            string sifre = txbAdminSifre.Text.Trim();

            // Sabit bilgilerle karşılaştırma
            if (adminAdi == sabitAdminAdi && sifre == sabitSifre)
            {
                MessageBox.Show("Admin girişi başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form7 form7 = new Form7();
                form7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Şifreyi hashlemek için mevcut HashPassword metodunu kullanabilirsiniz.
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }


        // Kayıt Ol İşlemi
        private void btnKayit_Click(object sender, EventArgs e)
        {
            // Form6'yı (Kayıt Formu) aç
            Form6 form6 = new Form6();
            form6.Show();
        }

        // Giriş bilgilerini doğrulayan yardımcı metot (isteğe bağlı, diğer yerlerde kullanılabilir)
        private bool CheckCredentials(string tableName, string usernameColumn, string passwordColumn, string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT COUNT(*) FROM {tableName} WHERE {usernameColumn} = @username AND {passwordColumn} = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // İki GroupBox arasında bırakılacak boşluk
            int gap = 150;

            // İki GroupBox toplam genişliği (grpBox genişliği * 2 + boşluk)
            int totalWidth = grpBoxKullanici.Width + grpBoxAdmin.Width + gap;

            // grpBoxKullanici için konum
            grpBoxKullanici.Left = (formWidth - totalWidth) / 2;
            grpBoxKullanici.Top = (formHeight - grpBoxKullanici.Height) / 2;

            // grpBoxAdmin için konum
            grpBoxAdmin.Left = grpBoxKullanici.Right + gap;
            grpBoxAdmin.Top = grpBoxKullanici.Top; // Yatayda aynı hizada tutmak için
        }
    }
}
