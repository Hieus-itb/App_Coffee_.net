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

//using App_Coffee.Controller;

namespace App_Coffee.view
{
    public partial class Dangnhap : Form
    {
        
        public Dangnhap()
        {
            InitializeComponent();
        }
        AccountController accountController = new AccountController();

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTaikhoan.Text;
            string password = txtMatkhau.Text;

            // Kiểm tra đăng nhập
            if (accountController.CheckLogin(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!");
                // Chuyển đến form chính hoặc chức năng khác
                Datban frm = new Datban();
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }
    }
}
