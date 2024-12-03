using System;
using System.Data;
using System.Windows.Forms;
using App_Coffee.controller;
using App_Coffee.model;
//using static Azure.Core.HttpHeader;


namespace App_Coffee.view
{
    public partial class Datban : Form
    {
        private Bancontroller bancontroller;
        private string currentUserRole;
        public Datban()
        {
            InitializeComponent();
            bancontroller = new Bancontroller();
            currentUserRole = Dangnhap.userRole; // Nhận quyền người dùng từ form đăng nhập

            LoadDataToTable();
            CheckAdminRole();
        }
        private void LoadDataToTable()
        {
            List <Ban> bans = bancontroller.GetAllBan();
            dataGridView1.DataSource = bans;
        }


        // Kiểm tra quyền admin để hiển thị nút Nhân viên
        private void CheckAdminRole()
        {
            if (currentUserRole == "Admin")
            {
                btnNhanvien.Visible = true;
            }
            else
            {
                btnNhanvien.Visible = false;
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
                bool success = bancontroller.DatBan(maBan);

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
                bool success = bancontroller.UpdateBanStatus(maBan, "Trống");

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
            //bool hasBanDaDat = banController.IsAnyBanDaDat();
            //if (!hasBanDaDat)
            //{
            //    MessageBox.Show("Không có bàn nào đang được đặt. Vui lòng đặt bàn trước!");
            //    return;
            //}

            //Goimon goiMonUI = new Goimon();
            //goiMonUI.Show();
            //this.Hide();
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            Doanhthu dthu = new Doanhthu();
            dthu.Show();

            this.Close();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            //QuanLy ql = new QuanLy();
            //ql.Show();
            //this.Hide();
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
