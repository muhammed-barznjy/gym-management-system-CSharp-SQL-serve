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
    class Add_member_class
    {
        DataTable DT;
        public void Add_New_Member(string NAME, string AGE, string ISHTRAK, DateTime date, double price, string Gender,DateTime Expire)
        {
            // bang krdnawayan
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            p[0].Value = NAME;
            p[1] = new SqlParameter("@Age", SqlDbType.NVarChar, 50);
            p[1].Value = AGE;
            p[2] = new SqlParameter("@Ishtrak", SqlDbType.NVarChar, 50);
            p[2].Value = ISHTRAK;
            p[3] = new SqlParameter("@Date", SqlDbType.Date);
            p[3].Value = date;
            p[4] = new SqlParameter("@Price", SqlDbType.NVarChar, 50);
            p[4].Value = price;
            p[5] = new SqlParameter("@Gender", SqlDbType.NVarChar, 50);
            p[5].Value = Gender;
            p[6] = new SqlParameter("@Expire", SqlDbType.Date);
            p[6].Value = Expire;
            ob.RUA("Add_New_Member", p);
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
       
        public void Update_Member(int ID, string NAME, string AGE, string ISHTRAK, DateTime date, double price, string Gender, DateTime Expire)
        {
            // bang krdnawayan
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@ID", SqlDbType.Int);
            p[0].Value = ID;
            p[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            p[1].Value = NAME;
            p[2] = new SqlParameter("@Age", SqlDbType.NVarChar, 50);
            p[2].Value = AGE;
            p[3] = new SqlParameter("@Ishtrak", SqlDbType.NVarChar, 50);
            p[3].Value = ISHTRAK;
            p[4] = new SqlParameter("@Date", SqlDbType.Date);
            p[4].Value = date;
            p[5] = new SqlParameter("@Price", SqlDbType.NVarChar, 50);
            p[5].Value = price;
            p[6] = new SqlParameter("@Gender", SqlDbType.NVarChar, 50);
            p[6].Value = Gender;
            p[7] = new SqlParameter("@Expire", SqlDbType.Date);
            p[7].Value = Expire;
            ob.RUA("Update_Member", p);
            ob.close();
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
        public void Delete_All_Member_Info(int M_ID)
        {
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ID", SqlDbType.Int);
            p[0].Value = M_ID;
            ob.RUA("Delete_All_Member_Info", p);
            ob.close();
        }
        public DataTable View_All_Ishtrak()
        {
            DataTable DT = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            DT = ob.Reader("View_All_Ishtrak", null);
            ob.close();
            return DT;
        }

    }   
}
