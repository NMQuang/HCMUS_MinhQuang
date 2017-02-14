using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using FORM_DO_AN.ServiceReference1;

namespace FORM_DO_AN
{
    class NGHIEP_VU
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
