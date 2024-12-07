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
            currentUserRole = Dangnhap.userRole; 

            LoadDataToTable();
            CheckAdminRole();
            DisplayLoggedInUser();
        }
        private void DisplayLoggedInUser()
        {
            string username = AccountModel.LoggedInUsername; 
            if (!string.IsNullOrEmpty(username))
            {
                txtUser.Text = username;  
            }
            else
            {
                txtUser.Text = "Chưa đăng nhập"; 
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

        private void btnXuatfile_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ dữ liệu trong DataGridView
            DataTable dataTable = new DataTable();

            // Thêm các cột từ DataGridView vào DataTable
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataTable.Columns.Add(column.Name);
            }

            // Thêm các dòng dữ liệu vào DataTable
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            // Mở SaveFileDialog để chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Gọi phương thức xuất file Excel
                    ExcelExporter.ExportDataTableToExcel(dataTable, filePath);
                    MessageBox.Show("File Excel đã được xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file: {ex.Message}");
                }
            }
        }
    }
}
