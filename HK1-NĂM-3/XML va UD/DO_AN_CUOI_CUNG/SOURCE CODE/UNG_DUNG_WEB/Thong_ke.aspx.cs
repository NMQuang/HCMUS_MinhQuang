using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.UI.WebControls.WebParts;

namespace UNG_DUNG_WEB
{
    public partial class Thong_ke : System.Web.UI.Page
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

            //Cập nhật thông tin thu chi các thành viên
            CapNhatThongTinThuChiCacThanhVien(theHien, namhienTai, thanghienTai);
            //Cập nhật tổng thu- chi gia đình theo tháng
            CapNhatTongThuChiGiaDinhTheoThang(theHien, thanghienTai);
        }

        private void CapNhatTongThuChiGiaDinhTheoThang(THE_HIEN theHien, int thanghienTai)
        {
            string dieuKien = dieuKien = String.Format("Thang={0}", thanghienTai);
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
            dieuKien = String.Format("Thang={0}", thanghienTai);
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
            theHien.inNoiDung(Label1, noiDungThuGiaDinh);
            theHien.inNoiDung(Label2, noiDungChiGiaDinh);
            theHien.inNoiDung(Label3, noiDungKetQuaGiaDinh);


            //Bảng datagridview
            /*List<string> baoCaoThu = new List<string>();
            List<string> baoCaoChi = new List<string>();
            List<int> baoCaoChenhLech = new List<int>();
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
            int bcThu, bcChi, bcChenhLech;
            for (int k = 0; k < baoCaoChi.Count(); k++)
            {
                Int32.TryParse(baoCaoThu[k], out bcThu);
                Int32.TryParse(baoCaoChi[k], out bcChi);
                bcChenhLech = (bcThu - bcChi);
                //baoCaoChenhLech[k] = bcChenhLech;
            }
            int j = 0;
            while (j < i)
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[j].Clone();
                row.Cells[0].Value = hoTen[j];
                row.Cells[1].Value = baoCaoThu[j];
                row.Cells[2].Value = baoCaoChi[j];
                //row.Cells[3].Value = baoCaoChenhLech[j];
                GridView1.Rows.;
                j++;
            }*/
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
            thanhVien = layGiaTriCuaTenThuocTinh(phanTuThu, viTri, "Ho_ten") + " :";
            Int32.TryParse(tongThu, out thu);
            Int32.TryParse(tongChi, out chi);
            tongThu = String.Format("{0:#,0.#} VNĐ", thu);
            tongChi = String.Format("{0:#,0.#} VNĐ", chi);
            thanhVien += "+ " + tongThu;
            thanhVien += "- " + tongChi;

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

    }
}