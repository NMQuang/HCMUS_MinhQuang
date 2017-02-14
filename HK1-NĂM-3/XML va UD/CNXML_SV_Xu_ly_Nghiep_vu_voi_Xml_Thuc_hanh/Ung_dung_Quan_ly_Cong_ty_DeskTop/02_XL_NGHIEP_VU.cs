using System;
using System.Collections.Generic;
 
using System.Text;
 
using System.Xml;
// Thông báo PET : class này được lập  trình độc lập hoàn toàn với các thành phần khác 
// Xem Case Study để hiểu rõ khái niệm độc lập hoàn toàn 
public partial class XL_NGHIEP_VU
{
    public readonly static string Ma_so_Loai_Doi_tuong_Cong_ty = "CONG_TY";
    public readonly static string Ma_so_Loai_Doi_tuong_Nhan_vien = "NHAN_VIEN";
    public readonly static string Ma_so_Loai_Doi_tuong_Don_vi = "DON_VI";

    //*******************************************************************************
    // ********Các Hàm xử lý Nghiệp vụ 
    #region "Xử lý Nghiệp vụ : Tra cứu "
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Ho_ten(XmlElement Goc, string Chuoi_Ho_ten)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
        Kq = Kq.FindAll(x => x.GetAttribute("Ho_ten").ToUpper().Contains(Chuoi_Ho_ten.ToUpper()));
        return Kq;

    }
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Muc_luong(XmlElement Goc, double Can_duoi, Double Can_tren)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
        // Sinh viên tự thực hiện
        return Kq;

    }
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Don_vi(XmlElement Goc, XmlElement Don_vi)
    {
        List<XmlElement> Kq;
        int ID_DON_VI = int.Parse(Don_vi.GetAttribute("ID"));
        Kq = Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(Goc,ID_DON_VI);
        
        return Kq;

    }
    #endregion
    #region "Xử lý Nghiệp vụ: Thống kê"
    public XmlElement[]  Thong_ke_So_luong_Nhan_vien_theo_Don_vi (XmlElement Goc)
    {
        XmlElement[] Kq;
        Kq = Danh_sach_Don_vi(Goc).ToArray();
        int Tong_so_Nhan_vien = Danh_sach_Nhan_vien(Goc).Count;
        foreach( XmlElement Don_vi in Kq )
        { int ID_DON_VI = int.Parse(Don_vi.GetAttribute("ID"));
            int So_Nhan_vien = Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(Goc, ID_DON_VI).Count;
           double Ty_le =  100.0 * So_Nhan_vien / Tong_so_Nhan_vien;
            Don_vi.SetAttribute("So_Nhan_vien", So_Nhan_vien.ToString());
            Don_vi.SetAttribute("Ty_le", Math.Round(Ty_le, 2) + "%");
        }   
        return Kq;

    }
    #endregion
    #region "Xử lý Nghiệp vụ: Nhập liệu "
    // *** Cập nhật
    public string Cap_nhat_Ho_so_Cong_ty(XmlElement Cong_ty)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Cap_nhat_Ho_so_Chi_nhanh(XmlElement Chi_nhanh)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Cap_nhat_Ho_so_Don_vi(XmlElement Don_vi)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Thuyen_chuyen_Nhan_vien(XmlElement Nhan_vien)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }

    //*** Ghi mới
    public string Thanh_lap_Chi_nhanh(XmlElement Chi_nhanh)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Thanh_lap_Don_vi(XmlElement Don_vi)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    //**** Xóa
    public string Giai_the_Chi_nhanh(XmlElement Chi_nhanh)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Giai_the_Don_vi(XmlElement Don_vi)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    #endregion
    //*******************************************************************************


    //*******************************************************************************
    // ********Các hàm xử lý nghiệp vụ cơ sở 
    // Lưu ý PET :  Tất cả các hàm đều là hàm nội bộ  
    #region "Xử lý  Nghiệp vụ cơ sở : Trích rút"
    //=======================================================
    // Trích rút Cấp 0 
    protected List<XmlElement> Danh_sach_Nhan_vien(XmlElement Goc)
    {
        List<XmlElement> Kq = new List<XmlElement>();
        foreach (XmlElement Nut in Goc.SelectNodes(Ma_so_Loai_Doi_tuong_Nhan_vien))
            Kq.Add(Nut);
        return Kq;
    }
    protected List<XmlElement> Danh_sach_Don_vi(XmlElement Goc)
    {
        List<XmlElement> Kq = new List<XmlElement>();
        foreach (XmlElement Nut in Goc.SelectNodes(Ma_so_Loai_Doi_tuong_Don_vi))
            Kq.Add(Nut);
        return Kq;
    }
    //Trích rút Cấp 1
    protected List<XmlElement> Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(XmlElement Goc, int ID_DON_VI)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
        Kq = Kq.FindAll(x => int.Parse(x.GetAttribute("ID_DON_VI")) == ID_DON_VI);
        return Kq;

    }
    #endregion
    #region "Xử lý  Nghiệp vụ cơ sở : Tạo chuỗi"
    //
    // **** Lưu ý PET( quan trọng ) : Trong tất cả các ứng dụng  với tất cả loại công nghệ, loại kiến trúc 
    //***** các hàm xử lý tạo chuỗi sẽ luôn luôn là hàm nền tảng nhất và quan trọng nhất 
   // *** Tuy nhiên với mục tiêu của ứng dụng này :Tạm thời  không có hàm nào hết trong ứng dụng này
    //
    #endregion

    //*******************************************************************************



}

