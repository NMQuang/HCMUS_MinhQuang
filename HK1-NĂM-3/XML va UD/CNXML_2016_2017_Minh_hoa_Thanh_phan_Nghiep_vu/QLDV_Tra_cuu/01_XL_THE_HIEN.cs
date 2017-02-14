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

    #endregion

    #region "Xử lý : Khởi động"

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
   
}

