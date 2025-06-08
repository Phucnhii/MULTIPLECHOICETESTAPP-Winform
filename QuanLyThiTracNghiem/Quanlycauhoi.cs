using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class Quanlycauhoi : Form
    {
        public Quanlycauhoi()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT iID, sNOIDUNG, sA, sB, sC, sD, sDAPAN, sMAMON FROM TB_CAUHOI";
                adt.SelectCommand = command;
                table.Clear();
                adt.Fill(table);
                drvCauhoi.DataSource = table;

               
                if (drvCauhoi.Columns.Count == 0)
                {
                    DataGridViewColumn column;

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "iID";
                    column.HeaderText = "ID";
                    column.Width = 50; 
                    drvCauhoi.Columns.Add(column);

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "sNOIDUNG";
                    column.HeaderText = "Nội Dung";
                    column.Width = 300; 
                    drvCauhoi.Columns.Add(column);

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "sA";
                    column.HeaderText = "Đáp Án A";
                    column.Width = 100; // Set width for Đáp Án A column
                    drvCauhoi.Columns.Add(column);

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "sB";
                    column.HeaderText = "Đáp Án B";
                    column.Width = 100; // Set width for Đáp Án B column
                    drvCauhoi.Columns.Add(column);

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "sC";
                    column.HeaderText = "Đáp Án C";
                    column.Width = 100; 
                    drvCauhoi.Columns.Add(column);

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "sD";
                    column.HeaderText = "Đáp Án D";
                    column.Width = 100; 
                    drvCauhoi.Columns.Add(column);

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "sDAPAN";
                    column.HeaderText = "Đáp Án Đúng";
                    column.Width = 100; 
                    drvCauhoi.Columns.Add(column);

                    column = new DataGridViewTextBoxColumn();
                    column.Name = "sMAMON";
                    column.HeaderText = "Mã Môn";
                    column.Width = 80; 
                    drvCauhoi.Columns.Add(column);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void Quanlycauhoi_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void drvCauhoi_Click(object sender, EventArgs e)
        {
            if (drvCauhoi.CurrentRow != null)
            {
                try
                {
                    txtID.Text = drvCauhoi.CurrentRow.Cells["iID"].Value.ToString();
                    rtbNoidung.Text = drvCauhoi.CurrentRow.Cells["sNOIDUNG"].Value.ToString();
                    txtDapanA.Text = drvCauhoi.CurrentRow.Cells["sA"].Value.ToString();
                    txtDapanB.Text = drvCauhoi.CurrentRow.Cells["sB"].Value.ToString();
                    txtDapanC.Text = drvCauhoi.CurrentRow.Cells["sC"].Value.ToString();
                    txtDapanD.Text = drvCauhoi.CurrentRow.Cells["sD"].Value.ToString();
                    txtDapandung.Text = drvCauhoi.CurrentRow.Cells["sDAPAN"].Value.ToString();
                    cbxMamon.Text = drvCauhoi.CurrentRow.Cells["sMAMON"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading selected row data: " + ex.Message);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty fields
                if (string.IsNullOrWhiteSpace(rtbNoidung.Text) || string.IsNullOrWhiteSpace(txtDapanA.Text) ||
                    string.IsNullOrWhiteSpace(txtDapanB.Text) || string.IsNullOrWhiteSpace(txtDapanC.Text) ||
                    string.IsNullOrWhiteSpace(txtDapanD.Text) || string.IsNullOrWhiteSpace(txtDapandung.Text) ||
                    string.IsNullOrWhiteSpace(cbxMamon.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các trường.");
                    return;
                }

                // Validate correct answer
                string correctAnswer = txtDapandung.Text;
                if (correctAnswer != txtDapanA.Text && correctAnswer != txtDapanB.Text &&
                    correctAnswer != txtDapanC.Text && correctAnswer != txtDapanD.Text)
                {
                    MessageBox.Show("Đáp án đúng phải giống với nội dung của một trong các đáp án A, B, C hoặc D.");
                    return;
                }

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TB_CAUHOI (sNOIDUNG, sA, sB, sC, sD, sDAPAN, sMAMON) VALUES (@Noidung, @DapanA, @DapanB, @DapanC, @DapanD, @Dapandung, @Mamon)";
                command.Parameters.AddWithValue("@Noidung", rtbNoidung.Text);
                command.Parameters.AddWithValue("@DapanA", txtDapanA.Text);
                command.Parameters.AddWithValue("@DapanB", txtDapanB.Text);
                command.Parameters.AddWithValue("@DapanC", txtDapanC.Text);
                command.Parameters.AddWithValue("@DapanD", txtDapanD.Text);
                command.Parameters.AddWithValue("@Dapandung", txtDapandung.Text);
                command.Parameters.AddWithValue("@Mamon", cbxMamon.Text);
                command.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty fields
                if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(rtbNoidung.Text) ||
                    string.IsNullOrWhiteSpace(txtDapanA.Text) || string.IsNullOrWhiteSpace(txtDapanB.Text) ||
                    string.IsNullOrWhiteSpace(txtDapanC.Text) || string.IsNullOrWhiteSpace(txtDapanD.Text) ||
                    string.IsNullOrWhiteSpace(txtDapandung.Text) || string.IsNullOrWhiteSpace(cbxMamon.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các trường.");
                    return;
                }

                // Validate correct answer
                string correctAnswer = txtDapandung.Text;
                if (correctAnswer != txtDapanA.Text && correctAnswer != txtDapanB.Text &&
                    correctAnswer != txtDapanC.Text && correctAnswer != txtDapanD.Text)
                {
                    MessageBox.Show("Đáp án đúng phải giống với nội dung của một trong các đáp án A, B, C hoặc D.");
                    return;
                }

                command = connection.CreateCommand();
                command.CommandText = "UPDATE TB_CAUHOI SET sNOIDUNG = @Noidung, sA = @DapanA, sB = @DapanB, sC = @DapanC, sD = @DapanD, sDAPAN = @Dapandung, sMAMON = @Mamon WHERE iID = @ID";
                command.Parameters.AddWithValue("@ID", txtID.Text);
                command.Parameters.AddWithValue("@Noidung", rtbNoidung.Text);
                command.Parameters.AddWithValue("@DapanA", txtDapanA.Text);
                command.Parameters.AddWithValue("@DapanB", txtDapanB.Text);
                command.Parameters.AddWithValue("@DapanC", txtDapanC.Text);
                command.Parameters.AddWithValue("@DapanD", txtDapanD.Text);
                command.Parameters.AddWithValue("@Dapandung", txtDapandung.Text);
                command.Parameters.AddWithValue("@Mamon", cbxMamon.Text);
                command.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM TB_CAUHOI WHERE iID = @ID";
                command.Parameters.AddWithValue("@ID", txtID.Text);
                command.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting data: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            QuanLy QL = new QuanLy();
            this.Hide();
            QL.ShowDialog();
            this.Close();
        }
    }
}
