using System;
using System.Collections.Generic;
 
using System.Text;
 
using System.Xml;
public partial class XL_NGHIEP_VU
{
    #region "Biến/Đối tượng toàn cục"

    #endregion

    #region "Xử lý : Khởi động"

    #endregion

    #region "Xử lý : Tạo chuỗi "
    // Lưu ý PET :
    // 1- Thuật giải của các hàm xử lý chỉ nhằm minh họa cú pháp của DOM 
    // == > Có thể sẽ phải áp dụng thuật giải khác với ứng dụng cụ thể 
    // Câu hỏi PET : Tạo sao phải đổi thuật giải ???
    // 2- Cả 2 Hàm xử lý  Tạo chuỗi có cùng đoạn Code 
    //  == > Cần tách thành hàm xử lý riêng 
    // Câu hỏi PET : Tạo sao tách hàm xử lý riêng ???
    public string Tao_Chuoi_Thong_tin(XmlElement Du_lieu)
    {
        string Kq = "";
        // Bước 1 : Xác định danh sách tên các loại đối tượng 
        List<string> Danh_sach_Ten_Loai_Doi_tuong = new List<string>();
        foreach (XmlElement Doi_tuong in Du_lieu.ChildNodes)
        {
            string Ten_Loai_Doi_tuong = Doi_tuong.Name;
            if (!Danh_sach_Ten_Loai_Doi_tuong.Contains(Ten_Loai_Doi_tuong))
                Danh_sach_Ten_Loai_Doi_tuong.Add(Ten_Loai_Doi_tuong);
        }
        // Bước 2 : Tạo chuỗi thông tin dựa trên kết quả bước 1 
        Kq = Du_lieu.Name + "\n";
        foreach (string Ten_Loai_Doi_tuong in Danh_sach_Ten_Loai_Doi_tuong)
            Kq += Ten_Loai_Doi_tuong + ":" + Du_lieu.SelectNodes(Ten_Loai_Doi_tuong).Count + "\n";
        return Kq;
    }

    public string Tao_Chuoi_Cau_truc(XmlElement Du_lieu)
    {
        string Kq = "";
        // Bước 1 : Xác định danh sách tên các loại đối tượng 
        List<string> Danh_sach_Ten_Loai_Doi_tuong = new List<string>();
        foreach (XmlElement Doi_tuong in Du_lieu.ChildNodes)
        {
            string Ten_Loai_Doi_tuong = Doi_tuong.Name;
            if (!Danh_sach_Ten_Loai_Doi_tuong.Contains(Ten_Loai_Doi_tuong))
                Danh_sach_Ten_Loai_Doi_tuong.Add(Ten_Loai_Doi_tuong);
        }
        // Bước 2 : Tạo chuỗi cấu trúc  dựa trên kết quả bước 1 
        Kq = Du_lieu.Name + "\n";
        foreach (string Ten_Loai_Doi_tuong in Danh_sach_Ten_Loai_Doi_tuong)
        {
            XmlElement Doi_tuong = (XmlElement) Du_lieu.SelectSingleNode(Ten_Loai_Doi_tuong);
            Kq += Ten_Loai_Doi_tuong + ": \n";
            foreach (XmlAttribute Thuoc_tinh in Doi_tuong.Attributes)
                Kq += "  " +Thuoc_tinh.Name + " ";

            Kq += "\n";
        }
      
        return Kq;
    }
    #endregion

}

