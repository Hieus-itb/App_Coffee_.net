using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Coffee.controller
{
    public class Ordercontroller
    {
        private SqlConnection conn;

        public Ordercontroller()
        {
            // Kết nối cơ sở dữ liệu
            conn = Connection.GetInstance().GetConnection();
        }
        public List<object[]> DanhSachDoUongDaGoi(string maBan)
        {
            var danhSachDoUong = new List<object[]>();
            string sql = "SELECT MADOUONG, TENDOUONG, SOLUONG, GIA FROM ORDER_ WHERE MABAN = @MaBan";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maDouong = reader["MADOUONG"].ToString();
                            string tenDouong = reader["TENDOUONG"].ToString();
                            int soLuong = Convert.ToInt32(reader["SOLUONG"]);
                            double gia = Convert.ToDouble(reader["GIA"]);

                            danhSachDoUong.Add(new object[] { maDouong, tenDouong, soLuong, gia });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return danhSachDoUong;
        }
        public List<object[]> GetDanhSachMonCuaBan(string maBan)
        {
            List<object[]> danhSachMon = new List<object[]>();
            string query = "SELECT MADOUONG, TENDOUONG, SOLUONG, GIA * SOLUONG AS TONGTIEN FROM ORDER_ WHERE MABAN = @MaBan";

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maDoUong = reader["MADOUONG"].ToString();
                            string tenDoUong = reader["TENDOUONG"].ToString();
                            int soLuong = Convert.ToInt32(reader["SOLUONG"]);
                            double tongTien = Convert.ToDouble(reader["TONGTIEN"]);

                            // Thêm dữ liệu vào danh sách dưới dạng mảng object[]
                            danhSachMon.Add(new object[] { maDoUong, tenDoUong, soLuong, tongTien });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách món: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return danhSachMon;
        }
        public double TongTienBan(string maBan)
        {
            double totalAmount = 0;
            string sql = "SELECT SUM(SOLUONG * GIA) AS TotalAmount FROM ORDER_ WHERE MABAN = @MaBan";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    totalAmount = Convert.ToDouble(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return totalAmount;
        }
        public bool DeleteAfterSuccess(string maBan)
        {
            string deleteSql = "DELETE FROM ORDER_ WHERE MABAN = @MaBan";

            using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
            {
                cmd.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return false;
        }

        public bool AddDrinkToTable(string maBan, string maDouong, string tenDouong, int soLuong, double gia, double chiPhi)
        {
            string sqlCheck = "SELECT SOLUONG, TONGTIEN FROM ORDER_ WHERE MABAN = @MaBan AND MADOUONG = @MaDouong";
            bool isUpdated = false;

            using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
            {
                cmdCheck.Parameters.AddWithValue("@MaBan", maBan);
                cmdCheck.Parameters.AddWithValue("@MaDouong", maDouong);

                try
                {
                    conn.Open();

                    using (SqlDataReader reader = cmdCheck.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu đồ uống đã tồn tại trong order
                        {
                            int currentQuantity = Convert.ToInt32(reader["SOLUONG"]);
                            double currentTotal = Convert.ToDouble(reader["TONGTIEN"]);

                            int newQuantity = currentQuantity + soLuong;
                            double newTotal = currentTotal + (soLuong * gia);

                            string sqlUpdate = "UPDATE ORDER_ SET SOLUONG = @NewQuantity, TONGTIEN = @NewTotal WHERE MABAN = @MaBan AND MADOUONG = @MaDouong";

                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@NewQuantity", newQuantity);
                                cmdUpdate.Parameters.AddWithValue("@NewTotal", newTotal);
                                cmdUpdate.Parameters.AddWithValue("@MaBan", maBan);
                                cmdUpdate.Parameters.AddWithValue("@MaDouong", maDouong);

                                reader.Close(); // Đóng reader trước khi thực thi lệnh UPDATE
                                cmdUpdate.ExecuteNonQuery();
                                isUpdated = true;

                                // Hiển thị thông báo cập nhật thành công
                                MessageBox.Show("Đã cập nhật số lượng đồ uống trong bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else // Nếu đồ uống chưa tồn tại trong order
                        {
                            reader.Close(); // Đóng reader trước khi thực thi lệnh INSERT
                            string sqlInsert = "INSERT INTO ORDER_ (MABAN, MADOUONG, TENDOUONG, SOLUONG, TONGTIEN, CHIPHI) VALUES (@MaBan, @MaDouong, @TenDouong, @SoLuong, @TongTien, @ChiPhi)";

                            using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                            {
                                cmdInsert.Parameters.AddWithValue("@MaBan", maBan);
                                cmdInsert.Parameters.AddWithValue("@MaDouong", maDouong);
                                cmdInsert.Parameters.AddWithValue("@TenDouong", tenDouong);
                                cmdInsert.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmdInsert.Parameters.AddWithValue("@TongTien", soLuong * gia);
                                cmdInsert.Parameters.AddWithValue("@ChiPhi", chiPhi);

                                cmdInsert.ExecuteNonQuery();
                                isUpdated = true;

                                // Hiển thị thông báo thêm mới thành công
                                MessageBox.Show("Đã thêm đồ uống mới vào bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi khi thêm đồ uống vào bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return isUpdated;
        }
    }
}
