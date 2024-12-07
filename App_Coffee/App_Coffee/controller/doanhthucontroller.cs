using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using App_Coffee.model;
using App_Coffee.view;

namespace App_Coffee.Controller
{
    public class Doanhthucontroller
    {
        private SqlConnection conn;

        public Doanhthucontroller()
        {
            conn = Connection.GetInstance().GetConnection();
        }
        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}");
                }
            }
        }

        public List<HoaDon> GetAllHoadon()
        {
            List<HoaDon> hoaDonList = new List<HoaDon>();
            string sql = "SELECT ID, NGAY, GIO, TONGCHIPHI, TONGTIEN FROM DOANHTHU";

            try
            {
                OpenConnection();

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
                                TongChiPhi = (float)(reader.IsDBNull(3) ? 0 : reader.GetDouble(3)),  
                                TongTien = (float)(reader.IsDBNull(4) ? 0 : reader.GetDouble(4))  
                            };

                            hoaDonList.Add(hoaDon);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching invoices: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string checkDataSql = "SELECT COUNT(*) FROM DOANHTHU";
                using (SqlCommand checkCmd = new SqlCommand(checkDataSql, conn))
                {
                    int rowCount = (int)checkCmd.ExecuteScalar();
                }

                string sql = "SELECT SUM(TONGTIEN) - SUM(TONGCHIPHI) FROM DOANHTHU";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return Convert.ToSingle(result);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính toán lãi: {ex.Message}", "Lỗi");
                return 0;
            }
        }

        // Lấy tổng chi phí
        public float GetTotalChiPhi()
        {
            try
            {
                string sql = "SELECT SUM(TONGCHIPHI) FROM DOANHTHU";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Convert.ToSingle(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total cost: {ex.Message}");
                return 0;
            }
        }
        

        // Lấy tổng tiền
        public float GetTotalTien()
        {
            try
            {
                string sql = "SELECT SUM(TONGTIEN) FROM DOANHTHU";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Convert.ToSingle(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching total money: {ex.Message}");
                return 0;
            }
        }

    }
}
