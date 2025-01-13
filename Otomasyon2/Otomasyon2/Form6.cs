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
using System.Security.Cryptography;

namespace Otomasyon2
{
    public partial class Form6 : DevExpress.XtraEditors.XtraForm
    {
        public Form6()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        SqlConnection connect = new SqlConnection(conString);

        private void btnKayit_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcı adı ve şifre boş mu kontrol et
                if (string.IsNullOrWhiteSpace(txbKullanAdi.Text) || string.IsNullOrWhiteSpace(txbKullanSifre.Text))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Eğer boşsa fonksiyonu sonlandır
                }

                // Şifre politikası kontrolü
                if (txbKullanSifre.Text.Length < 8 || !txbKullanSifre.Text.Any(char.IsUpper) || !txbKullanSifre.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Şifre en az 8 karakter uzunluğunda, bir büyük harf ve bir rakam içermelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Veritabanı bağlantı dizgesi (düzgün şekilde yapılandırılmalıdır)
                string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

                // Kullanıcı adı benzersiz mi kontrol et
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    // Kullanıcı adı kontrolü
                    string kontrol = "SELECT COUNT(*) FROM Kullanici WHERE kullanici_adi = @kullanici_adi";
                    using (SqlCommand kontrolKomut = new SqlCommand(kontrol, connect))
                    {
                        kontrolKomut.Parameters.AddWithValue("@kullanici_adi", txbKullanAdi.Text);
                        int mevcut = (int)kontrolKomut.ExecuteScalar();
                        if (mevcut > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten alınmış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Şifre hashleme (SHA-256 kullanımı)
                    //string hashedPassword = HashPassword(txbKullanSifre.Text);

                    // Kayıt ekleme sorgusu
                    string kayit = "INSERT INTO Kullanici (kullanici_adi, sifre) VALUES (@kullanici_adi, @sifre)";
                    using (SqlCommand komut = new SqlCommand(kayit, connect))
                    {
                        komut.Parameters.AddWithValue("@kullanici_adi", txbKullanAdi.Text);
                        komut.Parameters.AddWithValue("@sifre", txbKullanSifre.Text); //, hashedPassword

                        int result = komut.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txbKullanAdi.Clear();
                            txbKullanSifre.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Kayıt eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                // Hata mesajı
                MessageBox.Show("Hata: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Şifreyi hashlemek için bir yardımcı metod
      /*  private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }*/

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void btnKayitSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txbKullanAdiSil.Text) || string.IsNullOrWhiteSpace(txbKullanSifreSil.Text))
                {
                    MessageBox.Show("Lütfen kullanıcı adı ve şifreyi doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult sonuc = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No)
                    return;

                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                // Kullanıcıyı silmeye çalış
                string silSorgu = "DELETE FROM Kullanici WHERE kullanici_adi = @kullanici_adi AND sifre = @sifre";
                SqlCommand silKomut = new SqlCommand(silSorgu, connect);
                silKomut.Parameters.AddWithValue("@kullanici_adi", txbKullanAdiSil.Text);
                silKomut.Parameters.AddWithValue("@sifre", txbKullanSifreSil.Text);

                int sonucSil = silKomut.ExecuteNonQuery();

                if (sonucSil > 0)
                {
                    MessageBox.Show("Kayıt başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbKullanAdiSil.Clear();
                    txbKullanSifreSil.Clear();
                }
                else
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                // Foreign key hatası kontrolü
                if (ex.Number == 547) // SQL Server'da foreign key hatası numarası 547'dir
                {
                    MessageBox.Show("Tamamlanmamış ödeneleriniz var. Önce ilgili işlemleri tamamlayın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void Form6_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // İki GroupBox arasında bırakılacak boşluk
            int gap = 150;

            // İki GroupBox toplam genişliği (grpBox genişliği * 2 + boşluk)
            int totalWidth = grbKullanici.Width + grbAdmin.Width + gap;

            // grpBoxKullanici için konum
            grbKullanici.Left = (formWidth - totalWidth) / 2;
            grbKullanici.Top = (formHeight - grbKullanici.Height) / 2;

            // grpBoxAdmin için konum
            grbAdmin.Left = grbKullanici.Right + gap;
            grbAdmin.Top = grbKullanici.Top; // Yatayda aynı hizada tutmak için
        }
    }
}

