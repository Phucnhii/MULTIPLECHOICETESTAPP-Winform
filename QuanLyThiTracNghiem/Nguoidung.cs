using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyThiTracNghiem
{
    public partial class Nguoidung : Form
    {
        public Nguoidung()
        {
            InitializeComponent();
        }

        private void btndienthongtin_Click(object sender, EventArgs e)
        {
            Dienthongtin dienthongtin = new Dienthongtin();
            this.Hide();
            dienthongtin.ShowDialog();
            this.Close();
        }

        private void btndoimatkhau_Click(object sender, EventArgs e)
        {
            Doimatkhau doimatkhau = new Doimatkhau();
            this.Hide();
            doimatkhau.ShowDialog();
            this.Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void btndienthongtin_MouseLeave(object sender, EventArgs e)
        {
            btndienthongtin.ForeColor = Color.FromArgb(113, 21, 244);
        }

        private void btndienthongtin_MouseMove(object sender, MouseEventArgs e)
        {
            btndienthongtin.ForeColor = Color.FromArgb(79, 25, 156);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Tomato;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.Red;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LichSuThi ls = new LichSuThi();
            this.Hide();
            ls.ShowDialog();
            this.Close();
        }

        private void btnChatbot_Click(object sender, EventArgs e)
        {
            ChatBot chatBot = new ChatBot();
            chatBot.Show();
        }

        private void btnHistory_MouseMove(object sender, MouseEventArgs e)
        {
            btnHistory.ForeColor = Color.FromArgb(79, 25, 156);
        }

        private void btnHistory_MouseLeave(object sender, EventArgs e)
        {
            btnHistory.ForeColor = Color.FromArgb(113, 21, 244);
        }

        private void btnChatbot_MouseLeave(object sender, EventArgs e)
        {
            btnChatbot.ForeColor = Color.FromArgb(113, 21, 244);
        }

        private void btnChatbot_MouseMove(object sender, MouseEventArgs e)
        {
            btnChatbot.ForeColor = Color.FromArgb(79, 25, 156);
        }

        private void btnQLTTCaNhan_Click(object sender, EventArgs e)
        {
            Quanlythongtincanhan ttcn = new Quanlythongtincanhan();
            this.Hide();
            ttcn.ShowDialog();
            this.Close();
        }

        private void btn_tailieu_Click(object sender, EventArgs e)
        {
            QuestionForm qs = new QuestionForm();
            qs.ShowDialog();
        }
    }
}
