using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    class class_ishtrak
    {
     
            DataTable DT;
            public void add_New_Ishtrak(string Ishtrak)
            {
                //bang krdnawayan
                WindowsFormsApplication7.my_class ob = new my_class();
                ob.open();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Ishtrak", SqlDbType.NVarChar, 50);
                p[0].Value = Ishtrak;
                ob.RUA("Add_new_Ishtrak", p);
                ob.close();
            }
        }
    
}
