using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace QuanLyThiTracNghiem
{
    public partial class Thi : Form
    {
        int s, m, h;
        public int diemThi = 0;
        DataTable bangDeThi = new DataTable();
        int cauHienTai = 0;
        public int soCauDung = 0;
        int soCauHoi = 0;
        public bool deThi = false;
        int soCauNgauNhien = 10;

        string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
        string selectedSubject;

        public Thi(string chonmon, string dienten, string dienma)
        {
            InitializeComponent();
            gettenmon = chonmon;
            getmathisinh = dienma;
            gettenthisinh = dienten;

            selectedSubject = GetSubjectCode(chonmon);

            lblMamon.Text = selectedSubject;
        }

        private string GetSubjectCode(string subjectName)
        {
            switch (subjectName)
            {
                case "Nhập môn lập trình":
                    return "IT001";
                case "Lập trình hướng đối tượng":
                    return "IT002";
                case "Cấu trúc dữ liệu và giải thuật":
                    return "IT003";
                case "Cơ sở dữ liệu":
                    return "IT004";
                case "Nhập môn mạng máy tính":
                    return "IT005";
                default:
                    return "";
            }
        }

        async Task<DataTable> LoadDeThiAsync()
        {
            DataTable Bangcauhoi = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    await cnn.OpenAsync();
                    string query = "SELECT * FROM TB_CAUHOI WHERE sMAMON = @sMAMON";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@sMAMON", selectedSubject);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(Bangcauhoi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Bangcauhoi;
        }

        void TaoBangRandomCauHoi(DataTable Bangcauhoi)
        {
            try
            {
                Random rd = new Random();
                ArrayList arrCauhoi = new ArrayList();
                arrCauhoi.Clear();
                int x, dem = 0;
                int SoCauBangGoc = Bangcauhoi.Rows.Count;
                while (dem < soCauNgauNhien)
                {
                    x = rd.Next(0, SoCauBangGoc);
                    if (!arrCauhoi.Contains(x))
                    {
                        arrCauhoi.Add(x);
                        dem++;
                    }
                }
                for (int j = SoCauBangGoc - 1; j >= 0; j--)
                {
                    if (!arrCauhoi.Contains(j))
                    {
                        Bangcauhoi.Rows.RemoveAt(j);
                    }
                }
                bangDeThi = Bangcauhoi;
                bangDeThi.Columns.Add("DapAnTS");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void TaoBangRandomCauTraLoi()
        {
            try
            {
                soCauHoi = soCauNgauNhien;
                Random Rnd = new Random();

                for (int i = 0; i < soCauHoi; i++)
                {
                    List<string> answers = new List<string> { bangDeThi.Rows[i]["sA"].ToString(), bangDeThi.Rows[i]["sB"].ToString(), bangDeThi.Rows[i]["sC"].ToString(), bangDeThi.Rows[i]["sD"].ToString() };
                    string correctAnswer = bangDeThi.Rows[i]["sDAPAN"].ToString();

                    answers.Shuffle(Rnd);

                    bangDeThi.Rows[i]["sA"] = answers[0];
                    bangDeThi.Rows[i]["sB"] = answers[1];
                    bangDeThi.Rows[i]["sC"] = answers[2];
                    bangDeThi.Rows[i]["sD"] = answers[3];

                    string newCorrectAnswer = "";

                    if (answers[0] == correctAnswer) newCorrectAnswer = "A";
                    else if (answers[1] == correctAnswer) newCorrectAnswer = "B";
                    else if (answers[2] == correctAnswer) newCorrectAnswer = "C";
                    else if (answers[3] == correctAnswer) newCorrectAnswer = "D";

                    bangDeThi.Rows[i]["sDAPAN"] = newCorrectAnswer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private readonly TimeSpan examDuration = TimeSpan.FromMinutes(10);
        private DateTime endTime;

        private async void Thi_Load(object sender, EventArgs e)
        {
            lblNgaythi.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Set the end time of the exam
            endTime = DateTime.Now.Add(examDuration);

            // Start the countdown timer
            timer1.Start();

            try
            {
                if (deThi == true)
                    bangDeThi = await LoadDeThiAsync();
                else
                    bangDeThi = await LoadDeThiAsync();

                TaoBangRandomCauHoi(bangDeThi);
                TaoBangRandomCauTraLoi();
                loadCauHoiVaoControl();
                timer1.Start();

                btnCautruoc.Enabled = false;

                // Set the countdown timer to 10 minutes
                h = 0;
                m = 10;
                s = 0;
                timer1.Start();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        void loadCauHoiVaoControl()
        {
            try
            {
                groupBox1.Text = "Câu " + (cauHienTai + 1).ToString();
                lblNoidungcauhoi.Text = bangDeThi.Rows[cauHienTai]["sNOIDUNG"].ToString();

                // Escape ampersands for the answers when setting the label text
                lblA.Text = bangDeThi.Rows[cauHienTai]["sA"].ToString().Replace("&", "&&");
                lblB.Text = bangDeThi.Rows[cauHienTai]["sB"].ToString().Replace("&", "&&");
                lblC.Text = bangDeThi.Rows[cauHienTai]["sC"].ToString().Replace("&", "&&");
                lblD.Text = bangDeThi.Rows[cauHienTai]["sD"].ToString().Replace("&", "&&");

                rdbA.Checked = bangDeThi.Rows[cauHienTai]["DapAnTS"].ToString().Contains("A");
                rdbB.Checked = bangDeThi.Rows[cauHienTai]["DapAnTS"].ToString().Contains("B");
                rdbC.Checked = bangDeThi.Rows[cauHienTai]["DapAnTS"].ToString().Contains("C");
                rdbD.Checked = bangDeThi.Rows[cauHienTai]["DapAnTS"].ToString().Contains("D");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Ghi lại đáp án
        void GhiLaiDapAnTS()
        {
            string DapAnTS = "";
            if (rdbA.Checked == true) DapAnTS += "A";
            if (rdbB.Checked == true) DapAnTS += "B";
            if (rdbC.Checked == true) DapAnTS += "C";
            if (rdbD.Checked == true) DapAnTS += "D";
            bangDeThi.Rows[cauHienTai]["DapAnTS"] = DapAnTS;
        }

        public string gettenmon
        {
            set { this.lblMonthi.Text = value; }
        }
        public string getmathisinh
        {
            set { this.lblMathisinh.Text = value; }
        }
        public string gettenthisinh
        {
            set { this.lblHotenthisinh.Text = value; }
        }

        private void btnCautruoc_Click(object sender, EventArgs e)
        {
            try
            {
                GhiLaiDapAnTS();
                if (cauHienTai > 0)
                {
                    GhiLaiDapAnTS();
                    btnCautiep.Enabled = true;
                    rdbA.Checked = false;
                    rdbB.Checked = false;
                    rdbC.Checked = false;
                    rdbD.Checked = false;
                    cauHienTai--;
                    loadCauHoiVaoControl();
                }
                if (cauHienTai == 0) btnCautruoc.Enabled = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnCautiep_Click(object sender, EventArgs e)
        {
            try
            {
                GhiLaiDapAnTS();
                if (cauHienTai < soCauHoi - 1)
                {
                    GhiLaiDapAnTS();
                    btnCautruoc.Enabled = true;
                    rdbA.Checked = false;
                    rdbB.Checked = false;
                    rdbC.Checked = false;
                    rdbD.Checked = false;
                    cauHienTai++;
                    loadCauHoiVaoControl();
                }
                if (cauHienTai == soCauHoi - 1) btnCautiep.Enabled = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Calculate the remaining time
            TimeSpan remainingTime = endTime - DateTime.Now;

            // Check if time is up
            if (remainingTime.TotalSeconds <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Hết thời gian làm bài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KetThucBaiThi();
                return;
            }

            // Update the displayed time
            lblTime.Text = remainingTime.ToString(@"hh\:mm\:ss");
        }

        void KetThucBaiThi()
        {
            GhiLaiDapAnTS();
            soCauDung = 0;
            for (int i = 0; i < soCauHoi; i++)
            {
                if (!string.IsNullOrWhiteSpace(bangDeThi.Rows[i]["DapAnTS"].ToString()))
                {
                    if (bangDeThi.Rows[i]["sDAPAN"].ToString().Trim().Equals(bangDeThi.Rows[i]["DapAnTS"].ToString().Trim(), StringComparison.InvariantCultureIgnoreCase))
                        soCauDung++;
                }
            }
            diemThi = soCauDung * 10 / soCauHoi;
            timer1.Stop();

            // Mở Ketquathi form
            Ketquathi formKQ = new Ketquathi(lblMonthi.Text, lblHotenthisinh.Text, lblMathisinh.Text, diemThi.ToString(), soCauDung.ToString(), lblNgaythi.Text);

            this.Hide();
            formKQ.ShowDialog();
            this.Close();
        }

        private void btnNopbai_Click(object sender, EventArgs e)
        {
            msgBox m = new msgBox();

            // Subscribe to the ConfirmClicked event of msgBox
            m.ConfirmClicked += (s, args) => {
                KetThucBaiThi();
                m.Close();
            };

            m.ShowDialog();
        }

        private void rdbA_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbA.Checked == true)
            {
                rdbB.Checked = false;
                rdbC.Checked = false;
                rdbD.Checked = false;
            }
        }

        private void rdbB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbB.Checked == true)
            {
                rdbA.Checked = false;
                rdbC.Checked = false;
                rdbD.Checked = false;
            }
        }

        private void lblA_Click(object sender, EventArgs e)
        {
            rdbA.Checked = true;
            rdbB.Checked = false;
            rdbC.Checked = false;
            rdbD.Checked = false;
        }

        private void lblB_Click(object sender, EventArgs e)
        {
            rdbA.Checked = false;
            rdbB.Checked = true;
            rdbC.Checked = false;
            rdbD.Checked = false;
        }

        private void lblC_Click(object sender, EventArgs e)
        {
            rdbA.Checked = false;
            rdbB.Checked = false;
            rdbC.Checked = true;
            rdbD.Checked = false;
        }

        private void lblD_Click(object sender, EventArgs e)
        {
            rdbA.Checked = false;
            rdbB.Checked = false;
            rdbC.Checked = false;
            rdbD.Checked = true;
        }

        private void rdbC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbC.Checked == true)
            {
                rdbA.Checked = false;
                rdbB.Checked = false;
                rdbD.Checked = false;
            }
        }

        private void rdbD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbD.Checked == true)
            {
                rdbA.Checked = false;
                rdbB.Checked = false;
                rdbC.Checked = false;
            }
        }
    }

    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list, Random rnd)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
