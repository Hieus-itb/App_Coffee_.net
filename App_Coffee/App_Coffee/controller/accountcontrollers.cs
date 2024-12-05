using App_Coffee.model;
using App_Coffee.model.App_Coffee.model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace App_Coffee.Controller
{
    public class Accountcontroller
    {
        private SqlConnection conn;

        public Accountcontroller()
        {
            conn = Connection.GetInstance().GetConnection();
        }
        public bool AddAccount(int idNhanSu, string taikhoan, string matkhau, string role)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string hashedPassword = HashPassword(matkhau);
                string insertAccountSql = @"
                    INSERT INTO ACCOUNT (ID_NHAN_SU, TAIKHOAN, MATKHAU, CHUC_VU) 
                    VALUES (@IDNhanSu, @TaiKhoan, @MatKhau, @ChucVu)";

                using (SqlCommand cmd = new SqlCommand(insertAccountSql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDNhanSu", idNhanSu);
                    cmd.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", hashedPassword);
                    cmd.Parameters.AddWithValue("@ChucVu", role);

                    
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CheckUserCredentials(string username, string password)
        {
            try
            {
                string sql = "SELECT TAIKHOAN, MATKHAU, CHUC_VU FROM ACCOUNT WHERE TAIKHOAN = @taikhoan AND MATKHAU = @matkhau";
                string hashedPassword = HashPassword(password);
                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@taikhoan", username);
                    cmd.Parameters.AddWithValue("@matkhau", hashedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lưu tên người dùng vào lớp AccountModel
                            AccountModel.SetLoggedInUser(reader["TAIKHOAN"].ToString());

                            return true; // Đăng nhập thành công
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false; // Đăng nhập thất bại
        }

        public bool CheckAccountExists(string taikhoan)
        {
            string sql = "SELECT COUNT(*) FROM ACCOUNT WHERE Taikhoan = @Taikhoan";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Taikhoan", taikhoan);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count > 0; // Nếu count > 0 thì tài khoản đã tồn tại
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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


        public bool IsAdmin(string username)
        {
            try
            {
                string sql = "SELECT CHUC_VU FROM ACCOUNT WHERE TAIKHOAN = @taikhoan";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@taikhoan", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string chucVu = reader["CHUC_VU"].ToString().Trim();
                            return "Quản Lý".Equals(chucVu, StringComparison.OrdinalIgnoreCase);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                return null;
            }

            try
            {
                using (SHA256 sha256 = SHA256.Create()) // Sử dụng SHA-256 để băm
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)); // Băm mật khẩu
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashedBytes)
                    {
                        sb.AppendFormat("{0:x2}", b); // Chuyển đổi byte thành định dạng hex
                    }
                    return sb.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); // In lỗi nếu có
                return null;
            }
        }


    }
}
