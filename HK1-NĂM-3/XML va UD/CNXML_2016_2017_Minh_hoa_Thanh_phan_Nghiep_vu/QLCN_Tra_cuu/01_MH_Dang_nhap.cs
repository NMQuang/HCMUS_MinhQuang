using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
 
using System.Windows.Forms;
using System.Xml;
 
    public partial class MH_Dang_nhap : Form
    {
        public MH_Dang_nhap()
        {
            InitializeComponent();
        }

    #region "Biến/Đối tượng toàn cục"

    protected static string Ten_Dang_nhap_Ren_luyen_Ky_nang = "QLCN_1";
    protected static string Mat_khau_Ren_luyen_Ky_nang = Ten_Dang_nhap_Ren_luyen_Ky_nang;

    protected XL_LUU_TRU Luu_tru = new XL_LUU_TRU();
        protected XL_NGHIEP_VU  Nghiep_vu =new XL_NGHIEP_VU();
        protected XL_THE_HIEN The_hien = new XL_THE_HIEN();

       

        protected string Ten_Dang_nhap;
         protected string Mat_khau;
        protected string Thong_bao;
    #endregion

    #region "Xử lý giao diện"
    public void Xu_ly()
    {
        XL_Bien_co_Khoi_dong();
        this.ShowDialog();
    }
    #endregion
    #region "Xử lý Biến cố : Khởi động"
   protected  void XL_Bien_co_Khoi_dong()
        {
        // Khởi động giá trị biến/đối tượng
        Ten_Dang_nhap =  Ten_Dang_nhap_Ren_luyen_Ky_nang;
        Mat_khau = Mat_khau_Ren_luyen_Ky_nang;
        Thong_bao = Nghiep_vu.Tao_Chuoi_Thong_bao_MH_Dang_nhap();

        // Khởi động thể hiện 
        The_hien.Xuat_Chuoi(Ten_Dang_nhap, Th_Ten_Dang_nhap);
        The_hien.Xuat_Chuoi(Mat_khau, Th_Mat_khau);
        The_hien.Xuat_Chuoi(Thong_bao, Th_Thong_bao);
        //Lưu ý PET : Sẽ bổ sung xử lý chuẩn bị hàm xử lý biến cố trong XL_THE_HIEN trong phiên bản khác 

        Th_Yeu_cau_Dang_nhap.Click += XL_Bien_co_Yeu_cau_Dang_nhap;

       
        
        }




    #endregion

    #region "Xử lý Biến cố : Yêu cầu thực hiện xử lý"
    private void XL_Bien_co_Yeu_cau_Dang_nhap(object sender, EventArgs e)
    {
        Ten_Dang_nhap = The_hien.Nhap_Chuoi(Th_Ten_Dang_nhap);
        Mat_khau = The_hien.Nhap_Chuoi(Th_Mat_khau);
        XmlElement Goc = Luu_tru.Dang_nhap(Ten_Dang_nhap, Mat_khau);
        if (Goc != null && Goc.ChildNodes.Count > 0)
        {
            MH_Ung_dung Mh = new MH_Ung_dung();
            Mh.Xu_ly(Goc);
          
            Thong_bao = "Bạn đã xem minh họa ";
        }
        else
            Thong_bao = "Đăng nhập không hợp lệ";
        The_hien.Xuat_Chuoi(Thong_bao, Th_Thong_bao);
    }
    #endregion
}

