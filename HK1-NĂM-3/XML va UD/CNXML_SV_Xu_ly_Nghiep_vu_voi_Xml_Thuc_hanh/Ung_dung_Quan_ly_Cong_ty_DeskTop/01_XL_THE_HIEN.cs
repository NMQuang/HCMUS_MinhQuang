using System;
using System.Collections.Generic;
 
using System.Text;
 
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
 public    class XL_THE_HIEN
{

    #region "Biến/Đối tượng toàn cục"
    static XL_NGHIEP_VU Nghiep_vu = new XL_NGHIEP_VU();
    static ToolTip Th_Ghi_chu = new ToolTip();
    #endregion

    #region "Xử lý : Khởi động"
    public XL_THE_HIEN()
    {
        Th_Ghi_chu.IsBalloon = true;
        // Đơn giản quá ? 
    }
    #endregion

    #region "Xử lý : Nhập - Xuất chuỗi "
    public void  Xuat_Chuoi(string Chuoi, Control Th)
    {
        // Lưu ý PET : Hàm này sẽ cải tiến trong 1 phiên bản khác 
        Th.Text = Chuoi;
    }
    public string Nhap_Chuoi(Control Th)
    {
        string Kq;
        // Lưu ý PET : Hàm này sẽ cải tiến trong 1 phiên bản khác 
        Kq = Th.Text.Trim();
        return Kq;

    }
    #endregion

     

    #region "Xử lý : Nhập xuất yêu cầu"
    public void Xuat_Yeu_cau_Nhap_Chuoi(Control Th_Chuoi,  KeyEventHandler XL_Bien_co_Nhap_Chuoi)
    {  // Câu hỏi PET : Hàm quá  đơn giản !!! Tạo sao phải tạo hàm này ???
        Th_Chuoi.KeyDown += XL_Bien_co_Nhap_Chuoi;
    }
    #endregion

    #region "Xử lý : Xuất danh sách"
    // Lưu ý PET : Đây chỉ là hàm tạm thời == > Sẽ phải cải tiến
    public void Xuat_Danh_sach_Nhan_vien(List<XmlElement> Danh_sach_Nhan_vien,
                                FlowLayoutPanel Th_Danh_sach_Nhan_vien)
    {
        Th_Danh_sach_Nhan_vien.Controls.Clear();
        foreach (XmlElement Nhan_vien in Danh_sach_Nhan_vien)
        {
            // Tạo thể hiện 
             Button Th_Nhan_vien = new Button();
            Th_Danh_sach_Nhan_vien.Controls.Add(Th_Nhan_vien);
            // Xuất thông tin 
            string Chuoi_Tom_tat = Nhan_vien.GetAttribute("Ho_ten");// Tạm thời không dùng XL_NGHIEP_VU
            Th_Nhan_vien.Text =Chuoi_Tom_tat;
            string Chuoi_Thong_tin = Nhan_vien.GetAttribute("Ho_ten") + "\n";// Tạm thời không dùng XL_NGHIEP_VU
            Chuoi_Thong_tin += Nhan_vien.GetAttribute("Muc_luong");
            // Có thể bổ sung thêm thông tin
            Th_Ghi_chu.SetToolTip(Th_Nhan_vien, Chuoi_Thong_tin);
            // Định dạng 
            Th_Nhan_vien.Font = new Font("Arial", 10);
            Th_Nhan_vien.Size = new Size(100, 50);
            Th_Nhan_vien.BackColor = Color.White;
            Th_Nhan_vien.ForeColor = Color.Blue;
        }
    }
    #endregion
}

