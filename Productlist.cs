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
    public partial class Productlist : Form
    {
        Admin A;
        CustomerStaff CS;
        Orderlist OL;
        GreenHouse G;
        ChangePass CP;
        public Productlist()
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

        private void Back_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE PID=@PID", con);
                cmd.Parameters.AddWithValue("@PID", textBox1.Text);

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

        private void Productlist_Load(object sender, EventArgs e)
        {
            //Gridview Show
            try
            {
                SqlConnection Con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                Con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Product", Con);
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            OL = new Orderlist();
            OL.Show();
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

        private void button7_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button6_MouseEnter(object sender, EventArgs e)
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
