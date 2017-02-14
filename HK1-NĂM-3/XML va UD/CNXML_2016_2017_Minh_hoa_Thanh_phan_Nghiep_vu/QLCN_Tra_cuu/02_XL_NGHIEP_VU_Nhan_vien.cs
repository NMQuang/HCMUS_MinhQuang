using System;
using System.Collections.Generic;

using System.Text;

using System.Xml;
//=== Các hàm xử lý nghiệp vụ và nghiệp vụ cơ sở với loại đối tượng NHAN_VIEN
//==== Lưu ý PET : Cần quan sát và tìm hiểu tạo sao có hàm khai báo public có hàm khai báo protected 
//==== Thông báo PET : Đây là cách tổ chức chung cho tất cả các loại đối tượng 
// == > Các anh chị  sẽ áp dụng cách tổ chức này cho các loại đối tượng khác : CHI_NHANH, DON_VI,....

 // Lưu ý quan trọng : class này sẽ Tái sử dụng trên Hệ khách Web và Dịch vụ 
 
public partial class XL_NGHIEP_VU
{
    static string Ma_so_Loai_Doi_tuong_Nhan_vien = "NHAN_VIEN";
    //*******************************************************************************
    // ********Các Hàm xử lý Nghiệp vụ 
    #region "Xử lý Nghiệp vụ : Tra cứu "
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Ho_ten(XmlElement Goc, string Chuoi_Ho_ten)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
        Kq = Kq.FindAll(x => x.GetAttribute("Ho_ten").ToUpper().Contains(Chuoi_Ho_ten.ToUpper()));
        return Kq;

    }
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Muc_luong(XmlElement Goc,  double Can_duoi, Double Can_tren )
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
        // Sinh viên tự thực hiện
        return Kq;

    }
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Don_vi(XmlElement Goc,  XmlElement Don_vi)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
       // Sinh viên tự thực hiện
        return Kq;

    }
    #endregion
    #region "Xử lý Nghiệp vụ: Thống kê"
    // Xem lại Yêu cầu của QLNV_1 == > Nên có hàm nào ?
    #endregion
    #region "Xử lý Nghiệp vụ: Nhập liệu "
    // Xem lại Yêu cầu của QLNV_1 == > Nên có hàm nào ?
    #endregion
    //*******************************************************************************


    //*******************************************************************************
    // ********Các hàm xử lý nghiệp vụ cơ sở 
    #region "Xử lý  Nghiệp vụ cơ sở : Trích rút"
    //=======================================================
    // Lưu ý PET : Đây là hàm quan trọng nhất đó Câu hỏi PET : Tại sao ?
    public List<XmlElement> Danh_sach_Nhan_vien(XmlElement Goc)
    {
        List<XmlElement> Kq = new List<XmlElement>();
        foreach (XmlElement Nut in Goc.SelectNodes(Ma_so_Loai_Doi_tuong_Nhan_vien))
            Kq.Add(Nut);
        return Kq;
    }
    //===========================================================
    protected List<XmlElement> Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(XmlElement Goc, int ID_DON_VI)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
        // Sinh viên tự thực hiện
        return Kq;

    }
   
    //***** Có thể bổ sung các hàm trích rút khác theo ngữ cảnh 
    #endregion
    #region "Xử lý  Nghiệp vụ cơ sở : Tạo chuỗi"
    public string Tao_Chuoi_Tom_tat_Nhan_vien(XmlElement Nhan_vien)
    {   // Lưu ý PET :  Tùy vào ngữ cảnh của yêu cầu   
        // == > sẽ cung cấp thông tin thích hợp 
        // Với ngữ cảnh minh họa BL tôi chỉ đơn giản cung cấp họ tên 
        // Các anh chị có thể rèn luyện khi cung cấp thêm mức lương , đơn vị 
        string Kq = "";
        Kq = Nhan_vien.GetAttribute("Ho_ten");
        return Kq;
    }
    public string Tao_Chuoi_Thong_tin_Nhan_vien(XmlElement Nhan_vien)
    {    
        string Kq = "";
        // Sinh viên tự thực hiện
        return Kq;
    }
    #endregion

    //*******************************************************************************
}

