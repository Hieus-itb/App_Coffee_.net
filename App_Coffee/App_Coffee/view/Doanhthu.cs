using App_Coffee.controller;
using App_Coffee.Controller;
using App_Coffee.model;
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
        }

        private void CheckAdminRole()
        {
            btnNhanvien.Visible = btnDouong.Visible = currentUserRole == "Admin";
        }

        // Tải dữ liệu vào DataGridView
        private void LoadDataToTable()
        {
            try
            {
                // Lấy danh sách hóa đơn từ Controller
                List<HoaDon> hoaDonList = doanhThuController.GetAllHoadon();
                dataGridView1.DataSource = hoaDonList;

                // Tính tổng và hiển thị
                float totalChiphi = 0;
                float totalTien = 0;

                foreach (HoaDon hoaDon in hoaDonList)
                {
                    totalChiphi += hoaDon.TongChiPhi;
                    totalTien += hoaDon.TongTien;
                }

                txtChiphi.Text = totalChiphi.ToString("N2");
                txtLai.Text = doanhThuController.GetProfit().ToString("N2");
                txtSodon.Text = doanhThuController.GetInvoiceCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
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
            //Goimon goiMonForm = new Goimon();
            //goiMonForm.Show();
            //this.Dispose();
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {

        }
    }
}
