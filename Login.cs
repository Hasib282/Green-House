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
    public partial class Login : Form
    {
        Registration R;
        Admin A;
        Customer C;
        Staff S;
        

        public Login()
        {
            InitializeComponent();
        }
        
        public static string welcomeuser;


        //Create one Connection
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            R = new Registration();
            R.Show();
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






        //Show password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*'; 
            }
        }




        //Login Button Code
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select User Type");
                }
                //Login as admin
                else if (comboBox1.SelectedIndex == 0)
                {
                    if (textBox1.Text == " " || textBox2.Text == " ")
                    {
                        MessageBox.Show("Enter both User ID, Password or user type");
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Count(*) FROM Member WHERE ID='" + textBox1.Text + "' and Password='" + textBox2.Text + "'and Type='" + comboBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            welcomeuser = textBox1.Text;
                            this.Hide();
                            A = new Admin();
                            A.Show();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Id, Password or user type");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            comboBox1.Text = "User Type";

                        }
                        con.Close();
                    }
                }
                //logi as Customer
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (textBox1.Text == " " || textBox2.Text == " ")
                    {
                        MessageBox.Show("Enter both User ID and Password");
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Count(*) FROM Member WHERE ID='" + textBox1.Text + "' and Password='" + textBox2.Text + "' and Type='" + comboBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            welcomeuser = textBox1.Text;
                            this.Hide();
                            C = new Customer();
                            C.Show();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Id, Password or user type");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            comboBox1.Text = "User Type";
                        }
                        con.Close();
                    }
                }
                else
                {
                    //login as staff
                    if (textBox1.Text == " " || textBox2.Text == " ")
                    {
                        MessageBox.Show("Enter both User ID and Password");
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Count(*) FROM Member WHERE ID='" + textBox1.Text + "' and Password='" + textBox2.Text + "'and Type='" + comboBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            welcomeuser = textBox1.Text;
                            this.Hide();
                            S = new Staff();
                            S.Show();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Id, Password or User Type");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            comboBox1.Text = "User Type";
                        }
                        con.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        //Textbox which only takes int value
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 13)//8=backspace //46=delete //13Enter
            {
                e.Handled = true;
                MessageBox.Show("Insert Numbers Only");
            }
        }


        //Key down focus next textbox
        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
