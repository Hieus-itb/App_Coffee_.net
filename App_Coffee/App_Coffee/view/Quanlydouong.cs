using App_Coffee.controller;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace App_Coffee.view
{
    public partial class Quanlydouong : Form
    {
        private Douongcontroller controller;
        public Quanlydouong()
        {
            InitializeComponent();
            controller = new Douongcontroller();
            loadDouong();
            lockTxt();
        }
        public void lockTxt()
        {
            txtMadouong.ReadOnly = true;
            txtTendouong.ReadOnly = true;
            txtGia.ReadOnly = true;
            txtChiphinhaplieu.ReadOnly = true;
        }
        public bool unlockTxt()
        {
            txtMadouong.ReadOnly = false;
            txtTendouong.ReadOnly = false;
            txtGia.ReadOnly = false;
            txtChiphinhaplieu.ReadOnly = false;
            return true;
        }
        public void loadDouong()
        {
            List<Douong> douongList = controller.GetAllDouong();

            dataGridViewDouong.DataSource = douongList;

            dataGridViewDouong.ReadOnly = true;

            // Đổi tên tiêu đề cột

            dataGridViewDouong.Columns["MaDouong"].HeaderText = "Mã Đồ Uống";

            dataGridViewDouong.Columns["TenDouong"].HeaderText = "Tên Đồ Uống";

            dataGridViewDouong.Columns["Gia"].HeaderText = "Giá (VND)";

            dataGridViewDouong.Columns["Chiphi"].HeaderText = "Chi Phí (VND)";

            lockTxt();
        }

        private void dataGridViewDouong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewDouong.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = dataGridViewDouong.Rows[e.RowIndex];

                txtMadouong.Text = selectedRow.Cells["MaDouong"].Value.ToString();
                txtTendouong.Text = selectedRow.Cells["TenDouong"].Value.ToString();
                txtGia.Text = selectedRow.Cells["Gia"].Value.ToString();
                txtChiphinhaplieu.Text = selectedRow.Cells["Chiphi"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            unlockTxt();
            txtGia.Clear();
            txtChiphinhaplieu.Clear();
            txtTendouong.Clear();
            txtMadouong.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maDouong = txtMadouong.Text.Trim();
            string tenDouong = txtTendouong.Text.Trim();

            if (double.TryParse(txtGia.Text.Trim(), out double gia) && double.TryParse(txtChiphinhaplieu.Text.Trim(), out double chiphi))
            {
                Douong updatedDouong = new Douong
                {
                    MaDouong = maDouong,
                    TenDouong = tenDouong,
                    Gia = gia,
                    Chiphi = chiphi
                };


                if (controller.IsDouongExists(maDouong))
                {
                    bool success = controller.Update(updatedDouong);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDouong();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    bool success = controller.Insert(updatedDouong);

                    if (success)
                    {
                        MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDouong();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho giá và chi phí!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewDouong.SelectedRows.Count == 0) // Kiểm tra xem có món nào được chọn không
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy Mã Đồ Uống của món cần xóa
            string maDouong = dataGridViewDouong.SelectedRows[0].Cells["MaDouong"].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                bool success = controller.Delete(maDouong); // Giả sử có phương thức DeleteDouong trong controller

                if (success)
                {
                    MessageBox.Show("Món đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDouong();  // Tải lại danh sách món sau khi xóa thành công
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            unlockTxt();
        }

        private void btnKluu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không có thay đổi nào được lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMadouong.Clear();
            txtGia.Clear();
            txtTendouong.Clear();
            txtChiphinhaplieu.Clear();
            loadDouong();
        }

        private void btnDatban_Click(object sender, EventArgs e)
        {
            this.Close();
            Datban form = new Datban();
            form.Show();
        }

        private void btnDatmon_Click(object sender, EventArgs e)
        {
            this.Close();
            Goimon form = new Goimon();
            form.Show();
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            this.Close();
            Doanhthu form = new Doanhthu();
            form.Show();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            this.Close();
            QuanlyNhansu form = new QuanlyNhansu();
            form.Show();
        }
    }
}
