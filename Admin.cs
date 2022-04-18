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
    public partial class Admin : Form
    {
        CustomerStaff CS;
        Productlist Pl;
        Orderlist OL;
        GreenHouse G;
        ChangePass CP;
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CS = new CustomerStaff();
            CS.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pl = new Productlist();
            Pl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            OL= new Orderlist();
            OL.Show();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            
             this.Hide();
             G = new GreenHouse();
             G.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CP = new ChangePass();
            CP.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}
