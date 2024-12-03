using App_Coffee.Controller;
using Microsoft.Data.SqlClient;
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
    public partial class Dangnhap : Form
    {
        private AccountController accController;
        public static bool isAuthenticated = false;
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

            // Kiểm tra tài khoản và mật khẩu
            if (accController.CheckUserCredentials(username, password))
            {
                isAuthenticated = true;
                isAdmin = accController.IsAdmin(username); // Kiểm tra nếu là admin

                // Hiển thị form chính hoặc form admin
                if (isAdmin)
                {
                    MessageBox.Show("Đăng nhập thành công với quyền Admin!");
                    // Chuyển đến form quản lý admin
                    Datban frm = new Datban(); // Ví dụ: Form quản lý admin
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    // Chuyển đến form người dùng
                    Datban frm = new Datban();
                    this.Hide();
                    frm.ShowDialog();
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }

        private void btnDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangki dangki = new Dangki();
            dangki.Show();
        }
    }
}
