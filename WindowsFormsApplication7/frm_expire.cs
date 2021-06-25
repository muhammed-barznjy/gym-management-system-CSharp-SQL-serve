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
        public partial class frm_expire : Form
        {
            class_expire ob = new class_expire();
            DataTable dt = new DataTable();
            private static frm_expire n;
            public frm_expire()
            {
                InitializeComponent();
            View_Expire_Member();
                if (n == null)
                {
                    n = this;
                }
            }
            static void cf(object sender, FormClosedEventArgs e)
            {
                n = null;
            }
            public static frm_expire deleg
            {
                get
                {
                    if (n == null)
                    {
                        n = new frm_expire();
                    }
                    return n;
                }
            }
            public void View_Expire_Member()
            {
                dt = ob.View_Expire_Member();
                dataGridView1.DataSource = dt;
            }
            private void ڕیفرێشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Expire_Member();
        }

        private void سڕینەوەیداتاکانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("دڵنیایت لە سڕینەوەی ئەم یاریزانە...؟", "دڵنیایت", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ob.Delete_Member_Info(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                View_Expire_Member();
            }

            catch
            {
                MessageBox.Show("کردارەکەت هەڵەیە", "هەڵە", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //bo search amana basa
            if (txtSearch.Text == "")
            {
                View_Expire_Member();
            }
            else
            {
                dt = ob.Search_member(txtSearch.Text);
                this.dataGridView1.DataSource = dt;
            }
        }
    }
}
