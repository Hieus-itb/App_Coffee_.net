using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using App_Coffee.model;

namespace App_Coffee.Controller
{
    public class Doanhthucontroller
    {
        private SqlConnection conn;

        public Doanhthucontroller()
        {
            conn = Connection.GetInstance().GetConnection();
        }

        // Lấy danh sách hóa đơn dưới dạng List<HoaDon>
        public List<HoaDon> GetAllHoadon()
        {
            List<HoaDon> hoaDonList = new List<HoaDon>();

            try
            {
                string sql = "SELECT ID, NGAY, GIO, TONGCHIPHI, TONGTIEN FROM DOANHTHU";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoaDon hoaDon = new HoaDon
                            {
                                Id = reader.GetInt32(0),
                                Ngay = reader.GetDateTime(1),
                                Gio = reader.GetTimeSpan(2),
                                TongChiPhi = reader.GetFloat(3),
                                TongTien = reader.GetFloat(4)
                            };
                            hoaDonList.Add(hoaDon);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching invoices: {ex.Message}");
            }

            return hoaDonList;
        }

        // Lấy tổng số hóa đơn
        public int GetInvoiceCount()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM DOANHTHU";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching count: {ex.Message}");
                return 0;
            }
        }

        // Tính lãi (Tổng tiền - Tổng chi phí)
        public float GetProfit()
        {
            try
            {
                string sql = "SELECT SUM(TONGTIEN) AS TotalTien, SUM(TONGCHIPHI) AS TotalChiPhi FROM DOANHTHU";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            float totalTien = reader.IsDBNull(0) ? 0 : reader.GetFloat(0);
                            float totalChiPhi = reader.IsDBNull(1) ? 0 : reader.GetFloat(1);
                            return totalTien - totalChiPhi;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating profit: {ex.Message}");
            }
            return 0;
        }
    }
}
