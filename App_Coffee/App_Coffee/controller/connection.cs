using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Coffee.controller
{
    public class connection
    {
        private SqlConnection conn; 
        private string connectionString;

        
        public connection()
        {
             string connectionString = "Data Source=Van_Duc25\\SQLEXPRESS;Initial Catalog=QLCOFFEE;Integrated Security=True;Encrypt=True;";
             conn = new SqlConnection(connectionString);
        }

        // Phương thức để mở kết nối
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


        // Phương thức để đóng kết nối
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

    }
}
