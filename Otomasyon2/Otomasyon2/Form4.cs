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
    public partial class Form4 : DevExpress.XtraEditors.XtraForm
    {
        private int kullaniciId;

        public Form4(int id)
        {
            InitializeComponent();
            kullaniciId = id; // Kullanıcı ID'sini kaydediyoruz
        }

        private void btnYiyecek_Click(object sender, EventArgs e)
        {
            // "Yiyecek" tipini işlemek için çağrı
            KaydetVeGuncelle("Yiyecek", cmbYiyecek, cmbYiyecekAdet);
        }

        private void btnIcecek_Click(object sender, EventArgs e)
        {
            // "İçecek" tipini işlemek için çağrı
            KaydetVeGuncelle("İçecek", cmbIcecek, cmbIcecekAdet);
        }

        private void KaydetVeGuncelle(string urunTipi, System.Windows.Forms.ComboBox cmbUrun, System.Windows.Forms.ComboBox cmbAdet)
        {
            string urunAdi = cmbUrun.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(urunAdi))
            {
                MessageBox.Show($"{urunTipi} seçimi yapılmadı. Lütfen bir {urunTipi} seçin.");
                return;
            }

            if (!int.TryParse(cmbAdet.SelectedItem?.ToString(), out int urunAdet))
            {
                MessageBox.Show($"{urunTipi} adeti geçersiz. Lütfen geçerli bir adet seçin.");
                return;
            }

            string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Ürün bilgilerini Urunler tablosundan al
                    string queryUrunDetay = "SELECT Fiyat, Gider FROM Urunler WHERE UrunAdi = @UrunAdi";
                    decimal urunFiyat = 0;
                    decimal urunGider = 0;

                    using (SqlCommand command = new SqlCommand(queryUrunDetay, connection))
                    {
                        command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                urunFiyat = reader.GetDecimal(reader.GetOrdinal("Fiyat"));
                                urunGider = reader.GetDecimal(reader.GetOrdinal("Gider"));
                            }
                            else
                            {
                                MessageBox.Show($"{urunTipi} bilgisi bulunamadı. Lütfen geçerli bir {urunTipi} seçin.");
                                return;
                            }
                        }
                    }

                    // Toplam tutar ve gider hesaplama
                    decimal toplamTutar = urunAdet * urunFiyat;
                    decimal toplamGider = urunAdet * urunGider;

                    // Kantin tablosuna ekleme
                    string queryKantin = "INSERT INTO Kantin (KullaniciID, UrunAdi, Adet, Fiyat, ToplamTutar, Gider) " +
                                         "VALUES (@KullaniciID, @UrunAdi, @Adet, @Fiyat, @ToplamTutar, @Gider)";
                    using (SqlCommand command = new SqlCommand(queryKantin, connection))
                    {
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        command.Parameters.AddWithValue("@Adet", urunAdet);
                        command.Parameters.AddWithValue("@Fiyat", urunFiyat);
                        command.Parameters.AddWithValue("@ToplamTutar", toplamTutar);
                        command.Parameters.AddWithValue("@Gider", toplamGider);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show($"{urunTipi} başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }




        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // grbRezervasyon'un konumu
            grbKantin.Left = (formWidth - grbKantin.Width) / 2;
            grbKantin.Top = (formHeight - grbKantin.Height) / 2;
        }

    }
}
