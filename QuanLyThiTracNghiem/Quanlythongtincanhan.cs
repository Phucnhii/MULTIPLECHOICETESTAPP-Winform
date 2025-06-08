using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyThiTracNghiem
{
    public partial class Quanlythongtincanhan : Form
    {
        public Quanlythongtincanhan()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        string[] GetUserData(string username)
        {
            string[] userData = new string[4];

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tạo truy vấn SQL
                string query = "SELECT * FROM TB_USER WHERE sUSERNAME = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                // Mở kết nối
                connection.Open();

                // Thực thi truy vấn và đọc dữ liệu
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Lấy dữ liệu từ cột tương ứng trong dòng đầu tiên
                    userData[0] = reader["sMS"].ToString();
                    userData[1] = reader["sHOTEN"].ToString();
                    userData[2] = reader.GetDateTime(reader.GetOrdinal("tNGAYSINH")).ToString("dd/MM/yyyy");
                    userData[3] = reader["sEMAIL"].ToString();
                }
                else
                {
                    // Không tìm thấy người dùng với username tương ứng
                    throw new Exception("Người dùng không tồn tại.");
                }
            }

            return userData;
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            try
            {
                new MailAddress(tb_email.Text);
            }
            catch (FormatException)
            {
                lblDK.Visible = true;
                lblDK.ForeColor = Color.Red;
                lblDK.Text = "Email không hợp lệ!";
                return;
            }

            if (string.IsNullOrEmpty(tb_hoten.Text) || string.IsNullOrEmpty(tb_Mssv.Text) ||
                string.IsNullOrEmpty(tb_email.Text))
            {
                lblDK.Visible = true;
                lblDK.ForeColor = Color.Red;
                lblDK.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            command = connection.CreateCommand();
            command.CommandText = "update TB_USER set sHOTEN= N'" + tb_hoten.Text + "', tNGAYSINH= '" + dttime_ngsinh.Text + "', sEMAIL= '" + tb_email.Text + "' where sMS = '" + tb_Mssv.Text + "'";
            command.ExecuteNonQuery();

            lblDK.Visible = true;
            lblDK.ForeColor = Color.LimeGreen;
            lblDK.Text = "Cập nhật thông tin thành công!";
            return;
        }

        private void Quanlythongtincanhan_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            string username = Username.username;
            string[] userData = GetUserData(username);
            // Sử dụng dữ liệu lấy được từ cơ sở dữ liệu
            tb_Mssv.Text = userData[0];
            tb_hoten.Text = userData[1];
            dttime_ngsinh.Text = userData[2];
            tb_email.Text = userData[3];
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Nguoidung nd = new Nguoidung();
            this.Hide();
            nd.ShowDialog();
            this.Close();
        }

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
            Doimatkhau doimatkhau = new Doimatkhau();
            this.Hide();
            doimatkhau.ShowDialog();
            this.Close();
        }
    }
}