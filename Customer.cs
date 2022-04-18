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

namespace Green_House
{
    public partial class Customer : Form
    {
        EditProfile E;
        Catagories C;
        GreenHouse G;
        OrderShow OS;
        public Customer()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Are you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            E = new EditProfile();
            E.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            C = new Catagories();
            C.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            OS = new OrderShow();
            OS.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name from Member where ID='" + Login.welcomeuser + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UserName.Text = dr.GetValue(0).ToString();
                this.Text = "WELCOME" + dr.GetValue(0).ToString();
            }
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            E = new EditProfile();
            E.Show();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
