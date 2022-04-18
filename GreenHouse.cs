using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Green_House
{
    public partial class GreenHouse : Form
    {
        Login L;
        Registration R;
        public GreenHouse()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            L = new Login();
            L.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            R = new Registration();
            R.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Are you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here we are giving  you easy way to find rare Plants. We come with fresh and Unique Plants which are rare to find. Add one tree to the nature so that you can add a saviour to your life. Go green and save trees!!! ","About us", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
