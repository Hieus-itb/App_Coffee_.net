using System;
using Microsoft.Data.SqlClient;

namespace App_Coffee
{
    class KetNoi
    {
        private static string  connectionString = @"Data Source=LAPTOP-EGMSJUVU\MAYHIEU;Initial Catalog=QLCOFFEE;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                return conn;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                return null;
            }
        }
    }
}
