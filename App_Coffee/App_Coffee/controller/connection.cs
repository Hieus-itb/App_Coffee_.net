using System;
using System.Data.SqlClient;

namespace App_Coffee.Controller
{
    public class Connection
    {
        private SqlConnection conn;
        private string connectionString;

        // Constructor: Khởi tạo chuỗi kết nối
        public Connection()
        {
            connectionString = "Data Source=MAYHIEU\\SQLEXPRESS;Initial Catalog=QLCOFFEE;Integrated Security=True;Encrypt=True;";
            conn = new SqlConnection(connectionString);
        }

        // Phương thức mở kết nối
        public void OpenConnection()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    Console.WriteLine("Kết nối thành công!");
                }
                else
                {
                    Console.WriteLine("Kết nối đã mở sẵn.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi mở kết nối: " + ex.Message);
            }
        }

        // Phương thức đóng kết nối
        public void CloseConnection()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine("Đóng kết nối thành công!");
                }
                else
                {
                    Console.WriteLine("Không có kết nối để đóng.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }

        // Getter để lấy SqlConnection
        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}
