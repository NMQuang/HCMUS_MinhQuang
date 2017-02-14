using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//===   Thư viện này minh họa các xử lý nghiệp vụ nội bộ dùng chung cho hệ khách và Dịch vụ 
//  ( không được phép gọi trực tiếp từ bên ngoài )
// Lưu ý : Với mục tiêu minh họa kỹ thuật  thư viện sẽ
//  - Có rất nhiều hàm không cần thiết trong ngữ cảnh của QLNV_1
//  - Có 1 số hàm sẽ sử dụng trong ngữ cảnh QLNV_2
// Các anh chị xem Cấu trúc Source Code và áp dụng thích hợp vào đồ án ( nếu muốn !!! )
namespace Thu_vien_Nghiep_vu
{
    public class XL_NGHIEP_VU

    {
        
        protected List<XmlElement> Trich_rut_Danh_sach_Don_vi_theo_ID_CONG_TY(XmlElement Goc,
                                                                               int ID_CONG_TY)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Chi_nhanh in Trich_rut_Danh_sach_Chi_nhanh_theo_ID_CONG_TY(Goc, ID_CONG_TY))
            {
                int ID_CHI_NHANH = int.Parse(Chi_nhanh.GetAttribute("ID"));
                Kq.AddRange(Trich_rut_Danh_sach_Don_vi_theo_ID_CHI_NHANH(Goc, ID_CHI_NHANH));
            }
            return Kq;
        }

        protected List<XmlElement> Trich_rut_Danh_sach_Nhan_vien_theo_ID_CHI_NHANH(XmlElement Goc,
                                                                              int ID_CHI_NHANH)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Don_vi in Trich_rut_Danh_sach_Don_vi_theo_ID_CHI_NHANH(Goc, ID_CHI_NHANH))
            {
                int ID_DON_VI = int.Parse(Don_vi.GetAttribute("ID"));
                Kq.AddRange(Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(Goc, ID_DON_VI));
            }
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Nhan_vien_theo_ID_CONG_TY(XmlElement Goc,
                                                                                int ID_CONG_TY)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Don_vi in Trich_rut_Danh_sach_Don_vi_theo_ID_CONG_TY(Goc, ID_CONG_TY))
            {
                int ID_DON_VI = int.Parse(Don_vi.GetAttribute("ID"));
                Kq.AddRange(Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(Goc, ID_DON_VI));
            }
            return Kq;
        }
        //============= Xử lý cơ sở ===========
        //
        #region "Loại đối tượng GIOI_TINH"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Gioi_tinh(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("GIOI_TINH"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Gioi_tinh_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Gioi_tinh(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Gioi_tinh_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Gioi_tinh(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Gioi_tinh_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Gioi_tinh(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        //
        protected XmlElement Trich_rut_Gioi_tinh_theo_Nhan_vien(XmlElement Goc,
                                                                                 XmlElement Nhan_vien)
        {
            XmlElement Kq = Trich_rut_Gioi_tinh_theo_ID(Goc, Nhan_vien.GetAttribute("ID_GIOI_TINH"));
            return Kq;
        }
        //


        #endregion
        //

        #region "Loại đối tượng NGOAI_NGU"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Ngoai_ngu(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("NGOAI_NGU"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Ngoai_ngu_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Ngoai_ngu(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Ngoai_ngu_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Ngoai_ngu(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Ngoai_ngu_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Ngoai_ngu(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        //
        protected XmlElement Trich_rut_Ngoai_ngu_theo_Nhan_vien(XmlElement Goc,
                                                                                 XmlElement Nhan_vien)
        {
            XmlElement Kq = Trich_rut_Ngoai_ngu_theo_ID(Goc, Nhan_vien.GetAttribute("ID_NGOAI_NGU"));
            return Kq;
        }
        //


        #endregion
        //

        #region "Loại đối tượng CONG_TY"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Cong_ty(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("CONG_TY"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Cong_ty_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Cong_ty(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Cong_ty_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Cong_ty(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Cong_ty_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Cong_ty(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        //
        protected XmlElement Trich_rut_Cong_ty_theo_Chi_nhanh(XmlElement Goc,
                                                                                 XmlElement Chi_nhanh)
        {
            XmlElement Kq = Trich_rut_Cong_ty_theo_ID(Goc, Chi_nhanh.GetAttribute("ID_CONG_TY"));
            return Kq;
        }
        //

        protected XmlElement Trich_rut_Cong_ty_theo_Qlct(XmlElement Goc,
                                                                                 XmlElement Qlct)
        {
            XmlElement Kq = Trich_rut_Cong_ty_theo_ID(Goc, Qlct.GetAttribute("ID_CONG_TY"));
            return Kq;
        }
        //


        #endregion
        //

        #region "Loại đối tượng CHI_NHANH"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Chi_nhanh(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("CHI_NHANH"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Chi_nhanh_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Chi_nhanh(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Chi_nhanh_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Chi_nhanh(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Chi_nhanh_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Chi_nhanh(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        protected List<XmlElement> Trich_rut_Danh_sach_Chi_nhanh_theo_ID_CONG_TY(XmlElement Goc,
                                                                                  int ID_CONG_TY)
        {
            List<XmlElement> Kq = Danh_sach_Chi_nhanh(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_CONG_TY") == ID_CONG_TY.ToString());
            return Kq;
        }
        //

        //
        protected XmlElement Trich_rut_Chi_nhanh_theo_Don_vi(XmlElement Goc,
                                                                                 XmlElement Don_vi)
        {
            XmlElement Kq = Trich_rut_Chi_nhanh_theo_ID(Goc, Don_vi.GetAttribute("ID_CHI_NHANH"));
            return Kq;
        }
        //

        protected XmlElement Trich_rut_Chi_nhanh_theo_Qlcn(XmlElement Goc,
                                                                                 XmlElement Qlcn)
        {
            XmlElement Kq = Trich_rut_Chi_nhanh_theo_ID(Goc, Qlcn.GetAttribute("ID_CHI_NHANH"));
            return Kq;
        }
        //


        #endregion
        //

        #region "Loại đối tượng DON_VI"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Don_vi(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("DON_VI"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Don_vi_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Don_vi(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Don_vi_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Don_vi(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Don_vi_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Don_vi(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        protected List<XmlElement> Trich_rut_Danh_sach_Don_vi_theo_ID_CHI_NHANH(XmlElement Goc,
                                                                                  int ID_CHI_NHANH)
        {
            List<XmlElement> Kq = Danh_sach_Don_vi(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_CHI_NHANH") == ID_CHI_NHANH.ToString());
            return Kq;
        }

        //

        //
        protected XmlElement Trich_rut_Don_vi_theo_Nhan_vien(XmlElement Goc,
                                                                                 XmlElement Nhan_vien)
        {
            XmlElement Kq = Trich_rut_Don_vi_theo_ID(Goc, Nhan_vien.GetAttribute("ID_DON_VI"));
            return Kq;
        }
        //

        protected XmlElement Trich_rut_Don_vi_theo_Qldv(XmlElement Goc,
                                                                                 XmlElement Qldv)
        {
            XmlElement Kq = Trich_rut_Don_vi_theo_ID(Goc, Qldv.GetAttribute("ID_DON_VI"));
            return Kq;
        }
        //


        #endregion
        //

        #region "Loại đối tượng NHAN_VIEN"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Nhan_vien(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("NHAN_VIEN"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Nhan_vien_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Nhan_vien(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Nhan_vien_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Nhan_vien(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Nhan_vien_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        protected List<XmlElement> Trich_rut_Danh_sach_Nhan_vien_theo_ID_GIOI_TINH(XmlElement Goc,
                                                                                  int ID_GIOI_TINH)
        {
            List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_GIOI_TINH") == ID_GIOI_TINH.ToString());
            return Kq;
        }
        //

        protected List<XmlElement> Trich_rut_Danh_sach_Nhan_vien_theo_ID_DON_VI(XmlElement Goc,
                                                                                  int ID_DON_VI)
        {
            List<XmlElement> Kq = Danh_sach_Nhan_vien(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_DON_VI") == ID_DON_VI.ToString());
            return Kq;
        }
        //

        //
        protected XmlElement Trich_rut_Nhan_vien_theo_Nv(XmlElement Goc,
                                                                                 XmlElement Nv)
        {
            XmlElement Kq = Trich_rut_Nhan_vien_theo_ID(Goc, Nv.GetAttribute("ID_NHAN_VIEN"));
            return Kq;
        }
        //


        #endregion
        //

        #region "Loại đối tượng QLCT"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Qlct(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("QLCT"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Qlct_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Qlct(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Qlct_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Qlct(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Qlct_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Qlct(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        protected List<XmlElement> Trich_rut_Danh_sach_Qlct_theo_ID_CONG_TY(XmlElement Goc,
                                                                                  int ID_CONG_TY)
        {
            List<XmlElement> Kq = Danh_sach_Qlct(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_CONG_TY") == ID_CONG_TY.ToString());
            return Kq;
        }
        //

        //

        #endregion
        //

        #region "Loại đối tượng QLCN"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Qlcn(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("QLCN"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Qlcn_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Qlcn(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Qlcn_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Qlcn(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Qlcn_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Qlcn(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        protected List<XmlElement> Trich_rut_Danh_sach_Qlcn_theo_ID_CHI_NHANH(XmlElement Goc,
                                                                                  int ID_CHI_NHANH)
        {
            List<XmlElement> Kq = Danh_sach_Qlcn(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_CHI_NHANH") == ID_CHI_NHANH.ToString());
            return Kq;
        }
        //

        //

        #endregion
        //

        #region "Loại đối tượng QLDV"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Qldv(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("QLDV"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Qldv_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Qldv(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Qldv_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Qldv(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Qldv_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Qldv(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        protected List<XmlElement> Trich_rut_Danh_sach_Qldv_theo_ID_DON_VI(XmlElement Goc,
                                                                                  int ID_DON_VI)
        {
            List<XmlElement> Kq = Danh_sach_Qldv(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_DON_VI") == ID_DON_VI.ToString());
            return Kq;
        }
        //

        //

        #endregion
        //

        #region "Loại đối tượng NV"
        //====Trích rút Cấp 0
        protected List<XmlElement> Danh_sach_Nv(XmlElement Goc)
        {
            List<XmlElement> Kq = new List<XmlElement>();
            foreach (XmlElement Nut in Goc.SelectNodes("NV"))
                Kq.Add(Nut);
            return Kq;
        }
        //== Trích rút Cấp 1
        protected XmlElement Trich_rut_Nv_theo_ID(XmlElement Goc, int ID)
        {
            XmlElement Kq = Danh_sach_Nv(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID.ToString());
            return Kq;
        }
        protected XmlElement Trich_rut_Nv_theo_ID(XmlElement Goc, string ID)
        {
            XmlElement Kq = Danh_sach_Nv(Goc).FirstOrDefault(
                                                x => x.GetAttribute("ID") == ID);
            return Kq;
        }
        protected List<XmlElement> Trich_rut_Danh_sach_Nv_theo_DS_ID(XmlElement Goc, string DS_ID)
        {
            List<XmlElement> Kq = Danh_sach_Nv(Goc);
            string[] M = DS_ID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Kq = Kq.FindAll(x => M.Contains(x.GetAttribute("ID")));
            return Kq;
        }
        //
        protected List<XmlElement> Trich_rut_Danh_sach_Nv_theo_ID_NHAN_VIEN(XmlElement Goc,
                                                                                  int ID_NHAN_VIEN)
        {
            List<XmlElement> Kq = Danh_sach_Nv(Goc);
            Kq = Kq.FindAll(x => x.GetAttribute("ID_NHAN_VIEN") == ID_NHAN_VIEN.ToString());
            return Kq;
        }
        //

        //

        #endregion


    }

}