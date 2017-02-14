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

    protected XmlElement Du_lieu;
    protected string Chuoi_Du_lieu;

    protected string Thong_bao;
    #endregion

    #region "Xử lý Biến cố : Khởi động"
    public void XL_Bien_co_Khoi_dong(XmlElement Du_lieu)
    {
        this.Du_lieu = Du_lieu;
        Thong_bao = "Click chọn yêu cầu == > Xem kết quả";


        The_hien.Xuat_Chuoi(Thong_bao, Th_Thong_bao);
        Th_Yeu_cau_Xem_Thong_tin_Du_lieu.Click += XL_Bien_co_Yeu_cau_Xem_Thong_tin_Du_lieu;
        Th_Yeu_cau_Xem_Cau_truc_Du_lieu.Click += XL_Bien_co_Yeu_cau_Xem_Cau_truc_Du_lieu;
    }


    #endregion

    #region "Xử lý Biến cố :  Yêu cầu Xử lý  "
    
    private void XL_Bien_co_Yeu_cau_Xem_Thong_tin_Du_lieu(object sender, EventArgs e)
    {
        Chuoi_Du_lieu = Nghiep_vu.Tao_Chuoi_Thong_tin(Du_lieu);
        Thong_bao = "Yêu cấu Xem Thông tin : Không có thông báo nào hết  !!!";

        The_hien.Xuat_Chuoi(Chuoi_Du_lieu, Th_Du_lieu);
        The_hien.Xuat_Chuoi(Thong_bao, Th_Thong_bao);
    }
    private void XL_Bien_co_Yeu_cau_Xem_Cau_truc_Du_lieu(object sender, EventArgs e)
    {
        Chuoi_Du_lieu = Nghiep_vu.Tao_Chuoi_Cau_truc(Du_lieu);
        Thong_bao = "Yêu cấu Xem Cấu trúc : Không có thông báo nào hết  !!!";


        The_hien.Xuat_Chuoi(Chuoi_Du_lieu, Th_Du_lieu);
        The_hien.Xuat_Chuoi(Thong_bao, Th_Thong_bao);
    }
    #endregion
}

