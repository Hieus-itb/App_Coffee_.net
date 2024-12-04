namespace App_Coffee.view
{
    partial class Dangky
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

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTaikhoan = new TextBox();
            txtMatkhau = new TextBox();
            txtNhaplai = new TextBox();
            txtCaptcha = new TextBox();
            label6 = new Label();
            lbCaptcha = new Label();
            btnDangky = new Button();
            btnHuy = new Button();
            label7 = new Label();
            cbRole = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtHoten = new TextBox();
            txtNamsinh = new TextBox();
            txtSdt = new TextBox();
            label12 = new Label();
            txtGioitinh = new ComboBox();
            txtQuequan = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(396, 18);
            label1.Name = "label1";
            label1.Size = new Size(156, 42);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÝ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 113);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "Tài khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 161);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 213);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 3;
            label4.Text = "Nhập lại mật khẩu:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(293, 423);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 4;
            label5.Text = "Nhập Captcha:";
            // 
            // txtTaikhoan
            // 
            txtTaikhoan.Location = new Point(208, 106);
            txtTaikhoan.Name = "txtTaikhoan";
            txtTaikhoan.Size = new Size(232, 27);
            txtTaikhoan.TabIndex = 5;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Location = new Point(208, 158);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.PasswordChar = '*';
            txtMatkhau.Size = new Size(232, 27);
            txtMatkhau.TabIndex = 6;
            // 
            // txtNhaplai
            // 
            txtNhaplai.Location = new Point(208, 213);
            txtNhaplai.Name = "txtNhaplai";
            txtNhaplai.PasswordChar = '*';
            txtNhaplai.Size = new Size(232, 27);
            txtNhaplai.TabIndex = 7;
            // 
            // txtCaptcha
            // 
            txtCaptcha.Location = new Point(417, 416);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.Size = new Size(149, 27);
            txtCaptcha.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(293, 366);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 9;
            label6.Text = "Captcha:";
            // 
            // lbCaptcha
            // 
            lbCaptcha.Location = new Point(417, 366);
            lbCaptcha.Name = "lbCaptcha";
            lbCaptcha.Size = new Size(75, 20);
            lbCaptcha.TabIndex = 10;
            // 
            // btnDangky
            // 
            btnDangky.Location = new Point(305, 472);
            btnDangky.Name = "btnDangky";
            btnDangky.Size = new Size(94, 29);
            btnDangky.TabIndex = 11;
            btnDangky.Text = "Đăng ký";
            btnDangky.UseVisualStyleBackColor = true;
            btnDangky.Click += btnDangky_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(533, 472);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(69, 271);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 13;
            label7.Text = "Chức vụ:";
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Pha Chế", "Bồi Bàn", "Lao Công", "Quản Lý", "Bảo Vệ" });
            cbRole.Location = new Point(208, 271);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(151, 28);
            cbRole.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(506, 106);
            label8.Name = "label8";
            label8.Size = new Size(76, 20);
            label8.TabIndex = 15;
            label8.Text = "Họ và tên:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(506, 158);
            label9.Name = "label9";
            label9.Size = new Size(68, 20);
            label9.TabIndex = 16;
            label9.Text = "Giới tính:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(506, 216);
            label10.Name = "label10";
            label10.Size = new Size(74, 20);
            label10.TabIndex = 17;
            label10.Text = "Năm sinh:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(506, 274);
            label11.Name = "label11";
            label11.Size = new Size(100, 20);
            label11.TabIndex = 18;
            label11.Text = "Số điện thoại:";
            // 
            // txtHoten
            // 
            txtHoten.Location = new Point(612, 103);
            txtHoten.Name = "txtHoten";
            txtHoten.Size = new Size(232, 27);
            txtHoten.TabIndex = 19;
            // 
            // txtNamsinh
            // 
            txtNamsinh.Location = new Point(612, 216);
            txtNamsinh.Name = "txtNamsinh";
            txtNamsinh.Size = new Size(232, 27);
            txtNamsinh.TabIndex = 21;
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(612, 274);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(232, 27);
            txtSdt.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(506, 330);
            label12.Name = "label12";
            label12.Size = new Size(76, 20);
            label12.TabIndex = 23;
            label12.Text = "Quê quán:";
            // 
            // txtGioitinh
            // 
            txtGioitinh.FormattingEnabled = true;
            txtGioitinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            txtGioitinh.Location = new Point(612, 161);
            txtGioitinh.Name = "txtGioitinh";
            txtGioitinh.Size = new Size(180, 28);
            txtGioitinh.TabIndex = 24;
            // 
            // txtQuequan
            // 
            txtQuequan.FormattingEnabled = true;
            txtQuequan.Items.AddRange(new object[] { "An Giang  ", "Bà Rịa - Vũng Tàu  ", "Bắc Giang  ", "Bắc Kạn  ", "Bạc Liêu  ", "Bắc Ninh  ", "Bến Tre  ", "Bình Định  ", "Bình Dương  ", "Bình Phước  ", "Bình Thuận  ", "Cà Mau  ", "Cao Bằng  ", "Cần Thơ  ", "Đà Nẵng  ", "Đắk Lắk  ", "Đắk Nông  ", "Điện Biên  ", "Đồng Nai  ", "Đồng Tháp  ", "Gia Lai  ", "Hà Giang  ", "Hà Nam  ", "Hà Nội  ", "Hòa Bình  ", "Hậu Giang  ", "Hải Dương  ", "Hải Phòng  ", "Hưng Yên  ", "Khánh Hòa  ", "Kiên Giang  ", "Kon Tum  ", "Lai Châu  ", "Lâm Đồng  ", "Long An  ", "Nam Định  ", "Nghệ An  ", "Ninh Bình  ", "Ninh Thuận  ", "Phú Thọ  ", "Phú Yên  ", "Quảng Bình  ", "Quảng Nam  ", "Quảng Ngãi  ", "Quảng Ninh  ", "Quảng Trị  ", "Sóc Trăng  ", "Sơn La  ", "Tây Ninh  ", "Thái Bình  ", "Thái Nguyên  ", "Thanh Hóa  ", "Thừa Thiên Huế  ", "Tiền Giang  ", "Trà Vinh  ", "Tuyên Quang  ", "Vĩnh Long  ", "Vĩnh Phúc  ", "Yên Bái  ", "TP.HCM  ", "Hà Tĩnh  ", "Lạng Sơn  ", "Hòa Bình" });
            txtQuequan.Location = new Point(612, 327);
            txtQuequan.Name = "txtQuequan";
            txtQuequan.Size = new Size(180, 28);
            txtQuequan.TabIndex = 25;
            // 
            // Dangky
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 528);
            Controls.Add(txtQuequan);
            Controls.Add(txtGioitinh);
            Controls.Add(label12);
            Controls.Add(txtSdt);
            Controls.Add(txtNamsinh);
            Controls.Add(txtHoten);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(cbRole);
            Controls.Add(label7);
            Controls.Add(btnHuy);
            Controls.Add(btnDangky);
            Controls.Add(lbCaptcha);
            Controls.Add(label6);
            Controls.Add(txtCaptcha);
            Controls.Add(txtNhaplai);
            Controls.Add(txtMatkhau);
            Controls.Add(txtTaikhoan);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Dangky";
            Text = "Đăng kí";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTaikhoan;
        private TextBox txtMatkhau;
        private TextBox txtNhaplai;
        private TextBox txtCaptcha;
        private Label label6;
        private Label lbCaptcha;
        private Button btnDangky;
        private Button btnHuy;
        private Label label7;
        private ComboBox cbRole;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtHoten;
        private TextBox txtNamsinh;
        private TextBox txtSdt;
        private Label label12;
        private ComboBox txtGioitinh;
        private ComboBox txtQuequan;
    }

}
