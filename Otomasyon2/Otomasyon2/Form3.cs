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
    public partial class Form3 : DevExpress.XtraEditors.XtraForm
    {
        private int kullaniciId; // Kullanıcı ID
        private string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"; // Veritabanı bağlantı bilgisi

        public Form3(int id)
        {
            InitializeComponent();
            kullaniciId = id; // Kullanıcı ID'sini kaydediyoruz
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SaatleriAta(); // Saat butonlarına saat değerlerini ata
            SaatButonOlaylariniBagla(); // Saat butonlarına tıklama olaylarını bağla
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

        private void SaatButonOlaylariniBagla()
        {
            // Saat butonlarına tıklama olayını bağla
            for (int i = 1; i <= 8; i++)
            {
                Button saatButton = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;
                if (saatButton != null)
                {
                    saatButton.Click += SaatButton_Click;
                }
            }
        }

        // Saat butonuna tıklama işlemi
        private void SaatButton_Click(object sender, EventArgs e)
        {
            Button tıklananButon = sender as Button;

            if (tıklananButon != null)
            {
                // Seçilen butonun rengini sarıya (seçili) yap.
                if (tıklananButon.BackColor != Color.Yellow)
                {
                    // Diğer tüm butonların rengini beyaza döndür.
                    Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8 };
                    foreach (var button in buttons)
                    {
                        if (button.BackColor != Color.Red) // Kırmızı olanlar yeşil kalacak, beyaz olanlar beyaz olacak
                        {
                            button.BackColor = Color.White;
                        }
                    }

                    // Seçilen butonun rengini sarıya yap.
                    tıklananButon.BackColor = Color.Yellow;
                }
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

        private void btnRezervasyonYap_Click(object sender, EventArgs e)
        {
            // Tarih ve saat bilgisi
            DateTime tarih = dTmPck.Value.Date;
            string secilenSaat = null;

            // Seçilen saat butonunu kontrol et
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8 };
            foreach (var button in buttons)
            {
                if (button.BackColor == Color.Yellow)
                {
                    secilenSaat = button.Text;
                    break;
                }
            }

            if (secilenSaat == null)
            {
                MessageBox.Show("Lütfen bir saat seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Opsiyonel seçimler
            string krampon = cmbKrampon.SelectedItem?.ToString();
            string servis = cmbServis.SelectedItem?.ToString();

            // Ücret hesaplama
            decimal toplamTutar = 0;
            decimal toplamGider = 0;

            // Maç saati seçildiyse 1400 ekle (Gelir)
            if (secilenSaat != null)
            {
                toplamTutar += 1400;
                toplamGider += 250; // Maç gideri
            }

            // Krampon seçildiyse 30 ekle (Gelir) ve 5 ekle (Gider)
            if (krampon != null && krampon != "Belirtilmedi")
            {
                toplamTutar += 30;
                toplamGider += 5; // Krampon gideri
            }

            // Servis seçildiyse 200 ekle (Gelir) ve 80 ekle (Gider)
            if (servis != null && servis != "Belirtilmedi")
            {
                toplamTutar += 200;
                toplamGider += 80; // Servis gideri
            }

            // Kullanıcı adını almak için Kullanici tablosundan KullaniciID ile sorgu yap
            string kullaniciAdi = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kullanıcı adını almak için SQL sorgusu
                SqlCommand cmd = new SqlCommand("SELECT kullanici_adi FROM Kullanici WHERE KullaniciID = @KullaniciID", conn);
                cmd.Parameters.AddWithValue("@KullaniciID", kullaniciId); // Kullanıcı ID'sini parametre olarak geçir

                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    kullaniciAdi = result.ToString(); // Kullanıcı adı alınıyor
                }
            }

            // Eğer kullanıcı adı alınamadıysa işlemi iptal et
            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı alınamadı. Lütfen tekrar giriş yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Rezervasyonu ve doluluk durumunu veritabanına kaydet
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Rezervasyonlar tablosuna veri ekle
                        SqlCommand cmdRezervasyon = new SqlCommand(
                            "INSERT INTO Rezervasyonlar (Tarih, Saat, Krampon, Servis, KullaniciID, kullanici_adi, Tutar, Gider) " +
                            "VALUES (@Tarih, @Saat, @Krampon, @Servis, @KullaniciID, @kullanici_adi, @Tutar, @Gider)", conn, transaction);

                        cmdRezervasyon.Parameters.AddWithValue("@Tarih", tarih);
                        cmdRezervasyon.Parameters.AddWithValue("@Saat", secilenSaat);
                        cmdRezervasyon.Parameters.AddWithValue("@Krampon", (object)krampon ?? DBNull.Value);
                        cmdRezervasyon.Parameters.AddWithValue("@Servis", (object)servis ?? DBNull.Value);
                        cmdRezervasyon.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        cmdRezervasyon.Parameters.AddWithValue("@kullanici_adi", kullaniciAdi);
                        cmdRezervasyon.Parameters.AddWithValue("@Tutar", toplamTutar);
                        cmdRezervasyon.Parameters.AddWithValue("@Gider", toplamGider);

                        cmdRezervasyon.ExecuteNonQuery();

                        // DolulukDurumu tablosuna veri ekle
                        SqlCommand cmdDolulukDurumu = new SqlCommand(
                            "INSERT INTO DolulukDurumu (Tarih, Saat, Doluluk, KullaniciID) " +
                            "VALUES (@Tarih, @Saat, @Doluluk, @KullaniciID)", conn, transaction);

                        cmdDolulukDurumu.Parameters.AddWithValue("@Tarih", tarih);
                        cmdDolulukDurumu.Parameters.AddWithValue("@Saat", secilenSaat);
                        cmdDolulukDurumu.Parameters.AddWithValue("@Doluluk", 1);
                        cmdDolulukDurumu.Parameters.AddWithValue("@KullaniciID", kullaniciId);

                        cmdDolulukDurumu.ExecuteNonQuery();

                        // İşlem başarılı, değişiklikleri kaydet
                        transaction.Commit();

                       // MessageBox.Show("Rezervasyon başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda, yapılan değişiklikleri geri al
                        transaction.Rollback();
                        MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            MessageBox.Show("Rezervasyon başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Saat durumlarını güncelle
            dTmPck_ValueChanged(null, null);
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // grbRezervasyon'un konumu
            grbRezervasyon.Left = (formWidth - grbRezervasyon.Width) / 2;
            grbRezervasyon.Top = (formHeight - grbRezervasyon.Height) / 2;
        }
    }
}

