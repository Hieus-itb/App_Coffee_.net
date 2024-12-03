using System;
using System.Data;
using System.Windows.Forms;
using App_Coffee.controller;
using static Azure.Core.HttpHeader;


namespace App_Coffee.view
{
    public partial class Datban : Form
    {
        private BanController banController;
        private string currentUserRole;
        public Datban()
        {
            InitializeComponent();
            banController = new BanController();
            currentUserRole = userRole; // Nhận role người dùng từ form đăng nhập hoặc session

            LoadDataToTable();
            CheckAdminRole();
        }
        private void LoadDataToTable()
        {
            try
            {
                DataTable dt = banController.GetAllBan();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["TRANGTHAI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Căn chỉnh cột trạng thái
                dataGridView1.Columns["MABAN"].HeaderText = "Mã Bàn";
                dataGridView1.Columns["TENBAN"].HeaderText = "Tên Bàn";
                dataGridView1.Columns["TRANGTHAI"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Kiểm tra quyền admin để hiển thị nút Nhân viên
        private void CheckAdminRole()
        {
            if (currentUserRole == "Admin")
            {
                btnNhanVien.Visible = true;
            }
            else
            {
                btnNhanVien.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string maBan = selectedRow.Cells["MABAN"].Value.ToString();
                bool success = banController.DatBan(maBan);

                if (success)
                {
                    MessageBox.Show("Đặt bàn thành công!");
                    LoadDataToTable();
                }
                else
                {
                    MessageBox.Show("Lỗi khi đặt bàn!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để đặt!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string maBan = selectedRow.Cells["MABAN"].Value.ToString();
                bool success = banController.UpdateBanStatus(maBan, "Trống");

                if (success)
                {
                    MessageBox.Show("Hủy bàn thành công!");
                    LoadDataToTable();
                }
                else
                {
                    MessageBox.Show("Lỗi khi hủy bàn!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để hủy!");
            }
        }

        private void btnDatban_Click(object sender, EventArgs e)
        {

        }

        private void btnDatmon_Click(object sender, EventArgs e)
        {
            bool hasBanDaDat = banController.IsAnyBanDaDat();
            if (!hasBanDaDat)
            {
                MessageBox.Show("Không có bàn nào đang được đặt. Vui lòng đặt bàn trước!");
                return;
            }

            Goimon goiMonUI = new Goimon();
            goiMonUI.Show();
            this.Hide();
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            QuanLy ql = new QuanLy();
            ql.Show();
            this.Hide();
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
    }
}
