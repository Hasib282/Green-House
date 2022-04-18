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
    public partial class Outdoor1 : Form
    {
        GreenHouse G;
        EditProfile E;
        Customer Ca;
        Outdoor O;
        Outdoor2 O2;
        Outdoor3 O3;
        Outdoor4 O4;
        Outdoor5 O5;
        Outdoor6 O6;
        public Outdoor1()
        {
            InitializeComponent();
            OrderId();
        }
        //Current Date
        string d = DateTime.Now.ToString();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Check Box1 Item Name price
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=43", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkBox1.Text = dr.GetValue(0).ToString();
                    label2.Text = "Price : " + dr.GetValue(1).ToString() + " /-";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Check Box2 Item Name price
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=44", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkBox2.Text = dr.GetValue(0).ToString();
                    label4.Text = "Price : " + dr.GetValue(1).ToString() + " /-";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Check Box3 Item Name price
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=45", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkBox3.Text = dr.GetValue(0).ToString();
                    label5.Text = "Price : " + dr.GetValue(1).ToString() + " /-";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Check Box4 Item Name price
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=46", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkBox4.Text = dr.GetValue(0).ToString();
                    label6.Text = "Price : " + dr.GetValue(1).ToString() + " /-";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //Check Box5 Item Name price
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=47", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkBox5.Text = dr.GetValue(0).ToString();
                    label7.Text = "Price : " + dr.GetValue(1).ToString() + " /-";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Check Box6 Item Name price
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=48", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    checkBox6.Text = dr.GetValue(0).ToString();
                    label8.Text = "Price : " + dr.GetValue(1).ToString() + " /-";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select a Payment method");
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        int qty = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                        if (qty == 0)
                        {
                            MessageBox.Show("Quantity can't be zero '0'.");
                            dataGridView1.Rows.Clear();
                        }
                        else
                        {
                            int Qty = 0;
                            //Quantity set
                            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                            SqlCommand cmd = new SqlCommand("select Quantity from Product where Name='" + dataGridView1.Rows[i].Cells[0].Value + "'", con);
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                Qty = int.Parse(dr["Quantity"].ToString());
                            }
                            con.Close();
                            if (Qty == 0)
                            {
                                MessageBox.Show("Product is not available", "Stock out!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (Qty < qty)
                            {
                                MessageBox.Show("Not enough product available. Please decrease your quantity or try agin later.", "Not enough stock!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //Order Now
                                cmd = new SqlCommand(@"INSERT INTO [Order] (OrderId,ID,Address,Name,Price,Qty,Total,Payment,Status,Date)VALUES(@OrderID,@ID,@Address,'" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "',@Payment,@Status,@Date)", con);
                                con.Open();
                                cmd.Parameters.AddWithValue("@OrderID", OrderID.Text);
                                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox2.Text));
                                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                                cmd.Parameters.AddWithValue("@Payment", comboBox1.Text);
                                cmd.Parameters.AddWithValue("@Status", textBox4.Text);
                                cmd.Parameters.AddWithValue("@Date", Date.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                OrderId();
                                //Quantity decrease from datatable
                                cmd = new SqlCommand("update Product set Quantity=Quantity-'" + dataGridView1.Rows[i].Cells[2].Value + "' where Name='" + dataGridView1.Rows[i].Cells[0].Value + "'", con);
                                con.Open();
                                cmd.ExecuteReader();
                                con.Close();
                                dataGridView1.Rows.Clear();
                                MessageBox.Show("Thanks for choosing us. Your Order is confirmed");
                                comboBox1.Text = "Payment method";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Hide();
            O = new Outdoor();
            O.Show();
        }
        public void OrderId()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                SqlCommand cmd = new SqlCommand("select MAX(OrderID) from [Order] ", con);
                con.Open();
                var maxid = cmd.ExecuteScalar() as string;
                if (maxid == null)
                {
                    OrderID.Text = "E-000001";
                }
                else
                {
                    int intval = int.Parse(maxid.Substring(2, 6));
                    intval++;
                    OrderID.Text = string.Format("E-{0:000000}", intval);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        String name;
        int price;
        int tot;
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=43", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        name = dr.GetValue(0).ToString();
                        int Quantity = int.Parse(numericUpDown1.Value.ToString());
                        price = int.Parse(dr.GetValue(1).ToString());
                        tot = Quantity * price;
                        this.dataGridView1.Rows.Add(name, price, Quantity, tot);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (checkBox2.Checked)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=44", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        name = dr.GetValue(0).ToString();
                        int Quantity = int.Parse(numericUpDown2.Value.ToString());
                        price = int.Parse(dr.GetValue(1).ToString());
                        tot = Quantity * price;
                        this.dataGridView1.Rows.Add(name, price, Quantity, tot);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (checkBox3.Checked)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=45", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        name = dr.GetValue(0).ToString();
                        int Quantity = int.Parse(numericUpDown3.Value.ToString());
                        price = int.Parse(dr.GetValue(1).ToString());
                        tot = Quantity * price;
                        this.dataGridView1.Rows.Add(name, price, Quantity, tot);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (checkBox4.Checked)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=46", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        name = dr.GetValue(0).ToString();
                        int Quantity = int.Parse(numericUpDown4.Value.ToString());
                        price = int.Parse(dr.GetValue(1).ToString());
                        tot = Quantity * price;
                        this.dataGridView1.Rows.Add(name, price, Quantity, tot);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (checkBox5.Checked)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=47", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        name = dr.GetValue(0).ToString();
                        int Quantity = int.Parse(numericUpDown5.Value.ToString());
                        price = int.Parse(dr.GetValue(1).ToString());
                        tot = Quantity * price;
                        this.dataGridView1.Rows.Add(name, price, Quantity, tot);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (checkBox6.Checked)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Name,Price from Product where PID=48", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        name = dr.GetValue(0).ToString();
                        int Quantity = int.Parse(numericUpDown6.Value.ToString());
                        price = int.Parse(dr.GetValue(1).ToString());
                        tot = Quantity * price;
                        this.dataGridView1.Rows.Add(name, price, Quantity, tot);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            int sum = 0;
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);

            }
            textBox1.Text = sum.ToString();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            O5 = new Outdoor5();
            O5.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.Hide();
            O4 = new Outdoor4();
            O4.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            O3 = new Outdoor3();
            O3.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            O2 = new Outdoor2();
            O2.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            O = new Outdoor();
            O.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Outdoor1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-QLO3OM5;Initial Catalog=GreenHouse;Persist Security Info=True;User ID=Hasib;Password=Hasib282");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID,Address from Member where ID='" + Login.welcomeuser + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(1).ToString();
                }
                con.Close();
                Date.Text = d;
                Date.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                OrderID.Hide();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Are you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            G = new GreenHouse();
            G.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Hide();
            E = new EditProfile();
            E.Show();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ca = new Customer();
            Ca.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Hide();
            O6 = new Outdoor6();
            O6.Show();
        }
    }
}
