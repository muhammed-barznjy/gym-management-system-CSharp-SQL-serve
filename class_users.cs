using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    class class_users
    {
        DataTable dt;
        public void Add_New_User(string UserName, string Password, string UserType)
        {
            //bang krdnawa
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            p[0].Value = UserName;
            p[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            p[1].Value = Password;
            p[2] = new SqlParameter("@UserType", SqlDbType.NVarChar, 50);
            p[2].Value = UserType;
            ob.RUA("Add_New_User", p);
            ob.close();
        }
        public DataTable View_All_Users()
        {
            DataTable dt = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            dt = ob.Reader("View_All_Users", null);
            ob.close();
            return dt;
        }
        public void Update_Users(int ID, string UserName, string Password, string UserType)
        {
            //bang krdnawa
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@ID", SqlDbType.Int);
            p[0].Value = ID;
            p[1] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            p[1].Value = UserName;
            p[2] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            p[2].Value = Password;
            p[3] = new SqlParameter("@UserType", SqlDbType.NVarChar, 50);
            p[3].Value = UserType;
            ob.RUA("Update_Users", p);
            ob.close();
        }
        public void Delete_User(int M_ID)
        {
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@M_ID", SqlDbType.Int);
            p[0].Value = M_ID;
            ob.RUA("Delete_User", p);
            ob.close();
        }
        public DataTable Search_Users(string ID)
        {
            DataTable dt = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            p[0].Value = ID;
            dt = ob.Reader("Search_Users", p);
            ob.close();
            return dt;
        }
    }
}
