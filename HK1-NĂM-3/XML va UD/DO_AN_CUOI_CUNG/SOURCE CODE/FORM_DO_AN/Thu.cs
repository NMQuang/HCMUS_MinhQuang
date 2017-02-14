using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM_DO_AN
{
    public partial class Thu : Form
    {
        public Thu()
        {
            InitializeComponent();
        }

        private THE_HIEN theHien = new THE_HIEN();
        private NGHIEP_VU nghiepVu = new NGHIEP_VU();
        internal void LoadDuLieu()
        {


            //Lấy thông tin thu của gia đình và các thành viên
            LayThongTinThu(theHien);
        }

        private void LayThongTinThu(THE_HIEN theHien)
        {
            string tenBang = "";
            string cot = "";
            string dieuKien = "";
            XmlElement phanTu;
            //string[] a = new string[4];
            
           
            List<string> tenThanhVien = new List<string>();
            List<string> ngay = new List<string>();
            List<string> soTien = new List<string>();

            //Lấy thông tin thu riêng
            string loaiThu = "Riêng";
            tenBang = "KHOAN_THU_THANH_VIEN as KTTV,THANH_VIEN as TV";
            cot = "TV.Ho_ten as Ho_ten,KTTV.Ngay as Ngay,KTTV.So_tien as So_tien";
            dieuKien = "TV.ID = KTTV.ID_THANH_VIEN ";
            phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

            int i = 0;
            foreach (XmlElement tam in phanTu.ChildNodes)
            {
                //khoanThu.Add(tam.GetAttribute("Khoan_thu"));
                tenThanhVien.Add(tam.GetAttribute("Ho_ten"));
                ngay.Add(tam.GetAttribute("Ngay"));
                soTien.Add(tam.GetAttribute("So_tien"));
                i++;
            }
            
           
             int j = 0;
            
              while(j < i)
              {
                  DataGridViewRow row = (DataGridViewRow)dataGridViewX2.Rows[j].Clone();
                  row.Cells[0].Value = soTien[j];
                  row.Cells[1].Value = tenThanhVien[j];
                  row.Cells[2].Value = loaiThu;
                  row.Cells[3].Value = ngay[j];
                  dataGridViewX2.Rows.Add(row);
                  j++;
              }

              string tongThu = "";
              tenBang = " KHOAN_THU_THANH_VIEN as KTTV,THANH_VIEN as TV";
              cot = "sum(KTTV.So_tien) as Tong_thu";
              dieuKien = "TV.ID = KTTV.ID_THANH_VIEN";
              phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

              tongThu = layGiaTriCuaTenThuocTinh(phanTu, 0, "Tong_thu");
              int thu;
              Int32.TryParse(tongThu, out thu);
              tongThu = String.Format("{0:#,0.#} VNĐ", thu);

              theHien.inNoiDung(textBoxX1, tongThu);
            

        }

        private string layGiaTriCuaTenThuocTinh(XmlElement phanTu, int viTri, string tenThuocTinh)
        {
            if (phanTu.ChildNodes.Count > 0 && phanTu.ChildNodes.Count >= viTri)
            {
                int i = 0;
                foreach (XmlElement e in phanTu.ChildNodes)
                {
                    if (i == viTri)
                        return e.GetAttribute(tenThuocTinh);
                    i++;
                }
            }
            return "";
        }
        private void Thu_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            buttonX2.Enabled = false;
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thong_ke thongKe = new Thong_ke();
            thongKe.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chi chi = new Chi();
            chi.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thong_ke thongKe = new Thong_ke();
            thongKe.ShowDialog();
        }




      
    }
}
