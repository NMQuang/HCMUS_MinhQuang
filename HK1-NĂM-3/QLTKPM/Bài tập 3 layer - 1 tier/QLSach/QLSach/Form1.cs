using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSach.Sach_BLL;
using QLSach.Sach_DTO;

namespace QLSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = SachBLL.LoadAllBook();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string maSach = textBoxX1.Text;
            string tenSach = textBoxX2.Text;
            float donGia = float.Parse(textBoxX3.Text);
            string loaiSach = textBoxX4.Text;
            int soLuong = int.Parse(textBoxX6.Text);
            string NXB = textBoxX5.Text;
            SACH_DTO sach = new SACH_DTO(maSach,tenSach,donGia,loaiSach,NXB,soLuong);
            SachBLL.AddBook(sach);
            dataGridViewX1.DataSource = SachBLL.LoadAllBook();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            SachBLL.DeleteBook(int.Parse(textBoxX1.Text));
            dataGridViewX1.DataSource = SachBLL.LoadAllBook();
        }
    }
}
