using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Configuration;

namespace WindowsFormsApplication7
{
    public partial class Add_member : Form
    {
        Add_member_class ob = new Add_member_class();
        string gender;
        DataTable DT = new DataTable();
        private static Add_member n;
        public Add_member()
        {
            InitializeComponent();
            comboBox1.DataSource = ob.View_All_Ishtrak();
            comboBox1.DisplayMember = ("Ishtrak");
            comboBox1.ValueMember = "ID";

            View_ALL_MEMBER();
            if (n == null)
            {
                n = this;
            }
        }
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static Add_member deleg
        {
            get
            {
                if (n == null)
                {
                    n = new Add_member();
                }
                return n;
            }
        }
        public void View_ALL_MEMBER()
        {
            DT = ob.View_All_Member();
            dataGridView1.DataSource = DT;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "dd-MM-yyyy";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void clear()
        {
            txtSearch.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtAge.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //lo insert tya
                if (radioButton1.Checked == true)
                {
                    gender = "نێر";
                }
                else
                {
                    gender = "مێ";
                }
                ob.Add_New_Member(txtName.Text, txtAge.Text, comboBox1.Text,
                dateTimePicker1.Value, Convert.ToDouble(txtPrice.Text), gender,dateTimePicker2.Value);
                MessageBox.Show("...... بەسەرکەوتویی یاریزانەکە زیادکرا", "زیادکرا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT = ob.View_All_Member();
                Add_member.deleg.dataGridView1.DataSource = DT;
                clear();
            }
            catch
            {
                MessageBox.Show("....... کردارەکەت هەڵەیە ", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ڕیفرێشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_ALL_MEMBER();
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //lo update tya
                if (radioButton1.Checked == true)
                {
                    gender = "نێر";
                }
                else
                {
                    gender = "مێ";
                }
                ob.Update_Member(Convert.ToInt32(txtID.Text), txtName.Text, txtAge.Text, comboBox1.Text,
                dateTimePicker1.Value, Convert.ToDouble(txtPrice.Text), gender, dateTimePicker2.Value);
                MessageBox.Show("......بەسەرکەوتویی یاریزانەکە نوێکرایەوە  ", "نوێکرایەوە", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Add_member.deleg.dataGridView1.DataSource = DT;
                clear();
            }
            catch
            {
                MessageBox.Show("....کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAge.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "نێر")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
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
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم یاریزانە...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_Member_Info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_ALL_MEMBER();
                clear();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void سڕینەوەToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم یاریزانە...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_Member_Info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_ALL_MEMBER();
                clear();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //bo search amana basa
            if (txtSearch.Text == "")
            {
                View_ALL_MEMBER();
            }
            else
            {
                DT = ob.Search_member(txtSearch.Text);
                this.dataGridView1.DataSource= DT;
            }
        }
        private void سڕینەوەیهەمووداتاکانToolStripMenuItem_Click(object sender, EventArgs e)
        {
           try
            {
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی هەموو داتاکان ...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_All_Member_Info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_ALL_MEMBER();
                clear();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
      }

        private void button5_Click(object sender, EventArgs e)
        {
            add_ishtrak f4 = new add_ishtrak();
            f4.ShowDialog();
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            comboBox1.DataSource = ob.View_All_Ishtrak();
            comboBox1.DisplayMember = ("Ishtrak");
            comboBox1.ValueMember = "ID";
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
    
}
