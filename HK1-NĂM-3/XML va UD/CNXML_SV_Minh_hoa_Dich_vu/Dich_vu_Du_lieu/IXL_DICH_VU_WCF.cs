using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
//==== Lưu ý 1: Tất cả các công nghệ dịch vụ : ASMX,WCF,ResFull, ...đều chỉ là khung mà thôi !!!
// Xử lý thật sự chỉ có 1 nơi duy nhất XL_DICH_VU
//==== Lưu ý 2:  Xem lại Lưu ý 1 
namespace Dich_vu_Du_lieu
{
   
    [ServiceContract]
    public interface IXL_DICH_VU_WCF
    {
        #region "Xử lý Đăng nhập"


        [OperationContract]
        string Dang_nhap_QLCT(  string Ten_Dang_nhap,
                    string Mat_khau);

        [OperationContract]
        string Dang_nhap_QLCN(  string Ten_Dang_nhap,
                   string Mat_khau);

        [OperationContract]
        string Dang_nhap_QLDV( string Ten_Dang_nhap,
                   string Mat_khau);

        [OperationContract]
        string Dang_nhap_NV( string Ten_Dang_nhap,
                   string Mat_khau);
        
        [OperationContract]
        string Dang_nhap(  string Ten_Dang_nhap,
                   string Mat_khau);
      
        #endregion

        #region "Xử lý Nghiệp vụ"
        [OperationContract]
        string Tiep_nhan_Nhan_vien(string Chuoi_Xml_Nhan_vien);
       
        [OperationContract]
        string Cap_nhat_Ho_so_Nhan_vien(string Chuoi_Xml_Nhan_vien);

        [OperationContract]
        string Thanh_ly_Hop_dong_Nhan_vien(string Chuoi_Xml_Nhan_vien);
        
        #endregion
    }
}
