using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Coffee.controller
{
    internal class Douongcontroller
    {
        private SqlConnection conn;
        public Douongcontroller() 
        {
            conn = Connection.GetInstance().GetConnection();
        }
        //thêm
        public bool Insert(string maDouong, string tenDouong, double gia, double chiPhi)
        {
            try
            {
                string query = "INSERT INTO DOUONG (MADOUONG, TENDOUONG, GIA, CHIPHI) VALUES (@MADOUONG, @TENDOUONG, @GIA, @CHIPHI)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MADOUONG", maDouong);
                    cmd.Parameters.AddWithValue("@TENDOUONG", tenDouong);
                    cmd.Parameters.AddWithValue("@GIA", gia);
                    cmd.Parameters.AddWithValue("@CHIPHI", chiPhi);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
                return false;
            }
        }
        // Sửa
        public bool Update(string maDouong, string tenDouong, double gia, double chiPhi)
        {
            try
            {
                string query = "UPDATE DOUONG SET TENDOUONG = @TENDOUONG, GIA = @GIA, CHIPHI = @CHIPHI WHERE MADOUONG = @MADOUONG";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MADOUONG", maDouong);
                    cmd.Parameters.AddWithValue("@TENDOUONG", tenDouong);
                    cmd.Parameters.AddWithValue("@GIA", gia);
                    cmd.Parameters.AddWithValue("@CHIPHI", chiPhi);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
                return false;
            }
        }
        //Xóa
        public bool Delete(string maDouong)
        {
            try
            {
                string query = "DELETE FROM DOUONG WHERE MADOUONG = @MADOUONG";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MADOUONG", maDouong);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                conn.Close();
                return false;
            }
        }
        public List<Douong> douongs()
        {

        }

    }
}
