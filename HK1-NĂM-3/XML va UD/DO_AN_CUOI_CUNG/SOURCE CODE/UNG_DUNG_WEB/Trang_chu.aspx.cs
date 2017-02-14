using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UNG_DUNG_WEB.ServiceReference1;

namespace UNG_DUNG_WEB
{
    public partial class Trang_chu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load();
        }

        THE_HIEN TheHien = new THE_HIEN();
        #region"Biến/Đối tượng toàn cục"
        protected string noiDungThanhVien1 = "";
        protected string noiDungThanhVien2 = "";
        protected string noiDungThanhVien3 = "";
        protected string noiDungThanhVien4 = "";
        protected string noiDungNam1 = "";
        protected string noiDungNam2 = "";
        protected string noiDungNam3 = "";
        protected string noiDungThuChung = "0";
        protected string noiDungChiChung = "0";
        protected string noiDungKetQuaChung = "0";

        protected XmlElement phanTu;
        private NGHIEP_VU nghiepVu = new NGHIEP_VU();
        protected List<Button> danhSachNam = new List<Button>(5);
        protected List<Button> danhSachThang = new List<Button>(12);
        private THE_HIEN theHien = new THE_HIEN();

        protected int namhienTai = DateTime.Now.Year;
        protected int thanghienTai = 9;
        
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

            //Nam1.Focus();

           /* foreach (Control dieuKhien in danhSachTheoThang.Controls)
            {
                if(dieuKhien. == thanghienTai.ToString()+"/")
                {
                    dieuKhien.Focus();
                    break;
                }
            }*/

            //Cập nhật thông tin thu chi các thành viên
            CapNhatThongTinThuChiCacThanhVien(theHien, namhienTai, thanghienTai);
            //Cập nhật thu chi chung gia đình
            CapNhatThuChiChungGiaDinh(theHien, thanghienTai, namhienTai);
            //Cập nhật thống kê tháng
           // CapNhatThongKeTheoThang(theHien, namhienTai);
            //Cập nhât thống kê năm
           CapNhatThongKeTheoNam(theHien, namhienTai);
        }

        private void CapNhatThongKeTheoNam(THE_HIEN theHien, int namhienTai)
        {
            string cot = "";
            string tenBang = "";
            //string dieuKien = String.Format("Nam={0}", namhienTai);
            XmlElement phanTuThu, phanTuChi;
            
            cot = "Nam as Thoi_gian, sum(So_tien) as So_tien";
            tenBang = "(select year(KTGD.Ngay)as Nam,sum(KTGD.So_tien)as So_tien from KHOAN_THU_GIA_DINH as KTGD,GIA_DINH as GD where GD.ID = KTGD.ID_GIA_DINH group by year(KTGD.Ngay) union all select year(KTTV.Ngay) as Nam,sum(KTTV.So_tien) as So_tien from KHOAN_THU_THANH_VIEN as KTTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KTTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by year(KTTV.Ngay)) group by Nam order by Nam DESC";
            phanTuThu = nghiepVu.LayDuLieuBang(tenBang, cot, "");
            //noiDungThu = layGiaTriCuaTenThuocTinh(phanTuThu, 1, "Tong_thu");
            //theHien.inNoiDung()
            cot = "Nam as Thoi_gian, sum(So_tien) as So_tien";
            tenBang = "(select year(KCGD.Ngay)as Nam,sum(KCGD.So_tien)as So_tien from KHOAN_CHI_GIA_DINH as KCGD,GIA_DINH as GD where GD.ID = KCGD.ID_GIA_DINH group by year(KCGD.Ngay) union all select year(KCTV.Ngay)as Nam,sum(KCTV.So_tien)as So_tien from KHOAN_CHI_THANH_VIEN as KCTV,GIA_DINH as GD1,THANH_VIEN as TV where TV.ID= KCTV.ID_THANH_VIEN and TV.ID_GIA_DINH = GD1.ID group by year(KCTV.Ngay)) group by Nam order by Nam DESC";
            phanTuChi = nghiepVu.LayDuLieuBang(tenBang, cot, "");

            noiDungNam1 = taoNoiDungThanhVien(phanTuThu, phanTuChi, 0);
            noiDungNam2 = taoNoiDungThanhVien(phanTuThu, phanTuChi, 1);
            noiDungNam3 = taoNoiDungThanhVien(phanTuThu, phanTuChi, 2);

            theHien.inNoiDung(nam1, noiDungNam1);
            theHien.inNoiDung(nam2, noiDungNam2);
            theHien.inNoiDung(nam3, noiDungNam3);
        }

        private void CapNhatThongKeTheoThang(THE_HIEN theHien, int namhienTai)
        {
            string cot = "";
            string tenBang = "";
            string dieuKien = "";
            XmlElement phanTuThu, phanTuChi;
            cot = "Thang &'/'& Nam as Thoi_gian,Sum(So_tien) as Tong_thu";
            tenBang = "(select month(KTGD.Ngay) as Thang,year(KTGD.Ngay)as Nam,sum(KTGD.So_tien)as So_tien from KHOAN_THU_GIA_DINH as KTGD,GIA_DINH as GD where GD.ID = KTGD.ID_GIA_DINH group by year(KTGD.Ngay),month(KTGD.Ngay) union all select month(KTTV.Ngay) as Thang, year(KTTV.Ngay) as Nam, sum(KTTV.So_tien) as So_tien from KHOAN_THU_THANH_VIEN as KTTV, GIA_DINH as GD1, THANH_VIEN as TV where KTTV.ID_THANH_VIEN = TV.ID and TV.ID_GIA_DINH = GD1.ID group by year(KTTV.Ngay), month(KTTV.Ngay))";
            dieuKien = String.Format("Nam={0} group by Thang,Nam order by Nam DESC", namhienTai);
            phanTuThu = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);

            cot = "Thang &'/'& Nam as Thoi_gian,Sum(So_tien) as Tong_chi";
            tenBang = "(select month(KCGD.Ngay) as Thang,year(KCGD.Ngay)as Nam,sum(KCGD.So_tien)as So_tien from KHOAN_CHI_GIA_DINH as KCGD,GIA_DINH as GD where GD.ID = KCGD.ID_GIA_DINH group by year(KCGD.Ngay),month(KCGD.Ngay) union all select month(KCTV.Ngay) as Thang, year(KCTV.Ngay) as Nam, sum(KCTV.So_tien) as So_tien from KHOAN_CHI_THANH_VIEN as KCTV, GIA_DINH as GD1, THANH_VIEN as TV where KCTV.ID_THANH_VIEN = TV.ID and TV.ID_GIA_DINH = GD1.ID group by year(KCTV.Ngay), month(KCTV.Ngay))";
            dieuKien = String.Format("Nam={0} group by Thang,Nam order by Nam DESC ", namhienTai);
            phanTuChi = nghiepVu.LayDuLieuBang(tenBang, cot, dieuKien);
            //theHien.capNhatLaiPanel(danhSachTheoThang, phanTuThu, phanTuChi, namhienTai);
        }

        private void CapNhatThuChiChungGiaDinh(THE_HIEN theHien, int thanghienTai, int namhienTai)
        {
            string dieuKien = dieuKien = String.Format("year(Ngay)={0} and month(Ngay)={1}", namhienTai, thanghienTai);
            string tenBang = "KHOAN_THU_GIA_DINH";
            string cot = "sum(So_tien) as So_tien";
            string noiDungThuGiaDinh = "";
            string noiDungChiGiaDinh = "";
            string noiDungKetQuaGiaDinh = "";
            int thu, chi;

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

            noiDungKetQuaGiaDinh = (thu - chi).ToString();
            theHien.inNoiDung(tongThu, "+ " + noiDungThuGiaDinh + " VNĐ");
            theHien.inNoiDung(tongChi, "- " + noiDungChiGiaDinh + " VNĐ");
            theHien.inNoiDung(ketQua, "=> " + noiDungKetQuaGiaDinh + " VNĐ");
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


            //Đưa dữ liệu ra giao diện

            theHien.inNoiDung(thanhVien1, noiDungThanhVien1);
            theHien.inNoiDung(thanhVien2, noiDungThanhVien2);
            theHien.inNoiDung(thanhVien3, noiDungThanhVien3);
            theHien.inNoiDung(thanhVien4, noiDungThanhVien4);
            
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
            thanhVien = layGiaTriCuaTenThuocTinh(phanTuThu, viTri, "Ho_ten") +" :";
            Int32.TryParse(tongThu, out thu);
            Int32.TryParse(tongChi, out chi);
            tongThu = String.Format("{0:#,0.#} VNĐ", thu);
            tongChi = String.Format("{0:#,0.#} VNĐ", chi);
            thanhVien += "+ " + tongThu;
            thanhVien += "- " + tongChi;

            ketqua = thu - chi;
            ketQua = (thu - chi).ToString();
            ketQua = String.Format("{0:#,0.#} VNĐ", ketqua);
            thanhVien +="=> " + ketQua;
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

        protected void thongKe_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thong_ke.aspx");
        }
    }
}