using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace QuanLyThiTracNghiem
{
    public partial class Dienthongtin : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        SqlConnection cnn;
        string mon = "";

        public Dienthongtin()
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            InitializeComponent();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                mon = "Nhập môn lập trình";
            }
            if (radioButton2.Checked)
            {
                mon = "Lập trình hướng đối tượng";
            }
            if (radioButton3.Checked)
            {
                mon = "Cấu trúc dữ liệu và giải thuật";
            }
            if (radioButton4.Checked)
            {
                mon = "Cơ sở dữ liệu";
            }
            if (radioButton5.Checked)
            {
                mon = "Nhập môn mạng máy tính";
            }
        }

        private void btnLambai_Click(object sender, EventArgs e)
        {
            try
            {
                if (mon == "")
                {

                    lblDN.Visible = true;
                    lblDN.Text = "Vui lòng chọn môn thi!";
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(connectionString, cnn);
                    cmd.ExecuteNonQuery();
                    if (MessageBox.Show("Bạn có chắc chắn vào thi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //chuyen thong tin sang form thi
                        Thi thithat = new Thi(mon, lbHoTen.Text, lbMaSV.Text);
                        thithat.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch
            {
                this.Hide();
                Thi thithat = new Thi(mon, lbHoTen.Text, lbMaSV.Text);
                thithat.ShowDialog();
                this.Close();
            }
        }

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

        private void Dienthongtin_Load(object sender, EventArgs e)
        {
            try
            {
                string username = Username.username;
                string[] userData = GetUserData(username);

                // Sử dụng dữ liệu lấy được từ cơ sở dữ liệu
                lbMaSV.Text = userData[0];
                lbHoTen.Text = userData[1];
                lbNgaySinh.Text = userData[2];
                lbEmail.Text = userData[3];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Nguoidung ND = new Nguoidung();
            this.Hide();
            ND.ShowDialog();
            this.Close();
        }

        private void btnLambai_MouseLeave(object sender, EventArgs e)
        {
            btnLambai.ForeColor = Color.FromArgb(187, 39, 255);
        }

        private void btnLambai_MouseMove(object sender, MouseEventArgs e)
        {
            btnLambai.ForeColor = Color.FromArgb(133, 25, 183);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Tomato;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }
    }
}
