using App_Coffee.controller;
using App_Coffee.Controller;
using Model;
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
        private Accountcontroller accountController;
        private nhansucontroller Nhansucontroller;
        public Dangky()
        {
            InitializeComponent();
            accountController = new Accountcontroller();
            Nhansucontroller = new nhansucontroller();
            lbCaptcha.Text = GenerateCaptcha();
        }
        private string GenerateCaptcha()
        {
            Random random = new Random();
            int captchaNumber = random.Next(1000, 10000);
            return captchaNumber.ToString();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaikhoan.Text.Trim();
            string matkhau = txtMatkhau.Text.Trim();
            string nhaplai = txtNhaplai.Text.Trim();
            string hoten = txtHoten.Text.Trim();
            string quequan = txtQuequan.Text.Trim();
            string gioitinh = txtGioitinh.Text.Trim();
            string sdt = txtSdt.Text.Trim();
            string captcha = txtCaptcha.Text.Trim();
            string role = cbRole.Text.Trim();
            int namsinh;

            // Kiểm tra các trường đầu vào
            if (string.IsNullOrEmpty(taikhoan))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (taikhoan.Length <= 6)
            {
                MessageBox.Show("Tài khoản phải có độ dài lớn hơn 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matkhau.Length <= 6)
            {
                MessageBox.Show("Mật khẩu phải có độ dài lớn hơn 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(nhaplai))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nhaplai != matkhau)
            {
                MessageBox.Show("Mật khẩu và nhập lại mật khẩu không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNamsinh.Text))
            {
                MessageBox.Show("Vui lòng nhập năm sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNamsinh.Text.Trim(), out namsinh))
            {
                MessageBox.Show("Năm sinh phải là một số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (namsinh < 1900 || namsinh > DateTime.Now.Year)
            {
                MessageBox.Show("Năm sinh không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(captcha))
            {
                MessageBox.Show("Vui lòng nhập captcha!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (captcha != lbCaptcha.Text)
            {
                MessageBox.Show("Nhập captcha không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị thông báo nếu kiểm tra thành công
            MessageBox.Show("Thông tin nhập hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Tạo đối tượng nhân viên mới
            Nhansumodel model = new Nhansumodel(0, hoten, gioitinh, namsinh, role, quequan, sdt);

            // Thêm nhân viên vào cơ sở dữ liệu
            bool addEmployee = Nhansucontroller.AddEmployee(model, taikhoan, matkhau, role );
            if (addEmployee)
            {
                MessageBox.Show("Đăng ký thành công!");
                this.Close();
                Dangnhap frm = new Dangnhap();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
                return;
            }
           
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
