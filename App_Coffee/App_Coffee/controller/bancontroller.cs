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
            if (trangThai != "Trống" && trangThai != "Đã đặt")
            {
                Console.WriteLine("Giá trị trạng thái không hợp lệ: " + trangThai);
                return false;
            }
            try
            {
                string sql = "UPDATE BAN SET TRANGTHAI = @trangThai WHERE MABAN = @maBan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);
                cmd.Parameters.AddWithValue("@maBan", maBan);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string GetTenBan(string id)
        {
            string tenBan = "";
            string sql = "SELECT TENBAN FROM BAN WHERE MABAN = @id";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tenBan = reader["TENBAN"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
