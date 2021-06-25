using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApplication7;

namespace WindowsFormsApplication7
{
    class Employees
    {
        DataTable dt;
        public void Add_new_Employees(string Name, string Tell, string Jobe, string Salary, DateTime Date)
        {
            //bang krdnawayan
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            p[0].Value = Name;
            p[1] = new SqlParameter("@Tell", SqlDbType.NVarChar, 50);
            p[1].Value = Tell;
            p[2] = new SqlParameter("@Jobe", SqlDbType.NVarChar, 50);
            p[2].Value = Jobe;
            p[3] = new SqlParameter("@Salary", SqlDbType.NVarChar, 50);
            p[3].Value = Salary;
            p[4] = new SqlParameter("@Date", SqlDbType.Date);
            p[4].Value = Date;
            ob.RUA("Add_new_Employees", p);
            ob.close();
        }
        public void Update_employees(int ID, string Name, string Tell, string Jobe, string Salary, DateTime Date)
        {
            //bang krdnawayan
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@ID", SqlDbType.Int);
            p[0].Value = ID;
            p[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            p[1].Value = Name;
            p[2] = new SqlParameter("@Tell", SqlDbType.NVarChar, 50);
            p[2].Value = Tell;
            p[3] = new SqlParameter("@Job", SqlDbType.NVarChar, 50);
            p[3].Value = Jobe;
            p[4] = new SqlParameter("@Salary", SqlDbType.NVarChar, 50);
            p[4].Value = Salary;
            p[5] = new SqlParameter("@Date", SqlDbType.Date);
            p[5].Value = Date;
            ob.RUA("Update_employees", p);
            ob.close();
        }
        public void Delete_Employees_info(int M_ID)
        {
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("M_ID", SqlDbType.Int);
            p[0].Value = M_ID;
            ob.RUA("Delete_Employees_info", p);
            ob.close();
        }
        public void Delete_All_Employees_info(int ID)
        {
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("ID", SqlDbType.Int);
            p[0].Value = ID;
            ob.RUA("Delete_All_Employees_info", p);
            ob.close();
        }
        public DataTable View_All_Employees()
        {
            DataTable dt = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            dt = ob.Reader("View_All_Employees", null);
            ob.close();
            return dt;
        }
        public DataTable Search_Employees(string ID)
        {
            DataTable dt = new DataTable();
            WindowsFormsApplication7.my_class ob = new my_class();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            p[0].Value = ID;
            dt = ob.Reader("Search_Employees", p);
            ob.close();
            return dt;
        }
    }
}
