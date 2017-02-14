using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
 
    public partial class MH_Cap_nhat_Ho_so_Cong_ty : Form
    {
        public MH_Cap_nhat_Ho_so_Cong_ty()
        {
            InitializeComponent();
        }
    #region "Biến/Đối tượng toàn cục"

    protected XL_NGHIEP_VU Nghiep_vu = new XL_NGHIEP_VU();
    protected XL_THE_HIEN The_hien = new XL_THE_HIEN();

    protected XmlElement Goc;
    protected XmlElement Cong_ty;
    #endregion
    #region "Xử lý giao diện"
    public void Xu_ly(XmlElement Cong_ty)
    {
        this.Cong_ty = Cong_ty;
        this.Goc = Cong_ty.OwnerDocument.DocumentElement;
        XL_Bien_co_Khoi_dong();
        //==== Xử lý PET : Chỉ phục vụ giảng dạy 
        string Thong_bao_PET = "Thông báo  PET :\n";
        Thong_bao_PET += "Ứng dụng này minh họa  xử lý nghiệp vụ với Xml " + "\n";
        Thong_bao_PET += "== > Giao diện mức tối thiểu    " + "\n";
        Thong_bao_PET += "== > Sinh viên cần tập trung vào XL_NGHIEP_VU   " + "\n";
        Thong_bao_PET += "Lưu ý PET :   " + "\n";
        Thong_bao_PET += "1 Thành phần nghiệp vụ là thành phần quan trọng nhất của mô hình 3 lớp  " + "\n";
        Thong_bao_PET += "2  Công  nghệ Xml là công nghệ tốt nhất để thực hiện thành phần nghiệp vụ   " + "\n";
        Thong_bao_PET += "3 Xem thêm Source Code của dịch vụ  " + "\n";
        Th_Thong_bao_PET.Text = Thong_bao_PET;
        //======
        this.ShowDialog();
    }

    #endregion
    #region "Xử lý Biến cố : Khởi động"
    protected void XL_Bien_co_Khoi_dong()
    {
        Xuat_Ho_so_Cong_ty();
        Th_Yeu_cau_Cap_nhat_Ho_so_Cong_ty.Click += XL_Bien_co_Yeu_cau_Cap_nhat_Ho_so_Cong_ty;
       

    }

   

    //**** Lưu ý PET : Nên chuyển các hàm xử này vào class XL_THE_HIEN            

    protected void Xuat_Ho_so_Cong_ty()
    {
        foreach(  Control Th_Thuoc_tinh   in Th_Ho_so.Controls)
        {
            string Ten_Thuoc_tinh = Th_Thuoc_tinh.Name.Replace("Th_", "");
            if (Cong_ty.Attributes[Ten_Thuoc_tinh] != null)
                Th_Thuoc_tinh.Text = Cong_ty.GetAttribute(Ten_Thuoc_tinh);
         
        }

        

        
    }





    #endregion

    #region "Xử lý Biến cố : yêu cầu thực hiện Nghiệp vụ"
    private void XL_Bien_co_Yeu_cau_Cap_nhat_Ho_so_Cong_ty(object sender, EventArgs e)
    {
        PET_Dong_ho_Ho_tro_thuc_hanh.XL_DONG_HO Dong_ho = new PET_Dong_ho_Ho_tro_thuc_hanh.XL_DONG_HO();
        Nhap_Ho_so_Cong_ty();
        string Chuoi_loi = Nghiep_vu.Cap_nhat_Ho_so_Cong_ty(Cong_ty);
        //if (Chuoi_loi == "")
        //    // Xuất thông báo đã cập nhật 
        //    ;
        //else
        //      // Xuất thông báo lỗi 
    
        //==== Xử lý PET : Chỉ phục vụ giảng dạy =======
        string Thong_bao_PET = "Thông báo  PET : ";
        Thong_bao_PET += "Các anh chị tự thực hiện yêu cầu này   " + "\n";
        Thong_bao_PET += "Lưu ý : đã có hàm Cập nhật hồ sơ của Dịch vụ    " + "\n";
         this.Text = Dong_ho.Tao_Chuoi_Thoi_gian_do("");
        Th_Thong_bao_PET.Text = Thong_bao_PET;
        //======

    }
    //**** Lưu ý PET : Nên chuyển các hàm xử này vào class XL_THE_HIEN            

    protected  void  Nhap_Ho_so_Cong_ty()
    {
 
        foreach (Control Th_Thuoc_tinh in Th_Ho_so.Controls)
        {
            string Ten_Thuoc_tinh = Th_Thuoc_tinh.Name.Replace("Th_", "");
            if (Cong_ty.Attributes[Ten_Thuoc_tinh] != null)
               Cong_ty.SetAttribute(Ten_Thuoc_tinh, Th_Thuoc_tinh.Text.Trim());     
        }
 
    }
    #endregion
}

