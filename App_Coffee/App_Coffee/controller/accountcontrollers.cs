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
        public bool AddAccount(string taikhoan, string matkhau, int idNhansu, string chucvu)
        {
            try
            {
                string sql = "INSERT INTO ACCOUNT(TAIKHOAN, MATKHAU, ID_NHAN_SU, CHUC_VU) VALUES (@TaiKhoan, @MatKhau, @IdNhanSu, @ChucVu)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", matkhau);
                    cmd.Parameters.AddWithValue("@IdNhanSu", idNhansu);
                    cmd.Parameters.AddWithValue("@ChucVu", chucvu);

                    // Mở kết nối, thực thi câu lệnh và trả về kết quả
                    conn.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    // Kiểm tra xem có bản ghi nào được thêm vào không
                    return rowAffected > 0;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
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
