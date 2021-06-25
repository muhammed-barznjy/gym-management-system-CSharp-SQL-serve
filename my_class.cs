using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WindowsFormsApplication7
{
    class my_class
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlConnection cn;
        DataTable DT = new DataTable();

        public my_class()
        {
            cn = new SqlConnection(@"Data Source=DESKTOP-AKR4EDF;Initial Catalog=gym_system;Integrated Security=True");
        }
        public void open()
        {
            if(cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        public void close()
        {
            if(cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        //bo xwendnaway zanyariakany database ba proceger
        public DataTable Reader(string sp,SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if(p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            da = new SqlDataAdapter(cmd);
            da.Fill(DT);
            return DT;
        }
        //bo ziad krdn u srinawa w update
        public void RUA (string sp,SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if(p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
