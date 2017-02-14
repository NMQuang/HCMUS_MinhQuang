using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
 
using System.Windows.Forms;
using System.Xml;
 
    public partial class MH_Ung_dung : Form
    {
        public MH_Ung_dung()
        {
            InitializeComponent();
        }
    #region "Biến/Đối tượng toàn cục"
    protected XL_LUU_TRU Luu_tru = new XL_LUU_TRU();
    protected XL_NGHIEP_VU Nghiep_vu = new XL_NGHIEP_VU();
    protected XL_THE_HIEN The_hien = new XL_THE_HIEN();

    protected XmlElement Goc;

    protected List<XmlElement> Danh_sach_Nhan_vien;
    protected string Thong_bao;
    protected string Thong_bao_PET;
    protected PET_Dong_ho_Ho_tro_thuc_hanh.XL_DONG_HO Dong_ho;
    #endregion
    #region "Xử lý giao diện"
    public void Xu_ly(XmlElement Goc)
    {
        this.Goc = Goc;
        XL_Bien_co_Khoi_dong();
     
        string Thong_bao_PET = "Thông báo PET : Có thể sử dụng đồng hồ PET\n ";
        Thong_bao_PET += "Đo thời gian đọc hay khởi động";
        Th_Thong_bao_PET.Text = Thong_bao_PET;

        this.ShowDialog();
    }
   
    #endregion
    #region "Xử lý Biến cố : Khởi động"
  protected void XL_Bien_co_Khoi_dong( )
    {
    
        Thong_bao = "Nhập chuỗi kết thúc với Enter  == > Xem danh sách nhân viên";
        The_hien.Xuat_Chuoi(Thong_bao, Th_Thong_bao);
        The_hien.Xuat_Yeu_cau_Nhap_Chuoi(Th_Chuoi_Ho_ten, XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Ho_ten);
    }


    #endregion

    #region "Xử lý Biến cố :  Yêu cầu Xử lý  "
    // Tra cứu 
    private void XL_Bien_co_Yeu_cau_Tra_cuu_Nhan_vien_theo_Ho_ten(object sender, KeyEventArgs Bc)
    {
        if (Bc.KeyCode== Keys.Enter)
        {  // Chuẩn bị đo thời gian thực hiện 
            Dong_ho = new PET_Dong_ho_Ho_tro_thuc_hanh.XL_DONG_HO();
            // Nhập 
            string Chuoi_Ho_ten = Th_Chuoi_Ho_ten.Text.Trim();
            // Xử lý 
            Danh_sach_Nhan_vien = Nghiep_vu.Tra_cuu_Nhan_vien_theo_Ho_ten(Goc,Chuoi_Ho_ten);
            Thong_bao = "Tìm thấy : " + Danh_sach_Nhan_vien.Count + " nhân viên " ;
            Dong_ho.Tao_Chuoi_Thoi_gian_do("Xử lý  BL:"); // Ghi nhận thời gian thực hiện BL 
            // Xuất

            Th_Danh_sach_Nhan_vien.Controls.Clear();
            foreach( XmlElement Nhan_vien in Danh_sach_Nhan_vien)
            {
                // Tạo thể hiện 
               Label Th_Nhan_vien = new Label() ;
                Th_Danh_sach_Nhan_vien.Controls.Add(Th_Nhan_vien);
                // Xuất thông tin 
                Th_Nhan_vien.Text = Nghiep_vu.Tao_Chuoi_Tom_tat_Nhan_vien(Nhan_vien);
                // Định dạng 
                Th_Nhan_vien.AutoSize = true;
                Th_Nhan_vien.ForeColor = Color.White;
                Th_Nhan_vien.BorderStyle = BorderStyle.FixedSingle;
            }

            The_hien.Xuat_Chuoi(Thong_bao, Th_Thong_bao);


            Th_Thong_bao_PET.Text = Dong_ho.Tao_Chuoi_Thoi_gian_do("Xử lý VL:");
            // Ghi nhận thời gian toàn bộ quá trình từ khi bắt đầu 
            // Các anh chị nên sử dụng đồng hồ PET để đó thời gian xử lý khi lập trình 
            // ( Chỉ cần Add Reference với DLL 
        }
           
    }
     
    #endregion
}

