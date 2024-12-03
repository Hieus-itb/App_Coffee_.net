namespace App_Coffee.view
{
    partial class Dangki
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
            label1 = new Label();
            label2 = new Label();
            txtTaikhoan = new TextBox();
            label3 = new Label();
            txtMatkhau = new TextBox();
            label4 = new Label();
            txtNhaplai = new TextBox();
            btnDangki = new Button();
            label5 = new Label();
            txtCapcha = new TextBox();
            btnHuy = new Button();
            Captcha = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(339, 9);
            label1.Name = "label1";
            label1.Size = new Size(143, 43);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÍ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 121);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 1;
            label2.Text = "Tài khoản: ";
            // 
            // txtTaikhoan
            // 
            txtTaikhoan.Location = new Point(245, 118);
            txtTaikhoan.Name = "txtTaikhoan";
            txtTaikhoan.Size = new Size(291, 27);
            txtTaikhoan.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 198);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 3;
            label3.Text = "Mật khẩu:";
            // 
            // txtMatkhau
            // 
            txtMatkhau.Location = new Point(245, 198);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(291, 27);
            txtMatkhau.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(80, 274);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 5;
            label4.Text = "Nhập lại mật khẩu:";
            // 
            // txtNhaplai
            // 
            txtNhaplai.Location = new Point(245, 267);
            txtNhaplai.Name = "txtNhaplai";
            txtNhaplai.Size = new Size(291, 27);
            txtNhaplai.TabIndex = 6;
            // 
            // btnDangki
            // 
            btnDangki.Location = new Point(245, 411);
            btnDangki.Name = "btnDangki";
            btnDangki.Size = new Size(94, 29);
            btnDangki.TabIndex = 7;
            btnDangki.Text = "Đăng kí";
            btnDangki.UseVisualStyleBackColor = true;
            btnDangki.Click += btnDangki_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 331);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 8;
            label5.Text = "Nhập captcha:";
            // 
            // txtCapcha
            // 
            txtCapcha.Location = new Point(245, 331);
            txtCapcha.Name = "txtCapcha";
            txtCapcha.Size = new Size(291, 27);
            txtCapcha.TabIndex = 9;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(442, 411);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 11;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // Captcha
            // 
            Captcha.Location = new Point(625, 338);
            Captcha.Name = "Captcha";
            Captcha.Size = new Size(100, 20);
            Captcha.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(553, 338);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 13;
            label6.Text = "Captcha:";
            // 
            // Dangki
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 495);
            Controls.Add(label6);
            Controls.Add(Captcha);
            Controls.Add(btnHuy);
            Controls.Add(txtCapcha);
            Controls.Add(label5);
            Controls.Add(btnDangki);
            Controls.Add(txtNhaplai);
            Controls.Add(label4);
            Controls.Add(txtMatkhau);
            Controls.Add(label3);
            Controls.Add(txtTaikhoan);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Dangki";
            Text = "Đăng kí";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTaikhoan;
        private Label label3;
        private TextBox txtMatkhau;
        private Label label4;
        private TextBox txtNhaplai;
        private Button btnDangki;
        private Label label5;
        private TextBox txtCapcha;
        private Button btnHuy;
        private Label Captcha;
        private Label label6;
    }
}