namespace App_Coffee.view
{
    partial class Doanhthu
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
            txtSodon = new Label();
            label1 = new Label();
            panel3 = new Panel();
            txtChiphi = new Label();
            label2 = new Label();
            panel4 = new Panel();
            txtLai = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 639);
            panel1.TabIndex = 1;
            // 
            // btnDouong
            // 
            btnDouong.Location = new Point(0, 444);
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
            // panel2
            // 
            panel2.Controls.Add(txtSodon);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(306, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(243, 109);
            panel2.TabIndex = 2;
            // 
            // txtSodon
            // 
            txtSodon.AutoSize = true;
            txtSodon.Location = new Point(110, 70);
            txtSodon.Name = "txtSodon";
            txtSodon.Size = new Size(17, 20);
            txtSodon.TabIndex = 1;
            txtSodon.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 13);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 0;
            label1.Text = "Số đơn";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtChiphi);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(574, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(243, 109);
            panel3.TabIndex = 3;
            // 
            // txtChiphi
            // 
            txtChiphi.AutoSize = true;
            txtChiphi.Location = new Point(99, 70);
            txtChiphi.Name = "txtChiphi";
            txtChiphi.Size = new Size(17, 20);
            txtChiphi.TabIndex = 2;
            txtChiphi.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 18);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 0;
            label2.Text = "Chi phí";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtLai);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(842, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(243, 109);
            panel4.TabIndex = 3;
            // 
            // txtLai
            // 
            txtLai.AutoSize = true;
            txtLai.Location = new Point(103, 70);
            txtLai.Name = "txtLai";
            txtLai.Size = new Size(17, 20);
            txtLai.TabIndex = 3;
            txtLai.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 15);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 0;
            label3.Text = "Lãi thu";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(306, 165);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(779, 481);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Doanhthu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 658);
            Controls.Add(dataGridView1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Doanhthu";
            Text = "Doanhthu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
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
        private Label label1;
        private Panel panel3;
        private Label label2;
        private Panel panel4;
        private DataGridView dataGridView1;
        private Label txtSodon;
        private Label txtChiphi;
        private Label txtLai;
        private Label label3;
        private Button btnDouong;
    }
}