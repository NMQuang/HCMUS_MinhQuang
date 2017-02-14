using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using QLCT_Tra_cuu.DV_PET;


public partial class XL_LUU_TRU
{
 
    XL_DICH_VU_QLNV_1SoapClient Dich_vu = new XL_DICH_VU_QLNV_1SoapClient();
   //Lưu ý PET : Dịch vụ PET này sẽ chỉ hổ trợ 1 thời gian 
   //=== > Các anh chị sẽ phải tự tạo dịch vụ của riêng mình khi hết thời gian hổ trợ 
    public XmlElement Dang_nhap_PET(string Ten_Dang_nhap, string Mat_khau)
    {
        XmlElement Kq = null;
        try
        {
            string Chuoi_Xml = Dich_vu.Dang_nhap_QLCT_XDO(Ten_Dang_nhap, Mat_khau);
            XmlDocument Tai_lieu = new XmlDocument();
            Tai_lieu.LoadXml(Chuoi_Xml);
            Kq = Tai_lieu.DocumentElement;

        }
        catch
        {
            Kq = null;
        }
        return Kq;
    }
  

  
 

    
}


public partial class XL_NGHIEP_VU
{
 

 
    public string Tao_Chuoi_Thong_bao_MH_Dang_nhap()
    {
        string Kq = "Thông báo PET \n";
        Kq += "Đây là ứng dụng minh họa một trong các  kỹ thuật Thiết kế và Lập trình Business Layer - BL)   \n";
        Kq += "1. Mục tiêu chính : Cung cấp Source Code     \n";
        Kq += "    - Tổng quát : Kỹ thuật tổ chức hệ thống hàm xử lý  trên Hệ khách \n";
        Kq += "    - Tổng quát : Kỹ thuật  tổ chức  hệ thống hàm xử lý BL   \n";
        Kq += "    -  Cụ thể : Tra cứu nhân viên theo họ tên ( phần mềm QLNV_1 - Ứng dụng dành riêng cho QLCT  \n";
        Kq += "2. Sinh viên cần đọc thật kỹ Source Code  và áp dụng thích hợp khi lập trình\n";
        Kq += "3. Lưu ý : Ứng dụng này chỉ tập trung minh họa BL";
        Kq += "== > Giao diện chỉ đơn giản dùng để xem kết quả \n";
        Kq += "== > Sinh viên không nên quan tâm giao diện   \n";
        Kq += "== > Sinh viên phải tâp trung xem xử lý BL và tự rèn luyện với các tra cứu khác \n";
      
        return Kq;
    }
    

 
}
 
 