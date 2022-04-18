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
    public partial class insertproduct : Form
    {
        SProductList SPL;
        Staff S;
        GreenHouse G;
        Seditprofile Se;
        public insertproduct()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Show message if any field is empty
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("All the field must be fill");
            }


            else
            {
                //Check if Product Id is alredy exist or not
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE PID='" + textBox1.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Product ID " + textBox1.Text + " is already exist.\nPlease Enter an Unique Product ID");
                    ds.Clear();
                    textBox1.Text = "";
                }

                else
                {
                    try
                    {
                        //Registration Main part
                        con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO Product(PID,Name,Price,Quantity) VALUES(@PID,@Name,@Price,@Quantity)", con);
                        cmd.Parameters.AddWithValue("@PID", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Price", int.Parse(textBox3.Text));
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBox4.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully Inserted");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
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

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            SPL = new SProductList();
            SPL.Show();
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
            S = new Staff();
            S.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Se = new Seditprofile();
            Se.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void insertproduct_Load(object sender, EventArgs e)
        {
            //user name
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
