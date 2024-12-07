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
using static App_Coffee.model.ExcelExporter;

namespace App_Coffee.view
{
    public partial class Hoadon : Form
    {
        private Bancontroller bancontroller;
        private Douongcontroller douongcontroller;
        private Ordercontroller ordercontroller;
        private Goimon goimon;
        private string maban;
        private static InvoiceData currentInvoice;

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

        private void ExportInvoice()
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã món");
                dataTable.Columns.Add("Tên món");
                dataTable.Columns.Add("Số lượng");
                dataTable.Columns.Add("Giá");
                dataTable.Columns.Add("Chi phí");

                foreach (var item in currentInvoice.Items)
                {
                    dataTable.Rows.Add(item.MaMon, item.TenMon, item.SoLuong, item.Gia, item.ChiPhi);
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    ExcelExporter.ExportDataTableToExcel(dataTable, filePath);
                    MessageBox.Show("Hóa đơn đã được xuất thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất hóa đơn: {ex.Message}");
            }
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn thanh toán không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                DataGridView model = dataGridView1;
                double tongChiPhi = 0, tongTien = 0;

                string tenBan = bancontroller.GetTenBan(maban);

                currentInvoice = new InvoiceData
                {
                    MaBan = maban,
                    TenBan = tenBan,
                    NgayThanhToan = DateTime.Now
                };

                foreach (DataGridViewRow row in model.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                    {
                        string maDoUong = row.Cells[0].Value.ToString();
                        int soLuong = int.Parse(row.Cells[2].Value.ToString());
                        double gia = douongcontroller.getGia(maDoUong);
                        double chiPhi = douongcontroller.getChiphi(maDoUong);

                        currentInvoice.Items.Add(new HoaDonItem
                        {
                            MaMon = maDoUong,
                            TenMon = row.Cells[1].Value.ToString(),
                            SoLuong = soLuong,
                            Gia = gia,
                            ChiPhi = chiPhi
                        });

                        tongChiPhi += chiPhi * soLuong;
                        tongTien += gia * soLuong;
                    }
                }

                bool insertSuccess = ordercontroller.InsertDoanhThu(tongChiPhi, tongTien);

                MessageBox.Show("Thanh toán thành công!");

                var result = MessageBox.Show("Bạn có muốn xuất hóa đơn không?", "Xuất hóa đơn", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExportInvoice();
                }

                model.Rows.Clear();
                lbBan.Text = "";
                lbNgay.Text = "";

                bool updateStatusSuccess = bancontroller.UpdateBanStatus(maban, "Trống");
                if (!updateStatusSuccess)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái bàn!");
                    return;
                }

                goimon.UpdateLabels();

                bool deleteAfterSucess = ordercontroller.DeleteAfterSuccess(maban);
            }
            catch (Exception ex)
            {
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
