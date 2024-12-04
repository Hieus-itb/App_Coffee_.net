using App_Coffee.model;
using System.Data;
using System.Data.SqlClient;

namespace App_Coffee.controller
{
    internal class Douongcontroller
    {
        private SqlConnection conn;

        public Douongcontroller()
        {
            conn = Connection.GetInstance().GetConnection();
        }

        // Thêm
        public bool Insert(Douong douong)
        {
            string query = "INSERT INTO DOUONG (MADOUONG, TENDOUONG, GIA, CHIPHI) VALUES (@MADOUONG, @TENDOUONG, @GIA, @CHIPHI)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MADOUONG", douong.MaDouong);
                cmd.Parameters.AddWithValue("@TENDOUONG", douong.TenDouong);
                cmd.Parameters.AddWithValue("@GIA", douong.Gia);
                cmd.Parameters.AddWithValue("@CHIPHI", douong.Chiphi);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu thêm thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
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
        }

        // Sửa
        public bool Update(Douong douong)
        {
            string query = "UPDATE DOUONG SET TENDOUONG = @TENDOUONG, GIA = @GIA, CHIPHI = @CHIPHI WHERE MADOUONG = @MADOUONG";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MADOUONG", douong.MaDouong);
                cmd.Parameters.AddWithValue("@TENDOUONG", douong.TenDouong);
                cmd.Parameters.AddWithValue("@GIA", douong.Gia);
                cmd.Parameters.AddWithValue("@CHIPHI", douong.Chiphi);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
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
        }

        // Xóa
        public bool Delete(string maDouong)
        {
            string query = "DELETE FROM DOUONG WHERE MADOUONG = @MADOUONG";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MADOUONG", maDouong);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu xóa thành công
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
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
        }

        // Lấy tất cả đồ uống
        public List<Douong> GetAllDouong()
        {
            List<Douong> douongs = new List<Douong>();
            string query = "SELECT * FROM DOUONG";

            try
            {
                // Mở kết nối
                conn.Open();

                // Dùng using để đảm bảo SqlDataReader được đóng tự động
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Douong u = new Douong
                        {
                            MaDouong = reader["MaDouong"].ToString(),
                            TenDouong = reader["TenDouong"].ToString(),
                            Chiphi = Convert.ToSingle(reader["Gia"]),
                            Gia = Convert.ToSingle(reader["Chiphi"])
                        };
                        // Thêm vào danh sách
                        douongs.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return douongs;
        }
    }
}
