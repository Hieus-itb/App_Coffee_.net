using System;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace App_Coffee.Controller
{
    public class AccountController
    {
        private Connection connManager;
        private SqlConnection conn;

        public AccountController()
        {
            // Sử dụng lớp Connection để quản lý kết nối
            connManager = new Connection();
            connManager.OpenConnection();
            conn = connManager.GetConnection(); // Lấy kết nối từ đối tượng Connection
        }

        // Phương thức kiểm tra tài khoản và mật khẩu
        public bool CheckUserCredentials(string username, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);

                string sql = "SELECT * FROM ACCOUNT WHERE TAIKHOAN = @Username AND MATKHAU = @Password";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Đăng nhập thành công!");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra tài khoản: " + ex.Message);
            }
            return false;
        }

        // Phương thức băm mật khẩu
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // Phương thức kiểm tra quyền quản trị viên
        public bool IsAdmin(string taikhoan)
        {
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                // Câu lệnh SQL kiểm tra quyền quản lý
                string sql = @"SELECT ns.CHUC_VU 
                               FROM ACCOUNT a 
                               JOIN NHAN_SU ns ON a.ID_NHAN_SU = ns.ID_NHAN_SU 
                               WHERE a.TAIKHOAN = @TaiKhoan";

                cmd = new SqlCommand(sql, conn); // 'conn' là SqlConnection đã được mở kết nối trước
                cmd.Parameters.AddWithValue("@TaiKhoan", taikhoan);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string chucVu = reader["CHUC_VU"].ToString();
                    return string.Equals(chucVu, "Quản lý", StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi SQL: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng tài nguyên
                reader?.Close();
                cmd?.Dispose();
            }

            return false;
        }
    }
}
