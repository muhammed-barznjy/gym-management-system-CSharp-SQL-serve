using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    class login
    {
        public DataTable sp_login(string UserName, string Password, string UserType)
        {
            my_class op = new my_class();
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            p[0].Value = UserName;
            p[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            p[1].Value = Password;
            p[2] = new SqlParameter("@UserType", SqlDbType.NVarChar, 50);
            p[2].Value = UserType;
            op.open();
            dt = op.Reader("sp_login", p);
            op.close();
            return dt;
        }
    }
}
