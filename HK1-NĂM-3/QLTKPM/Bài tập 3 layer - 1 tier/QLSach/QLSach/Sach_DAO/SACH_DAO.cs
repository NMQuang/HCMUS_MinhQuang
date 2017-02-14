using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLSach.Sach_DTO;
namespace QLSach.Sach_DAO
{
    public class sqlConnectionData
    {
        public static SqlConnection KET_NOI()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MINH_QUANG\SQLEXPRESS;Initial Catalog=QLHS;Integrated Security=True");
            return con;
        }
    }
    public class SACH_DAO
    {
        //load danh sách tất cả sách
        public static DataTable layDanhSachTatCaSach()
        {
            SqlConnection con = sqlConnectionData.KET_NOI();
            SqlCommand cmd = new SqlCommand("store_TatCaSach", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Thêm 1 sách mới
        public static void themSachMoi(SACH_DTO sach)
        {
            SqlConnection con = sqlConnectionData.KET_NOI();
            SqlCommand cmd = new SqlCommand("store_Them", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenSach", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DonGia", SqlDbType.Float);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@NXB", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@LoaiSach", SqlDbType.NVarChar, 50);
            //Gán giá trị
            cmd.Parameters["@TenSach"].Value = sach.TenSach;
            cmd.Parameters["@DonGia"].Value = sach.DonGia;
            cmd.Parameters["@SoLuong"].Value = sach.SoLuong;
            cmd.Parameters["@NXB"].Value = sach.NXB;
            cmd.Parameters["@LoaiSach"].Value = sach.LoaiSach;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Xóa 1 sách
        public static void xoaSach(int maSach)
        {
            SqlConnection con = sqlConnectionData.KET_NOI();
            SqlCommand cmd = new SqlCommand("store_Xoa",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maSach", SqlDbType.Int);
            cmd.Parameters["@maSach"].Value = maSach;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}
