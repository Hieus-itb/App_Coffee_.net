using App_Coffee.controller;
using App_Coffee.Controller;
using App_Coffee.model;
using App_Coffee.model.App_Coffee.model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Coffee.view
{
    public partial class Goimon : Form
    {
        private Douongcontroller controller;
        private Bancontroller bancontroller;
        private Ordercontroller ordercontroller;
        private Doanhthucontroller doanhthucontroller;

        private string currentUserRole;
        private string maBan = "";
        public Goimon()
        {
            InitializeComponent();
            bancontroller = new Bancontroller();
            controller = new Douongcontroller();
            ordercontroller = new Ordercontroller();
            doanhthucontroller = new Doanhthucontroller();
            currentUserRole = Dangnhap.userRole;
            DisplayLoggedInUser();

            CheckAdminRole();
            loadDouong();
            LoadDataDouongdagoi(maBan);

            UpdateStatus("B01");
            UpdateStatus("B02");
            UpdateStatus("B03");
            UpdateStatus("B04");
            UpdateStatus("B05");
            UpdateStatus("B06");
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
        public void UpdateStatus(string maBan)
        {
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);

            switch (maBan)
            {
                case "B01":
                    UpdateLabelColor(maBan, lbBan1);
                    break;
                case "B02":
                    UpdateLabelColor(maBan, lbBan2);
                    break;
                case "B03":
                    UpdateLabelColor(maBan, lbBan3);
                    break;
                case "B04":
                    UpdateLabelColor(maBan, lbBan4);
                    break;
                case "B05":
                    UpdateLabelColor(maBan, lbBan5);
                    break;
                case "B06":
                    UpdateLabelColor(maBan, lbBan6);
                    break;
                default:
                    break;
            }
        }
        private void DeleteSelectedRow()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                string maban = maBan;
                string maDoUong = selectedRow.Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(maBan) && !string.IsNullOrEmpty(maDoUong))
                {
                    bool isDeleted = ordercontroller.DeleteFromDatabase(maBan, maDoUong);
                    if (isDeleted)
                    {
                        dataGridView2.Rows.Remove(selectedRow);

                        LoadDataDouongdagoi(maBan);

                        UpdateTotalAmountLabel();

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dữ liệu từ cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ, không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateLabelColor(string maBan, Label lbl)
        {
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);

            if (trangThaiBan)
            {
                lbl.ForeColor = Color.Red;
            }
            else
            {
                lbl.ForeColor = Color.Green;
            }
        }
        public void UpdateLabels()
        {

            Label[] lbBans = { lbBan1, lbBan2, lbBan3, lbBan4, lbBan5, lbBan6 };


            bool[] trangthaiBans = bancontroller.Trangthai();


            for (int i = 0; i < lbBans.Length; i++)
            {
                if (trangthaiBans[i])
                {
                    lbBans[i].ForeColor = Color.Green;
                }
                else
                {
                    lbBans[i].ForeColor = Color.Red;
                }
            }
        }


        public void loadDouong()
        {
            List<Douong> douongList = controller.GetAllDouong();

            dataGridView1.DataSource = douongList;

            dataGridView1.ReadOnly = true;

            dataGridView1.Columns["MaDouong"].HeaderText = "Mã Đồ Uống";

            dataGridView1.Columns["TenDouong"].HeaderText = "Tên Đồ Uống";

            dataGridView1.Columns["Gia"].HeaderText = "Giá (VND)";

            dataGridView1.Columns["Chiphi"].HeaderText = "Chi Phí (VND)";

            dataGridView1.Columns["Chiphi"].Visible = false;
        }
        private void HandleBanSelection(string maban)
        {
            maBan = maban;
            LoadDataDouongdagoi(maBan);
        }

        private void LoadDataDouongdagoi(string maBan)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            List<object[]> danhSachMon = ordercontroller.GetDanhSachMonCuaBan(maBan);

            dataGridView2.Columns.Add("MaDouong", "Mã Đồ Uống");
            dataGridView2.Columns.Add("TenDouong", "Tên Đồ Uống");
            dataGridView2.Columns.Add("SoLuong", "Số Lượng");
            dataGridView2.Columns.Add("TongTien", "Tổng Tiền");

            foreach (var mon in danhSachMon)
            {
                dataGridView2.Rows.Add(mon);
            }

            UpdateTotalAmountLabel();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
        public void UpdateTotalAmountLabel()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["TongTien"].Value != null)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["TongTien"].Value);
                }
            }

            lbThanhtien.Text = "Tổng tiền: " + totalAmount.ToString("C");
        }
        private void btnBan1_Click(object sender, EventArgs e)
        {
            maBan = "B01";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);

            }
        }

        private void btnBan2_Click(object sender, EventArgs e)
        {
            maBan = "B02";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan3_Click(object sender, EventArgs e)
        {
            maBan = "B03";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan4_Click(object sender, EventArgs e)
        {
            maBan = "B04";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {

                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan5_Click(object sender, EventArgs e)
        {
            maBan = "B05";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan6_Click(object sender, EventArgs e)
        {
            maBan = "B06";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn món trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedRow = dataGridView1.SelectedRows[0].Index;

                string madouong = dataGridView1.Rows[selectedRow].Cells[0].Value?.ToString();
                string tendouong = dataGridView1.Rows[selectedRow].Cells[1].Value?.ToString();

                if (string.IsNullOrEmpty(madouong) || string.IsNullOrEmpty(tendouong))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(dataGridView1.Rows[selectedRow].Cells[2].Value?.ToString(), out double gia))
                {
                    MessageBox.Show("Giá trị không hợp lệ, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soluong = 1;
                double tongtien;

                string maban = maBan;

                double chiphiDouong = controller.getChiphi(madouong);
                double chiphiMoi = soluong * chiphiDouong;

                bool isUpdated = ordercontroller.AddDrinkToTable(maban, madouong, tendouong, soluong, gia, chiphiMoi);

                LoadDataDouongdagoi(maban);

                if (isUpdated)
                {
                    MessageBox.Show("Món đã được thêm vào bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm món không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ấn vào bàn bên phải trước khi đặt món");
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            this.Close();
            Hoadon frm = new Hoadon(maBan);
            frm.Show();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Selected = true;
        }

        private void btnDatban_Click(object sender, EventArgs e)
        {
            this.Close();
            Datban form = new Datban();
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

        private void btnDouong_Click(object sender, EventArgs e)
        {
            this.Close();
            Quanlydouong form = new Quanlydouong();
            form.Show();
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

        private void btnDatmon_Click(object sender, EventArgs e)
        {
            this.Hide();

            Goimon gm = new Goimon();
            gm.Show();
        }

        private void Goimon_Load(object sender, EventArgs e)
        {

        }
    }
}
