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
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(326, 35);
            label1.Name = "label1";
            label1.Size = new Size(156, 42);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÝ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(128, 131);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "Tài khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 185);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(128, 250);
            label4.Name = "label4";
            label4.Size = new Size(133, 20);
            label4.TabIndex = 3;
            label4.Text = "Nhập lại mật khẩu:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(128, 310);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 4;
            label5.Text = "Nhập Captcha:";
            // 
            // txtTaikhoan
            // 
            txtTaikhoan.Location = new Point(267, 131);
            txtTaikhoan.Name = "txtTaikhoan";
            txtTaikhoan.Size = new Size(350, 27);
            txtTaikhoan.TabIndex = 5;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Location = new Point(267, 185);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(350, 27);
            txtMatkhau.TabIndex = 6;
            // 
            // txtNhaplai
            // 
            txtNhaplai.Location = new Point(267, 247);
            txtNhaplai.Name = "txtNhaplai";
            txtNhaplai.Size = new Size(350, 27);
            txtNhaplai.TabIndex = 7;
            // 
            // txtCaptcha
            // 
            txtCaptcha.Location = new Point(267, 307);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.Size = new Size(350, 27);
            txtCaptcha.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(128, 365);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 9;
            label6.Text = "Captcha:";
            // 
            // lbCaptcha
            // 
            lbCaptcha.Location = new Point(267, 365);
            lbCaptcha.Name = "lbCaptcha";
            lbCaptcha.Size = new Size(75, 20);
            lbCaptcha.TabIndex = 10;
            // 
            // btnDangky
            // 
            btnDangky.Location = new Point(217, 440);
            btnDangky.Name = "btnDangky";
            btnDangky.Size = new Size(94, 29);
            btnDangky.TabIndex = 11;
            btnDangky.Text = "Đăng ký";
            btnDangky.UseVisualStyleBackColor = true;
            btnDangky.Click += btnDangky_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(437, 440);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // Dangky
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 495);
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
    }

}
