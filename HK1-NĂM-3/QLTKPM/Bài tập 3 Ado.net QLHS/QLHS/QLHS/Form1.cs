using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace QLHS
{
    public partial class 
        Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ketnoi kn = new ketnoi();
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(txt_maLop.Text == "" || txt_tenLop.Text == "")
            {
                MessageBox.Show("Còn thiếu dữ liệu mã lớp và tên lớp");
            }else
            {
                DataTable dt = new DataTable();
                dt = kn.truyVan("select * from Lop where maLop = '" + txt_maLop.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã lớp đã tồn tại");
                }
                else
                {
                    kn.truyVan("insert into Lop values('" + txt_maLop.Text + "',N'" + txt_tenLop.Text + "','" + txt_khoaHoc.Text + "',N'" + txt_GVCN.Text + "')");
                    btn_lammoi_Click(sender, e);
                    xoaChu();
                    MessageBox.Show("Thêm thành công");
                }
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            dgv_Lop.DataSource = kn.truyVan("select * from Lop");
        }

        private void dgv_Lop_Click(object sender, EventArgs e)
        {
            int r = dgv_Lop.CurrentCell.RowIndex;
            txt_maLop.Enabled = false;
            btn_them.Enabled = false;
            txt_maLop.Text = dgv_Lop.Rows[r].Cells["maLop"].Value.ToString();
            txt_tenLop.Text = dgv_Lop.Rows[r].Cells["tenLop"].Value.ToString();
            txt_khoaHoc.Text = dgv_Lop.Rows[r].Cells["khoaHoc"].Value.ToString();
            txt_GVCN.Text = dgv_Lop.Rows[r].Cells["GVCN"].Value.ToString();

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            kn.truyVan("update Lop set tenLop = N'" + txt_tenLop.Text + "',khoaHoc ='" + txt_khoaHoc.Text + "',GVCN =N'" + txt_GVCN.Text + "' where maLop = '"+txt_maLop.Text+"'");
            MessageBox.Show("Sửa thành công");
            xoaChu();
            btn_lammoi_Click(sender, e);
        }

        private void xoaChu()
        {
            txt_maLop.Enabled = true;
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            txt_tenLop.ResetText();
            txt_maLop.ResetText();
            txt_khoaHoc.ResetText();
            txt_GVCN.ResetText();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_lammoi_Click(sender, e);
        }

        private void btn_huybo_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                xoaChu();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txt_maLop_TextChanged_1(object sender, EventArgs e)
        {
            if(txt_maLop.Enabled == true)
            btn_sua.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_maLop.Text != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    kn.truyVan("delete from Lop where maLop = '" + txt_maLop.Text + "'");
                    btn_lammoi_Click(sender, e);
                    xoaChu();
                }
            }
            else
            {
                MessageBox.Show("Không có mã lớp để xóa");
            }
        }
    }
}
