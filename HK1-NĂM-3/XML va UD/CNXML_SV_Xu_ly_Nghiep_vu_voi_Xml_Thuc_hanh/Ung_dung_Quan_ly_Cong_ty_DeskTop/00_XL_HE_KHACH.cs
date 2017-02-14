using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Ung_dung_Quan_ly_Cong_ty_DeskTop.DV_ASMX_Thu_nghiem;
    class XL_HE_KHACH
    {
      public XL_HE_KHACH ()
    {
        XL_DICH_VU_ASMXSoapClient Dich_vu = new XL_DICH_VU_ASMXSoapClient();
        string Chuoi_Xml_Goc = Dich_vu.Dang_nhap_QLCT("QLCT_1", "QLCT_1");
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.LoadXml(Chuoi_Xml_Goc);
        XmlElement Goc = Tai_lieu.DocumentElement;
        MH_Minh_hoa Mh = new MH_Minh_hoa();
        Mh.Xu_ly(Goc);
    }
    }
 
