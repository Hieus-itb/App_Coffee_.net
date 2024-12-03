using System;
using System.Data;
using System.Data.SqlClient;

namespace App_Coffee.controller
{
    internal class BanController
    {
        private SqlConnection conn;

        public BanController()
        {
            conn = DbConnection.GetInstance().GetConnection();
        }

        public DataTable GetAllBan()
        {
            try
            {
                string sql = "SELECT * FROM BAN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
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

        public string GetTrangThai(string maBan)
        {
            string sql = "SELECT TRANGTHAI FROM BAN WHERE MABAN = @maBan";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maBan", maBan);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["TRANGTHAI"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
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
