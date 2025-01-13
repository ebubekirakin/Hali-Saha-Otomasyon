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
    public partial class Form11 : DevExpress.XtraEditors.XtraForm
    {
        public Form11()
        {
            InitializeComponent();
        }

        // Veritabanı bağlantı dizgesi
        private readonly string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void Form11_Load(object sender, EventArgs e)
        {
            // GelirGider verilerini yükle
            LoadGelirGiderList();
   
        }

        /// <summary>
        /// GelirGider tablosundan kantin gelirlerini çeker ve toplam gelir hesaplar.
        /// </summary>
        private void LoadGelirGiderList()
        {
            string query = @"
        SELECT Tarih, Gelir, Gider, Aciklama, SatisID
        FROM GelirGider
        ORDER BY Tarih ASC";

            string totalQuery = @"
        SELECT 
            ISNULL(SUM(Gelir), 0) AS ToplamGelir, 
            ISNULL(SUM(Gider), 0) AS ToplamGider
        FROM GelirGider";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. GelirGider verilerini çekip DataGridView'e yükleme
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvGelirGider.DataSource = dt;

                    // 2. Toplam Gelir ve Gider hesaplama
                    using (SqlCommand cmd = new SqlCommand(totalQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal toplamGelir = reader["ToplamGelir"] != DBNull.Value ? Convert.ToDecimal(reader["ToplamGelir"]) : 0;
                                decimal toplamGider = reader["ToplamGider"] != DBNull.Value ? Convert.ToDecimal(reader["ToplamGider"]) : 0;

                                // Toplamları Label'e yazdır
                                lblGelirGider.Text = $"Toplam Gelir: {toplamGelir:C} - Toplam Gider: {toplamGider:C}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Daha fazla hata detayı almak için ToString kullanımı
                    MessageBox.Show("Hata oluştu: " + ex.ToString());
                }
            }
        }


        private void Form11_Resize(object sender, EventArgs e)
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // dgv konumu
            dgvGelirGider.Left = (formWidth - dgvGelirGider.Width) / 2;
            dgvGelirGider.Top = (formHeight - dgvGelirGider.Height) / 2;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Form11'i kapat
            this.Close();

            // Yeni bir Form11 oluştur ve aç
            Form11 form11 = new Form11();
            form11.Show();
        }
    }
}



