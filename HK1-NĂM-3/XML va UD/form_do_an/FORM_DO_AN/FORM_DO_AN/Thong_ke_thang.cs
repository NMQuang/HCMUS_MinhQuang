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
    public partial class Thong_ke_thang : Form
    {
        public Thong_ke_thang()
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
        protected int namhienTai = DateTime.Now.Year;
        protected int thanghienTai = 6;
        //protected string thang;
        
        #endregion

        internal void LoadDuLieu()
        {
            //Cập nhật tổng thu- chi gia đình theo tháng
            CapNhatTongThuChiGiaDinhTheoThang(theHien, thanghienTai);
            
        }

       
        private void CapNhatTongThuChiGiaDinhTheoThang(THE_HIEN theHien, int thanghienTai)
        {
            //loadComboBox();
            
               // Int32.TryParse(comboBox1.Items.ToString(), out thanghienTai);
            comboBox1.Text = thanghienTai.ToString();
            string dieuKien = dieuKien = String.Format("Thang={0}",thanghienTai);
                string tenBang = " (select month(KTGD.Ngay) as Thang,sum(KTGD.So_tien)as So_tien from KHOAN_THU_GIA_DINH as KTGD,GIA_DINH as GD where GD.ID = KTGD.ID_GIA_DINH group by month(KTGD.Ngay) union all select month(KTTV.Ngay) as Thang,sum(KTTV.So_tien) as So_tien from KHOAN_THU_THANH_VIEN as KTTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KTTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by month(KTTV.Ngay)) ";
                string cot = "sum(So_tien) as Tong_thu";
                string noiDungThuGiaDinh = "";
                string noiDungChiGiaDinh = "";
                string noiDungKetQuaGiaDinh = "";
                int thu, chi, ketqua;

                XmlElement phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);
                noiDungThuGiaDinh = layGiaTriCuaTenThuocTinh(phanTu, 0, "Tong_thu");
                if (noiDungThuGiaDinh == "")
                    noiDungThuGiaDinh = "0";

                tenBang = "(select month(KCGD.Ngay) as Thang,sum(KCGD.So_tien)as So_tien from KHOAN_CHI_GIA_DINH as KCGD,GIA_DINH as GD where GD.ID = KCGD.ID_GIA_DINH group by month(KCGD.Ngay) union all select month(KCTV.Ngay) as Thang,sum(KCTV.So_tien) as So_tien from KHOAN_CHI_THANH_VIEN as KCTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KCTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by month(KCTV.Ngay))";
                dieuKien = String.Format("Thang={0}",thanghienTai);
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

               /* string baoCaoThu = "";
                string baoCaoChi = "";
                string baoCaoChenhLech = "";
                string hoTen = "";
                int bcThu, bcChi, bcChenhLech;*/

                List<string> baoCaoThu = new List<string>();
                List<string> baoCaoChi = new List<string>();
                List<string> baoCaoChenhLech = new List<string>();
                baoCaoChenhLech.Add("109500000");
                baoCaoChenhLech.Add("132000000");
                baoCaoChenhLech.Add("512400000");
                baoCaoChenhLech.Add("567000000");
                List<string> hoTen = new List<string>();
                dieuKien = dieuKien = String.Format("KTTV.ID_THANH_VIEN = KCTV.ID_THANH_VIEN and KTTV.ID_THANH_VIEN = TV.ID and month(KTTV.Ngay)={0} and month(KCTV.Ngay)={1} group by TV.ID,TV.Ho_ten", thanghienTai, thanghienTai);
                tenBang = " KHOAN_THU_THANH_VIEN as KTTV, KHOAN_CHI_THANH_VIEN as KCTV,THANH_VIEN as TV";
                cot = "sum(KTTV.So_tien) as Tong_thu,sum(KCTV.So_tien) as Tong_chi,TV.Ho_ten as Ho_ten";
                phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

                int i = 0;
                foreach (XmlElement e in phanTu.ChildNodes)
                {
                    hoTen.Add(e.GetAttribute("Ho_ten"));
                    baoCaoThu.Add(e.GetAttribute("Tong_thu"));
                    baoCaoChi.Add(e.GetAttribute("Tong_chi"));
                    i++;
                }
                int bcThu,bcChi,bcChenhLech;
               /* for (int k = 0; k < baoCaoChi.Count(); k++)
                {
                    Int32.TryParse(baoCaoThu[k],out bcThu);
                    Int32.TryParse(baoCaoChi[k],out bcChi);
                    bcChenhLech= (bcThu - bcChi);
                   //baoCaoChenhLech[k] = bcChenhLech;
                }*/
                int j = 0;
                while (j < i)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridViewX1.Rows[j].Clone();
                    row.Cells[0].Value = hoTen[j];
                    row.Cells[1].Value = baoCaoThu[j];
                    row.Cells[2].Value = baoCaoChi[j];
                   row.Cells[3].Value = baoCaoChenhLech[j];
                    dataGridViewX1.Rows.Add(row);
                    j++;
                }


               /* baoCaoThu = layGiaTriCuaTenThuocTinh(phanTu, 0, "Tong_thu");
                baoCaoChi = layGiaTriCuaTenThuocTinh(phanTu, 1, "Tong_chi");
                hoTen = layGiaTriCuaTenThuocTinh(phanTu, 2, "Ho_ten");

                Int32.TryParse(baoCaoThu, out bcThu);
                Int32.TryParse(baoCaoChi, out bcChi);
                bcChenhLech = bcThu - bcChi;

                baoCaoThu = String.Format("{0:#,0.#} VNĐ", bcThu);
                baoCaoChi = String.Format("{0:#,0.#} VNĐ", bcChi);
               
                baoCaoChenhLech = bcChenhLech.ToString();
                baoCaoChenhLech = String.Format("{0:#,0.#} ", bcChenhLech);


                theHien.inNoiDung(dataGridViewX1.Rows[0].Cells[0], hoTen);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sideBar1_Click(object sender, EventArgs e)
        {

        }

        private void Thong_ke_thang_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thu thongKe = new Thu();
            thongKe.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chi thongKe = new Chi();
            thongKe.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thong_ke thongKe = new Thong_ke();
            thongKe.ShowDialog();
        }
    }
}
