using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Coffee.model
{
    internal class Douong
    {
        public string MaDouong { get; set; }
        public string TenDouong { get; set; }
        public float Gia { get; set; }
        public float Chiphi { get; set; }

        public Douong() { }
        public Douong(string maDouong, string tenDouong, float gia, float chiphi)
        {
            MaDouong = maDouong;
            TenDouong = tenDouong;
            Gia = gia;
            Chiphi = chiphi;
        }

    }
}
