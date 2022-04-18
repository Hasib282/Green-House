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
    public partial class InsertStaff : Form
    {
        CustomerStaff CS;
        Admin A;
        Productlist Pl;
        Orderlist OL;
        GreenHouse G;
        ChangePass CP;
        public InsertStaff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Declare the User type
            if (textBox8.Text != "Staff")
            {
                MessageBox.Show("User type must be Staff");
                textBox8.Text = "Staff";
            }
            else if(textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("Password not match");
                textBox6.Text = "";
                textBox7.Text = "";
            }

            //Show message if any field is empty
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("All the field must be fill");
            }


            else
            {
                //Check if User Id is alredy exist or not
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member WHERE ID='" + textBox1.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("User ID " + textBox1.Text + " is already exist.\nPlease Enter an Unique User ID");
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
                        cmd = new SqlCommand("INSERT INTO Member(ID,Name,Email,Phone,Address,Password,CPassword,Type) VALUES(@ID,@Name,@Email,@Phone,@Address,@Password,@CPassword,@Type)", con);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Phone", int.Parse(textBox4.Text));
                        cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Password", textBox6.Text);
                        cmd.Parameters.AddWithValue("@CPassword", textBox7.Text);
                        cmd.Parameters.AddWithValue("@Type", textBox8.Text);
                        
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully Inserted");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }
        //Back
        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            CS = new CustomerStaff();
            CS.Show();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox6.PasswordChar = '\0';
                textBox7.PasswordChar = '\0';
            }
            else
            {
                textBox6.PasswordChar = '*';
                textBox7.PasswordChar = '*';
            }
        }

        private void panel1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "ID Should not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Name Should not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox2, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (textBox3.Text.Length > 0)
            {
                if (!rEMail.IsMatch(textBox3.Text))
                {
                    MessageBox.Show("Invalid Email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "Phone Should not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textBox4, null);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider5.SetError(textBox5, "Address Should not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textBox5, null);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider6.SetError(textBox6, "Password Should not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(textBox6, null);
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider7.SetError(textBox7, "Confirm Password Should not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider7.SetError(textBox7, null);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 13)//8=backspace //46=delete
            {
                e.Handled = true;
                MessageBox.Show("Insert Numbers Only");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 13)//8=backspace //46=delete
            {
                e.Handled = true;
                MessageBox.Show("Insert Numbers Only");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "ID Should not be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void InsertStaff_Load(object sender, EventArgs e)
        {
            //Show user Name
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
                textBox8.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            OL = new Orderlist();
            OL.Show();
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

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            A = new Admin();
            A.Show();
        }
    }
}
