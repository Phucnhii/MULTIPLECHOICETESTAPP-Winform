namespace QuanLyThiTracNghiem
{
    partial class Xemketquathichung
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
            this.drvKetqua = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbTimkiem = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cbxDiem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMon = new System.Windows.Forms.Label();
            this.cbxMonthi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtSocaudung = new System.Windows.Forms.TextBox();
            this.txtMathisinh = new System.Windows.Forms.TextBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drvKetqua)).BeginInit();
            this.grbTimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // drvKetqua
            // 
            this.drvKetqua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drvKetqua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.drvKetqua.Location = new System.Drawing.Point(16, 259);
            this.drvKetqua.Margin = new System.Windows.Forms.Padding(4);
            this.drvKetqua.Name = "drvKetqua";
            this.drvKetqua.RowHeadersWidth = 51;
            this.drvKetqua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drvKetqua.Size = new System.Drawing.Size(1079, 326);
            this.drvKetqua.TabIndex = 0;
            this.drvKetqua.Click += new System.EventHandler(this.drvKetqua_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "sMS";
            this.Column1.HeaderText = "MSSV";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "sHOTENKQ";
            this.Column2.HeaderText = "Họ tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 220;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tNGAYTHI";
            this.Column3.HeaderText = "Ngày thi";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 160;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "sTENMON";
            this.Column4.HeaderText = "Môn thi";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 250;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "iSOCAUDUNG";
            this.Column5.HeaderText = "Số câu đúng";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 110;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "iDIEM";
            this.Column6.HeaderText = "Điểm";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 110;
            // 
            // grbTimkiem
            // 
            this.grbTimkiem.Controls.Add(this.btnExit);
            this.grbTimkiem.Controls.Add(this.btnXoa);
            this.grbTimkiem.Controls.Add(this.cbxDiem);
            this.grbTimkiem.Controls.Add(this.label4);
            this.grbTimkiem.Controls.Add(this.lblMon);
            this.grbTimkiem.Controls.Add(this.cbxMonthi);
            this.grbTimkiem.Controls.Add(this.label3);
            this.grbTimkiem.Controls.Add(this.label2);
            this.grbTimkiem.Controls.Add(this.label1);
            this.grbTimkiem.Controls.Add(this.txtHoten);
            this.grbTimkiem.Controls.Add(this.txtSocaudung);
            this.grbTimkiem.Controls.Add(this.txtMathisinh);
            this.grbTimkiem.Controls.Add(this.btnTimkiem);
            this.grbTimkiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTimkiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(39)))), ((int)(((byte)(255)))));
            this.grbTimkiem.Location = new System.Drawing.Point(16, 27);
            this.grbTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.grbTimkiem.Name = "grbTimkiem";
            this.grbTimkiem.Padding = new System.Windows.Forms.Padding(4);
            this.grbTimkiem.Size = new System.Drawing.Size(1079, 215);
            this.grbTimkiem.TabIndex = 1;
            this.grbTimkiem.TabStop = false;
            this.grbTimkiem.Text = "Hiển Thị";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(39)))), ((int)(((byte)(255)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnExit.Location = new System.Drawing.Point(907, 140);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 37);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Tomato;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnXoa.Location = new System.Drawing.Point(907, 95);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 37);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbxDiem
            // 
            this.cbxDiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDiem.FormattingEnabled = true;
            this.cbxDiem.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxDiem.Location = new System.Drawing.Point(734, 137);
            this.cbxDiem.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDiem.Name = "cbxDiem";
            this.cbxDiem.Size = new System.Drawing.Size(100, 31);
            this.cbxDiem.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(668, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Điểm:";
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMon.Location = new System.Drawing.Point(445, 66);
            this.lblMon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(78, 23);
            this.lblMon.TabIndex = 9;
            this.lblMon.Text = "Môn thi:";
            // 
            // cbxMonthi
            // 
            this.cbxMonthi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMonthi.FormattingEnabled = true;
            this.cbxMonthi.Items.AddRange(new object[] {
            "Nhập môn lập trình",
            "Lập trình hướng đối tượng",
            "Cấu trúc dữ liệu và giải thuật",
            "Cơ sở dữ liệu",
            "Nhập môn mạng máy tính"});
            this.cbxMonthi.Location = new System.Drawing.Point(530, 62);
            this.cbxMonthi.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMonthi.Name = "cbxMonthi";
            this.cbxMonthi.Size = new System.Drawing.Size(304, 31);
            this.cbxMonthi.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(464, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đúng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "MSSV:";
            // 
            // txtHoten
            // 
            this.txtHoten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoten.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoten.Location = new System.Drawing.Point(130, 137);
            this.txtHoten.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(264, 30);
            this.txtHoten.TabIndex = 4;
            // 
            // txtSocaudung
            // 
            this.txtSocaudung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSocaudung.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSocaudung.Location = new System.Drawing.Point(530, 137);
            this.txtSocaudung.Margin = new System.Windows.Forms.Padding(4);
            this.txtSocaudung.Name = "txtSocaudung";
            this.txtSocaudung.Size = new System.Drawing.Size(103, 30);
            this.txtSocaudung.TabIndex = 3;
            // 
            // txtMathisinh
            // 
            this.txtMathisinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMathisinh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMathisinh.Location = new System.Drawing.Point(130, 64);
            this.txtMathisinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtMathisinh.Name = "txtMathisinh";
            this.txtMathisinh.Size = new System.Drawing.Size(264, 30);
            this.txtMathisinh.TabIndex = 2;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(39)))), ((int)(((byte)(255)))));
            this.btnTimkiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.ForeColor = System.Drawing.Color.White;
            this.btnTimkiem.Location = new System.Drawing.Point(907, 50);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(120, 37);
            this.btnTimkiem.TabIndex = 0;
            this.btnTimkiem.Text = "Tìm Kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = false;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // Xemketquathichung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuanLyThiTracNghiem.Properties.Resources._34239037_3_yutyty_1231;
            this.ClientSize = new System.Drawing.Size(1108, 598);
            this.Controls.Add(this.grbTimkiem);
            this.Controls.Add(this.drvKetqua);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Xemketquathichung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem kết quả thi chung";
            this.Load += new System.EventHandler(this.Xemketquathichung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drvKetqua)).EndInit();
            this.grbTimkiem.ResumeLayout(false);
            this.grbTimkiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView drvKetqua;
        private System.Windows.Forms.GroupBox grbTimkiem;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.ComboBox cbxMonthi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtSocaudung;
        private System.Windows.Forms.TextBox txtMathisinh;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.ComboBox cbxDiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnExit;
    }
}