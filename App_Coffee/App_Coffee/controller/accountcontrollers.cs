using System;
using System.Data.SqlClient;

namespace App_Coffee.Controller
{
    public class AccountController
    {
        private SqlConnection conn;

        public AccountController()
        {
            conn = DbConnection.GetInstance().GetConnection();
        }
        public bool addAccount(string username, string password)
        {
            string sql = "INSERT INTO ACCOUNT (TAIKHOAN, MATKHAU) VALUES (@username, @password)";
            conn.Open();
            try
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    // Thêm tham số để tránh SQL Injection
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

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
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@taikhoan", username);
                    cmd.Parameters.AddWithValue("@matkhau", password);

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


    }
}
