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
    public partial class koga_frm : Form
    {
        private static koga_frm n;
        DataTable dt = new DataTable();
        koga_class ob = new koga_class();
        public koga_frm()
        {
            InitializeComponent();
            View_All_Expenses();
            if (n == null)
            {
                n = this;
            }
        }
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static koga_frm deleg
        {
            get
            {
                if (n == null)
                {
                    n = new koga_frm();
                }
                return n;
            }
        }
        public void View_All_Expenses()
        {
            dt = ob.View_All_Expenses();
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //zyadkrdny karmand
                ob.Add_New_Expenses(txtName.Text, txtZhmara.Text,
                Convert.ToDouble(txtPrice.Text), txtTb.Text, dateTimePicker1.Value.Date);
                MessageBox.Show("بەسەرکەوتویی زیادکرا ........", "زیادکرا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////هەموو داتاکان بانگ دەکەینەوە
                dt = ob.View_All_Expenses();
                koga_frm.deleg.dataGridView1.DataSource = dt;
                clear();
            }
            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtZhmara.Text = "";
            txtPrice.Text = "";
            txtTb.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //awa lo away ladata grid view pishanman bdat
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtZhmara.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTb.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                View_All_Expenses();
            }
            else
            {
                dt = ob.Search_Expenses(txtSearch.Text);
                this.dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //nwe krd nawa karmand
                ob.Update_Expenses(Convert.ToInt32(txtID.Text), txtName.Text, txtZhmara.Text,
                Convert.ToDouble(txtPrice.Text), txtTb.Text, dateTimePicker1.Value.Date);
                MessageBox.Show("بەسەرکەوتوی نوێ کرایەوە ........", "نوێکرایەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////هەموو داتاکان بانگ دەکەینەوە
                dt = ob.View_All_Expenses();
                koga_frm.deleg.dataGridView1.DataSource = dt;
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
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم کاڵایەی کۆگا ...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_All_Expenses_info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_All_Expenses();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ڕیفرێشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_All_Expenses();
            clear();
        }

        private void سڕینەوەToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم کاڵایەی کۆگا ...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_All_Expenses_info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_All_Expenses();
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
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی هەموو کاڵاکان ...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_All_Expens_info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_All_Expenses();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
