using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Web.Hosting;
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
    public class XL_DICH_VU_ASMX : System.Web.Services.WebService
    {
       
        protected static DirectoryInfo Thu_muc_Project = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
        protected static DirectoryInfo Thu_muc_Solution = Thu_muc_Project.Parent;
        protected static DirectoryInfo Thu_muc_Du_lieu = Thu_muc_Solution.GetDirectories("Du_lieu")[0];
        protected static DirectoryInfo Thu_muc_CSDL = Thu_muc_Du_lieu.GetDirectories("CSDL")[0];
        protected static string Ten_Phan_mem = "Hoang_hon_Som";
        protected static string Phien_ban = "Ren_luyen_ky_nang"; // Không phân quyền
        protected static string Ten_CSDL = Ten_Phan_mem + "_" + Phien_ban;
        protected static string Duong_dan_Tap_tin_CSDL = Thu_muc_CSDL.FullName + @"\" + Ten_CSDL + ".xml";
        protected static XmlElement Goc=null;

      public  XL_DICH_VU_ASMX()
        {
            if (Goc == null )
            {
                XmlDocument Tai_lieu = new XmlDocument();
                Tai_lieu.Load(Duong_dan_Tap_tin_CSDL);
                Goc = Tai_lieu.DocumentElement;
            }
        }
        // Lưu ý PET : Dịch vụ này chỉ  phục vụ minh họa về Xử lý nghiệp vụ
        // Các anh chị sẽ tự xây dựng dịch vụ riêng cho mình 
      
        [WebMethod]
        public string Dang_nhap_QLCT(string Ten_Dang_nhap, string Mat_khau)
        {
            string Kq = "";
            if (Ten_Dang_nhap == "QLCT_1" && Mat_khau == "QLCT_1")
                Kq = Goc.OuterXml;
            return Kq;
        }
        [WebMethod]
        public string Cap_nhat_Ho_so_Cong_ty(string Chuoi_Tham_so_Khung)
        {
            string Kq =""; // Không có lỗi
            XmlDocument Tai_lieu = new XmlDocument();
            Tai_lieu.LoadXml(Chuoi_Tham_so_Khung);
            XmlElement Tham_so_Khung = Tai_lieu.DocumentElement;

            XmlElement Cong_ty_He_khach = (XmlElement)Tham_so_Khung.ChildNodes[0];
            XmlElement Cong_ty = (XmlElement)Goc.SelectSingleNode("CONG_TY");
            foreach (XmlAttribute Thuoc_tinh in Cong_ty.Attributes)
            {
                string Ten = Thuoc_tinh.Name;
                if (Ten !="ID")
                     Cong_ty.SetAttribute(Ten, Cong_ty_He_khach.GetAttribute(Ten));
            }
            
            Goc.OwnerDocument.Save(Duong_dan_Tap_tin_CSDL);
            return Kq;
        }
    }
}
