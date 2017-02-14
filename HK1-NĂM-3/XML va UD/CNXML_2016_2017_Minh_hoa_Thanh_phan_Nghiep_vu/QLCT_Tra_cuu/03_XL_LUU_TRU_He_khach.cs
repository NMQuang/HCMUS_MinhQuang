using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;
 
public partial class XL_LUU_TRU
 {
    #region "Biến/Đối tượng toàn cục"
   
    #endregion

    #region "Xử lý : Khởi động"
    public XL_LUU_TRU()
    {
       
    }
    #endregion

    #region "Xử lý : Đọc - Ghi dữ liệu có cấu trúc"
    public XmlElement Dang_nhap(string Ten_Dang_nhap , string  Mat_khau  )
    {   // Sinh viên sẽ phải tự thay thế với dịch vụ của riêng mình 
        XmlElement Kq = Dang_nhap_PET(Ten_Dang_nhap, Mat_khau);      
        return Kq;
    }
    public string Ghi_moi(XmlElement Doi_tuong)
    {
        string Kq = "";
        // Sinh viên tự thực hiện
        return Kq;
    }
    public string Cap_nhat(XmlElement Doi_tuong)
    {
        string Kq = "";
        // Sinh viên tự thực hiện
        return Kq;
    }
    public string Xoa(XmlElement Doi_tuong)
    {
        string Kq = "";
        // Sinh viên tự thực hiện
        return Kq;
    }
    #endregion

    #region "Xử lý : Đọc -Ghi dữ liệu phi cấu trúc - Media"
    public byte[] Doc_Nhi_phan_Hinh(string Ma_so)
    {
        byte[] Kq = new byte[] { };
        // Sinh viên tự thực hiện
        return Kq;
    }

    public string Ghi_Nhi_phan_Hinh(string Ma_so, byte[] Nhi_phan_Hinh)
    {
        string Kq = "";
        // Sinh viên tự thực hiện
        return Kq;
    }

    #endregion
}

