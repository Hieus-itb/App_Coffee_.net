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
using System.Data.SqlClient;


namespace App_Coffee.view
{
    public partial class Dangnhap : Form
    {
        private Accountcontroller accController;
        public static string userRole = "";

        public Dangnhap()
        {
            InitializeComponent();
            accController = new Accountcontroller();
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTaikhoan.Text.Trim();
            string password = txtMatkhau.Text.Trim();

            if (accController.CheckUserCredentials(username, password))
            {
                userRole = accController.IsAdmin(username) ? "Admin" : "User";

                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();

                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
                
            }
        }

        private void btnDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dangki = new Dangky();
            dangki.Show();
        }
    }
}
