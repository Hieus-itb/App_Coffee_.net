using App_Coffee.controller;
using App_Coffee.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Coffee.view
{
    public partial class Quanlydouong : Form
    {
        private Douongcontroller controller;
        public Quanlydouong()
        {
            InitializeComponent();
            controller = new Douongcontroller();
            loadDouong();
        }
        public void loadDouong() 
        {
            List<Douong> douong = controller.GetAllDouong();

            dataGridView1.DataSource = douong;

            dataGridView1.Columns["MaDouong"].HeaderText = "Mã Đồ Uống";
            dataGridView1.Columns["TenDouong"].HeaderText = "Tên Đồ Uống";
            dataGridView1.Columns["Gia"].HeaderText = "Giá (VND)";
            dataGridView1.Columns["Chiphi"].HeaderText = "Chi Phí (VND)";
        }
    }
}
