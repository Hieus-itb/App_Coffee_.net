using System;

namespace Model
{
   
    public class Nhansumodel
    {
        // Properties
        public int Id { get; set; } // ID_NHAN_SU
        public string HoVaTen { get; set; } // HO_VA_TEN
        public string GioiTinh { get; set; } // GIOI_TINH
        public int NamSinh { get; set; } // NAM_SINH
        public string ChucVu { get; set; } // CHUC_VU
        public string QueQuan { get; set; } // QUE_QUAN
        public string SoDienThoai { get; set; } // SO_DIEN_THOAI

        // Default Constructor
        public Nhansumodel() { }

        // Parameterized Constructor
        public Nhansumodel(int id, string hoVaTen, string gioiTinh, int namSinh, string chucVu, string queQuan, string soDienThoai)
        {
            Id = id;
            HoVaTen = hoVaTen;
            GioiTinh = gioiTinh;
            NamSinh = namSinh;
            ChucVu = chucVu;
            QueQuan = queQuan;
            SoDienThoai = soDienThoai;
        }

        // ToString Method
        public override string ToString()
        {
            return $"NhanSuModel{{ Id={Id}, HoVaTen='{HoVaTen}', GioiTinh='{GioiTinh}', NamSinh={NamSinh}, ChucVu='{ChucVu}', QueQuan='{QueQuan}', SoDienThoai='{SoDienThoai}' }}";
        }
    }
}
