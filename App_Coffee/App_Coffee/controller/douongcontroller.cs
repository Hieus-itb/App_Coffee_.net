using App_Coffee.model;
using System.Collections.Specialized;
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

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    // Đảm bảo kết nối được mở một lần
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Douong douong = new Douong
                            {
                                MaDouong = reader["MaDouong"].ToString(),
                                TenDouong = reader["TenDouong"].ToString(),
                                Gia = reader["Gia"] != DBNull.Value && double.TryParse(reader["Gia"].ToString(), out double gia) ? gia : 0,
                                Chiphi = reader["Chiphi"] != DBNull.Value && double.TryParse(reader["Chiphi"].ToString(), out double chiphi) ? chiphi : 0
                            };

                            douongs.Add(douong);
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
            }

            return douongs;
        }
        public bool IsDouongExists(string maDouong)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Douong WHERE MaDouong = @MaDouong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDouong", maDouong);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    return count > 0; // Nếu có ít nhất 1 món có Mã Đồ Uống này, trả về true (tồn tại)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
