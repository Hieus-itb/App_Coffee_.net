using App_Coffee.controller;
using App_Coffee.model.App_Coffee.model;
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
    public partial class QuanlyNhansu : Form
    {
        private Bancontroller bancontroller;
        private nhansucontroller nhansucontroller;
        private string currentUserRole;

        public QuanlyNhansu()
        {
            InitializeComponent();
            nhansucontroller = new nhansucontroller();
            currentUserRole = Dangnhap.userRole; 

            EnableTextFields(false);
            LoadDataToTable();
            dataGridView1.ClearSelection();
            DisplayLoggedInUser();
            CheckAdminRole();
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
            DataTable nhanSuData = nhansucontroller.GetAllNhanSu();
            if (nhanSuData != null)
            {
                dataGridView1.DataSource = nhanSuData;
            }
            else
            {
                MessageBox.Show("Không thể tải dữ liệu nhân sự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteFields()
        {
            txtID.Text = "";
            txtHoten.Text = "";
            txtGioitinh.Text = "";
            txtQuequan.Text = "";
            txtNamsinh.Text = "";
            txtChucvu.Text = "";
            txtSdt.Text = "";
            txtTaikhoan.Text = "";
            txtMatkhau.Text = "";
        }

        private void EnableTextFields(bool enable)
        {
            txtHoten.ReadOnly = !enable;
            txtNamsinh.ReadOnly = !enable;
            txtGioitinh.ReadOnly = !enable;
            txtChucvu.ReadOnly = !enable;
            txtQuequan.ReadOnly = !enable;
            txtSdt.ReadOnly = !enable;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnableTextFields(true);
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {
            EnableTextFields(false);
            DeleteFields();

            MessageBox.Show("Đã hủy!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_NHAN_SU"].Value);

                bool isDeleted = nhansucontroller.DeleteEmployee(selectedId);

                if (isDeleted)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    MessageBox.Show("Nhân viên đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_NHAN_SU"].Value);

            Nhansumodel employee = new Nhansumodel
            {
                Id = selectedId,
                HoVaTen = txtHoten.Text,
                GioiTinh = txtGioitinh.Text,
                ChucVu = txtChucvu.Text,
                QueQuan = txtQuequan.Text,
                SoDienThoai = txtSdt.Text
            };

            int namSinh;
            if (int.TryParse(txtNamsinh.Text, out namSinh))
            {
                employee.NamSinh = namSinh;
            }
            else
            {
                MessageBox.Show("Năm sinh không hợp lệ. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isUpdated = nhansucontroller.editEmployee(employee);

            if (isUpdated)
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToTable();
                EnableTextFields(false);
                DeleteFields();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimkiem.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable resultTable = nhansucontroller.SearchNhanSu(searchTerm);

            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                dataGridView1.DataSource = resultTable;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells["ID_NHAN_SU"].Value?.ToString();
                txtHoten.Text = row.Cells["HO_VA_TEN"].Value?.ToString();
                txtTaikhoan.Text = row.Cells["TAIKHOAN"].Value?.ToString();
                txtMatkhau.Text = row.Cells["MATKHAU"].Value?.ToString();
                txtNamsinh.Text = row.Cells["NAM_SINH"].Value?.ToString();
                txtGioitinh.Text = row.Cells["GIOI_TINH"].Value?.ToString();
                txtChucvu.Text = row.Cells["CHUC_VU"].Value?.ToString();
                txtQuequan.Text = row.Cells["QUE_QUAN"].Value?.ToString();
                txtSdt.Text = row.Cells["SO_DIEN_THOAI"].Value?.ToString();

                EnableTextFields(false);
            }
        }

        private void btnDatban_Click(object sender, EventArgs e)
        {
            this.Hide();

            Datban db = new Datban();
            db.Show();
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

            Doanhthu dthu = new Doanhthu();
            dthu.Show();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            this.Hide();

            QuanlyNhansu ql = new QuanlyNhansu();
            ql.Show();
        }

        private void btnDouong_Click(object sender, EventArgs e)
        {
            this.Hide();

            Quanlydouong qldu = new Quanlydouong();
            qldu.Show();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Dangnhap frm = new Dangnhap();
                frm.Show();
                this.Hide();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Dangky dk = new Dangky();
            dk.Show();
        }
    }
}
