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
    public partial class OrderShow : Form
    {
        GreenHouse G;
        EditProfile E;
        Customer C;
        public OrderShow()
        {
            InitializeComponent();
        }

        private void OrderShow_Load(object sender, EventArgs e)
        {
            //User Name
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Order] where ID='" + Login.welcomeuser + "'", Con);
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
            G = new GreenHouse();
            G.Show();
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

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            C = new Customer();
            C.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            C = new Customer();
            C.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            E = new EditProfile();
            E.Show();
        }
    }
}
