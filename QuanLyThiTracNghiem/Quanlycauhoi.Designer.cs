namespace QuanLyThiTracNghiem
{
    partial class Quanlycauhoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.rtbNoidung = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.drvCauhoi = new System.Windows.Forms.DataGridView();
            this.cbxMamon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDapanA = new System.Windows.Forms.TextBox();
            this.txtDapanB = new System.Windows.Forms.TextBox();
            this.txtDapanC = new System.Windows.Forms.TextBox();
            this.txtDapanD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDapandung = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.quanly = new System.Windows.Forms.ToolStripMenuItem();
            this.doimk = new System.Windows.Forms.ToolStripMenuItem();
            this.huongdan = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drvCauhoi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(58)))), ((int)(((byte)(192)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(959, 50);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(107, 63);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(58)))), ((int)(((byte)(192)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(959, 153);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(107, 63);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Tomato;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(959, 256);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 64);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // rtbNoidung
            // 
            this.rtbNoidung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNoidung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(58)))), ((int)(((byte)(192)))));
            this.rtbNoidung.Location = new System.Drawing.Point(39, 57);
            this.rtbNoidung.Name = "rtbNoidung";
            this.rtbNoidung.Size = new System.Drawing.Size(691, 133);
            this.rtbNoidung.TabIndex = 3;
            this.rtbNoidung.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(757, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Môn ";
            // 
            // drvCauhoi
            // 
            this.drvCauhoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvCauhoi.Location = new System.Drawing.Point(39, 366);
            this.drvCauhoi.Name = "drvCauhoi";
            this.drvCauhoi.ReadOnly = true;
            this.drvCauhoi.RowHeadersVisible = false;
            this.drvCauhoi.RowHeadersWidth = 51;
            this.drvCauhoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drvCauhoi.Size = new System.Drawing.Size(884, 220);
            this.drvCauhoi.TabIndex = 8;
            this.drvCauhoi.Click += new System.EventHandler(this.drvCauhoi_Click);
            // 
            // cbxMamon
            // 
            this.cbxMamon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMamon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMamon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(58)))), ((int)(((byte)(192)))));
            this.cbxMamon.FormattingEnabled = true;
            this.cbxMamon.Items.AddRange(new object[] {
            "IT001",
            "IT002",
            "IT003",
            "IT004",
            "IT005"});
            this.cbxMamon.Location = new System.Drawing.Point(802, 96);
            this.cbxMamon.Name = "cbxMamon";
            this.cbxMamon.Size = new System.Drawing.Size(121, 31);
            this.cbxMamon.TabIndex = 9;
            this.cbxMamon.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(34, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(408, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(408, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "D";
            // 
            // txtDapanA
            // 
            this.txtDapanA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDapanA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDapanA.Location = new System.Drawing.Point(62, 208);
            this.txtDapanA.Name = "txtDapanA";
            this.txtDapanA.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDapanA.Size = new System.Drawing.Size(290, 30);
            this.txtDapanA.TabIndex = 14;
            // 
            // txtDapanB
            // 
            this.txtDapanB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDapanB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDapanB.Location = new System.Drawing.Point(62, 256);
            this.txtDapanB.Name = "txtDapanB";
            this.txtDapanB.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDapanB.Size = new System.Drawing.Size(290, 30);
            this.txtDapanB.TabIndex = 15;
            // 
            // txtDapanC
            // 
            this.txtDapanC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDapanC.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDapanC.Location = new System.Drawing.Point(436, 208);
            this.txtDapanC.Name = "txtDapanC";
            this.txtDapanC.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDapanC.Size = new System.Drawing.Size(294, 30);
            this.txtDapanC.TabIndex = 16;
            // 
            // txtDapanD
            // 
            this.txtDapanD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDapanD.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDapanD.Location = new System.Drawing.Point(437, 256);
            this.txtDapanD.Name = "txtDapanD";
            this.txtDapanD.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDapanD.Size = new System.Drawing.Size(294, 30);
            this.txtDapanD.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(35, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Nội dung câu hỏi";
            // 
            // txtDapandung
            // 
            this.txtDapandung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDapandung.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDapandung.ForeColor = System.Drawing.Color.Red;
            this.txtDapandung.Location = new System.Drawing.Point(159, 308);
            this.txtDapandung.Name = "txtDapandung";
            this.txtDapandung.Size = new System.Drawing.Size(571, 30);
            this.txtDapandung.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(34, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Đáp án đúng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(757, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(58)))), ((int)(((byte)(192)))));
            this.txtID.Location = new System.Drawing.Point(802, 60);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(121, 30);
            this.txtID.TabIndex = 22;
            // 
            // quanly
            // 
            this.quanly.Name = "quanly";
            this.quanly.Size = new System.Drawing.Size(32, 19);
            // 
            // doimk
            // 
            this.doimk.Name = "doimk";
            this.doimk.Size = new System.Drawing.Size(32, 19);
            // 
            // huongdan
            // 
            this.huongdan.Name = "huongdan";
            this.huongdan.Size = new System.Drawing.Size(32, 19);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(752, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 180);
            this.label9.TabIndex = 25;
            this.label9.Text = "Chú thích:\r\nIT001: Nhập môn lập trình\r\nIT002: Lập trình hướng \r\n          đối tượ" +
    "ng\r\nIT003: Cấu trúc dữ liệu \r\n          và giải thuật\r\nIT004: Cơ sở dữ liệu\r\nIT0" +
    "05: Nhập môn \r\n          mạng máy tính";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(58)))), ((int)(((byte)(192)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(959, 366);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 220);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Quanlycauhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuanLyThiTracNghiem.Properties.Resources.gradient_abstraction_blue_205793_3840x2160;
            this.ClientSize = new System.Drawing.Size(1108, 598);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDapandung);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDapanD);
            this.Controls.Add(this.txtDapanC);
            this.Controls.Add(this.txtDapanB);
            this.Controls.Add(this.txtDapanA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxMamon);
            this.Controls.Add(this.drvCauhoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbNoidung);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Quanlycauhoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý câu hỏi";
            this.Load += new System.EventHandler(this.Quanlycauhoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drvCauhoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.RichTextBox rtbNoidung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView drvCauhoi;
        private System.Windows.Forms.ComboBox cbxMamon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDapanA;
        private System.Windows.Forms.TextBox txtDapanB;
        private System.Windows.Forms.TextBox txtDapanC;
        private System.Windows.Forms.TextBox txtDapanD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDapandung;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ToolStripMenuItem quanly;
        private System.Windows.Forms.ToolStripMenuItem doimk;
        private System.Windows.Forms.ToolStripMenuItem huongdan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExit;
    }
}