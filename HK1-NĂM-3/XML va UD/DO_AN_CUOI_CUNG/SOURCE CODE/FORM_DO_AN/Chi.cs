using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FORM_DO_AN
{
    public partial class Chi : Form
    {
        public Chi()
        {
            InitializeComponent();
        }

        private THE_HIEN theHien = new THE_HIEN();
        private NGHIEP_VU nghiepVu = new NGHIEP_VU();

        internal void LoadDuLieu()
        {


            //Lấy thông tin chi của gia đình và các thành viên
            LayThongTinChi(theHien);
        }
        private void LayThongTinChi(THE_HIEN theHien)
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
            string loaiChi = "Riêng";
            tenBang = "KHOAN_CHI_THANH_VIEN as KCTV,THANH_VIEN as TV";
            cot = "TV.Ho_ten as Ho_ten,KCTV.Ngay as Ngay,KCTV.So_tien as So_tien";
            dieuKien = "TV.ID = KCTV.ID_THANH_VIEN ";
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

            while (j < i)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewX1.Rows[j].Clone();
                row.Cells[0].Value = soTien[j];
                row.Cells[1].Value = tenThanhVien[j];
                row.Cells[2].Value = loaiChi;
                row.Cells[3].Value = ngay[j];
                dataGridViewX1.Rows.Add(row);
                j++;
            }
            string tongChi = "";
            tenBang = " KHOAN_CHI_THANH_VIEN as KCTV,THANH_VIEN as TV";
            cot = "sum(KCTV.So_tien) as Tong_chi";
            dieuKien = "TV.ID = KCTV.ID_THANH_VIEN";
            phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

            tongChi = layGiaTriCuaTenThuocTinh(phanTu, 0, "Tong_chi");
            int chi;
            Int32.TryParse(tongChi, out chi);
            tongChi = String.Format("{0:#,0.#} VNĐ", chi);

            theHien.inNoiDung(textBoxX1, tongChi);



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

        private void Chi_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            buttonX3.Enabled = false;
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thong_ke thongKe = new Thong_ke();
            thongKe.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thu thu = new Thu();
            thu.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thong_ke thongKe = new Thong_ke();
            thongKe.ShowDialog();
        }
    }
}
