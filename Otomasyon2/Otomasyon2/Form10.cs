using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Otomasyon2
{
    public partial class Form10 : DevExpress.XtraEditors.XtraForm
    {
        private string connectionString = "Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // Önerileri yükle
            OnerileriGetir();
        }

        private void OnerileriGetir()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Okundu sütununu kullanarak sorguyu değiştirelim
                string query = "SELECT OneriID, OneriMetni, Tarih, KullaniciID, Okundu AS Durum FROM OnerilerSikayetler";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // DataGridView'e verileri yükle
                gridViewOneri.DataSource = dt;

                // Satır rengini ayarla
                foreach (DataGridViewRow row in gridViewOneri.Rows)
                {
                    // Burada "Durum" yerine "Okundu" kullanmamız gerekebilir
                    if (row.Cells["Durum"].Value != null && Convert.ToBoolean(row.Cells["Durum"].Value) == true)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen; // Okundu rengi
                    }
                }
            }
        }



        private void btnOkundu_Click(object sender, EventArgs e)
        {
            if (gridViewOneri.SelectedRows.Count > 0)
            {
                int oneriID = Convert.ToInt32(gridViewOneri.SelectedRows[0].Cells["OneriID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE OnerilerSikayetler SET Okundu = 1 WHERE OneriID = @OneriID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OneriID", oneriID);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Öneri okundu olarak işaretlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Satır rengini değiştir
                            gridViewOneri.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGreen;

                            // Okundu sütununu güncelle
                            gridViewOneri.SelectedRows[0].Cells["Durum"].Value = 1; // Okundu olarak işaretle
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir öneri seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridViewOneri.SelectedRows.Count > 0)
            {
                int oneriID = Convert.ToInt32(gridViewOneri.SelectedRows[0].Cells["OneriID"].Value);
                DialogResult dialogResult = MessageBox.Show("Bu öneriyi silmek istediğinizden emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string deleteQuery = "DELETE FROM OnerilerSikayetler WHERE OneriID = @OneriID";

                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@OneriID", oneriID);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                MessageBox.Show("Öneri başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Seçilen satırı DataGridView'den kaldır
                                gridViewOneri.Rows.RemoveAt(gridViewOneri.SelectedRows[0].Index);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir öneri seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Form10'u kapat
            this.Close();

            // Yeni bir Form9 oluştur ve aç
            Form10 form10 = new Form10();
            form10.Show();
        }
    }
}



