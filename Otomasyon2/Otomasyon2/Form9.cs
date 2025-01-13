using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Otomasyon2
{
    public partial class Form9 : DevExpress.XtraEditors.XtraForm
    {
        // Veritabanı bağlantısı için connection string
        private string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Form9()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde kullanıcı listesini çekmek ve gösterme
        private void Form9_Load(object sender, EventArgs e)
        {
            // Kullanıcı listesini yükle
            LoadUserList();

            LoadReservationList();

            // Grid üzerindeki düzenlemeyi engelle
            DisableGridEditing();
        }

        // Kullanıcı listesini veritabanından çekme ve GridControl'e yükleme
        private void LoadUserList()
        {
            // Kullanıcılar ile Kantin tablosundaki toplam tutarları ilişkilendiren sorgu
            string query = @"
        SELECT 
            Kullanici.KullaniciID, 
            Kullanici.kullanici_adi, 
            ISNULL((SELECT SUM(ToplamTutar) FROM Kantin WHERE Kantin.KullaniciID = Kullanici.KullaniciID), 0) AS ToplamTutar
        FROM Kullanici
        ORDER BY KullaniciID ASC"; // Kullanıcıları artan sırada listele

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Sonuçları gridControl'e bağlama
                    gridControl1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}");
                }
            }
        }

        private void LoadReservationList()
        {
            // Rezervasyonlar tablosundan her kullanıcının toplam borcunu çek
            string query = @"
    SELECT 
        Kullanici.KullaniciID, 
        Kullanici.kullanici_adi, 
        ISNULL(SUM(Rezervasyonlar.Tutar), 0) AS ToplamTutar
    FROM Kullanici
    LEFT JOIN Rezervasyonlar ON Kullanici.KullaniciID = Rezervasyonlar.KullaniciID
    GROUP BY Kullanici.KullaniciID, Kullanici.kullanici_adi
    ORDER BY Kullanici.KullaniciID ASC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl2.DataSource = dt;  // Rezervasyonlar listesini gridView2'ye yükle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            // Seçilen kullanıcıyı almak
            var selectedRow = gridView1.GetFocusedDataRow();
            if (selectedRow != null)
            {
                int kullaniciId = Convert.ToInt32(selectedRow["KullaniciID"]);
                string kullaniciAdi = selectedRow["kullanici_adi"].ToString();

                // Kullanıcının tüm ToplamTutar ve Gider değerlerini toplamak için sorgular
                string sumQuery = "SELECT SUM(ToplamTutar) AS ToplamGelir, SUM(Gider) AS ToplamGider FROM Kantin WHERE KullaniciID = @KullaniciID";

                decimal toplamGelir = 0; // Kullanıcıya ait toplam gelir
                decimal toplamGider = 0; // Kullanıcıya ait toplam gider

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // ToplamGelir ve ToplamGider hesaplama
                        SqlCommand sumCmd = new SqlCommand(sumQuery, conn);
                        sumCmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);

                        using (SqlDataReader reader = sumCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                toplamGelir = reader["ToplamGelir"] != DBNull.Value ? Convert.ToDecimal(reader["ToplamGelir"]) : 0;
                                toplamGider = reader["ToplamGider"] != DBNull.Value ? Convert.ToDecimal(reader["ToplamGider"]) : 0;
                            }
                        }

                        // ToplamGelir ve ToplamGider sıfır ise ödeme yapılamaz
                        if (toplamGelir <= 0 && toplamGider <= 0)
                        {
                            MessageBox.Show("Toplam tutar 0 olduğundan ödeme yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Kullanıcının verilerini Kantin ve Rezervasyonlar tablosundan silmek
                        string deleteQuery = "DELETE FROM Kantin WHERE KullaniciID = @KullaniciID;";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        deleteCmd.ExecuteNonQuery();

                        // GelirGider tablosuna ödeme kaydını eklemek
                        string gelirGiderQuery = "INSERT INTO GelirGider (Tarih, Gelir, Gider, Aciklama) VALUES (@Tarih, @Gelir, @Gider, @Aciklama)";
                        SqlCommand gelirGiderCmd = new SqlCommand(gelirGiderQuery, conn);
                        gelirGiderCmd.Parameters.AddWithValue("@Tarih", DateTime.Now); // Güncel tarih
                        gelirGiderCmd.Parameters.AddWithValue("@Gelir", toplamGelir);  // Toplam gelir
                        gelirGiderCmd.Parameters.AddWithValue("@Gider", toplamGider);  // Toplam gider
                        gelirGiderCmd.Parameters.AddWithValue("@Aciklama", $"Kullanıcı ({kullaniciAdi}) kantin ödemesi");
                        gelirGiderCmd.ExecuteNonQuery();

                        MessageBox.Show("Ödeme başarılı, borç silindi.");

                        // Sayfayı yenileyerek borcu silinen kullanıcıyı listede güncelleme
                        LoadUserList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }
        }


        private void btnOdemeYap2_Click(object sender, EventArgs e)
        {
            // Seçilen kullanıcıyı almak
            var selectedRow = gridView2.GetFocusedDataRow();
            if (selectedRow != null)
            {
                int kullaniciId = Convert.ToInt32(selectedRow["KullaniciID"]);
                string kullaniciAdi = selectedRow["kullanici_adi"].ToString();

                // Kullanıcının Rezervasyonlar tablosundaki toplam tutar ve giderlerini almak için sorgular
                string sumReservationQuery = "SELECT SUM(Tutar) AS ToplamRezervasyonTutar, SUM(Gider) AS ToplamRezervasyonGider FROM Rezervasyonlar WHERE KullaniciID = @KullaniciID";

                decimal toplamRezervasyonTutar = 0; // Kullanıcının toplam rezervasyon tutarı
                decimal toplamRezervasyonGider = 0; // Kullanıcının toplam rezervasyon gideri

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Rezervasyonlar tablosundaki toplam tutar ve gideri hesaplama
                        SqlCommand sumReservationCmd = new SqlCommand(sumReservationQuery, conn);
                        sumReservationCmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        using (SqlDataReader reader = sumReservationCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                toplamRezervasyonTutar = reader["ToplamRezervasyonTutar"] != DBNull.Value
                                    ? Convert.ToDecimal(reader["ToplamRezervasyonTutar"])
                                    : 0;

                                toplamRezervasyonGider = reader["ToplamRezervasyonGider"] != DBNull.Value
                                    ? Convert.ToDecimal(reader["ToplamRezervasyonGider"])
                                    : 0;
                            }
                        }

                        // Toplam tutar sıfırsa ödeme yapılmasın
                        if (toplamRezervasyonTutar <= 0)
                        {
                            MessageBox.Show("Toplam tutar 0 olduğundan ödeme yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Kullanıcının Rezervasyonlar tablosundaki kayıtlarını silme
                        string deleteReservationQuery = "DELETE FROM Rezervasyonlar WHERE KullaniciID = @KullaniciID";
                        SqlCommand deleteReservationCmd = new SqlCommand(deleteReservationQuery, conn);
                        deleteReservationCmd.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        deleteReservationCmd.ExecuteNonQuery();

                        // GelirGider tablosuna ödeme kaydını eklemek
                        string gelirGiderQuery = "INSERT INTO GelirGider (Tarih, Gelir, Gider, Aciklama) VALUES (@Tarih, @Gelir, @Gider, @Aciklama)";
                        SqlCommand gelirGiderCmd = new SqlCommand(gelirGiderQuery, conn);
                        gelirGiderCmd.Parameters.AddWithValue("@Tarih", DateTime.Now); // Güncel tarih
                        gelirGiderCmd.Parameters.AddWithValue("@Gelir", toplamRezervasyonTutar); // Toplam gelir
                        gelirGiderCmd.Parameters.AddWithValue("@Gider", toplamRezervasyonGider); // Toplam gider
                        gelirGiderCmd.Parameters.AddWithValue("@Aciklama", $"Kullanıcı ({kullaniciAdi}) saha ücretleri ödemesi");
                        gelirGiderCmd.ExecuteNonQuery();

                        MessageBox.Show("Ödeme başarılı, borç silindi.");

                        // GridView2'yi güncelle
                        LoadReservationList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }
        }



        // Grid üzerindeki düzenleme özelliklerini devre dışı bırakma
        private void DisableGridEditing()
        {
            // gridView1'deki düzenleme özelliklerini devre dışı bırakıyoruz
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;

            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;


        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Form9'u kapat
            this.Close();

            // Yeni bir Form9 oluştur ve aç
            Form9 form9 = new Form9();
            form9.Show();
        }

        private void txtKullaniciAra_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtKullaniciAra.Text.Trim();

            // gridView1 için filtreleme
            FilterGridViewWithDataView(gridView1, searchText);
            // gridView2 için filtreleme
            FilterGridViewWithDataView(gridView2, searchText);
        }

        private void FilterGridViewWithDataView(DevExpress.XtraGrid.Views.Grid.GridView gridView, string searchText)
        {
            if (gridView.DataSource is DataView dataView)
            {
                // RowFilter kullanarak arama yapıyoruz
                dataView.RowFilter = $"kullanici_adi LIKE '%{searchText}%'";
            }
            else
            {
                MessageBox.Show("Veri kaynağı DataView değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}



