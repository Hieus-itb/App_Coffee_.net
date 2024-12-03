using App_Coffee.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Coffee.view
{
    public partial class Dangky : Form
    {
        private AccountController accountController;
        public Dangky()
        {
            InitializeComponent();
            accountController = new AccountController();
            lbCaptcha.Text = GenerateCaptcha();
        }
        private string GenerateCaptcha()
        {
            Random random = new Random();
            int captchaNumber = random.Next(1000, 10000);
            return captchaNumber.ToString();
        }
        private void btnDangki_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaikhoan.Text.Trim();
            string matkhau = txtMatkhau.Text.Trim();
            string nhaplai = txtNhaplai.Text.Trim();
            string captcha = txtCaptcha.Text.Trim();

            // Kiểm tra các trường đầu vào
            if (string.IsNullOrEmpty(taikhoan))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return;
            }

            if (taikhoan.Length <= 6)
            {
                MessageBox.Show("Tài khoản phải có độ dài lớn hơn 6 ký tự!");
                return;
            }

            if (string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }

            if (matkhau.Length <= 6)
            {
                MessageBox.Show("Mật khẩu phải có độ dài lớn hơn 6 ký tự!");
                return;
            }

            if (string.IsNullOrEmpty(nhaplai))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                return;
            }

            if (string.IsNullOrEmpty(captcha))
            {
                MessageBox.Show("Vui lòng nhập captcha!");
                return;
            }

            // Kiểm tra captcha
            if (captcha != lbCaptcha.Text)
            {
                MessageBox.Show("Nhập captcha không chính xác!");
                return;
            }

            // Kiểm tra khớp mật khẩu
            if (nhaplai != matkhau)
            {
                MessageBox.Show("Mật khẩu và nhập lại mật khẩu không trùng nhau!");
                return;
            }

            // Thêm tài khoản vào hệ thống
            bool add = accountController.addAccount(taikhoan, matkhau);
            if (add)
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }
        }
    }
}
