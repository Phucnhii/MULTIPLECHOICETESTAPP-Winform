using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class Ketquathi : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        SqlConnection cnn;
        string strngay;

        public Ketquathi(string strtenmon, string strten, string strma, string strdiem, string strsocaudung, string strngaythi)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            InitializeComponent();

            getvalueformtenmon = strtenmon; //ten mon thi
            getvalueformdienten = strten; //ten
            getvalueformdienma = strma; //ma thi sinh
            getvaluediem = strdiem; //diem
            getvaluesocaudung = strsocaudung; //so cau dung
            getvaluengaythi = strngaythi;
        }

        //lay du lieu tu form thi
        public string getvalueformtenmon
        {
            set
            {
                this.lblTenmon.Text = value;
            }
        }
        public string getvalueformdienten
        {
            set
            {
                this.lblHoten.Text = value;
            }

        }
        public string getvalueformdienma
        {
            set
            {
                this.lblMathisinh.Text = value;
            }
        }
        public string getvaluediem
        {
            set
            {
                this.lblDiem.Text = value;
            }
        }
        public string getvaluesocaudung
        {
            set
            {
                this.lblSocaudung.Text = value;
            }
        }
        public string getvaluengaythi
        {
            set
            {
                this.lblNgaythi.Text = value;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Nguoidung ND = new Nguoidung();
            this.Hide();
            ND.ShowDialog();
            this.Close();
        }

        private void Ketquathi_Load(object sender, EventArgs e)
        {
            string strten, strma, strsocaudung, strdiem, strMon, strngay;
            strten = lblHoten.Text;
            strma = lblMathisinh.Text;
            strsocaudung = lblSocaudung.Text;
            strMon = lblTenmon.Text;
            strdiem = lblDiem.Text;
            strngay = lblNgaythi.Text;

            string userEmail = GetUserEmail(strma); // Get the user's email from the database

            if (!string.IsNullOrEmpty(userEmail))
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "spKETQUA_INSERT";

                        try
                        {
                            cmd.Parameters.Add("@iMAKETQUA", SqlDbType.Int).Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("@sHOTENKQ", strten);
                            cmd.Parameters.AddWithValue("@sMS", strma);
                            cmd.Parameters.AddWithValue("@sTENMON", strMon);
                            cmd.Parameters.AddWithValue("@iDIEM", int.Parse(strdiem));
                            cmd.Parameters.AddWithValue("@iSOCAUDUNG", int.Parse(strsocaudung));
                            cmd.Parameters.AddWithValue("@tNGAYTHI", DateTime.Parse(strngay)); // Assuming strngay is a date
                            cmd.ExecuteNonQuery();
                            cnn.Close();

                            // Send email with the results
                            SendEmailResults(strten, strma, strMon, strdiem, strsocaudung, strngay, userEmail);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Có lỗi lưu kết quả! {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy email của người dùng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUserEmail(string studentId)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT sEMAIL FROM TB_USER WHERE sMS = @sMS", cnn))
                    {
                        cmd.Parameters.AddWithValue("@sMS", studentId);

                        object result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void SendEmailResults(string name, string studentId, string subject, string score, string correctAnswers, string examDate, string toEmail)
        {
            try
            {
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFrom = "nglebaophuc@gmail.com";
                string password = "rsoj vcnt qbdw sxjl";
                string emailTo = toEmail;
                string subjectEmail = "Kết quả thi cá nhân - Ứng dụng thi trắc nghiệm";
                string body = $"Xin chào {name},\n\n" +
                              $"Đây là kết quả thi của bạn:\n" +
                              $"Môn thi: {subject}\n" +
                              $"Điểm: {score}\n" +
                              $"Số câu đúng: {correctAnswers}/10\n" +
                              $"Ngày thi: {examDate}\n\n" +
                              $"Best regards,\n" +
                              $"Đội ngũ ứng dụng thi trắc nghiệm";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subjectEmail;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.Tomato;
        }

        private void btnThoat_MouseMove(object sender, MouseEventArgs e)
        {
            btnThoat.BackColor = Color.Red;
        }
    }
}
