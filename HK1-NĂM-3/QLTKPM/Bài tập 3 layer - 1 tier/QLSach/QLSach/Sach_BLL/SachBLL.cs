using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSach.Sach_DAO;
using QLSach.Sach_DTO;
using System.Data;
namespace QLSach.Sach_BLL
{
    public class SachBLL
    {
        //Load danh sách tất cả sách
        public static DataTable LoadAllBook()
        {
            return SACH_DAO.layDanhSachTatCaSach();
        }
        //Thêm 1 sách mới
        public static void AddBook(SACH_DTO sach)
        {
            SACH_DAO.themSachMoi(sach);
        }

        //Xóa 1 sách
        public static void DeleteBook(int maSach)
        {
            SACH_DAO.xoaSach(maSach);
        }
    }
}
