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
    public partial class Orderlist : Form
    {
        Admin A;
        CustomerStaff CS;
        Productlist Pl;
        GreenHouse G;
        ChangePass CP;
        public Orderlist()
        {
            InitializeComponent();
        }
        //Exit Button
        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Are you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            A = new Admin();
            A.Show();
        }


        //Search Operation
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Order] WHERE OrderID=@OrderID", con);
                cmd.Parameters.AddWithValue("@OrderID", textBox1.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void Orderlist_Load(object sender, EventArgs e)
        {
            //DataGridView
            try
            {
                SqlConnection Con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Order]", Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


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

        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CS = new CustomerStaff();
            CS.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pl = new Productlist();
            Pl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            CP = new ChangePass();
            CP.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }

        private void label5_Click(object sender, EventArgs e)
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

        private void button8_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button6_MouseLeave(object sender, EventArgs e)
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
