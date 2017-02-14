using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QLHS
{
    class ketnoi
    {
        public static string chuoiKetNoi = @"Data Source=MINH_QUANG\SQLEXPRESS;Initial Catalog=QLHS;Integrated Security=True";
        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SqlConnection open()
        {
            con = new SqlConnection(chuoiKetNoi);
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
        public SqlConnection close()
        {
            con = new SqlConnection(chuoiKetNoi);
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }

        public DataTable truyVan(string sql)
        {
            open();
            dt = new DataTable();
            cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }

        public DataTable select_procedure(string tenProcedure)
        {
            dt = new DataTable();
            open();
            cmd = new SqlCommand(tenProcedure,con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public SqlCommand add_hocSinh(string mahs,string tenhs,string malop,DateTime ngaysinh,string gioitinh,double sdt)
        {
            open();
            cmd = new SqlCommand("add_hocsinh",con);
            cmd.Parameters.Add(new SqlParameter("@mahs", mahs));
            cmd.Parameters.Add(new SqlParameter("@tenhs", tenhs));
            cmd.Parameters.Add(new SqlParameter("@malop", malop));
            cmd.Parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
            cmd.Parameters.Add(new SqlParameter("@gioitinh", gioitinh));
            cmd.Parameters.Add(new SqlParameter("@sdt", sdt));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            close();
            return cmd;
        }

        public SqlCommand update_hocSinh(string mahs, string tenhs, string malop, DateTime ngaysinh, string gioitinh, double sdt)
        {
            open();
            cmd = new SqlCommand("update_hocsinh", con);
            cmd.Parameters.Add(new SqlParameter("@mahs", mahs));
            cmd.Parameters.Add(new SqlParameter("@tenhs", tenhs));
            cmd.Parameters.Add(new SqlParameter("@malop", malop));
            cmd.Parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
            cmd.Parameters.Add(new SqlParameter("@gioitinh", gioitinh));
            cmd.Parameters.Add(new SqlParameter("@sdt", sdt));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            close();
            return cmd;
        }
        public SqlCommand delete_hocsinh(string mahs)
        {
            open();
            cmd = new SqlCommand("delete_hocsinh", con);
            cmd.Parameters.Add(new SqlParameter("@mahs", mahs));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            close();
            return cmd;
        }
        public DataTable search_hocsinh(string chuoiTimKiem)
        {
            dt = new DataTable();
            
            open();
            cmd = new SqlCommand("search_hocsinh", con);
            cmd.Parameters.Add(new SqlParameter("@chuoiTimKiem", chuoiTimKiem));
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            close();
            return dt;
        }
        public void loadComboBox(ComboBox tenComboBox,string tenBang,string cotTen,string cotMa)
        {
            dt = new DataTable();
            dt = truyVan("select * from " + tenBang);
            tenComboBox.DataSource = dt;
            tenComboBox.DisplayMember = cotTen;
            tenComboBox.ValueMember = cotMa;
        }
    }
}
