namespace App_Coffee.view
{
    partial class Dangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dangnhap));
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            btnDangky = new LinkLabel();
            btnDangnhap = new Button();
            txtMatkhau = new TextBox();
            txtTaikhoan = new TextBox();
            label1 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(628, 583);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnDangky);
            panel2.Controls.Add(btnDangnhap);
            panel2.Controls.Add(txtMatkhau);
            panel2.Controls.Add(txtTaikhoan);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(646, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(499, 583);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 408);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 5;
            label2.Text = "Chưa có tài khoản ?";
            // 
            // btnDangky
            // 
            btnDangky.AutoSize = true;
            btnDangky.Location = new Point(214, 408);
            btnDangky.Name = "btnDangky";
            btnDangky.Size = new Size(63, 20);
            btnDangky.TabIndex = 4;
            btnDangky.TabStop = true;
            btnDangky.Text = "Đăng ký";
            btnDangky.LinkClicked += btnDangky_LinkClicked;
            // 
            // btnDangnhap
            // 
            btnDangnhap.BackColor = Color.FromArgb(204, 102, 0);
            btnDangnhap.Location = new Point(80, 312);
            btnDangnhap.Name = "btnDangnhap";
            btnDangnhap.Size = new Size(331, 46);
            btnDangnhap.TabIndex = 3;
            btnDangnhap.Text = "Đăng nhập";
            btnDangnhap.UseVisualStyleBackColor = false;
            btnDangnhap.Click += btnDangnhap_Click;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Location = new Point(80, 247);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(331, 27);
            txtMatkhau.TabIndex = 2;
            txtMatkhau.UseSystemPasswordChar = true;
            // 
            // txtTaikhoan
            // 
            txtTaikhoan.Location = new Point(80, 180);
            txtTaikhoan.Name = "txtTaikhoan";
            txtTaikhoan.Size = new Size(331, 27);
            txtTaikhoan.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(164, 49);
            label1.Name = "label1";
            label1.Size = new Size(175, 41);
            label1.TabIndex = 0;
            label1.Text = "Đăng nhập";
            // 
            // Dangnhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 607);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Dangnhap";
            Text = "Form1";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private LinkLabel btnDangky;
        private Button btnDangnhap;
        private TextBox txtMatkhau;
        private TextBox txtTaikhoan;
        private Label label1;
    }
}