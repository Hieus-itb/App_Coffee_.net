using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

namespace App_Coffee.Controller
{
    public class AccountController
    {
        SqlConnection conn = KetNoi.GetConnection();

        public bool CheckLogin(string username, string password)
        {
            SqlConnection conn = KetNoi.GetConnection();
            if (conn == null || conn.State != ConnectionState.Open)
            {
                Console.WriteLine("Không thể kết nối đến cơ sở dữ liệu.");
                return false; // Không thể kết nối đến cơ sở dữ liệu
            }

            // Câu truy vấn để kiểm tra tài khoản
            string query = "SELECT COUNT(*) FROM ACCOUNT WHERE TAIKHOAN = @username AND MATKHAU = @password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Nếu có tài khoản thì trả về true
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thực thi truy vấn: " + ex.Message);
                return false;
            }
        }

    }
}
