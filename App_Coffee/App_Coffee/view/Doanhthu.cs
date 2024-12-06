using App_Coffee.controller;
using App_Coffee.Controller;
using App_Coffee.model;
using App_Coffee.model.App_Coffee.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static Azure.Core.HttpHeader;

namespace App_Coffee.view
{
    public partial class Doanhthu : Form
    {
        private Doanhthucontroller doanhThuController;
        private string currentUserRole;

        public Doanhthu()
        {
            InitializeComponent();

            doanhThuController = new Doanhthucontroller();
            currentUserRole = Dangnhap.userRole; // Nhận quyền từ form đăng nhập

            LoadDataToTable();
            CheckAdminRole();
            DisplayLoggedInUser();
        }
        private void DisplayLoggedInUser()
        {
            string username = AccountModel.LoggedInUsername;  // Lấy tên người dùng từ lớp AccountModel
            if (!string.IsNullOrEmpty(username))
            {
                txtUser.Text = username;  // Hiển thị tên người dùng lên TextBox
            }
            else
            {
                txtUser.Text = "Chưa đăng nhập";  // Nếu không có tên người dùng, hiển thị thông báo
            }
        }
        private void CheckAdminRole()
        {
            if (currentUserRole == "Admin")
            {
                btnNhanvien.Visible = true;
                btnDouong.Visible = true;
            }
            else
            {
                btnNhanvien.Visible = false;
                btnDouong.Visible = false;
            }
        }

        private void LoadDataToTable()
        {
            try
            {
                List<HoaDon> hoaDonList = doanhThuController.GetAllHoadon();

                if (hoaDonList.Count > 0)
                {
                    dataGridView1.DataSource = hoaDonList;
                }


                float totalChiphi = doanhThuController.GetTotalChiPhi();
                float totalTien = doanhThuController.GetTotalTien();
                float profit = doanhThuController.GetProfit();


                txtChiphi.Text = totalChiphi.ToString("N2");
                txtLai.Text = profit.ToString("N2");
                txtSodon.Text = doanhThuController.GetInvoiceCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi");
            }
        }


        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Dangnhap frm = new Dangnhap();
                frm.Show();
                this.Dispose();
            }
        }

        private void btnDatban_Click(object sender, EventArgs e)
        {
            Datban datBanForm = new Datban();
            datBanForm.Show();
            this.Dispose();
        }

        private void btnDatmon_Click(object sender, EventArgs e)
        {
            this.Hide();

            Goimon gm = new Goimon();
            gm.Show();
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            this.Hide();

            QuanlyNhansu ql = new QuanlyNhansu();
            ql.Show();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            this.Hide();

            QuanlyNhansu ql = new QuanlyNhansu();
            ql.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDouong_Click(object sender, EventArgs e)
        {
            this.Hide();

            Quanlydouong qldu = new Quanlydouong();
            qldu.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
