using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class Xemketquathichung : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public Xemketquathichung()
        {
            InitializeComponent();
        }

        private DataTable getKetqua()
        {
            string procName = "spKETQUA_GET";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procName, cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable("TB_KETQUA");
                        da.Fill(tbl);
                        return tbl;
                    }
                }
            }

        }

        private void hienKetqua()
        {
            DataTable t = getKetqua();
            DataView v = new DataView(t);
            drvKetqua.AutoGenerateColumns = false;
            drvKetqua.ReadOnly = true;
            drvKetqua.DataSource = v;
            drvKetqua.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void Xemketquathichung_Load(object sender, EventArgs e)
        {
            hienKetqua();
        }

        private void drvKetqua_Click(object sender, EventArgs e)
        {
            DataView dvKetqua = (DataView)drvKetqua.DataSource;
            DataRowView row = dvKetqua[drvKetqua.CurrentRow.Index];
            txtMathisinh.Text = row["sMS"].ToString();
            txtHoten.Text = row["sHOTENKQ"].ToString();
            cbxMonthi.Text = row["sTENMON"].ToString();
            txtSocaudung.Text = row["iSOCAUDUNG"].ToString();
            cbxDiem.Text = row["iDIEM"].ToString();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            List<string> conditions = new List<string>();

            // Kiểm tra và xây dựng điều kiện lọc
            if (!string.IsNullOrEmpty(txtMathisinh.Text))
            {
                conditions.Add(string.Format("sMS = '{0}'", txtMathisinh.Text));
            }
            if (!string.IsNullOrEmpty(txtHoten.Text))
            {
                conditions.Add(string.Format("sHOTENKQ = '{0}'", txtHoten.Text));
            }
            if (!string.IsNullOrEmpty(txtSocaudung.Text))
            {
                conditions.Add(string.Format("iSOCAUDUNG = {0}", txtSocaudung.Text));
            }
            if (!string.IsNullOrEmpty(cbxDiem.Text))
            {
                conditions.Add(string.Format("iDIEM = {0}", cbxDiem.Text));
            }
            if (!string.IsNullOrEmpty(cbxMonthi.Text))
            {
                conditions.Add(string.Format("sTENMON = '{0}'", cbxMonthi.Text));
            }

            // Kiểm tra nếu không có điều kiện lọc nào được thêm vào
            if (conditions.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một điều kiện để tìm kiếm.");
                return;
            }

            // Xây dựng chuỗi điều kiện lọc cuối cùng
            string filterCondition = string.Join(" AND ", conditions);

            // Lọc dữ liệu và hiển thị lên DataGridView
            try
            {
                DataView dvKetqua = drvKetqua.DataSource as DataView;
                dvKetqua.RowFilter = filterCondition;
                drvKetqua.DataSource = dvKetqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMathisinh.Text) ||
                string.IsNullOrEmpty(txtHoten.Text) ||
                string.IsNullOrEmpty(txtSocaudung.Text) ||
                cbxMonthi.SelectedItem == null ||
                cbxDiem.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi xóa!");
                return;
            }

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("", cnn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "DELETE FROM TB_KETQUA WHERE sMS = @sMS AND sHOTENKQ = @sHOTENKQ AND sTENMON = @sTENMON AND iSOCAUDUNG = @iSOCAUDUNG AND iDIEM = @iDIEM";

                    cmd.Parameters.AddWithValue("@sMS", txtMathisinh.Text);
                    cmd.Parameters.AddWithValue("@sHOTENKQ", txtHoten.Text);
                    cmd.Parameters.AddWithValue("@sTENMON", cbxMonthi.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@iSOCAUDUNG", txtSocaudung.Text);
                    cmd.Parameters.AddWithValue("@iDIEM", cbxDiem.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    hienKetqua();
                }
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
