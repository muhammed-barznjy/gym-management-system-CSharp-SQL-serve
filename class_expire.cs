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
    class class_expire
    {
        DataTable DT;
        
        public DataTable View_Expire_Member()
        {
            DataTable DT = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            DT = ob.Reader("View_Expire_Member", null);
            ob.close();
            return DT;
        }
        public DataTable Search_member(string ID)
        {
            DataTable DT = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            p[0].Value = ID;
            DT = ob.Reader("Search_member", p);
            ob.close();
            return DT;
        }
        public void Delete_Member_Info(int M_ID)
        {
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("M_ID", SqlDbType.Int);
            p[0].Value = M_ID;
            ob.RUA("Delete_Member_Info", p);
            ob.close();
        }
        public DataTable View_All_Member()
        {
            DataTable DT = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            DT = ob.Reader("View_All_Member", null);
            ob.close();
            return DT;
        }
    }
}
