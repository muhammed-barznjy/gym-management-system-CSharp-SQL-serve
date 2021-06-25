using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication7
{
    public partial class main_frm : Form
    {
        public main_frm()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void main_frm_Load(object sender, EventArgs e)
        {
            label6.Text = Program.admin.ToString();
            label4.Text = Program.username.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_member frm = new Add_member();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_employee fr = new frm_employee();
            fr.TopLevel = false;
            fr.AutoScroll = true;
            panel3.Controls.Add(fr);
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            koga_frm frm = new koga_frm();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            users fr = new users();
            fr.TopLevel = false;
            fr.AutoScroll = true;
            panel3.Controls.Add(fr);
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm_report frm = new frm_report();
            frm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_expire frm = new frm_expire();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            panel3.Controls.Add(frm);
            frm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            about frm = new about();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            panel3.Controls.Add(frm);
            frm.Show();
        }
    }
}
