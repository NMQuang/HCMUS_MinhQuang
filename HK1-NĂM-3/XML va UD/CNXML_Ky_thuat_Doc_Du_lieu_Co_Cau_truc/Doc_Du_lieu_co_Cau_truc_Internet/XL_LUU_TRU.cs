using System;
using System.Collections.Generic;
 
using System.Text;
 
using System.IO;
using System.Xml;
 
public  class XL_LUU_TRU
 {
    #region "Biến/Đối tượng toàn cục"
    Doc_Du_lieu_co_Cau_truc_Internet.DV_ASMX_Thu_nghiem.XL_DICH_VU_ASMXSoapClient Dich_vu = new Doc_Du_lieu_co_Cau_truc_Internet.DV_ASMX_Thu_nghiem.XL_DICH_VU_ASMXSoapClient();
    #endregion

    #region "Xử lý : Khởi động"
    public XL_LUU_TRU()
    {
       
    }
    #endregion

    #region "Xử lý : Đọc dữ liệu có cấu trúc"
    public XmlElement Doc_Du_lieu()
    {
        XmlElement Kq=null;
        string Chuoi_Xml = Dich_vu.Doc_Du_lieu();
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.LoadXml(Chuoi_Xml);
        Kq = Tai_lieu.DocumentElement;
        return Kq;
    }
    
    #endregion
}

