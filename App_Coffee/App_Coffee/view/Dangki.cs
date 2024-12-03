using App_Coffee.Controller;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Coffee.view
{
    public partial class Dangki : Form
    {
        private AccountController accountController;
        public Dangki()
        {
            InitializeComponent();
            Captcha.Text = GenerateCaptcha();
            accountController = new AccountController();
        }

        static string GenerateCaptcha()
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
            string captcha = txtCapcha.Text.Trim();
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
            if (captcha != Captcha.Text)
            {
                MessageBox.Show("Nhập captcha không chính xác!");
                return;
            }
            if (nhaplai != matkhau)
            {
                MessageBox.Show("Mật khẩu và nhập lại mật khẩu không trùng nhau!");
                return;
            }
            bool add = accountController.AddAccount(taikhoan, matkhau);
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
