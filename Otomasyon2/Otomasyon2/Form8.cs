using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Otomasyon2
{
    public partial class Form8 : DevExpress.XtraEditors.XtraForm
    {
        public Form8()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde kullanıcıları getir
        private void Form8_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // Kullanıcıları veritabanından çek ve DataGridView'e yükle
        private void LoadUsers(string searchText = "")
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = "SELECT KullaniciID, kullanici_adi, Engellenen FROM Kullanici";

                if (!string.IsNullOrEmpty(searchText))
                    query += " WHERE kullanici_adi LIKE '%' + @searchText + '%'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@searchText", searchText);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewUsers.DataSource = dt;
            }
        }

        // Engelleme butonuna tıklandığında seçilen kullanıcıyı engelle
        private void btnEngelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int kullaniciID = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["KullaniciID"].Value);
                DialogResult dialogResult = MessageBox.Show("Bu kullanıcıyı engellemek istediğinizden emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                    {
                        string updateQuery = "UPDATE Kullanici SET Engellenen = 1 WHERE KullaniciID = @KullaniciID";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                MessageBox.Show("Kullanıcı engellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Seçilen satır rengini kırmızı yap
                                dataGridViewUsers.SelectedRows[0].DefaultCellStyle.BackColor = Color.Red;
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
                MessageBox.Show("Lütfen engellemek için bir kullanıcı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Kullanıcı adıyla arama yapılırken her yazıldığında kullanıcıları filtrele
        private void txtKullaniciAra_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtKullaniciAra.Text;
            LoadUsers(searchText);
        }

        // DataGridView hücrelerini formatla (Engellenen kullanıcıları kırmızı renkte göster)
        private void dataGridViewUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "Engellenen" && e.Value != null)
            {
                bool engellenen = Convert.ToBoolean(e.Value);
                if (engellenen)
                {
                    dataGridViewUsers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void engellemeyiKaldir_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int kullaniciID = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["KullaniciID"].Value);
                DialogResult dialogResult = MessageBox.Show("Bu kullanıcının engellemesini kaldırmak istediğinizden emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-BSOS29N\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                    {
                        string updateQuery = "UPDATE Kullanici SET Engellenen = 0 WHERE KullaniciID = @KullaniciID";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                MessageBox.Show("Kullanıcının engellemesi kaldırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Seçilen satırın rengini eski haline getirme (örneğin, beyaz)
                                dataGridViewUsers.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
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
                MessageBox.Show("Lütfen engellemesini kaldırmak için bir kullanıcı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Form8'i kapat
            this.Close();

            // Yeni bir Form8 oluştur ve aç
            Form8 form8 = new Form8();
            form8.Show();
        }
    }
}


