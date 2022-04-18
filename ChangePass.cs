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
using System.Configuration;

namespace Green_House
{
    public partial class ChangePass : Form
    {
        Admin A;
        CustomerStaff CS;
        Productlist Pl;
        Orderlist OL;
        GreenHouse G;
        public ChangePass()
        {
            InitializeComponent();
            panel2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Member set Password= '" + textBox2.Text + "', CPassword = '" + textBox3.Text + "' where ID ='"+Login.welcomeuser+"'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your password has been changed successfully");
                    con.Close();
                    textBox3.Text = "";
                    textBox2.Text = "";
                    panel2.Hide();
                    textBox1.Show();
                    label1.Show();
                    button2.Show();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangePass_Load(object sender, EventArgs e)
        {
            //Show User Name
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {  
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member where ID='" + Login.welcomeuser + "' and Password ='" + textBox1.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Insert new Password");
                    panel2.Show();
                    button2.Visible = false;
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Password not matched");
                    textBox1.Text = "";
                }
                dr.Close();
                con.Close();
                button2.Hide();
                textBox1.Hide();
                label1.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            A = new Admin();
            A.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CS = new CustomerStaff();
            CS.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            OL = new Orderlist();
            OL.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pl = new Productlist();
            Pl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            A = new Admin();
            A.Show();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button8_MouseLeave(object sender, EventArgs e)
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
