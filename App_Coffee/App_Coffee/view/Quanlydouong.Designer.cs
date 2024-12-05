namespace App_Coffee.view
{
    partial class Quanlydouong
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
            dataGridViewDouong = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtMadouong = new TextBox();
            txtTendouong = new TextBox();
            txtGia = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnKluu = new Button();
            label5 = new Label();
            txtChiphinhaplieu = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDouong).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDouong);
            panel1.Controls.Add(btnDangxuat);
            panel1.Controls.Add(btnNhanvien);
            panel1.Controls.Add(btnDoanhthu);
            panel1.Controls.Add(btnDatmon);
            panel1.Controls.Add(btnDatban);
            panel1.Controls.Add(txtUser);
            panel1.Location = new Point(3, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 639);
            panel1.TabIndex = 2;
            // 
            // btnDouong
            // 
            btnDouong.Location = new Point(0, 446);
            btnDouong.Name = "btnDouong";
            btnDouong.Size = new Size(259, 61);
            btnDouong.TabIndex = 6;
            btnDouong.Text = "Đồ uống";
            btnDouong.UseVisualStyleBackColor = true;
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
            btnNhanvien.Location = new Point(0, 388);
            btnNhanvien.Name = "btnNhanvien";
            btnNhanvien.Size = new Size(259, 61);
            btnNhanvien.TabIndex = 4;
            btnNhanvien.Text = "Nhân viên";
            btnNhanvien.UseVisualStyleBackColor = true;
            btnNhanvien.Click += btnNhanvien_Click;
            // 
            // btnDoanhthu
            // 
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
            txtUser.Location = new Point(107, 36);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(49, 20);
            txtUser.TabIndex = 0;
            txtUser.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(503, 17);
            label1.Name = "label1";
            label1.Size = new Size(347, 41);
            label1.TabIndex = 3;
            label1.Text = "DANH SÁCH ĐỒ UỐNG";
            // 
            // dataGridViewDouong
            // 
            dataGridViewDouong.ColumnHeadersHeight = 29;
            dataGridViewDouong.Location = new Point(316, 329);
            dataGridViewDouong.Name = "dataGridViewDouong";
            dataGridViewDouong.RowHeadersWidth = 51;
            dataGridViewDouong.Size = new Size(668, 203);
            dataGridViewDouong.TabIndex = 4;
            dataGridViewDouong.CellClick += dataGridViewDouong_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 127);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 5;
            label2.Text = "Mã đồ uống:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 190);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 6;
            label3.Text = "Tên đồ uống:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(314, 237);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 7;
            label4.Text = "Giá bán: ";
            // 
            // txtMadouong
            // 
            txtMadouong.Location = new Point(415, 124);
            txtMadouong.Name = "txtMadouong";
            txtMadouong.Size = new Size(44, 27);
            txtMadouong.TabIndex = 8;
            // 
            // txtTendouong
            // 
            txtTendouong.Location = new Point(415, 187);
            txtTendouong.Name = "txtTendouong";
            txtTendouong.Size = new Size(328, 27);
            txtTendouong.TabIndex = 9;
            // 
            // txtGia
            // 
            txtGia.Location = new Point(415, 234);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(163, 27);
            txtGia.TabIndex = 10;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(314, 585);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm món";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(457, 585);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa món";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(603, 585);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa món";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(745, 585);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 14;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnKluu
            // 
            btnKluu.Location = new Point(890, 585);
            btnKluu.Name = "btnKluu";
            btnKluu.Size = new Size(94, 29);
            btnKluu.TabIndex = 15;
            btnKluu.Text = "Không lưu";
            btnKluu.UseVisualStyleBackColor = true;
            btnKluu.Click += btnKluu_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(316, 287);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 16;
            label5.Text = "Giá nhập liệu:";
            // 
            // txtChiphinhaplieu
            // 
            txtChiphinhaplieu.Location = new Point(415, 284);
            txtChiphinhaplieu.Name = "txtChiphinhaplieu";
            txtChiphinhaplieu.Size = new Size(163, 27);
            txtChiphinhaplieu.TabIndex = 17;
            // 
            // Quanlydouong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 649);
            Controls.Add(txtChiphinhaplieu);
            Controls.Add(label5);
            Controls.Add(btnKluu);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtGia);
            Controls.Add(txtTendouong);
            Controls.Add(txtMadouong);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewDouong);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Quanlydouong";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDouong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnDouong;
        private Button btnDangxuat;
        private Button btnNhanvien;
        private Button btnDoanhthu;
        private Button btnDatmon;
        private Button btnDatban;
        private Label txtUser;
        private Label label1;
        private DataGridView dataGridViewDouong;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtMadouong;
        private TextBox txtTendouong;
        private TextBox txtGia;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnKluu;
        private Label label5;
        private TextBox txtChiphinhaplieu;
    }
}