using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GroupProjectDJT
{
    public partial class MembershipForm : PanelMenuForm
    {
        public override Panel MainPanel => membershipFormPanel;

        private Main _parent;

        public MembershipForm(Main parent)
        {
            InitializeComponent();

            _parent = parent;
        }

        private void MembershipForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Connecting to MySQL...");

            string fName = textBox1.Text;
            string lName = textBox2.Text;
            string Email = textBox3.Text;
            string Phone = textBox4.Text;
            string Password = passwordTextBox.Text;

            if (
                fName.Length > 0 &&
                lName.Length > 0 &&
                Email.Length > 0 &&
                Phone.Length > 0 && 
                Password.Length > 0
            )
            {
                string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "INSERT INTO djt_member (fName, lName, email, phone, password) VALUES (@fName, @lName, @email, @phone, @password)";

                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@fName", fName);
                    cmd.Parameters.AddWithValue("@lName", lName);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@phone", Phone);
                    cmd.Parameters.AddWithValue("@password", Password);



                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
                Console.WriteLine("Your Membership has been created!");




                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                //need to give the customer his/her id


                MySql.Data.MySqlClient.MySqlConnection conn2 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

                try
                {

                    Console.WriteLine("Connecting to MySQL...");
                    conn2.Open();
                    string sql = "SELECT id FROM djt_member WHERE fName = @fName AND lName = @lName AND email = @email ";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn2);


                    cmd.Parameters.AddWithValue("@fName", fName);
                    cmd.Parameters.AddWithValue("@lName", lName);
                    cmd.Parameters.AddWithValue("@email", Email);

                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.Read())
                    {

                        String id = myReader["id"].ToString();
                        label6.Text = "Your Membership ID is: " + id + " Thank You!";

                        _parent.showPanel("Login");

                        clearInputs();
                    }
                    myReader.Close();




                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn2.Close();
                Console.WriteLine("Done.");
            }
            else
            {
                MessageBox.Show("You cannot leave any fields blank!");
            }
           

            

        }

        private void membershipFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearInputs()
        {
            foreach (TextBox textBox in tableLayoutPanel1.Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }
        }
    }
}
