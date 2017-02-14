using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using UNG_DUNG_WEB.ServiceReference1;
namespace UNG_DUNG_WEB
{
    public class NGHIEP_VU
    {
        protected XL_DICH_VU_ASMXSoapClient dataService = new XL_DICH_VU_ASMXSoapClient();

        internal System.Xml.XmlElement LayDuLieuBang(string tenBang, string cot, string dieuKien)
        {
            string chuoiXml = dataService.docBang(tenBang, cot, dieuKien);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(chuoiXml);
            return doc.DocumentElement;
        }
    }
}