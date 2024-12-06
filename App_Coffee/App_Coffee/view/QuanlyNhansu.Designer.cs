namespace App_Coffee.view
{
    partial class QuanlyNhansu
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
            panel1 = new Panel();
            btnDouong = new Button();
            btnDangxuat = new Button();
            btnNhanvien = new Button();
            btnDoanhthu = new Button();
            btnDatmon = new Button();
            btnDatban = new Button();
            txtUser = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtID = new TextBox();
            txtHoten = new TextBox();
            txtGioitinh = new TextBox();
            txtNamsinh = new TextBox();
            txtChucvu = new TextBox();
            txtQuequan = new TextBox();
            txtSdt = new TextBox();
            txtTaikhoan = new TextBox();
            txtMatkhau = new TextBox();
            dataGridView1 = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnKLuu = new Button();
            txtTimkiem = new TextBox();
            btnTimkiem = new Button();
            label11 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 48, 34);
            panel1.Controls.Add(btnDouong);
            panel1.Controls.Add(btnDangxuat);
            panel1.Controls.Add(btnNhanvien);
            panel1.Controls.Add(btnDoanhthu);
            panel1.Controls.Add(btnDatmon);
            panel1.Controls.Add(btnDatban);
            panel1.Controls.Add(txtUser);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 639);
            panel1.TabIndex = 1;
            // 
            // btnDouong
            // 
            btnDouong.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDouong.Location = new Point(0, 445);
            btnDouong.Name = "btnDouong";
            btnDouong.Size = new Size(259, 61);
            btnDouong.TabIndex = 7;
            btnDouong.Text = "Đồ uống";
            btnDouong.UseVisualStyleBackColor = true;
            btnDouong.Click += btnDouong_Click;
            // 
            // btnDangxuat
            // 
            btnDangxuat.Location = new Point(76, 607);
            btnDangxuat.Name = "btnDangxuat";
            btnDangxuat.Size = new Size(94, 29);
            btnDangxuat.TabIndex = 5;
            btnDangxuat.Text = "Đăng xuất";
            btnDangxuat.UseVisualStyleBackColor = true;
            btnDangxuat.Click += btnDangxuat_Click;
            // 
            // btnNhanvien
            // 
            btnNhanvien.BackColor = Color.FromArgb(146, 73, 0);
            btnNhanvien.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhanvien.ForeColor = Color.White;
            btnNhanvien.Location = new Point(0, 388);
            btnNhanvien.Name = "btnNhanvien";
            btnNhanvien.Size = new Size(259, 61);
            btnNhanvien.TabIndex = 4;
            btnNhanvien.Text = "Nhân viên";
            btnNhanvien.UseVisualStyleBackColor = false;
            btnNhanvien.Click += btnNhanvien_Click;
            // 
            // btnDoanhthu
            // 
            btnDoanhthu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoanhthu.Location = new Point(0, 331);
            btnDoanhthu.Name = "btnDoanhthu";
            btnDoanhthu.Size = new Size(259, 61);
            btnDoanhthu.TabIndex = 3;
            btnDoanhthu.Text = "Doanh thu";
            btnDoanhthu.UseVisualStyleBackColor = true;
            btnDoanhthu.Click += btnDoanhthu_Click;
            // 
            // btnDatmon
            // 
            btnDatmon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatmon.Location = new Point(0, 277);
            btnDatmon.Name = "btnDatmon";
            btnDatmon.Size = new Size(259, 58);
            btnDatmon.TabIndex = 2;
            btnDatmon.Text = "Đặt món";
            btnDatmon.UseVisualStyleBackColor = true;
            btnDatmon.Click += btnDatmon_Click;
            // 
            // btnDatban
            // 
            btnDatban.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatban.Location = new Point(0, 218);
            btnDatban.Name = "btnDatban";
            btnDatban.Size = new Size(259, 63);
            btnDatban.TabIndex = 1;
            btnDatban.Text = "Đặt bàn";
            btnDatban.UseVisualStyleBackColor = true;
            btnDatban.Click += btnDatban_Click;
            // 
            // txtUser
            // 
            txtUser.AutoSize = true;
            txtUser.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtUser.ForeColor = Color.White;
            txtUser.Location = new Point(76, 34);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(103, 41);
            txtUser.TabIndex = 0;
            txtUser.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(493, 22);
            label1.Name = "label1";
            label1.Size = new Size(297, 41);
            label1.TabIndex = 2;
            label1.Text = "QUẢN LÝ NHÂN SỰ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(354, 111);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 3;
            label2.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(493, 111);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 4;
            label3.Text = "Họ Tên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(823, 111);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 5;
            label4.Text = "Giới tính:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(354, 156);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 6;
            label5.Text = "Năm sinh:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(715, 159);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 7;
            label6.Text = "Chức vụ:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(354, 205);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 8;
            label7.Text = "Quê quán:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(354, 257);
            label8.Name = "label8";
            label8.Size = new Size(100, 20);
            label8.TabIndex = 9;
            label8.Text = "Số điện thoại:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(356, 307);
            label9.Name = "label9";
            label9.Size = new Size(74, 20);
            label9.TabIndex = 10;
            label9.Text = "Tài khoản:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(696, 307);
            label10.Name = "label10";
            label10.Size = new Size(73, 20);
            label10.TabIndex = 11;
            label10.Text = "Mật khẩu:";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(387, 108);
            txtID.Name = "txtID";
            txtID.Size = new Size(54, 27);
            txtID.TabIndex = 12;
            // 
            // txtHoten
            // 
            txtHoten.Location = new Point(558, 108);
            txtHoten.Name = "txtHoten";
            txtHoten.Size = new Size(221, 27);
            txtHoten.TabIndex = 13;
            // 
            // txtGioitinh
            // 
            txtGioitinh.Location = new Point(897, 108);
            txtGioitinh.Name = "txtGioitinh";
            txtGioitinh.Size = new Size(109, 27);
            txtGioitinh.TabIndex = 14;
            // 
            // txtNamsinh
            // 
            txtNamsinh.Location = new Point(436, 156);
            txtNamsinh.Name = "txtNamsinh";
            txtNamsinh.Size = new Size(242, 27);
            txtNamsinh.TabIndex = 15;
            // 
            // txtChucvu
            // 
            txtChucvu.Location = new Point(785, 156);
            txtChucvu.Name = "txtChucvu";
            txtChucvu.Size = new Size(221, 27);
            txtChucvu.TabIndex = 16;
            // 
            // txtQuequan
            // 
            txtQuequan.Location = new Point(436, 205);
            txtQuequan.Name = "txtQuequan";
            txtQuequan.Size = new Size(570, 27);
            txtQuequan.TabIndex = 17;
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(460, 250);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(546, 27);
            txtSdt.TabIndex = 18;
            // 
            // txtTaikhoan
            // 
            txtTaikhoan.Enabled = false;
            txtTaikhoan.Location = new Point(436, 304);
            txtTaikhoan.Name = "txtTaikhoan";
            txtTaikhoan.Size = new Size(242, 27);
            txtTaikhoan.TabIndex = 19;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Enabled = false;
            txtMatkhau.Location = new Point(775, 304);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(231, 27);
            txtMatkhau.TabIndex = 20;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(354, 439);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(654, 200);
            dataGridView1.TabIndex = 21;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(384, 351);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(113, 32);
            btnThem.TabIndex = 22;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(503, 351);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(113, 32);
            btnSua.TabIndex = 23;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(622, 348);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(113, 32);
            btnXoa.TabIndex = 24;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(743, 348);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(113, 32);
            btnLuu.TabIndex = 25;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnKLuu
            // 
            btnKLuu.Location = new Point(862, 348);
            btnKLuu.Name = "btnKLuu";
            btnKLuu.Size = new Size(113, 32);
            btnKLuu.TabIndex = 26;
            btnKLuu.Text = "Không Lưu";
            btnKLuu.UseVisualStyleBackColor = true;
            btnKLuu.Click += btnKLuu_Click;
            // 
            // txtTimkiem
            // 
            txtTimkiem.Location = new Point(436, 391);
            txtTimkiem.Name = "txtTimkiem";
            txtTimkiem.Size = new Size(420, 27);
            txtTimkiem.TabIndex = 27;
            // 
            // btnTimkiem
            // 
            btnTimkiem.Location = new Point(862, 391);
            btnTimkiem.Name = "btnTimkiem";
            btnTimkiem.Size = new Size(113, 27);
            btnTimkiem.TabIndex = 28;
            btnTimkiem.Text = "Tìm kiếm";
            btnTimkiem.UseVisualStyleBackColor = true;
            btnTimkiem.Click += btnTimkiem_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(356, 394);
            label11.Name = "label11";
            label11.Size = new Size(67, 20);
            label11.TabIndex = 29;
            label11.Text = "Nhập ID:";
            // 
            // QuanlyNhansu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 652);
            Controls.Add(label11);
            Controls.Add(btnTimkiem);
            Controls.Add(txtTimkiem);
            Controls.Add(btnKLuu);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dataGridView1);
            Controls.Add(txtMatkhau);
            Controls.Add(txtTaikhoan);
            Controls.Add(txtSdt);
            Controls.Add(txtQuequan);
            Controls.Add(txtChucvu);
            Controls.Add(txtNamsinh);
            Controls.Add(txtGioitinh);
            Controls.Add(txtHoten);
            Controls.Add(txtID);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "QuanlyNhansu";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnDangxuat;
        private Button btnNhanvien;
        private Button btnDoanhthu;
        private Button btnDatmon;
        private Button btnDatban;
        private Label txtUser;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtID;
        private TextBox txtHoten;
        private TextBox txtGioitinh;
        private TextBox txtNamsinh;
        private TextBox txtChucvu;
        private TextBox txtQuequan;
        private TextBox txtSdt;
        private TextBox txtTaikhoan;
        private TextBox txtMatkhau;
        private DataGridView dataGridView1;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnKLuu;
        private Button btnDouong;
        private TextBox txtTimkiem;
        private Button btnTimkiem;
        private Label label11;
    }
}