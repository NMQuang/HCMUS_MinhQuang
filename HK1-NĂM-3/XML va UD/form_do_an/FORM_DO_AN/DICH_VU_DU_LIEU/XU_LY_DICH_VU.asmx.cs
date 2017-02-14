using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace DICH_VU_DU_LIEU
{
    /// <summary>
    /// Summary description for XU_LY_DICH_VU
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class XU_LY_DICH_VU : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string loadDuLieu()
        {
            XL_DICH_VU dichVu = new XL_DICH_VU();
            string ketQua = "";
            XmlElement Goc = dichVu.DocGoc();
            ketQua = Goc.OuterXml;
            return ketQua;

        }
    }
}
