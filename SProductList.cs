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
    public partial class SProductList : Form
    {
        insertproduct ip;
        UpdateProductList Up;
        Staff S;
        GreenHouse G;
        SOrderList SO;
        Seditprofile Se;
        public SProductList()
        {
            InitializeComponent();
        }


        //Gridview Show
        void Binddata()
        {
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
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            S = new Staff();
            S.Show();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            S = new Staff();
            S.Show();
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
        

        //Insert Product Page
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ip = new insertproduct();
            ip.Show();
        }
        //Update Product Page
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Up = new UpdateProductList();
            Up.Show();
        }




        //Delete Operation
        private void button3_Click(object sender, EventArgs e)
        {
            //Delete Product List
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE Product WHERE PID=@PID", con);
                cmd.Parameters.AddWithValue("@PID", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully deleted");
                Binddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Search Button
        private void button4_Click(object sender, EventArgs e)
        {
            //Search Product List
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE PID=@PID", con);
                cmd.Parameters.AddWithValue("@PID", int.Parse(textBox1.Text));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {

            this.Hide();
            SO = new SOrderList();
            SO.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Se = new Seditprofile();
            Se.Show();
        }
        private void SProductList_Load(object sender, EventArgs e)
        {
            //Show Product List from database to Gridview
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
    }
}
