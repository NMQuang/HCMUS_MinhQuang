using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Hosting;
using System.IO;
using Thu_vien_Nghiep_vu;

//==== Lưu ý 1: Tất cả các công nghệ dịch vụ : ASMX,WCF,ResFull, ...đều chỉ là khung mà thôi !!!
// Xử lý thật sự chỉ có 1 nơi duy nhất XL_DICH_VU
//=== Lưu ý 2 : Đây chỉ là kỹ thuật mở đầu về Dịch vụ !!!

//== > Sẽ còn cải tiến với ít nhất 2 vấn đề lớn : Bảo mật, Tốc độ
// ( Các vấn đề trên là thực tế nhưng không được yêu cầu trong ngữ cảnh đồ án môn học )

//=== Lưu ý 3 : Mô hình lập trình này có thể áp dụng với Hệ khách 
// ( bao gồm DeskTop , Web hay Mobile ) với đối tượng He_khach thay cho Dich_vu
// ( Các màn hình giao diện cũng tương tự như các công nghệ dịch vụ mà thôi !!! )
public class XL_DICH_VU : XL_NGHIEP_VU
   {
  
    #region "Biến/Đối tượng toàn cục"
    protected static DirectoryInfo Thu_muc_Project = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
    protected static DirectoryInfo Thu_muc_Solution = Thu_muc_Project.Parent;
    protected static DirectoryInfo Thu_muc_Du_lieu = Thu_muc_Solution.GetDirectories("Du_lieu")[0];
    protected static DirectoryInfo Thu_muc_CSDL = Thu_muc_Du_lieu.GetDirectories("CSDL")[0];
    protected static string Ten_Phan_mem = "Hoang_hon_Som";
    protected static string Phien_ban = "QLNV_1";  
    protected static string Ten_CSDL = Ten_Phan_mem + "_" + Phien_ban;
    protected static string Duong_dan_Tap_tin_CSDL = Thu_muc_CSDL.FullName + @"\" + Ten_CSDL + ".xml";
    protected XmlElement Goc = null;
    protected static XL_NGHIEP_VU Nghiep_vu = new XL_NGHIEP_VU();
    #endregion

    #region"Xử lý Khởi động"
  public XL_DICH_VU()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.Load(Duong_dan_Tap_tin_CSDL);
        Goc = Tai_lieu.DocumentElement;

    }
    #endregion

    #region "Xử lý Đăng nhập"
    protected void Ket_xuat(XmlElement Doi_tuong, XmlElement Dich)
    {
        XmlDocument Tai_lieu_Dich = Dich.OwnerDocument;
        XmlElement Doi_tuong_Ket_xuat = (XmlElement)Tai_lieu_Dich.ImportNode(Doi_tuong, true);
        Dich.AppendChild(Doi_tuong_Ket_xuat);
    }
    protected void Ket_xuat(List<XmlElement> Danh_sach, XmlElement Dich)
    {
        XmlDocument Tai_lieu_Dich = Dich.OwnerDocument;
        foreach (XmlElement Doi_tuong in Danh_sach)
        {
            XmlElement Doi_tuong_Ket_xuat = (XmlElement)Tai_lieu_Dich.ImportNode(Doi_tuong, true);
            Dich.AppendChild(Doi_tuong_Ket_xuat);
        }
    }


    public XmlElement Dang_nhap_QLCT(  string Ten_Dang_nhap, string Mat_khau)
    {
        XmlElement Kq;
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.LoadXml("<QLCT />");
        Kq = Tai_lieu.DocumentElement;
        XmlElement QLCT = Danh_sach_Qlct(Goc).FirstOrDefault(x =>
              x.GetAttribute("Ten_Dang_nhap") == Ten_Dang_nhap && x.GetAttribute("Mat_khau") == Mat_khau);
        if (QLCT != null)
        {
            int ID_CONG_TY = int.Parse(QLCT.GetAttribute("ID_CONG_TY"));
            XmlElement Cong_ty = Trich_rut_Cong_ty_theo_ID(Goc, ID_CONG_TY);
            Ket_xuat(Cong_ty, Kq);
            List<XmlElement> Danh_sach_Chi_nhanh = Trich_rut_Danh_sach_Chi_nhanh_theo_ID_CONG_TY(Goc, ID_CONG_TY);
            Ket_xuat(Danh_sach_Chi_nhanh, Kq);
            List<XmlElement> Danh_sach_Don_vi = Trich_rut_Danh_sach_Don_vi_theo_ID_CONG_TY(Goc, ID_CONG_TY);
            Ket_xuat(Danh_sach_Don_vi, Kq);
            List<XmlElement> Danh_sach_Nhan_vien = Trich_rut_Danh_sach_Nhan_vien_theo_ID_CONG_TY(Goc, ID_CONG_TY);
            Ket_xuat(Danh_sach_Nhan_vien, Kq);
            //=== Danh mục 
            Ket_xuat(Danh_sach_Gioi_tinh(Goc), Kq);
           
        }
        return Kq;
    }
    public XmlElement Dang_nhap_QLCN( 
                                               string Ten_Dang_nhap, string Mat_khau)
    {
        XmlElement Kq;
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.LoadXml("<QLCN />");
        Kq = Tai_lieu.DocumentElement;
        XmlElement QLCN = Danh_sach_Qlcn(Goc).FirstOrDefault(x =>
               x.GetAttribute("Ten_Dang_nhap") == Ten_Dang_nhap && x.GetAttribute("Mat_khau") == Mat_khau);
        if (QLCN != null)
        {
            int ID_CHI_NHANH = int.Parse(QLCN.GetAttribute("ID_CHI_NHANH"));
            XmlElement Chi_nhanh = Trich_rut_Chi_nhanh_theo_ID(Goc, ID_CHI_NHANH);
            Ket_xuat(Chi_nhanh, Kq);
            List<XmlElement> Danh_sach_Don_vi = Trich_rut_Danh_sach_Don_vi_theo_ID_CHI_NHANH(Goc, ID_CHI_NHANH);
            Ket_xuat(Danh_sach_Don_vi, Kq);
            List<XmlElement> Danh_sach_Nhan_vien = Trich_rut_Danh_sach_Nhan_vien_theo_ID_CHI_NHANH(Goc, ID_CHI_NHANH);
            Ket_xuat(Danh_sach_Nhan_vien, Kq);

            XmlElement Cong_ty = Trich_rut_Cong_ty_theo_ID(Goc, Chi_nhanh.GetAttribute("ID_CONG_TY"));
            Ket_xuat(Cong_ty, Kq);
            //=== Danh mục 
            Ket_xuat(Danh_sach_Gioi_tinh(Goc), Kq);
         
        }
        return Kq;
    }

    public XmlElement Dang_nhap_QLDV( 
                                               string Ten_Dang_nhap, string Mat_khau)
    {
        XmlElement Kq;
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.LoadXml("<QLDV />");
        Kq = Tai_lieu.DocumentElement;
        XmlElement QLDV = Danh_sach_Qldv(Goc).FirstOrDefault(x =>
               x.GetAttribute("Ten_Dang_nhap") == Ten_Dang_nhap && x.GetAttribute("Mat_khau") == Mat_khau);
        if (QLDV != null)
        {
            int ID_DON_VI = int.Parse(QLDV.GetAttribute("ID_DON_VI"));
            XmlElement Don_vi = Trich_rut_Don_vi_theo_ID(Goc, ID_DON_VI);
            Ket_xuat(Don_vi, Kq);
            List<XmlElement> Danh_sach_Nhan_vien = Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(Goc, ID_DON_VI);
            Ket_xuat(Danh_sach_Nhan_vien, Kq);

            XmlElement Chi_nhanh = Trich_rut_Chi_nhanh_theo_ID(Goc, Don_vi.GetAttribute("ID_CHI_NHANH"));
            Ket_xuat(Chi_nhanh, Kq);
            XmlElement Cong_ty = Trich_rut_Cong_ty_theo_ID(Goc, Chi_nhanh.GetAttribute("ID_CONG_TY"));
            Ket_xuat(Cong_ty, Kq);
            //=== Danh mục 
            Ket_xuat(Danh_sach_Gioi_tinh(Goc), Kq);
        
        }
        return Kq;
    }


    public XmlElement Dang_nhap_NV( 
                                              string Ten_Dang_nhap, string Mat_khau)
    {
        XmlElement Kq;
        XmlDocument Tai_lieu = new XmlDocument();
        Tai_lieu.LoadXml("<NV />");
        Kq = Tai_lieu.DocumentElement;
        XmlElement NV = Danh_sach_Nv(Goc).FirstOrDefault(x =>
               x.GetAttribute("Ten_Dang_nhap") == Ten_Dang_nhap && x.GetAttribute("Mat_khau") == Mat_khau);
        if (NV != null)
        {
            int ID_NHAN_VIEN = int.Parse(NV.GetAttribute("ID_NHAN_VIEN"));
            XmlElement Nhan_vien = Trich_rut_Nhan_vien_theo_ID(Goc, ID_NHAN_VIEN);
            Ket_xuat(Nhan_vien, Kq);

            XmlElement Don_vi = Trich_rut_Don_vi_theo_ID(Goc, Nhan_vien.GetAttribute("ID_DON_VI"));
            Ket_xuat(Don_vi, Kq);
            XmlElement Chi_nhanh = Trich_rut_Chi_nhanh_theo_ID(Goc, Don_vi.GetAttribute("ID_CHI_NHANH"));
            Ket_xuat(Chi_nhanh, Kq);
            XmlElement Cong_ty = Trich_rut_Cong_ty_theo_ID(Goc, Chi_nhanh.GetAttribute("ID_CONG_TY"));
            Ket_xuat(Cong_ty, Kq);
            //=== Danh mục 
            Ket_xuat(Danh_sach_Gioi_tinh(Goc), Kq);
       
        }
        return Kq;
    }


    public XmlElement Dang_nhap( 
                                           string Ten_Dang_nhap, string Mat_khau)
    {
        XmlElement Kq = Dang_nhap_QLCT( Ten_Dang_nhap, Mat_khau);
        if (Kq.ChildNodes.Count == 0)
        {
            Kq = Dang_nhap_QLCN(  Ten_Dang_nhap, Mat_khau);
            if (Kq.ChildNodes.Count == 0)
            {
                Kq = Dang_nhap_QLDV(  Ten_Dang_nhap, Mat_khau);
                if (Kq.ChildNodes.Count == 0)
                    Kq = Dang_nhap_NV(  Ten_Dang_nhap, Mat_khau);
            }
        }
        return Kq;
    }
    #endregion

    #region"Xử lý Nghiệp vụ "
    // Lưu ý : Chỉ minh họa 1 loại đối tượng với 1 loại nghiệp vụ tiếp nhận thông tin 
    // == > Thực tế sẽ phải bổ sung các loại đối tượng khác và các loại xử lý khác 
    #region "Loại đối tượng : NHAN_VIEN   "    
    //=====Tra cứu 
    //
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Ho_ten(XmlElement Goc,
                                                    string Chuoi_Ho_ten)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
        Kq = Kq.FindAll(x => x.GetAttribute("Ho_ten").ToString().ToUpper().Contains(Chuoi_Ho_ten.ToUpper()));
        return Kq;
    }
    //
    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Muc_luong(XmlElement Goc,
                                               double Can_duoi, double Can_tren)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);

        Kq = Kq.FindAll(x => double.Parse(x.GetAttribute("Muc_luong")) >= Can_duoi &&
                double.Parse(x.GetAttribute("Muc_luong")) <= Can_tren);
        return Kq;
    }
    //

   

    public List<XmlElement> Tra_cuu_Nhan_vien_theo_Don_vi(XmlElement Goc,
                                                XmlElement Don_vi)
    {
        List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);

        Kq = Kq.FindAll(x => x.GetAttribute("ID_DON_VI") == Don_vi.GetAttribute("ID"));
        return Kq;
    }
    //

    //==== Thống kê
    //
  
    //

    public XmlElement[] Thong_ke_So_luong_Nhan_vien_theo_Don_vi(XmlElement Goc)
    {
        XmlElement[] Kq;
        Kq = Danh_sach_Don_vi(Goc).ToArray();
        int Tong_so_Nhan_vien = Danh_sach_Nhan_vien(Goc).Count;
        foreach (XmlElement Don_vi in Kq)
        {
            int ID_DON_VI = int.Parse(Don_vi.GetAttribute("ID"));
            int So_luong = Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(Goc, ID_DON_VI).Count;
            double Ty_le = 100.0 * So_luong / Tong_so_Nhan_vien;
            Don_vi.SetAttribute("So_luong", So_luong.ToString());
            Don_vi.SetAttribute("Ty_le", Math.Round(Ty_le, 2).ToString());
        }
        return Kq;
    }
    //

    //==== Cập nhật
    protected string Kiem_tra_Cap_nhat_Ho_so_Nhan_vien(XmlElement Nhan_vien)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Cap_nhat_Ho_so_Nhan_vien(XmlElement Nhan_vien)
    {
        string Kq = Kiem_tra_Cap_nhat_Ho_so_Nhan_vien(Nhan_vien);
        if (Kq == "")
        {
            Kq = "Sinh viên tự thực hiện";
        }
        return Kq;
    }
    //==== Ghi mới
    protected string Kiem_tra_Tiep_nhan_Nhan_vien(XmlElement Nhan_vien)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Tiep_nhan_Nhan_vien(XmlElement Nhan_vien)
    {
        string Kq = Kiem_tra_Tiep_nhan_Nhan_vien(Nhan_vien);
        if (Kq == "")
        {
            Kq = "Sinh viên tự thực hiện";
        }
        return Kq;
    }
    //==== Xóa

    protected string Kiem_tra_Thanh_ly_Hop_dong_Nhan_vien(XmlElement Nhan_vien)
    {
        string Kq = "Sinh viên tự thực hiện";
        return Kq;
    }
    public string Thanh_ly_Hop_dong_Nhan_vien(XmlElement Nhan_vien)
    {
        string Kq = Kiem_tra_Thanh_ly_Hop_dong_Nhan_vien(Nhan_vien);
        if (Kq == "")
        {
            Kq = "Sinh viên tự thực hiện";
        }
        return Kq;
    }
    #endregion
     
    #endregion
}
