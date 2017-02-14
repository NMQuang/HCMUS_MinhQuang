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
using FORM_DO_AN.ServiceReference1;

namespace FORM_DO_AN
{
    public partial class Trang_chu : Form
    {
        int namHienTai = 0;
        int thangHienTai = 0;
        THE_HIEN TheHien = new THE_HIEN();
        public Trang_chu()
        {
            InitializeComponent();
        }

        #region"Biến/Đối tượng toàn cục"
        protected string noiDungThanhVien1 = "";
        protected string noiDungThanhVien2 = "";
        protected string noiDungThanhVien3 = "";
        protected string noiDungThanhVien4 = "";
        protected string noiDungThuChung = "0";
        protected string noiDungChiChung = "0";
        protected string noiDungKetQuaChung = "0";

        protected XmlElement phanTu;
        private NGHIEP_VU nghiepVu = new NGHIEP_VU();
        protected List<Button> danhSachNam = new List<Button>(5);
        protected List<Button> danhSachThang = new List<Button>(12);
        private THE_HIEN theHien = new THE_HIEN();

        protected int namhienTai = DateTime.Now.Year;
        protected int thanghienTai =9;
        
        #endregion

        internal void Load()
        {
            string dieuKien = "";
            string cot = "";
            string tenBang = "";
            int thu = 0;
            int chi = 0;
            XmlElement phanTuThu;
            XmlElement phanTuChi;

            buttonNam1.Focus();

            foreach (Control dieuKhien in panelDanhSachThang.Controls)
            {
                if(dieuKhien.Text == thanghienTai.ToString()+"/")
                {
                    dieuKhien.Focus();
                    break;
                }
            }

            //Cập nhật thông tin thu chi các thành viên
           CapNhatThongTinThuChiCacThanhVien(theHien, namhienTai, thanghienTai);
            //Cập nhật thu chi chung gia đình
            CapNhapThuChiChungGiaDinh(theHien, thanghienTai, namhienTai);
            //Cập nhật thống kê tháng
          CapNhatThongKeTheoThang(theHien, namhienTai);
            //Cập nhât thống kê năm
          CapNhatThongKeTheoNam(theHien, namhienTai);
        }

        private void CapNhatThongKeTheoNam(THE_HIEN theHien, int namhienTai) 
        {
            string cot = "";
            string tenBang = "";
            XmlElement phanTuThu, phanTuChi;
            cot = "Nam as Thoi_gian, sum(So_tien) as Tong_thu";
            tenBang = "(select year(KTGD.Ngay)as Nam,sum(KTGD.So_tien)as So_tien from KHOAN_THU_GIA_DINH as KTGD,GIA_DINH as GD where GD.ID = KTGD.ID_GIA_DINH group by year(KTGD.Ngay) union all select year(KTTV.Ngay) as Nam,sum(KTTV.So_tien) as So_tien from KHOAN_THU_THANH_VIEN as KTTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KTTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by year(KTTV.Ngay)) group by Nam order by Nam DESC";
            phanTuThu = nghiepVu.LayDuLieuBang(tenBang, cot, "");

            cot = "Nam as Thoi_gian, sum(So_tien) as Tong_chi";
            tenBang = "(select year(KCGD.Ngay)as Nam,sum(KCGD.So_tien)as So_tien from KHOAN_CHI_GIA_DINH as KCGD,GIA_DINH as GD where GD.ID = KCGD.ID_GIA_DINH group by year(KCGD.Ngay) union all select year(KCTV.Ngay)as Nam,sum(KCTV.So_tien)as So_tien from KHOAN_CHI_THANH_VIEN as KCTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KCTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by year(KCTV.Ngay)) group by Nam order by Nam DESC";
            phanTuChi = nghiepVu.LayDuLieuBang(tenBang, cot, "");

            theHien.capNhatLaiPanel(panelEx2, phanTuThu, phanTuChi, namhienTai);
        }

        private void CapNhatThongKeTheoThang(THE_HIEN theHien, int namhienTai)
        {
            string cot = "";
            string tenBang = "";
            string dieuKien = "";
            XmlElement phanTuThu, phanTuChi;
            cot = "Thang &'/'& Nam as Thoi_gian,Sum(So_tien) as Tong_thu";
            tenBang = "(select month(KTGD.Ngay) as Thang,year(KTGD.Ngay)as Nam,sum(KTGD.So_tien)as So_tien from KHOAN_THU_GIA_DINH as KTGD,GIA_DINH as GD where GD.ID = KTGD.ID_GIA_DINH group by year(KTGD.Ngay),month(KTGD.Ngay) union all select month(KTTV.Ngay) as Thang, year(KTTV.Ngay) as Nam, sum(KTTV.So_tien) as So_tien from KHOAN_THU_THANH_VIEN as KTTV, GIA_DINH as GD1, THANH_VIEN as TV where KTTV.ID_THANH_VIEN = TV.ID and TV.ID_GIA_DINH = GD1.ID group by year(KTTV.Ngay), month(KTTV.Ngay))";
            dieuKien = String.Format("Nam={0} group by Thang,Nam order by Nam DESC",namhienTai);
            phanTuThu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

            cot = "Thang &'/'& Nam as Thoi_gian,Sum(So_tien) as Tong_chi";
            tenBang = "(select month(KCGD.Ngay) as Thang,year(KCGD.Ngay)as Nam,sum(KCGD.So_tien)as So_tien from KHOAN_CHI_GIA_DINH as KCGD,GIA_DINH as GD where GD.ID = KCGD.ID_GIA_DINH group by year(KCGD.Ngay),month(KCGD.Ngay) union all select month(KCTV.Ngay) as Thang, year(KCTV.Ngay) as Nam, sum(KCTV.So_tien) as So_tien from KHOAN_CHI_THANH_VIEN as KCTV, GIA_DINH as GD1, THANH_VIEN as TV where KCTV.ID_THANH_VIEN = TV.ID and TV.ID_GIA_DINH = GD1.ID group by year(KCTV.Ngay), month(KCTV.Ngay))";
            dieuKien = String.Format("Nam={0} group by Thang,Nam order by Nam DESC ", namhienTai);
            phanTuChi = nghiepVu.LayDuLieuBang(tenBang,cot,dieuKien);
            theHien.capNhatLaiPanel(panelDanhSachThang, phanTuThu, phanTuChi, namhienTai);
        }

        private void CapNhapThuChiChungGiaDinh(THE_HIEN theHien, int thanghienTai, int namhienTai)
        {
            string dieuKien = dieuKien = String.Format("year(Ngay)={0} and month(Ngay)={1}", namhienTai, thanghienTai);
            string tenBang = "KHOAN_THU_GIA_DINH";
            string cot = "sum(So_tien) as So_tien";
            string noiDungThuGiaDinh = "";
            string noiDungChiGiaDinh = "";
            string noiDungKetQuaGiaDinh = "";
            int thu, chi, ketqua;

            XmlElement phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);
            noiDungThuGiaDinh = layGiaTriCuaTenThuocTinh(phanTu, 0, "So_tien");
            if (noiDungThuGiaDinh == "")
                noiDungThuGiaDinh = "0";

            tenBang = "KHOAN_CHI_GIA_DINH";
            phanTu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);
            noiDungChiGiaDinh = layGiaTriCuaTenThuocTinh(phanTu, 0, "So_tien");
            if (noiDungChiGiaDinh == "")
                noiDungChiGiaDinh = "0";

            Int32.TryParse(noiDungThuGiaDinh, out thu);
            Int32.TryParse(noiDungChiGiaDinh, out chi);

            noiDungThuGiaDinh = String.Format("{0:#,0.#} VNĐ", thu);
            noiDungChiGiaDinh = String.Format("{0:#,0.#} VNĐ", chi);

            ketqua = thu - chi;
            noiDungKetQuaGiaDinh = (thu - chi).ToString();
            noiDungKetQuaGiaDinh = String.Format("{0:#,0.#} VNĐ", ketqua);
            theHien.inNoiDung(labelThuChung, "+ " + noiDungThuGiaDinh);
            theHien.inNoiDung(labelChiChung, "- " + noiDungChiGiaDinh);
            theHien.inNoiDung(labelKetQuaChung, "=> " + noiDungKetQuaGiaDinh);
        }

        private void CapNhatThongTinThuChiCacThanhVien(THE_HIEN theHien, int namhienTai, int thanghienTai)
        {
            string dieuKien = "";
            string cot = "";
            string tenBang = "";
            XmlElement phanTuThu, phanTuChi;
            //Lấy nội dung các thành viên trong khoản thu
            cot = "TV1.Ho_ten as Ho_ten, sum(KTTV.So_tien) as So_tien";
            tenBang = "KHOAN_THU_THANH_VIEN as KTTV, THANH_VIEN as TV1";
            dieuKien = String.Format("KTTV.ID_THANH_VIEN = TV1.ID and month(KTTV.Ngay) = {0} and year(KTTV.Ngay) = {1} group by year(KTTV.Ngay), month(KTTV.Ngay), TV1.Ho_ten ", thanghienTai, namhienTai);
            phanTuThu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);
            //Lấy nội dung các thành viên trong khoản chi
            cot = "TV2.Ho_ten as Ho_ten, sum(KCTV.So_tien) as So_tien";
            tenBang = "KHOAN_CHI_THANH_VIEN as KCTV, THANH_VIEN as TV2";
            dieuKien = String.Format("KCTV.ID_THANH_VIEN = TV2.ID and month(KCTV.Ngay) = {0} and year(KCTV.Ngay) = {1} group by year(KCTV.Ngay), month(KCTV.Ngay), TV2.Ho_ten ", thanghienTai, namhienTai);
            phanTuChi = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

            noiDungThanhVien1 = taoNoiDungThanhVien(phanTuThu, phanTuChi, 0);
            noiDungThanhVien2 = taoNoiDungThanhVien(phanTuThu, phanTuChi, 1);
            noiDungThanhVien3 = taoNoiDungThanhVien(phanTuThu, phanTuChi, 2);
            noiDungThanhVien4 = taoNoiDungThanhVien(phanTuThu, phanTuChi, 3);
            

            //ĐƯa dữ liệu ra giao diện
            theHien.inNoiDung(labelThanhVien1, noiDungThanhVien1);
            theHien.inNoiDung(labelThanhVien2, noiDungThanhVien2);
            theHien.inNoiDung(labelThanhVien3, noiDungThanhVien3);
            theHien.inNoiDung(labelThanhVien4, noiDungThanhVien4);
        }

        private string taoNoiDungThanhVien(XmlElement phanTuThu, XmlElement phanTuChi, int viTri)
        {
            int thu = 0;
            int chi = 0;
            int ketqua = 0;
            string tongThu = "0";
            string tongChi = "0";
            string ketQua = "0";
            string thanhVien = "";

            tongThu = layGiaTriCuaTenThuocTinh(phanTuThu, viTri, "So_tien");
            tongChi = layGiaTriCuaTenThuocTinh(phanTuChi, viTri, "So_tien");
            thanhVien = layGiaTriCuaTenThuocTinh(phanTuThu, viTri, "Ho_ten") + "\n\n\n";
            Int32.TryParse(tongThu, out thu);
            Int32.TryParse(tongChi, out chi);
            tongThu = String.Format("{0:#,0.#} VNĐ", thu);
            tongChi = String.Format("{0:#,0.#} VNĐ", chi);
            thanhVien += "+ " + tongThu + "\n";
            thanhVien += "- " + tongChi +"\n";

            ketqua = thu - chi;
            ketQua = (thu - chi).ToString();
            ketQua = String.Format("{0:#,0.#} VNĐ", ketqua);
            thanhVien += "=> " + ketQua;
            return thanhVien;
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

        private void buttonThang2_Click(object sender, EventArgs e)
        {

        }

        private void buttonNam3_Click(object sender, EventArgs e)
        {
            /*string[] tu = buttonNam3.Text.Split('\n');
            Int32.TryParse(tu[0], out namhienTai);
            buttonThang2.Select();
            tu = buttonThang1.Text.Split('/');
            Int32.TryParse(tu[0], out thanghienTai);
            CapNhatThongKeTheoThang(theHien, namhienTai);
            CapNhatThongTinThuChiCacThanhVien(theHien, namhienTai, thanghienTai);
            CapNhapThuChiChungGiaDinh(theHien, thanghienTai, namhienTai);*/
            
        }

        private void groupBoxThanhVien3_Enter(object sender, EventArgs e)
        {

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
