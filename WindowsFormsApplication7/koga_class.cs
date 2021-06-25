using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    class koga_class
    {
        DataTable dt;
        public void Add_New_Expenses(string Name, string ChanDana, double Price, string TB, DateTime date)
        {
            //bangkrdnawayan
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            p[0].Value = Name;
            p[1] = new SqlParameter("@ChanDana", SqlDbType.NVarChar, 50);
            p[1].Value = ChanDana;
            p[2] = new SqlParameter("@Price", SqlDbType.NVarChar, 50);
            p[2].Value = Price;
            p[3] = new SqlParameter("@TB", SqlDbType.NVarChar, 50);
            p[3].Value = TB;
            p[4] = new SqlParameter("@Date", SqlDbType.Date);
            p[4].Value = date;
            ob.RUA("Add_New_Expenses", p);
            ob.close();
        }
        public void Update_Expenses(int ID, string Name, string ChanDana, double Price, string TB, DateTime date)
        {
            //bangkrdnawayan
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@ID", SqlDbType.Int);
            p[0].Value = ID;
            p[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            p[1].Value = Name;
            p[2] = new SqlParameter("@ChanDana", SqlDbType.NVarChar, 50);
            p[2].Value = ChanDana;
            p[3] = new SqlParameter("@Price", SqlDbType.NVarChar, 50);
            p[3].Value = Price;
            p[4] = new SqlParameter("@TB", SqlDbType.NVarChar, 50);
            p[4].Value = TB;
            p[5] = new SqlParameter("@Date", SqlDbType.Date);
            p[5].Value = date;
            ob.RUA("Update_Expenses", p);
            ob.close();
        }
        public DataTable View_All_Expenses()
        {
            DataTable dt = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            dt = ob.Reader("View_All_Expenses", null);
            ob.close();
            return dt;
        }
        public void Delete_All_Expenses_info(int M_ID)
        {
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("ID", SqlDbType.Int);
            p[0].Value = M_ID;
            ob.RUA("Delete_All_Expenses_info", p);
            ob.close();
        }
        public void Delete_All_Expens_info(int M_ID)
        {
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("ID", SqlDbType.Int);
            p[0].Value = M_ID;
            ob.RUA("Delete_All_Expens_info", p);
            ob.close();
        }
        public DataTable Search_Expenses(string ID)
        {
            DataTable dt = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            p[0].Value = ID;
            dt = ob.Reader("Search_Expenses", p);
            ob.close();
            return dt;
        }
    }
}
