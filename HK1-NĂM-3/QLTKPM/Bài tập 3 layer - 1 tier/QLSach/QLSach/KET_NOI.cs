using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLSach
{
    class KET_NOI
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
    }
}
