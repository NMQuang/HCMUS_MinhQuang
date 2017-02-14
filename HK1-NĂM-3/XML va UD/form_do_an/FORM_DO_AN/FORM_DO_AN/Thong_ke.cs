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
    public partial class Thong_ke : Form
    {
        public Thong_ke()
        {
            InitializeComponent();
        }
        #region"Biến/Đối tượng toàn cục"
        private THE_HIEN theHien = new THE_HIEN();
        private NGHIEP_VU nghiepVu = new NGHIEP_VU();
        protected string noiDungThanhVien1 = "";
        protected string noiDungThanhVien2 = "";
        protected string noiDungThanhVien3 = "";
        protected string noiDungThanhVien4 = "";
        protected string noiDungThuChung = "0";
        protected string noiDungChiChung = "0";
        protected string noiDungKetQuaChung = "0";

        protected XmlElement phanTu;
        protected int namhienTai = DateTime.Now.Year;
        protected int thanghienTai = 9;
        #endregion

        internal void LoadDuLieu()
        {
            //Cập nhât thông tin thu chi các thành viên
            CapNhatThongTinThuChiThanhVien(theHien, namhienTai, thanghienTai);
            //Đưa tổng thu- chi ra
            CapNhatTongThuChiGiaDinh(theHien, thanghienTai,namhienTai);
        }

        private void CapNhatTongThuChiGiaDinh(THE_HIEN theHien, int thanghienTai, int namhienTai)
        {
            string dieuKien = dieuKien = String.Format("year(Ngay)={0} and month(Ngay)={1}", namhienTai, thanghienTai);
            string tenBang = "KHOAN_THU_GIA_DINH";
            string cot = "sum(So_tien) as So_tien";
            string noiDungThuGiaDinh = "";
            string noiDungChiGiaDinh = "";
           // string noiDungKetQuaGiaDinh = "";
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
            noiDungThuGiaDinh = String.Format("{0:#,0.#} VNĐ",thu);
            noiDungChiGiaDinh = String.Format("{0:#,0.#} VNĐ", chi);
           // noiDungKetQuaGiaDinh = (thu - chi).ToString();
            theHien.inNoiDung(textBoxX1, "+ " + noiDungThuGiaDinh);
            theHien.inNoiDung(textBoxX2, "- " + noiDungChiGiaDinh);
            //theHien.inNoiDung(labelKetQuaChung, "=> " + noiDungKetQuaGiaDinh+" VNĐ")
        }

        private void CapNhatThongTinThuChiThanhVien(THE_HIEN theHien, int namhienTai, int thanghienTai)
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
            thanhVien = layGiaTriCuaTenThuocTinh(phanTuThu, viTri, "Ho_ten") + "\n\n\n";
            Int32.TryParse(tongThu, out thu);
            Int32.TryParse(tongChi, out chi);
            tongThu = String.Format("{0:#,0.#} VNĐ", thu);
            tongChi = String.Format("{0:#,0.#} VNĐ", chi);
            thanhVien += "+ " + tongThu + "\n";
            thanhVien += "- " + tongChi + "\n";

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

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thong_ke_thang thongKeThang = new Thong_ke_thang();
            thongKeThang.ShowDialog();
            
        }

        private void Thong_ke_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            buttonX4.Enabled = false;
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thong_ke_nam thongKeNam = new Thong_ke_nam();
            thongKeNam.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chi chi = new Chi();
            chi.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thu thu = new Thu();
            thu.ShowDialog();
        }

        
    }
}
