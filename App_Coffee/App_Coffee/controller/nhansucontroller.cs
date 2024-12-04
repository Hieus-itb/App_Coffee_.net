using App_Coffee;
using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace App_Coffee.controller
{
    public class nhansucontroller
    {
        private SqlConnection conn;
        public nhansucontroller()
        {
            conn = Connection.GetInstance().GetConnection();
        }

        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        //------------------------QUAN LY NHAN SU---------------------------------------
        //Không chỉnh sửa thêm
        public DataTable GetAllNhanSu()
        {
            DataTable result = new DataTable();
            string sql = @"
                SELECT NS.ID_NHAN_SU, NS.HO_VA_TEN, A.TAIKHOAN, A.MATKHAU, 
                       NS.NAM_SINH, NS.GIOI_TINH, A.CHUC_VU, NS.QUE_QUAN, NS.SO_DIEN_THOAI
                FROM NHAN_SU NS
                LEFT JOIN ACCOUNT A ON NS.ID_NHAN_SU = A.ID_NHAN_SU";

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }
    
        public bool editEmployee(Nhansumodel employee)
        {
            try
            {
                string sql = @"
                UPDATE NHAN_SU 
                SET HO_VA_TEN = @HO_VA_TEN, GIOI_TINH = @GIOI_TINH, NAM_SINH = @NAM_SINH, 
                    CHUC_VU = @CHUC_VU, QUE_QUAN = @QUE_QUAN, SO_DIEN_THOAI = @SO_DIEN_THOAI 
                WHERE ID_NHAN_SU = @ID_NHAN_SU";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HO_VA_TEN", employee.HoVaTen);
                    cmd.Parameters.AddWithValue("@GIOI_TINH", employee.GioiTinh);
                    cmd.Parameters.AddWithValue("@NAM_SINH", employee.NamSinh);
                    cmd.Parameters.AddWithValue("@CHUC_VU", employee.ChucVu);
                    cmd.Parameters.AddWithValue("@QUE_QUAN", employee.QueQuan);
                    cmd.Parameters.AddWithValue("@SO_DIEN_THOAI", employee.SoDienThoai);
                    cmd.Parameters.AddWithValue("@ID_NHAN_SU", employee.Id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool addEmployee(Nhansumodel nhansumodel)
        {
            try
            {
                string sql = @"
                INSERT INTO NHAN_SU (HO_VA_TEN, GIOI_TINH, NAM_SINH, CHUC_VU, QUE_QUAN, SO_DIEN_THOAI) 
                VALUES (@HO_VA_TEN, @GIOI_TINH, @NAM_SINH, @CHUC_VU, @QUE_QUAN, @SO_DIEN_THOAI)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HO_VA_TEN", nhansumodel.HoVaTen);
                    cmd.Parameters.AddWithValue("@GIOI_TINH", nhansumodel.GioiTinh);
                    cmd.Parameters.AddWithValue("@NAM_SINH", nhansumodel.NamSinh);
                    cmd.Parameters.AddWithValue("@CHUC_VU", nhansumodel.ChucVu);
                    cmd.Parameters.AddWithValue("@QUE_QUAN", nhansumodel.QueQuan);
                    cmd.Parameters.AddWithValue("@SO_DIEN_THOAI", nhansumodel.SoDienThoai);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        public bool DeleteEmployee(int id)
        {
            try
            {
                string sqlAccount = "DELETE FROM ACCOUNT WHERE ID_NHAN_SU = @ID";
                string sqlEmployee = "DELETE FROM NHAN_SU WHERE ID_NHAN_SU = @ID";

                using (SqlCommand cmdAccount = new SqlCommand(sqlAccount, conn))
                {
                    cmdAccount.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmdAccount.ExecuteNonQuery(); 
                    conn.Close();
                }

                using (SqlCommand cmdEmployee = new SqlCommand(sqlEmployee, conn))
                {
                    cmdEmployee.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    int rowsAffected = cmdEmployee.ExecuteNonQuery(); 
                    conn.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public DataTable SearchNhanSu(string searchTerm)
        {
            string sql = "SELECT * FROM NHAN_SU WHERE ID_NHAN_SU LIKE @SearchTerm";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);  

                    return resultTable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }



        //----------------------------------------------------------------------------------------------
        //Được chỉnh sửa
        public bool CheckEmployeeExists(int idNhanSu)
        {
            string sql = "SELECT COUNT(*) FROM NHAN_SU WHERE ID_NHAN_SU = @ID_NHAN_SU";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_NHAN_SU", idNhanSu);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
