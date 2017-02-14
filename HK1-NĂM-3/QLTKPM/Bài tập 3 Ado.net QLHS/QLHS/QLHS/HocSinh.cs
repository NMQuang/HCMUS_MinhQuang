using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHS
{
    public partial class HocSinh : Form
    {
        public HocSinh()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        private void HocSinh_Load(object sender, EventArgs e)
        {
           // kn.loadComboBox(cbo_malop, "Lop", "tenlop", "malop");
            dgv_HocSinh.DataSource = kn.select_procedure("select_hocsinh");
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(txt_mahocsinh.Text == "" || txt_tenhocsinh.Text == "")
            {
                MessageBox.Show("Mã học sinh, tên và mã lớp không được để trống.");
                txt_mahocsinh.Focus();
            }
            else
            {
                DataTable dt = new DataTable();
                dt = kn.truyVan("select*from HocSinh where maHocSinh = '"+txt_mahocsinh.Text+"'");
                if(dt.Rows.Count > 0)
                {
                    
                    MessageBox.Show("Đã tồn tại mã học sinh","Lỗi");
                }
                else
                {
                    dt = null;
                    dt = new DataTable();
                    dt = kn.truyVan("select*from Lop where maLop = '" + txt_malop.Text + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại mã lớp đã nhập", "Lỗi");
                    }else
                    {
                        int c;
                        if(txt_dienthoai.Text != "" && !int.TryParse(txt_dienthoai.Text,out c))
                        {
                            MessageBox.Show("Số điện thoại không được phép nhâp bằng chữ","Lỗi");
                        }else
                        {
                            string gt = "true";
                            if(rbn_nu.Checked == true)
                            {
                                gt = "False";
                            }

                            kn.add_hocSinh(txt_mahocsinh.Text, txt_tenhocsinh.Text, txt_malop.Text, dtp_ngaysinh.Value, gt, double.Parse(txt_dienthoai.Text));
                            dgv_HocSinh.DataSource = kn.select_procedure("select_hocsinh");
                            xoaChu();
                            MessageBox.Show("Thêm thành công");
                        }
                    }
                }
            }
        }

        private void dgv_HocSinh_Click(object sender, EventArgs e)
        {
            int r = dgv_HocSinh.CurrentCell.RowIndex;
            btn_them.Enabled = false;
            txt_mahocsinh.Enabled = false;
            txt_mahocsinh.Text = dgv_HocSinh.Rows[r].Cells["mahocsinh"].Value.ToString();
            txt_tenhocsinh.Text = dgv_HocSinh.Rows[r].Cells["tenhocsinh"].Value.ToString();
            txt_malop.Text = dgv_HocSinh.Rows[r].Cells["malop"].Value.ToString();
            txt_dienthoai.Text = dgv_HocSinh.Rows[r].Cells["sdt"].Value.ToString();
           
            if(dgv_HocSinh.Rows[r].Cells["gioitinh"].Value.ToString() == "Nam")
            {
                rbn_nam.Checked = true;
            }else
            {
                rbn_nu.Checked = true;
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_mahocsinh.Text == "" || txt_tenhocsinh.Text == "" )
            {
                MessageBox.Show("Mã học sinh, tên và mã lớp không được để trống.");
                txt_mahocsinh.Focus();
            }
            else
            {
                DataTable dt;
                
                    dt = null;
                    dt = new DataTable();
                    dt = kn.truyVan("select*from Lop where maLop = '" + txt_malop.Text + "'");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại mã lớp đã nhập", "Lỗi");
                    }
                    else
                    {
                        int c;
                        if (txt_dienthoai.Text != "" && !int.TryParse(txt_dienthoai.Text, out c))
                        {
                            MessageBox.Show("Số điện thoại không được phép nhâp bằng chữ", "Lỗi");
                        }
                        else
                        {
                            string gt = "true";
                            if (rbn_nu.Checked == true)
                            {
                                gt = "False";
                            }
                        DialogResult traloi;
                        traloi = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (traloi == DialogResult.Yes)
                        {
                            kn.update_hocSinh(txt_mahocsinh.Text, txt_tenhocsinh.Text, txt_malop.Text, dtp_ngaysinh.Value, gt, double.Parse(txt_dienthoai.Text));
                            dgv_HocSinh.DataSource = kn.select_procedure("select_hocsinh");
                            xoaChu();
                            MessageBox.Show("Sửa thành công");
                        }
                        }
                    }
                
            }
        }
        private void xoaChu()
        {
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            
            txt_mahocsinh.Enabled = true;
            txt_dienthoai.ResetText();
            txt_malop.ResetText();
            txt_tenhocsinh.ResetText();
            txt_mahocsinh.ResetText();
            rbn_nam.Checked = true;
        }

        private void txt_mahocsinh_KeyDown(object sender, KeyEventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if(txt_mahocsinh.Text == "")
            {
                MessageBox.Show("Bạn phải điền mã học sinh");
            }
            else
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {


                    kn.delete_hocsinh(txt_mahocsinh.Text);
                    dgv_HocSinh.DataSource = kn.select_procedure("select_hocsinh");
                    xoaChu();
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = kn.search_hocsinh(txt_timkiem.Text);
            dgv_HocSinh.DataSource = dt;
        }
    }
    
}
