using App_Coffee.model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace App_Coffee.controller
{
    internal class Bancontroller
    {
        private SqlConnection conn;
        public Bancontroller()
        {
            conn = Connection.GetInstance().GetConnection();
            OpenConnection(); // Mở kết nối khi khởi tạo controller
        }
        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public List<Ban> GetAllBan()
        {
            List<Ban> listBan = new List<Ban>();
            string sql = "SELECT * FROM BAN";
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ban ban = new Ban
                            {
                                MaBan = reader["MABAN"].ToString(),
                                TenBan = reader["TENBAN"].ToString(),
                                TrangThai = reader["TRANGTHAI"].ToString()
                            };
                            listBan.Add(ban);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
            }
            return listBan;
        }

        public bool IsAnyBanDaDat()
        {
            string sql = "SELECT COUNT(*) AS SoLuong FROM BAN WHERE TRANGTHAI = N'Đã đặt'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool GetTrangThai(string maBan)
        {
            bool trangThai = false;

            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                    return false;
                }
            }

            string sql = "SELECT TRANGTHAI FROM BAN WHERE MABAN = @maBan";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maBan", maBan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // So sánh và loại bỏ khoảng trắng thừa nếu có
                        trangThai = reader["TRANGTHAI"].ToString().Trim() == "Đã đặt";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi truy vấn: " + e.Message);
            }

            return trangThai;
        }

        public bool[] Trangthai()
        {
            bool[] trangThaiBans = new bool[6];
            try
            {
                string sql = "SELECT MABAN, TRANGTHAI FROM BAN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                int index = 0;
                while (reader.Read())
                {
                    string maBan = reader["MABAN"].ToString();
                    string trangthai = reader["TRANGTHAI"].ToString();
                    trangThaiBans[index] = trangthai == "Trống";
                    index++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return trangThaiBans;
        }

        public bool DatBan(string maBan)
        {
            return UpdateBanStatus(maBan, "Đã đặt");
        }

        public bool UpdateBanStatus(string maBan, string trangThai)
        {
            // Kiểm tra giá trị trạng thái hợp lệ
            if (trangThai != "Trống" && trangThai != "Đã đặt")
            {
                Console.WriteLine("Giá trị trạng thái không hợp lệ: " + trangThai);
                return false;
            }

            try
            {
                // Đảm bảo kết nối đã được mở
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Chuẩn bị câu lệnh SQL để cập nhật trạng thái bàn
                string sql = "UPDATE BAN SET TRANGTHAI = @trangThai WHERE MABAN = @maBan";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@trangThai", trangThai);
                    cmd.Parameters.AddWithValue("@maBan", maBan);

                    // Thực thi câu lệnh và lấy số dòng bị ảnh hưởng
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Trả về true nếu có ít nhất một dòng bị ảnh hưởng
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và in thông báo
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
            finally
            {
                // Đảm bảo đóng kết nối nếu nó đang mở
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public string GetTenBan(string id)
        {
            string tenBan = "";
            string sql = "SELECT TENBAN FROM BAN WHERE MABAN = @id";

            try
            {
                // Kiểm tra và mở kết nối nếu chưa mở
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Thực thi câu lệnh SQL
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    // Đọc dữ liệu
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenBan = reader["TENBAN"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }
            finally
            {
                // Đảm bảo kết nối sẽ được đóng sau khi sử dụng
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return tenBan;
        }


        public string GetID(string tenBan)
        {
            string sql = "SELECT MABAN FROM BAN WHERE TENBAN = @tenBan";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenBan", tenBan);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["MABAN"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
