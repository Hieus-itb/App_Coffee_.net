using App_Coffee;
using App_Coffee.Controller;
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

        public bool AddEmployee(Nhansumodel nhansumodel, string taikhoan, string matkhau, string role)
        {
            try
            {
                string insertNhanSuSql = @"
                    INSERT INTO NHAN_SU (HO_VA_TEN, GIOI_TINH, NAM_SINH, CHUC_VU, QUE_QUAN, SO_DIEN_THOAI) 
                    VALUES (@HoVaTen, @GioiTinh, @NamSinh, @ChucVu, @QueQuan, @SoDienThoai);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertNhanSuSql, conn))
                {
                    cmd.Parameters.AddWithValue("@HoVaTen", nhansumodel.HoVaTen);
                    cmd.Parameters.AddWithValue("@GioiTinh", nhansumodel.GioiTinh);
                    cmd.Parameters.AddWithValue("@NamSinh", nhansumodel.NamSinh);
                    cmd.Parameters.AddWithValue("@ChucVu", nhansumodel.ChucVu);
                    cmd.Parameters.AddWithValue("@QueQuan", nhansumodel.QueQuan);
                    cmd.Parameters.AddWithValue("@SoDienThoai", nhansumodel.SoDienThoai);

                    OpenConnection();
                    int idNhanSu = Convert.ToInt32(cmd.ExecuteScalar());

                    return AddAccount(idNhanSu, taikhoan, matkhau, role);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }



        public bool AddAccount(int idNhanSu, string taikhoan, string matkhau, string role)
        {
            try
            {
                string hashedPassword = Accountcontroller.HashPassword(matkhau);
                string insertAccountSql = @"
                    INSERT INTO ACCOUNT (ID_NHAN_SU, TAIKHOAN, MATKHAU, CHUC_VU) 
                    VALUES (@IDNhanSu, @TaiKhoan, @MatKhau, @ChucVu)";

                using (SqlCommand cmd = new SqlCommand(insertAccountSql, conn))
                {
                    cmd.Parameters.AddWithValue("@IDNhanSu", idNhanSu);
                    cmd.Parameters.AddWithValue("@TaiKhoan", taikhoan);  
                    cmd.Parameters.AddWithValue("@MatKhau", hashedPassword);  
                    cmd.Parameters.AddWithValue("@ChucVu", role);

                    OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
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
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
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
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public int GetIDNhanvien()
        {
            int idNV = 0;  // Giá trị mặc định nếu không tìm thấy ID_NHAN_SU
            string sql = "SELECT MAX(ID_NHAN_SU) FROM NHAN_SU";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    
                    if (result != DBNull.Value)
                    {
                        idNV = Convert.ToInt32(result);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
                {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return idNV + 1;
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
