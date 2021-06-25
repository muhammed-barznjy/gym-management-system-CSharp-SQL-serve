using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class frm_employee : Form
    {
        Employees ob = new Employees();
        DataTable dt = new DataTable();
        private static frm_employee n;
        public frm_employee()
        {
            InitializeComponent();
            View_All_Employees();
            if (n == null)
            {
                n = this;
            }
        }
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static frm_employee deleg
        {
            get
            {
                if (n == null)
                {
                    n = new frm_employee();
                }
                return n;
            }
        }
        public void View_All_Employees()
        {
            dt = ob.View_All_Employees();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //zyadkrdny karmand
                ob.Add_new_Employees(textBox1.Text, textBox4.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value.Date);
                MessageBox.Show("بەسەرکەوتویی کارمەندەکە زیادکرا ........", "زیادکرا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////هەموو داتاکان بانگ دەکەینەوە
                dt = ob.View_All_Employees();
                frm_employee.deleg.dataGridView1.DataSource = dt;
                clear();
            }
            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void clear()
        {
            //bo batalkrdny text boxakan
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //update karmand
                ob.Update_employees(Convert.ToInt32(textBox6.Text), textBox1.Text, textBox4.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value.Date);
                MessageBox.Show("بەسەرکەوتویی کارمەندەکە نوێکرایەوە ........", "نوێکرایەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////هەموو داتاکان بانگ دەکەینەوە
                dt = ob.View_All_Employees();
                frm_employee.deleg.dataGridView1.DataSource = dt;
                clear();
            }
            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم یاریزانە...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_Employees_info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_All_Employees();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ڕیفرێشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_All_Employees();
        }

        private void سڕینەوەیداتاکانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم یاریزانە...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_Employees_info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_All_Employees();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void سڕینەوەیهەمووداتاکانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی هەموو کارمەندەکان...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_All_Employees_info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_All_Employees();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //awa lo away ladata grid view pishanman bdat
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                View_All_Employees();
            }
            else
            {
                dt = ob.Search_Employees(textBox5.Text);
                this.dataGridView1.DataSource = dt;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    
}
