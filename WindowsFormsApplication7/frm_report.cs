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
    public partial class frm_report : Form
    {
        public frm_report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rep_members frm = new rep_members();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            rep_employees frm = new rep_employees();
            frm.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
