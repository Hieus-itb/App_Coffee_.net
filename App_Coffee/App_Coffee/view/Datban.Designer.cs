namespace App_Coffee.view
{
    partial class Datban
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
            base.Dispose(disposing);///
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
            btnHuy = new Button();
            btnDat = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 639);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnDouong
            // 
            btnDouong.BackColor = Color.White;
            btnDouong.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDouong.ForeColor = Color.Black;
            btnDouong.Location = new Point(0, 446);
            btnDouong.Name = "btnDouong";
            btnDouong.Size = new Size(259, 61);
            btnDouong.TabIndex = 7;
            btnDouong.Text = "Đồ uống";
            btnDouong.UseVisualStyleBackColor = false;
            btnDouong.Click += btnDouong_Click_1;
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
            btnNhanvien.BackColor = Color.White;
            btnNhanvien.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhanvien.ForeColor = Color.Black;
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
            btnDoanhthu.BackColor = Color.White;
            btnDoanhthu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoanhthu.ForeColor = Color.Black;
            btnDoanhthu.Location = new Point(0, 331);
            btnDoanhthu.Name = "btnDoanhthu";
            btnDoanhthu.Size = new Size(259, 61);
            btnDoanhthu.TabIndex = 3;
            btnDoanhthu.Text = "Doanh thu";
            btnDoanhthu.UseVisualStyleBackColor = false;
            btnDoanhthu.Click += btnDoanhthu_Click;
            // 
            // btnDatmon
            // 
            btnDatmon.BackColor = Color.White;
            btnDatmon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatmon.ForeColor = Color.Black;
            btnDatmon.Location = new Point(0, 277);
            btnDatmon.Name = "btnDatmon";
            btnDatmon.Size = new Size(259, 58);
            btnDatmon.TabIndex = 2;
            btnDatmon.Text = "Đặt món";
            btnDatmon.UseVisualStyleBackColor = false;
            btnDatmon.Click += btnDatmon_Click;
            // 
            // btnDatban
            // 
            btnDatban.BackColor = Color.FromArgb(146, 73, 0);
            btnDatban.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatban.ForeColor = Color.White;
            btnDatban.Location = new Point(0, 218);
            btnDatban.Name = "btnDatban";
            btnDatban.Size = new Size(259, 63);
            btnDatban.TabIndex = 1;
            btnDatban.Text = "Đặt bàn";
            btnDatban.UseVisualStyleBackColor = false;
            btnDatban.Click += btnDatban_Click;
            // 
            // txtUser
            // 
            txtUser.AutoSize = true;
            txtUser.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtUser.ForeColor = Color.White;
            txtUser.Location = new Point(0, 27);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(103, 41);
            txtUser.TabIndex = 0;
            txtUser.Text = "Name";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnHuy);
            panel2.Controls.Add(btnDat);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(277, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(923, 639);
            panel2.TabIndex = 1;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(778, 182);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(114, 47);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy bàn";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnDat
            // 
            btnDat.Location = new Point(778, 103);
            btnDat.Name = "btnDat";
            btnDat.Size = new Size(114, 47);
            btnDat.TabIndex = 2;
            btnDat.Text = "Đặt bàn";
            btnDat.UseVisualStyleBackColor = true;
            btnDat.Click += btnDat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(146, 73, 0);
            label1.Location = new Point(374, 12);
            label1.Name = "label1";
            label1.Size = new Size(164, 41);
            label1.TabIndex = 1;
            label1.Text = "Coffee_LD";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(57, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(679, 514);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Datban
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 663);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Datban";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnDatban;
        private Label txtUser;
        private Button btnNhanvien;
        private Button btnDoanhthu;
        private Button btnDatmon;
        private Button btnDangxuat;
        private Panel panel2;
        private Button btnHuy;
        private Button btnDat;
        private Label label1;
        private DataGridView dataGridView1;
        private Button btnDouong;
    }
}