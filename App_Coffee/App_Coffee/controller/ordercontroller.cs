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
            string sql = "SELECT MADOUONG, TENDOUONG, SOLUONG, TONGTIEN FROM ORDER_ WHERE MABAN = @MaBan";

            // Đảm bảo kết nối được mở trước khi thực hiện truy vấn
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaBan", maBan);

                try
                {
                    // Đảm bảo sử dụng using để tự động đóng DataReader
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maDouong = reader["MADOUONG"].ToString();
                            string tenDouong = reader["TENDOUONG"].ToString();
                            int soLuong = Convert.ToInt32(reader["SOLUONG"]);
                            double gia = Convert.ToDouble(reader["TONGTIEN"]);

                            danhSachDoUong.Add(new object[] { maDouong, tenDouong, soLuong, gia });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo đóng kết nối khi hoàn tất
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
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

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open(); 
                }

                using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);

                    
                    int rowsAffected = cmd.ExecuteNonQuery();

             
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
          
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteFromDatabase(string maBan, string maDoUong)
        {
            string sql = "DELETE FROM ORDER_ WHERE MABAN = @MABAN AND MADOUONG = @MADOUONG";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@MABAN", maBan);
                    cmd.Parameters.AddWithValue("@MADOUONG", maDoUong);

                    // Mở kết nối
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // Thực thi câu lệnh xóa
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Kiểm tra số dòng bị ảnh hưởng (xóa thành công sẽ trả về > 0 dòng)
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Dữ liệu đã được xóa thành công.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Không có dữ liệu nào được xóa.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // In lỗi ra console nếu có lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
            finally
            {
                // Đảm bảo đóng kết nối sau khi thực hiện
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool InsertDoanhThu(double tongChiPhi, double tongTien)
        {
            string insertDoanhThuSql = "INSERT INTO DOANHTHU (TONGCHIPHI, TONGTIEN) VALUES (@TongChiPhi, @TongTien)";
            using (SqlCommand cmd = new SqlCommand(insertDoanhThuSql, conn))
            {
                cmd.Parameters.AddWithValue("@TongChiPhi", tongChiPhi);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);

                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu thêm thành công
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi thêm doanh thu: " + ex.Message);
                    return false;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        public double TinhTongChiPhi(string maBan)
        {
            try
            {
                string sql = @"
            SELECT SUM(CHIPHI) AS TongChiPhi
            FROM ORDER_
            WHERE MABAN = @MaBan";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["TongChiPhi"] != DBNull.Value ? Convert.ToDouble(reader["TongChiPhi"]) : 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            return 0; // Trả về 0 nếu không có dữ liệu hoặc xảy ra lỗi
        }

        public bool AddDrinkToTable(string maBan, string maDouong, string tenDouong, int soLuong, double gia, double chiPhi)
        {
            string sqlCheck = "SELECT SOLUONG, TONGTIEN, CHIPHI FROM ORDER_ WHERE MABAN = @MaBan AND MADOUONG = @MaDouong";
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
                            double currentChiPhi = Convert.ToDouble(reader["CHIPHI"]);

                            int newQuantity = currentQuantity + soLuong;
                            double newTotal = currentTotal + (soLuong * gia);
                            double newChiPhi = currentChiPhi + chiPhi;
                            string sqlUpdate = @"
                        UPDATE ORDER_ 
                        SET SOLUONG = @NewQuantity, TONGTIEN = @NewTotal, CHIPHI = @NewChiPhi 
                        WHERE MABAN = @MaBan AND MADOUONG = @MaDouong";

                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@NewQuantity", newQuantity);
                                cmdUpdate.Parameters.AddWithValue("@NewTotal", newTotal);
                                cmdUpdate.Parameters.AddWithValue("@NewChiPhi", newChiPhi);
                                cmdUpdate.Parameters.AddWithValue("@MaBan", maBan);
                                cmdUpdate.Parameters.AddWithValue("@MaDouong", maDouong);

                                reader.Close(); // Đóng reader trước khi thực thi lệnh UPDATE
                                cmdUpdate.ExecuteNonQuery();
                                isUpdated = true;

                                MessageBox.Show("Đã cập nhật số lượng đồ uống trong bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else // Nếu đồ uống chưa tồn tại trong order
                        {
                            reader.Close(); // Đóng reader trước khi thực thi lệnh INSERT
                            string sqlInsert = @"
                        INSERT INTO ORDER_ (MABAN, MADOUONG, TENDOUONG, SOLUONG, TONGTIEN, CHIPHI) 
                        VALUES (@MaBan, @MaDouong, @TenDouong, @SoLuong, @TongTien, @ChiPhi)";

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

                                MessageBox.Show("Đã thêm đồ uống mới vào bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
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
