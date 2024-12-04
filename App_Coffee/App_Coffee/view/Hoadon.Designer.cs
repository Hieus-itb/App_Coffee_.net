namespace App_Coffee.view
{
    partial class Hoadon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            lbBan = new Label();
            label4 = new Label();
            lbNgay = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            btnThanhtoan = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(394, 18);
            label1.Name = "label1";
            label1.Size = new Size(162, 41);
            label1.TabIndex = 0;
            label1.Text = "HÓA ĐƠN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 84);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 1;
            label2.Text = "Bàn:";
            // 
            // lbBan
            // 
            lbBan.Location = new Point(120, 84);
            lbBan.Name = "lbBan";
            lbBan.Size = new Size(501, 20);
            lbBan.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 134);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày đặt:";
            // 
            // lbNgay
            // 
            lbNgay.Location = new Point(120, 134);
            lbNgay.Name = "lbNgay";
            lbNgay.Size = new Size(533, 20);
            lbNgay.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(288, 173);
            label6.Name = "label6";
            label6.Size = new Size(393, 41);
            label6.TabIndex = 5;
            label6.Text = "DANH SÁCH MÓN ĐÃ GỌI";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 232);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(864, 188);
            dataGridView1.TabIndex = 6;
            // 
            // btnThanhtoan
            // 
            btnThanhtoan.Location = new Point(799, 451);
            btnThanhtoan.Name = "btnThanhtoan";
            btnThanhtoan.Size = new Size(94, 29);
            btnThanhtoan.TabIndex = 7;
            btnThanhtoan.Text = "Thanh toán";
            btnThanhtoan.UseVisualStyleBackColor = true;
            btnThanhtoan.Click += btnThanhtoan_Click;
            // 
            // Hoadon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 514);
            Controls.Add(btnThanhtoan);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(lbNgay);
            Controls.Add(label4);
            Controls.Add(lbBan);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Hoadon";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lbBan;
        private Label label4;
        private Label lbNgay;
        private Label label6;
        private DataGridView dataGridView1;
        private Button btnThanhtoan;
    }
}