using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Data;
using System.IO;
using System;
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

        protected static XL_LUU_TRU dichVu = new XL_LUU_TRU();
        protected static XmlElement duLieu = XL_DICH_VU_ASMX.dichVu.docDuLieu();
        [WebMethod]
        public string docDuLieu()
        {
            string ketQua = "";
            XmlElement duLieu = dichVu.docDuLieu();
            ketQua = duLieu.OuterXml;
            return ketQua;
        }

        [WebMethod]

        public string docBang(string tenBang, string cot = "*", string dieuKien = "")
        {
            XmlElement phanTu = dichVu.docBangTuCSDL(tenBang, cot, dieuKien);
            return phanTu.OuterXml;
        }
        [WebMethod]
        public string themDuLieu(string chuoiXml)
        {
            string ketQua = "";
            XL_LUU_TRU dichVu = new XL_LUU_TRU();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(chuoiXml);
                string chuoiXmlMoi = dichVu.Them(doc.DocumentElement);
                StringReader stringReader = new StringReader(chuoiXmlMoi);
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(stringReader);
                foreach (DataTable table in dataSet.Tables)
                    dichVu.ghiBangAccess(table);
            }
            catch (Exception ex)
            {
                ketQua = ex.Message;
            }
            return ketQua;
        }
        [WebMethod]
        public string Cap_nhat(string Chuoi_Xml)
        {
            string Kq = "";
            // Sinh viên tự thực hiện
            return Kq;
        }
        [WebMethod]
        public string Xoa(string Chuoi_Xml)
        {
            string Kq = "";
            // Sinh viên tự thực hiện
            return Kq;
        }

        //===== Dữ liệu phi cấu trúc Media 
        [WebMethod]
        public byte[] Doc_Hinh(string Ma_so)
        {
            byte[] Kq;
            Kq = dichVu.Doc_Hinh(Ma_so);
            return Kq;
        }
        [WebMethod]
        public string Ghi_Hinh(string Ma_so, byte[] Nhi_phan_Hinh)
        {
            string Kq = "";
            // Sinh viên tự thực hiện
            return Kq;
        }
    }
}
