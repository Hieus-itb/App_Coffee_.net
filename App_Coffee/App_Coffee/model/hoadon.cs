using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Coffee.model
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime Ngay { get; set; }
        public TimeSpan Gio { get; set; }
        public float TongChiPhi { get; set; }
        public float TongTien { get; set; }
    }
}
