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
    public partial class SOrderList : Form
    {
        SProductList SPL;
        Staff S;
        GreenHouse G;
        Seditprofile Se;
        public SOrderList()
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
        
        private void label6_Click(object sender, EventArgs e)
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
        
        private void SOrderList_Load(object sender, EventArgs e)
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
            //DataGridView
            try
            {
                SqlConnection Con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Order] ", Con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Se = new Seditprofile();
            Se.Show();
        }
        //Search Operation
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Insert Product ID to Search");
                }
                else
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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SPL = new SProductList();
            SPL.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }

        //Update Order Status
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Status");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Input OrderID First");
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE [Order] SET  Status=@Status WHERE OrderID=@OrderID", con);
                    cmd.Parameters.AddWithValue("@OrderID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Updated");
                    textBox1.Text = "";
                    comboBox1.Text = "Select Status";
                    Binddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
