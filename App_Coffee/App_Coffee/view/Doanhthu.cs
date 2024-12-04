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

        // Tải dữ liệu vào DataGridView
        private void LoadDataToTable()
        {
            try
            {
                // Lấy danh sách hóa đơn từ Controller
                List<HoaDon> hoaDonList = doanhThuController.GetAllHoadon();

                // Kiểm tra xem danh sách có dữ liệu hay không
                if (hoaDonList.Count > 0)
                {
                    dataGridView1.DataSource = hoaDonList;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }

                dataGridView1.DataSource = hoaDonList;

                // Lấy tổng chi phí và tổng tiền từ database thông qua Controller
                float totalChiphi = doanhThuController.GetTotalChiPhi(); // Cập nhật phương thức GetTotalChiPhi() trong Controller
                float totalTien = doanhThuController.GetTotalTien(); // Cập nhật phương thức GetTotalTien() trong Controller

                // Hiển thị các thông tin lên UI
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
