using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net; // Sử dụng hàm băm mật khẩu Bcrypt

namespace QuanLyThiTracNghiem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label3.Parent = pictureBox4;
            lblDN.Parent = pictureBox4;
            lblTaikhoan.Parent = pictureBox4;
            lblMatkhau.Parent = pictureBox4;
            txtTaikhoan.Parent = pictureBox4;
            txtMatkhau.Parent = pictureBox4;
            cbHienmatkhau.Parent = pictureBox4;
            btnDangnhap.Parent = pictureBox4;
            label1.Parent = pictureBox4;
            label2.Parent = pictureBox4;
            pictureBox1.Parent = pictureBox4;
            pictureBox2.Parent = pictureBox4;
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        public class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }

        private void cbHienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienmatkhau.Checked)
            {
                txtMatkhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatkhau.PasswordChar = '●';
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tk = txtTaikhoan.Text;
            string mk = txtMatkhau.Text;

            Username.username = txtTaikhoan.Text.Trim();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    string sql = "SELECT sPASS FROM TB_USER WHERE sUSERNAME = @username";
                    if (tk == "admin")
                        sql = "SELECT sMATKHAU FROM TB_ADMIN WHERE sTAIKHOAN = @username";

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@username", tk);

                        SqlDataReader dta = cmd.ExecuteReader();

                        if (string.IsNullOrEmpty(txtTaikhoan.Text) || string.IsNullOrEmpty(txtMatkhau.Text))
                        {
                            lblDN.Visible = true;
                            lblDN.Text = "Vui lòng nhập đầy đủ thông tin!";
                            return;
                        }

                        if (dta.Read())
                        {
                            string storedHash = tk == "admin" ? dta["sMATKHAU"].ToString() : dta["sPASS"].ToString();

                            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(mk, storedHash);

                            if (isPasswordValid)
                            {
                                if (tk != "admin")
                                {
                                    Nguoidung ND = new Nguoidung();
                                    this.Hide();
                                    ND.ShowDialog();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Admin đăng nhập thành công!", "Thông báo");
                                    QuanLy QL = new QuanLy();
                                    this.Hide();
                                    QL.ShowDialog();
                                    this.Close();
                                }
                            }
                            else
                            {
                                lblDN.Visible = true;
                                lblDN.Text = "Tên đăng nhập hoặc mật khẩu không chính xác.";
                            }
                        }
                        else
                        {
                            lblDN.Visible = true;
                            lblDN.Text = "Tên đăng nhập hoặc mật khẩu không chính xác.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblDN.Visible = true;
                    lblDN.Text = "Tên đăng nhập hoặc mật khẩu không chính xác.";
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dangky DK = new Dangky();
            this.Hide();
            DK.ShowDialog();
            this.Close();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(label2.Font, System.Drawing.FontStyle.Regular);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(label2.Font, System.Drawing.FontStyle.Underline);
        }

        private void btnDangnhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangnhap.ForeColor = Color.FromArgb(187, 39, 255);
        }

        private void btnDangnhap_MouseMove(object sender, MouseEventArgs e)
        {
            btnDangnhap.ForeColor = Color.FromArgb(133, 25, 183);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChatBot chatBot = new ChatBot();
            chatBot.Show();
        }
    }
}
