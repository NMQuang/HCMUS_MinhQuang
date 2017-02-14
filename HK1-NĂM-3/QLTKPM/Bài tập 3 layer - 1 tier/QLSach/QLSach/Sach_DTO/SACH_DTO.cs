using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.Sach_DTO
{
    public class SACH_DTO
    {
        private string maSach;

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        string tenSach;

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }
        float donGia;

        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        string loaiSach;

        public string LoaiSach
        {
            get { return loaiSach; }
            set { loaiSach = value; }
        }
        string nXB;

        public string NXB
        {
            get { return nXB; }
            set { nXB = value; }
        }
        int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public SACH_DTO(string maSach,string tenSach,float donGia,string loaiSach,string nxb,int soLuong){
            MaSach = maSach;
            TenSach = tenSach;
            DonGia = donGia;
            LoaiSach = loaiSach;
            NXB = nxb;
            SoLuong = soLuong;
        }
    }
}
