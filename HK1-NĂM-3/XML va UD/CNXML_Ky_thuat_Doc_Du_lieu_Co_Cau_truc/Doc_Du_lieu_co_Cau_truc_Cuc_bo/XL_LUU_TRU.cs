using System;
using System.Collections.Generic;
 
using System.Text;
 
using System.IO;
using System.Xml;
public enum CONG_NGHE_LUU_TRU
{   CSDL,
    XML
}
public  class XL_LUU_TRU
 {
    #region "Biến/Đối tượng toàn cục"
    protected static DirectoryInfo Thu_muc_Debug = new DirectoryInfo(Environment.CurrentDirectory);
    protected static DirectoryInfo Thu_muc_Solution = Thu_muc_Debug.Parent.Parent.Parent;

    protected static string Thu_muc_Du_lieu = Thu_muc_Solution.FullName + @"\Du_lieu";
    protected static string Thu_muc_XML = Thu_muc_Du_lieu + @"\XML";

    protected static string Ten_Ung_dung = "PET";
    protected static string Phien_ban = "Ren_luyen_Ky_nang";
    protected static string Ten_Du_lieu_Luu_tru = Ten_Ung_dung + "_" + Phien_ban;

    protected static CONG_NGHE_LUU_TRU Cong_nghe = CONG_NGHE_LUU_TRU.XML;
    protected string Duong_dan_Tap_tin_Xml = "";
    #endregion

    #region "Xử lý : Khởi động"
    public XL_LUU_TRU()
    {
        if (Cong_nghe == CONG_NGHE_LUU_TRU.XML)
            Duong_dan_Tap_tin_Xml = Thu_muc_XML + @"\" + Ten_Du_lieu_Luu_tru + ".xml";
        else if (Cong_nghe == CONG_NGHE_LUU_TRU.CSDL)
            ;  // Sẽ minh họa sau 
    }
    #endregion

    #region "Xử lý : Đọc dữ liệu có cấu trúc"
    public XmlElement Doc_Du_lieu()
    {
        XmlElement Kq=null;
        if (Cong_nghe == CONG_NGHE_LUU_TRU.XML)
            Kq = Doc_Du_lieu_tu_Tap_tin_Xml();
        else if (Cong_nghe == CONG_NGHE_LUU_TRU.CSDL)
            ;  // Sẽ minh họa sau 
        return Kq;
    }
    protected XmlElement Doc_Du_lieu_tu_Tap_tin_Xml()
    {
        XmlElement Kq = null;
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.Load(Duong_dan_Tap_tin_Xml);
        Kq = Tai_lieu.DocumentElement;
        return Kq;
    }
    protected XmlElement Doc_Du_lieu_tu_CSDL()
    {
        XmlElement Kq = null; ;
        return Kq;

    }
    #endregion
}

