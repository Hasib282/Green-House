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
    public partial class EditProfile : Form
    {
        Customer C;
        GreenHouse G;
        public EditProfile()
        {
            InitializeComponent();
        }
        void Username()
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
        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Are you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            C = new Customer();
            C.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("Are you sure want to change your Name?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Member set Name= '" + textBox1.Text + "' where ID ='" + Login.welcomeuser + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Name has been changed successfully");
                    con.Close();
                    Username();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("Are you sure want to Change your Email?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Member set Email = '" + textBox2.Text + "' where ID ='" + Login.welcomeuser + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Email has been changed successfully");
                    con.Close();
                }
                
            }
            


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("Are you sure want to Change your Phone Number?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Member set Phone = '" + textBox3.Text + "' where ID ='" + Login.welcomeuser + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Phone has been changed successfully");
                    con.Close();
                }
                
            }
            


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("Are you sure want to Change your Address?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Member set Address= '" + textBox4.Text + "' where ID ='" + Login.welcomeuser + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Address has been changed successfully");
                    con.Close();
                }
                
            }
            

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult iExit;
                iExit = MessageBox.Show("Are you sure want to change your password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Member set Password= '" + textBox5.Text + "', CPassword= '" + textBox5.Text + "' where ID ='" + Login.welcomeuser + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your password has been changed successfully");
                    con.Close();
                }
                
            }
            

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name,Email,Phone,Address,Password from Member where ID='" + Login.welcomeuser + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr.GetValue(0).ToString();
                    textBox2.Text = dr.GetValue(1).ToString();
                    textBox3.Text = dr.GetValue(2).ToString();
                    textBox4.Text = dr.GetValue(3).ToString();
                    textBox5.Text = dr.GetValue(4).ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 13)//8=backspace //46=delete
            {
                e.Handled = true;
                MessageBox.Show("Insert Numbers Only");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (textBox2.Text.Length > 0)
            {
                if (!rEMail.IsMatch(textBox2.Text))
                {
                    MessageBox.Show("Invalid Email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            C = new Customer();
            C.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
