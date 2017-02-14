using System;
using System.Collections.Generic;
 
using System.Text;
 
using System.Xml;
using System.Windows.Forms;
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
}

