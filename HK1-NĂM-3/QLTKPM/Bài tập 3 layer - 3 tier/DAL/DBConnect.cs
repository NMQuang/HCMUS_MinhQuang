using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnect
    {
        public SqlConnection con = new SqlConnection("");
        public SqlConnection getCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }

        public int ExeNonQuery(SqlCommand cmd)
        {
            cmd.Connection = getCon();
            int row = -1;
            row = cmd.ExecuteNonQuery();
            con.Close();
            return row;
        }

        public object ExeScalar(SqlCommand cmd)
        {
            cmd.Connection = getCon();
            object obj = -1;
            obj = cmd.ExecuteScalar();
            con.Close();
            return obj;
        }

        public DataTable ExeReader(SqlCommand cmd) 
        {
            cmd.Connection = getCon();
            SqlDataReader sdr;
            DataTable dt = new DataTable();
            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;


        }
    }
}
