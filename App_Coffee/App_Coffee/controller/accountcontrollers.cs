using System;
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
        public bool addAccount(string username, string password, string chucvu)
        {
            string sql = "INSERT INTO ACCOUNT (TAIKHOAN, MATKHAU, CHUC_VU) VALUES (@username, @password, @chucvu)";

            try
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    // Băm mật khẩu trước khi lưu vào cơ sở dữ liệu
                    string hashedPassword = HashPassword(password); // Mã hóa mật khẩu

                    // Thêm tham số để tránh SQL Injection
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword); // Lưu mật khẩu đã băm
                    command.Parameters.AddWithValue("@chucvu", chucvu);

                    // Thực thi câu lệnh
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có hàng nào được thêm hay không
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Ghi log hoặc xử lý ngoại lệ
                Console.WriteLine("Lỗi khi thêm tài khoản: " + ex.Message);
                return false;
            }
        }

        public bool CheckUserCredentials(string username, string password)
        {
            try
            {
                string sql = "SELECT * FROM ACCOUNT WHERE TAIKHOAN = @taikhoan AND MATKHAU = @matkhau";

                // Băm mật khẩu trước khi kiểm tra
                string hashedPassword = HashPassword(password);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@taikhoan", username);
                    cmd.Parameters.AddWithValue("@matkhau", hashedPassword); // Dùng mật khẩu đã băm

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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
