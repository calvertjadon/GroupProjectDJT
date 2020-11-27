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
    public partial class LoginForm : PanelMenuForm
    {
        public override Panel MainPanel => loginPanel;

        private Main _parent;

        public LoginForm(Main parent)
        {
            InitializeComponent();

            _parent = parent;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text;
            var password = passwordTextBox.Text;

            //get the price and VIP price from the database

            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);


            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn3.Open();
                string sql = "SELECT * FROM djt_member WHERE email = @email AND password = @password;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);


                MySqlDataReader myReader = cmd.ExecuteReader();

                if (myReader.HasRows)
                {
                    myReader.Read();
                    int memberId = Int32.Parse(myReader["id"].ToString());

                    _parent.setMember(memberId);

                    clearInputs();
                }
                else
                {
                    MessageBox.Show(@"Incorrect");
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn3.Close();
            Console.WriteLine("Done.");

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
