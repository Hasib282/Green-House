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
    public partial class UpdateProductList : Form
    {
        SProductList SPL;
        Staff S;
        GreenHouse G;
        SOrderList SO;
        Seditprofile Se;
        public UpdateProductList()
        {
            InitializeComponent();
            panel4.Hide();
            panel5.Hide();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            S = new Staff();
            S.Show();
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
        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            SPL = new SProductList();
            SPL.Show();
        }
        //Exit Button
        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Are you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }           
        }
        private void UpdateProductList_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Update Product Price
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Product SET  Price=@Price WHERE PID=@PID", con);
                cmd.Parameters.AddWithValue("@PID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Price", int.Parse(textBox2.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated");
                panel4.Hide();
                button3.Show();
                button4.Show();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Update Product Quantity
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Product SET  Quantity=Quantity+@Quantity WHERE PID=@PID", con);
                cmd.Parameters.AddWithValue("@PID", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated");
                panel5.Hide();
                button3.Show();
                button4.Show();
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Update Price Button
        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Show();
            button3.Hide();
            button4.Hide();
        }
        //Update Quantity Button
        private void button4_Click(object sender, EventArgs e)
        {
            panel5.Show();
            button3.Hide();
            button4.Hide();
        }
    }
}
