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

namespace App_Coffee.view
{
    public partial class Hoadon : Form
    {
        private Bancontroller bancontroller;
        private Douongcontroller douongcontroller;
        private Ordercontroller ordercontroller;
        private Goimon goimon;
        private string maban;

        
        public Hoadon(string _maban)
        {
            InitializeComponent();
            bancontroller = new Bancontroller();
            douongcontroller = new Douongcontroller();
            ordercontroller = new Ordercontroller();
            goimon = new Goimon();
            this.maban = _maban;
            LoadData();
        }
        public void SetNgayDat()
        {
            lbNgay.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void SetDanhSachMon(List<string[]> danhSachMon)
        {
            var model = (DataGridView)dataGridView1;
            model.Rows.Clear();

            foreach (var mon in danhSachMon)
            {
                model.Rows.Add(mon);
            }
        }
        private void LoadData()
        {

            lbBan.Text = bancontroller.GetTenBan(maban);
            lbNgay.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            List<object[]> danhSachDoUong = ordercontroller.DanhSachDoUongDaGoi(maban);

            DataGridView model = dataGridView1;
            model.ColumnCount = 4;
            model.Columns[0].Name = "Mã món";
            model.Columns[1].Name = "Tên món";
            model.Columns[2].Name = "Số lượng";
            model.Columns[3].Name = "Giá";

            foreach (var row in danhSachDoUong)
            {
                model.Rows.Add(row);
            }
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy dữ liệu từ DataGridView
                DataGridView model = dataGridView1; 
                double tongChiPhi = 0, tongTien = 0;

                string tenBan = bancontroller.GetTenBan(maban);

                // Duyệt qua các dòng trong DataGridView
                foreach (DataGridViewRow row in model.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        string maDoUong = row.Cells[0].Value.ToString();
                        int soLuong = int.Parse(row.Cells[2].Value.ToString());
                        double gia = double.Parse(row.Cells[3].Value.ToString());
                        double chiPhi = douongcontroller.getChiphi(maDoUong);
                        tongChiPhi += chiPhi * soLuong;

                        
                        tongTien += gia * soLuong;
                    }
                }

                // Gọi phương thức insertDoanhThu và deleteAfterSucess
                bool insertSuccess = ordercontroller.InsertDoanhThu(tongChiPhi, tongTien);
                

                // Hiển thị thông báo thanh toán thành công
                MessageBox.Show("Thanh toán thành công!");

                

                // Làm sạch bảng và thông tin bàn
                model.Rows.Clear();
                lbBan.Text = "";
                lbNgay.Text = "";
                // Cập nhật trạng thái bàn
                bool updateStatusSuccess = bancontroller.UpdateBanStatus(maban, "Trống");
                if (!updateStatusSuccess)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái bàn!");
                    return;
                }
                else 
                {
                    goimon.UpdateLabels();
                } 
                
                bool deleteAfterSucess = ordercontroller.DeleteAfterSuccess(maban);
                
                
            }
            catch (Exception ex)
            {
                // In lỗi ra console và hiển thị thông báo lỗi
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
            }
            finally
            {
                this.Close();
                Goimon frm = new Goimon();
                frm.Show();
            }

        }
    }
}
