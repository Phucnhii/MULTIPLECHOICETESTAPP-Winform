using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
            label1.Parent = panel1;
            pictureBox1.Parent = panel1;
        }

        private void btnXemkq_Click(object sender, EventArgs e)
        {
            Xemketquathichung xemkq = new Xemketquathichung();
            this.Hide();
            xemkq.ShowDialog();
            this.Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void btnQLtaikhoan_Click(object sender, EventArgs e)
        {
            Quanlytaikhoan ql = new Quanlytaikhoan();
            this.Hide();
            ql.ShowDialog();
            this.Close();
        }

        private void btnQLcauhoi_Click(object sender, EventArgs e)
        {
            Quanlycauhoi ql = new Quanlycauhoi();
            this.Hide();
            ql.ShowDialog();
            this.Close();
        }

        private void btnQLcauhoi_MouseLeave(object sender, EventArgs e)
        {
            btnQLcauhoi.ForeColor = Color.FromArgb(100, 58, 192);
        }

        private void btnQLcauhoi_MouseMove(object sender, MouseEventArgs e)
        {
            btnQLcauhoi.ForeColor = Color.FromArgb(44, 18, 103);
        }

        private void btnQLtaikhoan_MouseLeave(object sender, EventArgs e)
        {
            btnQLtaikhoan.ForeColor = Color.FromArgb(100, 58, 192);
        }

        private void btnQLtaikhoan_MouseMove(object sender, MouseEventArgs e)
        {
            btnQLtaikhoan.ForeColor = Color.FromArgb(44, 18, 103);
        }

        private void btnXemkq_MouseLeave(object sender, EventArgs e)
        {
            btnXemkq.ForeColor = Color.FromArgb(100, 58, 192);
        }

        private void btnXemkq_MouseMove(object sender, MouseEventArgs e)
        {
            btnXemkq.ForeColor = Color.FromArgb(44, 18, 103);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Tomato;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.Red;
        }
    }
}