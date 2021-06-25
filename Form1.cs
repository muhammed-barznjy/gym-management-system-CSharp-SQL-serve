using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        login log = new login();
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextBoxEmptt())
            {
                DataTable dt = log.sp_login(textBox1.Text, textBox2.Text, comboBox1.Text.ToString());
                if (dt.Rows.Count > 0)
                {
                    // bo danany admin name
                    Program.admin = dt.Rows[0]["UserType"].ToString();
                    Program.username = dt.Rows[0]["UserName"].ToString();

                    this.Hide();
                    main_frm frm = new main_frm();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(" ........ناوی بەکارهێنەر یان وشەی تێپەڕ هەڵەیە ","ئاگاداری",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
        private bool TextBoxEmptt()
        {
            if (textBox1.Text.Trim() == "")
            {
                label4.Visible = true;
                label4.Text = "بەکارهێنەر بەتاڵە !";
                textBox1.Select();
                return false;
            }
            else if (textBox2.Text.Trim() == "")
            {
                label4.Visible = true;
                label4.Text = "تێپەڕە وشە بەتاڵە !";
                textBox2.Select();
                return false;
            }
            else if (comboBox1.Text.Trim() == "")
            {
                label4.Visible = true;
                label4.Text = "جۆری بەکارهێنەر بەتاڵە !";
                comboBox1.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
