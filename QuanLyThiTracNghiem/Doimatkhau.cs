using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net; 

namespace QuanLyThiTracNghiem
{
    public partial class Doimatkhau : Form
    {
        public Doimatkhau()
        {
            InitializeComponent();
            label1.Parent = pictureBox4;
            label2.Parent = pictureBox4;
            label3.Parent = pictureBox4;
            tb_newpass.Parent = pictureBox4;
            tb_renewpass.Parent = pictureBox4;
            cbNewPass.Parent = pictureBox4;
            cbReNewPass.Parent = pictureBox4;
            lblDMK.Parent = pictureBox4;
            btnDoimatkhau.Parent = pictureBox4;
            btnExit.Parent = pictureBox4;
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }

        private bool IsPasswordValid(string password)
        {
            // Kiểm tra độ dài tối thiểu là 8 ký tự
            if (password.Length < 8)
                return false;

            // Kiểm tra có ít nhất một chữ cái và một chữ số sử dụng Regex
            Regex alphaNumericRegex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d).{8,}$");
            return alphaNumericRegex.IsMatch(password);
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_newpass.Text) || string.IsNullOrEmpty(tb_renewpass.Text))
            {
                lblDMK.Visible = true;
                lblDMK.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            if (tb_newpass.Text != tb_renewpass.Text)
            {
                lblDMK.Visible = true;
                lblDMK.Text = "Mật khẩu không trùng khớp!";
                return;
            }

            string password = tb_newpass.Text;

            // Kiểm tra mật khẩu
            if (!IsPasswordValid(password))
            {
                lblDMK.Visible = true;
                lblDMK.Text = "Mật khẩu cần có ít nhất 8 ký tự gồm chữ cái và số!";
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(tb_newpass.Text); // Băm mật khẩu mới

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    
                    string selectQuery = "SELECT * FROM TB_USER WHERE sUSERNAME = @sUSERNAME";
                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, cnn))
                    {
                        selectCmd.Parameters.AddWithValue("@sUSERNAME", Username.username);
                        using (SqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy thông tin người dùng từ cơ sở dữ liệu
                                string sMS = reader.GetString(reader.GetOrdinal("sMS"));
                                string sHOTEN = reader.GetString(reader.GetOrdinal("sHOTEN"));
                                DateTime tNGAYSINH = reader.GetDateTime(reader.GetOrdinal("tNGAYSINH"));
                                string sEMAIL = reader.GetString(reader.GetOrdinal("sEMAIL"));
                                string sUSERNAME = reader.GetString(reader.GetOrdinal("sUSERNAME"));

                                // Đóng DataReader trước khi thực hiện truy vấn mới
                                reader.Close();

                                // Cập nhật mật khẩu mới cho người dùng
                                string updateQuery = "UPDATE TB_USER SET sPASS = @sPASS WHERE sMS = @sMS";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, cnn))
                                {
                                    updateCmd.Parameters.AddWithValue("@sMS", sMS);
                                    updateCmd.Parameters.AddWithValue("@sPASS", hashedPassword);
                                    updateCmd.ExecuteNonQuery();
                                }

                                // Hiển thị thông báo và chuyển đến form đăng nhập
                                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Login login = new Login();
                                this.Hide();
                                login.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                lblDMK.Visible = true;
                                lblDMK.Text = "Không tìm thấy thông tin người dùng!";
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Quanlythongtincanhan ttcn = new Quanlythongtincanhan();
            this.Hide();
            ttcn.ShowDialog();
            this.Close();
        }

        private void cbHienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNewPass.Checked)
            {
                tb_newpass.PasswordChar = (char)0;
            }
            else
            {
                tb_newpass.PasswordChar = '●';
            }
        }

        private void cbReNewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbReNewPass.Checked)
            {
                tb_renewpass.PasswordChar = (char)0;
            }
            else
            {
                tb_renewpass.PasswordChar = '●';
            }
        }

        private void btnDoimatkhau_MouseLeave(object sender, EventArgs e)
        {
            btnDoimatkhau.ForeColor = Color.FromArgb(187, 39, 255);
        }

        private void btnDoimatkhau_MouseMove(object sender, MouseEventArgs e)
        {
            btnDoimatkhau.ForeColor = Color.FromArgb(133, 25, 183);
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
