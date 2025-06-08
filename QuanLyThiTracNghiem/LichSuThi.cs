using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class LichSuThi : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public LichSuThi()
        {
            InitializeComponent();
        }

        private void LichSuThi_Load(object sender, EventArgs e)
        {
            drvKetqua.AutoGenerateColumns = false;
            drvKetqua.ReadOnly = true;
            drvKetqua.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);

            string sUSERNAME = Username.username;

            // Lấy sMS và sHOTEN từ bảng TB_USER
            string queryUser = "SELECT sMS, sHOTEN FROM TB_USER WHERE sUSERNAME = @sUSERNAME";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandUser = new SqlCommand(queryUser, connection);
                commandUser.Parameters.AddWithValue("@sUSERNAME", sUSERNAME);

                string sMS = "";
                string sHOTENKQ = "";

                try
                {
                    connection.Open();
                    SqlDataReader reader = commandUser.ExecuteReader();

                    if (reader.Read())
                    {
                        sMS = reader["sMS"].ToString();
                        sHOTENKQ = reader["sHOTEN"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }
                finally
                {
                    connection.Close();
                }

                string queryKetQua = "SELECT sMS, sHOTENKQ, sTENMON, iSOCAUDUNG, iDIEM, tNGAYTHI " +
                                     "FROM TB_KETQUA " +
                                     "WHERE sMS = @sMS AND sHOTENKQ = @sHOTENKQ";

                SqlCommand commandKetQua = new SqlCommand(queryKetQua, connection);
                commandKetQua.Parameters.AddWithValue("@sMS", sMS);
                commandKetQua.Parameters.AddWithValue("@sHOTENKQ", sHOTENKQ);

                SqlDataAdapter adapter = new SqlDataAdapter(commandKetQua);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    drvKetqua.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Nguoidung nd = new Nguoidung();
            this.Hide();
            nd.ShowDialog();
            this.Close();
        }
    }
}
