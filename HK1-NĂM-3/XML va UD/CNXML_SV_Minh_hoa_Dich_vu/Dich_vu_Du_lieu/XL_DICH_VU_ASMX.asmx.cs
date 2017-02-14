using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
namespace Dich_vu_Du_lieu
{
    /// <summary>
    /// Summary description for XL_DICH_VU_ASMX
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]


    //==== Lưu ý 1: Tất cả các công nghệ dịch vụ : ASMX,WCF,ResFull, ...đều chỉ là khung mà thôi !!!
    // Xử lý thật sự chỉ có 1 nơi duy nhất XL_DICH_VU
    //==== Lưu ý 2:   Chọn Dịch vụ này như Start Page == > Cho thực hiện và xem kết quả 
    public class XL_DICH_VU_ASMX : System.Web.Services.WebService
    {

        #region "Xử lý Đăng nhập"


        [WebMethod]
        public string  Dang_nhap_QLCT(  string Ten_Dang_nhap, 
                    string Mat_khau)
        {
            string  Kq;
            XL_DICH_VU Dich_vu = Global.Dich_vu;
            Kq = Dich_vu.Dang_nhap_QLCT(Ten_Dang_nhap, Mat_khau).OuterXml;
            return Kq;
        }
        [WebMethod]
        public string Dang_nhap_QLCN( string Ten_Dang_nhap,
                   string Mat_khau)
        {
            string Kq;
            XL_DICH_VU Dich_vu = Global.Dich_vu;
            Kq = Dich_vu.Dang_nhap_QLCN(Ten_Dang_nhap, Mat_khau).OuterXml;
            return Kq;
        }
        [WebMethod]
        public string Dang_nhap_QLDV( string Ten_Dang_nhap,
                   string Mat_khau)
        {
            string Kq;
            XL_DICH_VU Dich_vu = Global.Dich_vu;
            Kq = Dich_vu.Dang_nhap_QLDV(Ten_Dang_nhap, Mat_khau).OuterXml;
            return Kq;
        }
        [WebMethod]
        public string Dang_nhap_NV(  string Ten_Dang_nhap,
                   string Mat_khau)
        {
            string Kq;
            XL_DICH_VU Dich_vu = Global.Dich_vu;
            Kq = Dich_vu.Dang_nhap_NV(Ten_Dang_nhap, Mat_khau).OuterXml;
            return Kq;
        }
        [WebMethod]
        public string Dang_nhap(  string Ten_Dang_nhap,
                   string Mat_khau)
        {
            string Kq;
            XL_DICH_VU Dich_vu = Global.Dich_vu;
            Kq = Dich_vu.Dang_nhap(Ten_Dang_nhap, Mat_khau).OuterXml;
            return Kq;
        }
        #endregion

        #region "Xử lý Nghiệp vụ"
        [WebMethod]
        public string Tiep_nhan_Nhan_vien(string Chuoi_Xml_Nhan_vien)
        {
            string Kq = "Sinh viên tự thực hiện";
            return Kq;
        }
        [WebMethod]
        public string Cap_nhat_Ho_so_Nhan_vien(string Chuoi_Xml_Nhan_vien)
        {
            string Kq = "Sinh viên tự thực hiện";
            return Kq;
        }
        [WebMethod]
        public string Thanh_ly_Hop_dong_Nhan_vien(string Chuoi_Xml_Nhan_vien)
        {
            string Kq = "Sinh viên tự thực hiện";
            return Kq;
        }
        #endregion
    }
}
