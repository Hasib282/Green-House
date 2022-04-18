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
    public partial class CustomerStaff : Form
    {
        Admin A;
        InsertStaff IS;
        Productlist Pl;
        Orderlist OL;
        GreenHouse G;
        ChangePass CP;
        public CustomerStaff()
        {
            InitializeComponent();
        }

        //For Binding or showing Database information on DataGridView
        void Binddata()
        {
            SqlConnection Con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
            Con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Member", Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        //Insert Staff Operation
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            IS = new InsertStaff();
            IS.Show();
        }


        //DELETE Operation
        private void button2_Click(object sender, EventArgs e)
        {            
            try
            {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE Member WHERE ID=@ID",con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully deleted");
            textBox1.Text = "";
            Binddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //SEARCH Operation
        private void button3_Click(object sender, EventArgs e)
        {            
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

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
        //Logout
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }
        //OrderList
        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            OL = new Orderlist();
            OL.Show();
        }
        //Change Password
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            CP = new ChangePass();
            CP.Show();
        }
        
        //ProductList
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pl = new Productlist();
            Pl.Show();
        }
        private void CustomerStaff_Load(object sender, EventArgs e)
        {
            //DataGridView
            try
            {
            SqlConnection Con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
            Con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Member", Con);
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




        //Back Button
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            A = new Admin();
            A.Show();
        }


        //Green House
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            A = new Admin();
            A.Show();
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

        private void button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button5_MouseLeave(object sender, EventArgs e)
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

        private void button4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
