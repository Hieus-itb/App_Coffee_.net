using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using App_Coffee.Controller;

namespace App_Coffee.view
{
    public partial class Dangnhap : Form
    {
        private AccountController accController; // Biến điều khiển
        private bool isAuthenticated = false;   // Trạng thái xác thực
        private bool isAdmin = false;
        public Dangnhap()
        {
            InitializeComponent();
            accController = new AccountController();
        }
        
        

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTaikhoan.Text.Trim();
            string password = txtMatkhau.Text.Trim();

            if (accController.CheckUserCredentials(username, password))
            {
                isAuthenticated = true;
                isAdmin = accController.IsAdmin(username);

                //Datban frm = new Datban(isAdmin); // Mở form đặt bàn
                //frm.Show();
                this.Close(); // Đóng form đăng nhập
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Kiểm tra lại tài khoản hoặc mật khẩu.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
