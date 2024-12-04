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
    public partial class Goimon : Form
    {
        private Douongcontroller controller;
        public Goimon()
        {
            InitializeComponent();
            controller = new Douongcontroller();
            loadDouong();
        }
        public void loadDouong()
        {
            List<Douong> douongList = controller.GetAllDouong();

            dataGridView1.DataSource = douongList;

            dataGridView1.ReadOnly = true;

            // Đổi tên tiêu đề cột

            dataGridView1.Columns["MaDouong"].HeaderText = "Mã Đồ Uống";

            dataGridView1.Columns["TenDouong"].HeaderText = "Tên Đồ Uống";

            dataGridView1.Columns["Gia"].HeaderText = "Giá (VND)";

            dataGridView1.Columns["Chiphi"].HeaderText = "Chi Phí (VND)";
            // ẩn
            dataGridView1.Columns["Chiphi"].Visible = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
