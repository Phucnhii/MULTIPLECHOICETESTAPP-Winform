using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using BCrypt.Net; // Sử dụng hàm băm mật khẩu Bcrypt

namespace QuanLyThiTracNghiem
{
    public partial class Dangky : Form
    {
        private string otp;
        private string name;

        public Dangky()
        {
            InitializeComponent();
            lblWelcome.Parent = pictureBox4;
            label1.Parent = pictureBox4;
            label2.Parent = pictureBox4;
            label3.Parent = pictureBox4;
            label4.Parent = pictureBox4;
            label5.Parent = pictureBox4;
            label6.Parent = pictureBox4;
            tb_ms.Parent = pictureBox4;
            tb_name.Parent = pictureBox4;
            dtp_birthdate.Parent = pictureBox4;
            tb_email.Parent = pictureBox4;
            tb_username.Parent = pictureBox4;
            tb_pass.Parent = pictureBox4;
            cbHienmatkhau.Parent = pictureBox4;
            lblDK.Parent = pictureBox4;
            btnDangky.Parent = pictureBox4; 
            label8.Parent = pictureBox4;
            label9.Parent = pictureBox4;
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }

        private bool IsUsernameValid(string username)
        {
            // Kiểm tra độ dài tối thiểu là 6 ký tự
            if (username.Length < 6)
                return false;

            return true;
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

        private void btnDangky_Click(object sender, EventArgs e)
        {
            string ms = tb_ms.Text;
            string username = tb_username.Text;
            string pass = tb_pass.Text;
            name = tb_name.Text; 
            string email = tb_email.Text;
            DateTime birthdate = dtp_birthdate.Value;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass) ||
                string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                lblDK.Visible = true;
                lblDK.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            // Băm mật khẩu trước khi lưu vào cơ sở dữ liệu
            string hashedPassword = PasswordHelper.HashPassword(pass);

            // Email validation
            try
            {
                new MailAddress(email);
            }
            catch (FormatException)
            {
                lblDK.Visible = true;
                lblDK.Text = "Email không hợp lệ!";
                return;
            }

            // Kiểm tra username
            if (!IsUsernameValid(tb_username.Text))
            {
                lblDK.Visible = true;
                lblDK.Text = "Tên đăng nhập cần có ít nhất 6 ký tự!";
                return;
            }

            // Kiểm tra mật khẩu
            if (!IsPasswordValid(tb_pass.Text))
            {
                lblDK.Visible = true;
                lblDK.Text = "Mật khẩu cần có ít nhất 8 ký tự gồm chữ cái và số!";
                return;
            }

            // Generate OTP
            otp = GenerateOtp();
            // Send OTP to email
            SendOtpEmail(email, otp);

            this.Hide();
            // Show OTP Verification Form
            OtpVerification otpForm = new OtpVerification(otp, ms, name, birthdate, email, username, hashedPassword, connectionString);
            otpForm.ShowDialog();
            this.Close();
        }

        private string GenerateOtp()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString();
        }

        private void SendOtpEmail(string email, string otp)
        {
            try
            {
                MailMessage mail = new MailMessage("nglebaophuc@gmail.com", email);
                SmtpClient client = new SmtpClient
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    Credentials = new System.Net.NetworkCredential("nglebaophuc@gmail.com", "rsoj vcnt qbdw sxjl"),
                    EnableSsl = true,
                };

                mail.Subject = "Verification Code - Ứng dụng thi trắc nghiệm";
                mail.IsBodyHtml = true;
                mail.Body = $@"<p>Xin chào {name},</p>

<p>Cảm ơn bạn đã lựa chọn Ứng dụng thi trắc nghiệm.<br/>
Vui lòng nhập mã OTP bên dưới để hoàn tất đăng ký:</p>
<p><b><span style='font-size:16px;'>{otp}</span></b></p>
<p>Thanks,<br/>
Đội ngũ ứng dụng thi trắc nghiệm.</p>";
                client.Send(mail);
            }
            catch (Exception ex)
            {
                lblDK.Visible = true;
                lblDK.Text = "Lỗi gửi mã OTP hoặc email không hợp lệ!";
            }
        }

        private void cbHienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienmatkhau.Checked)
            {
                tb_pass.PasswordChar = (char)0;
            }
            else
            {
                tb_pass.PasswordChar = '●';
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.Font = new System.Drawing.Font(label8.Font, System.Drawing.FontStyle.Regular);
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.Font = new System.Drawing.Font(label8.Font, System.Drawing.FontStyle.Underline);
        }

        private void btnDangky_MouseLeave(object sender, EventArgs e)
        {
            btnDangky.ForeColor = Color.FromArgb(187, 39, 255);
        }

        private void btnDangky_MouseMove(object sender, MouseEventArgs e)
        {
            btnDangky.ForeColor = Color.FromArgb(133, 25, 183);
        }
    }
}