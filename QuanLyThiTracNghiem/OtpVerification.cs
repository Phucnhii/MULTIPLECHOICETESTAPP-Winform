using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks; 

namespace QuanLyThiTracNghiem
{
    public partial class OtpVerification : Form
    {
        private string otp;
        private string ms;
        private string name;
        private DateTime birthdate;
        private string email;
        private string username;
        private string pass;
        private string connectionString;

        public OtpVerification(string otp, string ms, string name, DateTime birthdate, string email, string username, string pass, string connectionString)
        {
            InitializeComponent();
            this.otp = otp;
            this.ms = ms;
            this.name = name;
            this.birthdate = birthdate;
            this.email = email;
            this.username = username;
            this.pass = pass;
            this.connectionString = connectionString;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (tb_otp.Text == otp)
            {
                RegisterUser();
            }
            else
            {     
                lblStatus.Visible = true;
                lblStatus.Text = "Mã OTP không chính xác!";
            }
        }

        private async void RegisterUser()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    string sql = @"INSERT INTO TB_USER (sMS, sHOTEN, tNGAYSINH, sEMAIL, sUSERNAME, sPASS)
                           VALUES (@sMS, @sHOTEN, @tNGAYSINH, @sEMAIL, @sUSERNAME, @sPASS)";
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@sMS", ms);
                        cmd.Parameters.AddWithValue("@sHOTEN", name);
                        cmd.Parameters.AddWithValue("@tNGAYSINH", birthdate);
                        cmd.Parameters.AddWithValue("@sEMAIL", email);
                        cmd.Parameters.AddWithValue("@sUSERNAME", username);
                        cmd.Parameters.AddWithValue("@sPASS", pass);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            lblStatus.Visible = true;
                            lblStatus.Text = "Đăng kí thành công! Hãy đăng nhập";

                            // Introduce a delay of 2 seconds
                            await Task.Delay(2000);

                            this.Hide();
                            Login LG = new Login();
                            LG.ShowDialog(); // Dang ky thanh cong thi trang dang nhap hien ra
                            this.Close();
                        }
                        else
                        {
                            lblStatus.Text = "Đăng ký không thành công. Vui lòng thử lại!";

                            // Introduce a delay of 2 seconds
                            await Task.Delay(2000);

                            this.Hide();
                            Login LG = new Login();
                            LG.ShowDialog();
                            this.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    lblStatus.Text = "Lỗi kết nối cơ sở dữ liệu!";
                }
            }
        }

        private void btnVerify_MouseLeave(object sender, EventArgs e)
        {
            btnVerify.ForeColor = Color.RoyalBlue;
        }

        private void btnVerify_MouseMove(object sender, MouseEventArgs e)
        {
            btnVerify.ForeColor = Color.Navy;
        }

        private void OtpVerification_Load(object sender, EventArgs e)
        {

        }
    }
}
