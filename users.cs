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
    public partial class users : Form
    {
        class_users ob = new class_users();
        DataTable dt = new DataTable();
        private static users n;
        public users()
        {
            InitializeComponent();
            View_All_Users();
            if (n == null)
            {
                n = this;
            }
        }
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static users deleg
        {
            get
            {
                if (n == null)
                {
                    n = new users();
                }
                return n;
            }
        }
        public void View_All_Users()
        {
            dt = ob.View_All_Users();
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //zyadkrdny bakarhenar
                ob.Add_New_User(txtName.Text, txtZhmara.Text, comboBox1.Text);
                MessageBox.Show("بەسەرکەوتویی بەکارهێنەر زیادکرا ........", "زیادکرا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////هەموو داتاکان بانگ دەکەینەوە
                dt = ob.View_All_Users();
                users.deleg.dataGridView1.DataSource = dt;
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
            txtID.Text = "";
            txtName.Text = "";
            txtZhmara.Text = "";
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //update 
                ob.Update_Users(Convert.ToInt32(txtID.Text), txtName.Text, txtZhmara.Text, comboBox1.Text);
                MessageBox.Show("بەسەرکەوتویی بەکارهێنەرەکە نوێکرایەوە ........", "نوێکرایەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////هەموو داتاکان بانگ دەکەینەوە
                dt = ob.View_All_Users();
                users.deleg.dataGridView1.DataSource = dt;
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
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم کارمەندە...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_User(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_All_Users();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtgaran_TextChanged(object sender, EventArgs e)
        {
            if (txtgaran.Text == "")
            {
                View_All_Users();
            }
            else
            {
                dt = ob.Search_Users(txtgaran.Text);
                this.dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //awa lo away ladata grid view pishanman bdat
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtZhmara.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ڕیفرێشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_All_Users();
            clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
