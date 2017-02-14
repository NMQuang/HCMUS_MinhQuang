using System;
using System.Collections.Generic;
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

    public class XL_DICH_VU_ASMX : System.Web.Services.WebService
    {

        protected static XL_LUU_TRU Luu_tru = new XL_LUU_TRU();
        [WebMethod]
        public string Doc_Du_lieu()
        {
            string Kq = "";
            // Thông báo PET : Xử lý này chỉ dùng minh họa đọc dữ liệu trên Internet với ASMX
            // Lưu ý PET : Xử lý này nhất thiết phải cải tiến khi xây dựng ứng dụng 
            // Câu hỏi PET : Tạo sao phải cải tiến ???
            XmlElement Du_lieu = Luu_tru.Doc_Du_lieu();
            Kq = Du_lieu.OuterXml;
            return Kq;
        }
    }
}
