using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BEL;
using System.Data;
using System.Data.SqlClient;
namespace BAL
{
    public class Operation
    {
        public DBConnect db = new DBConnect();
        public Infomation info = new Infomation();

        public int insertEmp(Infomation info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO empRegister VALUES ('" + info.name + "','" + info.gender + "','" + info.dob + "','" + info.address + "','" + info.education + "','" + info.username + "','" + info.password + "')";
            return db.ExeNonQuery(cmd);
        }

        public DataTable login(Infomation info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from empRegister where Username='" + info.username + "' and Password='" + info.password + "'";
            return db.ExeReader(cmd);
        }

        public DataTable viewemployees(Infomation info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from empregister where usertype='U'";
            return db.ExeReader(cmd);

        }
    }
}
