namespace App_Coffee.view
{
    partial class Goimon
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
            panel2 = new Panel();
            label1 = new Label();
            lbBan6 = new Label();
            lbBan5 = new Label();
            lbBan4 = new Label();
            lbBan3 = new Label();
            lbBan2 = new Label();
            lbBan1 = new Label();
            btnBan6 = new Button();
            btnBan5 = new Button();
            btnBan4 = new Button();
            btnBan3 = new Button();
            btnBan2 = new Button();
            btnBan1 = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            btnThem = new Button();
            btnXoa = new Button();
            label3 = new Label();
            dataGridView2 = new DataGridView();
            btnThanhtoan = new Button();
            lbThanhtien = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 639);
            panel1.TabIndex = 2;
            // 
            // btnDouong
            // 
            btnDouong.Location = new Point(0, 443);
            btnDouong.Name = "btnDouong";
            btnDouong.Size = new Size(259, 61);
            btnDouong.TabIndex = 11;
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
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lbBan6);
            panel2.Controls.Add(lbBan5);
            panel2.Controls.Add(lbBan4);
            panel2.Controls.Add(lbBan3);
            panel2.Controls.Add(lbBan2);
            panel2.Controls.Add(lbBan1);
            panel2.Controls.Add(btnBan6);
            panel2.Controls.Add(btnBan5);
            panel2.Controls.Add(btnBan4);
            panel2.Controls.Add(btnBan3);
            panel2.Controls.Add(btnBan2);
            panel2.Controls.Add(btnBan1);
            panel2.Location = new Point(928, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(296, 638);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 508);
            label1.Name = "label1";
            label1.Size = new Size(251, 60);
            label1.TabIndex = 12;
            label1.Text = "Lưu ý:\r\n+ Chữ xanh: Bàn hiện đang trống.\r\n+ Chữ đỏ   : Bàn hiện đang có người.\r\n";
            // 
            // lbBan6
            // 
            lbBan6.AutoSize = true;
            lbBan6.Location = new Point(203, 462);
            lbBan6.Name = "lbBan6";
            lbBan6.Size = new Size(42, 20);
            lbBan6.TabIndex = 11;
            lbBan6.Text = "Bài 6";
            // 
            // lbBan5
            // 
            lbBan5.AutoSize = true;
            lbBan5.Location = new Point(57, 462);
            lbBan5.Name = "lbBan5";
            lbBan5.Size = new Size(42, 20);
            lbBan5.TabIndex = 10;
            lbBan5.Text = "Bài 5";
            // 
            // lbBan4
            // 
            lbBan4.AutoSize = true;
            lbBan4.Location = new Point(203, 304);
            lbBan4.Name = "lbBan4";
            lbBan4.Size = new Size(42, 20);
            lbBan4.TabIndex = 9;
            lbBan4.Text = "Bài 4";
            // 
            // lbBan3
            // 
            lbBan3.AutoSize = true;
            lbBan3.Location = new Point(53, 304);
            lbBan3.Name = "lbBan3";
            lbBan3.Size = new Size(42, 20);
            lbBan3.TabIndex = 8;
            lbBan3.Text = "Bài 3";
            // 
            // lbBan2
            // 
            lbBan2.AutoSize = true;
            lbBan2.Location = new Point(199, 146);
            lbBan2.Name = "lbBan2";
            lbBan2.Size = new Size(46, 20);
            lbBan2.TabIndex = 7;
            lbBan2.Text = "Bàn 2";
            // 
            // lbBan1
            // 
            lbBan1.AutoSize = true;
            lbBan1.Location = new Point(53, 146);
            lbBan1.Name = "lbBan1";
            lbBan1.Size = new Size(46, 20);
            lbBan1.TabIndex = 6;
            lbBan1.Text = "Bàn 1";
            // 
            // btnBan6
            // 
            btnBan6.Image = Properties.Resources.table;
            btnBan6.Location = new Point(171, 354);
            btnBan6.Name = "btnBan6";
            btnBan6.Size = new Size(106, 105);
            btnBan6.TabIndex = 5;
            btnBan6.UseVisualStyleBackColor = true;
            btnBan6.Click += btnBan6_Click;
            // 
            // btnBan5
            // 
            btnBan5.Image = Properties.Resources.table;
            btnBan5.Location = new Point(22, 354);
            btnBan5.Name = "btnBan5";
            btnBan5.Size = new Size(106, 105);
            btnBan5.TabIndex = 4;
            btnBan5.UseVisualStyleBackColor = true;
            btnBan5.Click += btnBan5_Click;
            // 
            // btnBan4
            // 
            btnBan4.Image = Properties.Resources.table;
            btnBan4.Location = new Point(171, 196);
            btnBan4.Name = "btnBan4";
            btnBan4.Size = new Size(106, 105);
            btnBan4.TabIndex = 3;
            btnBan4.UseVisualStyleBackColor = true;
            btnBan4.Click += btnBan4_Click;
            // 
            // btnBan3
            // 
            btnBan3.Image = Properties.Resources.table;
            btnBan3.Location = new Point(22, 196);
            btnBan3.Name = "btnBan3";
            btnBan3.Size = new Size(106, 105);
            btnBan3.TabIndex = 2;
            btnBan3.UseVisualStyleBackColor = true;
            btnBan3.Click += btnBan3_Click;
            // 
            // btnBan2
            // 
            btnBan2.Image = Properties.Resources.table;
            btnBan2.Location = new Point(171, 38);
            btnBan2.Name = "btnBan2";
            btnBan2.Size = new Size(106, 105);
            btnBan2.TabIndex = 1;
            btnBan2.UseVisualStyleBackColor = true;
            btnBan2.Click += btnBan2_Click;
            // 
            // btnBan1
            // 
            btnBan1.Image = Properties.Resources.table;
            btnBan1.Location = new Point(22, 38);
            btnBan1.Name = "btnBan1";
            btnBan1.Size = new Size(106, 105);
            btnBan1.TabIndex = 0;
            btnBan1.UseVisualStyleBackColor = true;
            btnBan1.Click += btnBan1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(449, 9);
            label2.Name = "label2";
            label2.Size = new Size(324, 38);
            label2.TabIndex = 4;
            label2.Text = "DANH SÁCH ĐỒ UỐNG";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(282, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(491, 188);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(812, 105);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(812, 198);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(389, 278);
            label3.Name = "label3";
            label3.Size = new Size(460, 41);
            label3.TabIndex = 8;
            label3.Text = "DANH SÁCH ĐỒ UỐNG ĐÃ GỌI";
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(282, 332);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(624, 188);
            dataGridView2.TabIndex = 9;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // btnThanhtoan
            // 
            btnThanhtoan.Location = new Point(812, 584);
            btnThanhtoan.Name = "btnThanhtoan";
            btnThanhtoan.Size = new Size(94, 29);
            btnThanhtoan.TabIndex = 10;
            btnThanhtoan.Text = "Thanh Toán";
            btnThanhtoan.UseVisualStyleBackColor = true;
            btnThanhtoan.Click += btnThanhtoan_Click;
            // 
            // lbThanhtien
            // 
            lbThanhtien.AutoSize = true;
            lbThanhtien.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbThanhtien.ImageAlign = ContentAlignment.TopCenter;
            lbThanhtien.Location = new Point(296, 561);
            lbThanhtien.Name = "lbThanhtien";
            lbThanhtien.Size = new Size(0, 31);
            lbThanhtien.TabIndex = 11;
            // 
            // Goimon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 645);
            Controls.Add(lbThanhtien);
            Controls.Add(btnThanhtoan);
            Controls.Add(dataGridView2);
            Controls.Add(label3);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Goimon";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private Panel panel2;
        private Label lbBan6;
        private Label lbBan5;
        private Label lbBan4;
        private Label lbBan3;
        private Label lbBan2;
        private Label lbBan1;
        private Button btnBan6;
        private Button btnBan5;
        private Button btnBan4;
        private Button btnBan3;
        private Button btnBan2;
        private Button btnBan1;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button btnThem;
        private Button btnXoa;
        private Label label3;
        private DataGridView dataGridView2;
        private Button btnThanhtoan;
        private Button btnDouong;
        private Label lbThanhtien;
    }
}