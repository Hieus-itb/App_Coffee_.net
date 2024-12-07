using OfficeOpenXml;
using System;
using System.Data;
using System.IO;

namespace App_Coffee.model
{
    public class ExcelExporter
    {
        public static void ExportDataTableToExcel(DataTable dataTable, string filePath)
        {
            try
            {
                // Tạo đối tượng ExcelPackage
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Tạo một worksheet mới
                    var worksheet = package.Workbook.Worksheets.Add("Doanh Thu");

                    // Thêm tiêu đề cột vào worksheet
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                    }

                    // Thêm dữ liệu từ DataTable vào worksheet
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col];
                        }
                    }

                    // Lưu file Excel
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xuất file Excel: " + ex.Message);
            }
        }


        public class InvoiceData
        {
            public string MaBan { get; set; }
            public string TenBan { get; set; }
            public DateTime NgayThanhToan { get; set; }
            public List<HoaDonItem> Items { get; set; }

            public InvoiceData()
            {
                Items = new List<HoaDonItem>();
            }
        }

        public class HoaDonItem
        {
            public string MaMon { get; set; }
            public string TenMon { get; set; }
            public int SoLuong { get; set; }
            public double Gia { get; set; }
            public double ChiPhi { get; set; }
        }

    }
}
