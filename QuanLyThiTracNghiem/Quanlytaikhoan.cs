using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net; 

namespace QuanLyThiTracNghiem
{
    public partial class Quanlytaikhoan : Form
    {
        public Quanlytaikhoan()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from TB_USER";
            adt.SelectCommand = command;
            table.Clear();
            adt.Fill(table);
            dataGridView1.DataSource = table;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private void Quanlytaikhoan_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_Mssv.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            tb_Mssv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            tb_hoten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dttime_ngsinh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            tb_email.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            tb_username.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            tb_password.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            string hashedPassword = HashPassword(tb_password.Text);
            command = connection.CreateCommand();
            command.CommandText = "insert into TB_USER values('" + tb_Mssv.Text + "', N'" + tb_hoten.Text + "', '" + dttime_ngsinh.Text + "', '" + tb_email.Text + "', '" + tb_username.Text + "', '" + hashedPassword + "' )";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from TB_USER where sMS= '" + tb_Mssv.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            string hashedPassword = HashPassword(tb_password.Text);
            command = connection.CreateCommand();
            command.CommandText = "update TB_USER set sHOTEN= N'" + tb_hoten.Text + "', tNGAYSINH= '" + dttime_ngsinh.Text + "', sEMAIL= '" + tb_email.Text + "', sUSERNAME= '" + tb_username.Text + "', sPASS= '" + hashedPassword + "' where sMS = '" + tb_Mssv.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void bt_khoitao_Click(object sender, EventArgs e)
        {
            tb_Mssv.Text = "";
            tb_hoten.Text = "";
            tb_email.Text = "";
            dttime_ngsinh.Text = "01/01/2000";
            tb_username.Text = " ";
            tb_password.Text = " ";
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            QuanLy QL = new QuanLy();
            this.Hide();
            QL.ShowDialog();
            this.Close();
        }
    }
}
