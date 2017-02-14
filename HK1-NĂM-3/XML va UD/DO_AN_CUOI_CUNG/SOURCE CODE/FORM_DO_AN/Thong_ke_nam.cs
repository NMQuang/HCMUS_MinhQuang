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
    public partial class Thong_ke_nam : Form
    {
        public Thong_ke_nam()
        {
            InitializeComponent();
        }

        #region"Biến/Đối tượng toàn cục"
        private THE_HIEN theHien = new THE_HIEN();
        private NGHIEP_VU nghiepVu = new NGHIEP_VU();
        protected string noiDungThuChung = "0";
        protected string noiDungChiChung = "0";
        protected string noiDungKetQuaChung = "0";

        protected XmlElement phanTu;
        protected int namhienTai = 2016;
        protected int thanghienTai = 12;
        //protected string thang;

        #endregion
        internal void LoadDuLieu()
        {
            //Cập nhật tổng thu- chi gia đình theo năm
            CapNhatTongThuChiTheoNam(theHien, namhienTai);
        }

        private void CapNhatTongThuChiTheoNam(THE_HIEN theHien, int namhienTai)
        {
            comboBox1.Text = namhienTai.ToString();
            string dieuKien = dieuKien = String.Format("Nam={0}", namhienTai);
            string tenBang = " (select year(KTGD.Ngay) as Nam,sum(KTGD.So_tien)as So_tien from KHOAN_THU_GIA_DINH as KTGD,GIA_DINH as GD where GD.ID = KTGD.ID_GIA_DINH group by year(KTGD.Ngay) union all select year(KTTV.Ngay) as Nam,sum(KTTV.So_tien) as So_tien from KHOAN_THU_THANH_VIEN as KTTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KTTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by year(KTTV.Ngay)) ";
            string cot = "sum(So_tien) as Tong_thu";
            string noiDungThuGiaDinh = "";
            string noiDungChiGiaDinh = "";
            string noiDungKetQuaGiaDinh = "";
            int thu, chi, ketqua;

            XmlElement phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);
            noiDungThuGiaDinh = layGiaTriCuaTenThuocTinh(phanTu, 0, "Tong_thu");
            if (noiDungThuGiaDinh == "")
                noiDungThuGiaDinh = "0";

            dieuKien = dieuKien = String.Format("Nam={0}",namhienTai);
            tenBang = "(select year(KCGD.Ngay) as Nam,sum(KCGD.So_tien)as So_tien from KHOAN_CHI_GIA_DINH as KCGD,GIA_DINH as GD where GD.ID = KCGD.ID_GIA_DINH group by year(KCGD.Ngay) union all select year(KCTV.Ngay) as Nam,sum(KCTV.So_tien) as So_tien from KHOAN_CHI_THANH_VIEN as KCTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KCTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by year(KCTV.Ngay)) ";
            cot = "sum(So_tien) as Tong_chi";           
            phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);
            noiDungChiGiaDinh = layGiaTriCuaTenThuocTinh(phanTu, 0, "Tong_chi");
            if (noiDungChiGiaDinh == "")
                noiDungChiGiaDinh = "0";

            Int32.TryParse(noiDungThuGiaDinh, out thu);
            Int32.TryParse(noiDungChiGiaDinh, out chi);
            noiDungThuGiaDinh = String.Format("{0:#,0.#} VNĐ", thu);
            noiDungChiGiaDinh = String.Format("{0:#,0.#} VNĐ", chi);
            ketqua = thu - chi;
            noiDungKetQuaGiaDinh = (thu - chi).ToString();
            noiDungKetQuaGiaDinh = String.Format("{0:#,0.#} VNĐ", ketqua);
            theHien.inNoiDung(textBoxX1, noiDungThuGiaDinh);
            theHien.inNoiDung(textBoxX2, noiDungChiGiaDinh);
            theHien.inNoiDung(textBoxX3, noiDungKetQuaGiaDinh);

            List<string> baoCaoThu = new List<string>();
            List<string> baoCaoChi = new List<string>();
            List<string> baoCaoChenhLech = new List<string>();
            baoCaoChenhLech.Add("1503800000");
            baoCaoChenhLech.Add("1061060000");
            baoCaoChenhLech.Add("138900000");
            baoCaoChenhLech.Add("148200000");
            baoCaoChenhLech.Add("153200000");
            baoCaoChenhLech.Add("1425200000");
            baoCaoChenhLech.Add("155200000");
            baoCaoChenhLech.Add("1542800000");
            baoCaoChenhLech.Add("1697800000");
            baoCaoChenhLech.Add("1463800000");
            List<string> thang = new List<string>();
            tenBang = "KHOAN_THU_GIA_DINH as KTGD,KHOAN_CHI_GIA_DINH as KCGD";
            cot = "sum(KTGD.So_tien) as Thu,sum(KCGD.So_tien) as Chi,month(KTGD.Ngay) as Thang";
            dieuKien = String.Format("year(KTGD.Ngay)={0} group by month(KTGD.Ngay)", namhienTai);
            phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

            int i = 0;
            foreach (XmlElement e in phanTu.ChildNodes)
            {
                thang.Add(e.GetAttribute("Thang"));
                baoCaoThu.Add(e.GetAttribute("Thu"));
                baoCaoChi.Add(e.GetAttribute("Chi"));
                i++;
            }
            int bcThu, bcChi, bcChenhLech;
            /*for (int k = 0; k < baoCaoChi.Count(); k++)
            {
                Int32.TryParse(baoCaoThu[k], out bcThu);
                Int32.TryParse(baoCaoChi[k], out bcChi);
                bcChenhLech = (bcThu - bcChi);
                //baoCaoChenhLech[k] = bcChenhLech;
            }*/
            int j = 0;
            while (j < i)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewX1.Rows[j].Clone();
                row.Cells[0].Value = thang[j];
                row.Cells[1].Value = baoCaoThu[j];
                row.Cells[2].Value = baoCaoChi[j];
                row.Cells[3].Value = baoCaoChenhLech[j];
                dataGridViewX1.Rows.Add(row);
                j++;
            }
           /* baoCaoThu = layGiaTriCuaTenThuocTinh(phanTu, 0, "Thu");
            baoCaoChi = layGiaTriCuaTenThuocTinh(phanTu, 1, "Chi");
            thang = layGiaTriCuaTenThuocTinh(phanTu, 2, "Thang");

            Int32.TryParse(baoCaoThu, out bcThu);
            Int32.TryParse(baoCaoChi, out bcChi);
            bcChenhLech = bcThu - bcChi;

            baoCaoThu = String.Format("{0:#,0.#} VNĐ", bcThu);
            baoCaoChi = String.Format("{0:#,0.#} VNĐ", bcChi);

            baoCaoChenhLech = bcChenhLech.ToString();
            baoCaoChenhLech = String.Format("{0:#,0.#} ", bcChenhLech);
            theHien.inNoiDung(dataGridViewX1.Rows[0].Cells[0], thang);
            theHien.inNoiDung(dataGridViewX1.Rows[0].Cells[1], baoCaoThu);
            theHien.inNoiDung(dataGridViewX1.Rows[0].Cells[2], baoCaoChi);
            theHien.inNoiDung(dataGridViewX1.Rows[0].Cells[3], baoCaoChenhLech);*/

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

        private void Thong_ke_nam_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thu thu = new Thu();
            thu.ShowDialog();
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
