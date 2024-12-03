using System;
using System.Data.SqlClient;

namespace App_Coffee
{
    public class Connection
    {
        private static Connection instance;

        private SqlConnection conn;

        private Connection()
        {
            try
            {
                // Chuỗi kết nối mới sử dụng SQL Server với Windows Authentication
                string connectionString = "Data Source=Van_Duc25\\SQLEXPRESS;Initial Catalog=QLCOFFEE;Integrated Security=True;";

                // Tạo kết nối
                conn = new SqlConnection(connectionString);
                conn.Open(); // Mở kết nối
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while connecting to the database: " + e.Message);
            }
        }

        public static Connection GetInstance()
        {
            if (instance == null)
            {
                instance = new Connection();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

    }
}
