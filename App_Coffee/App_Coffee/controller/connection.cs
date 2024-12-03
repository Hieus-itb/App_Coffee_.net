using System;
using System.Data.SqlClient;

namespace App_Coffee
{
    public class DbConnection
    {
        private static DbConnection instance;
        private SqlConnection conn;

        private DbConnection()
        {
            try
            {
                // Chuỗi kết nối mới sử dụng SQL Server với Windows Authentication
                string connectionString = "Data Source=LAPTOP-EGMSJUVU\\MAYHIEU;Initial Catalog=QLCOFFEE;Integrated Security=True";

                // Tạo kết nối
                conn = new SqlConnection(connectionString);
                conn.Open(); // Mở kết nối
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while connecting to the database: " + e.Message);
            }
        }

        public static DbConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DbConnection();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}
