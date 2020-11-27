using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProjectDJT
{
    public partial class ReservationForm : PanelMenuForm
    {
        public override Panel MainPanel => seatsPanel;

        private string _eventId;

        public string EventId
        {
            set
            {
                _eventId = value;
                eventIdLabel.Text = "Event ID: " + _eventId;
            }

            get => _eventId;
        }

        public string EventTitle
        {
            set
            {
                eventSelectionTitleLabel.Text = "Here are all the seats for: " + value;
            }
        }

        private Dictionary<String, Color> _checkboxColors = new Dictionary<String, Color>()
        {
            {"Checked", Color.LawnGreen},
            {"Unchecked", Color.White},
        };

        private List<CheckBox> checkboxes;

        private int seatLimit = 4;

        public ReservationForm()
        {
            InitializeComponent();

            Console.WriteLine("Loaded");
            checkboxes = tableLayoutPanel1.Controls.OfType<CheckBox>().ToList();

            foreach (var cb in checkboxes)
            {
                cb.CheckedChanged += checkBox_CheckedChanged;
                cb.BackColor = _checkboxColors["Unchecked"];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int numSelected = 0;
            foreach (var checkbox in checkboxes)
            {
                if (checkbox.Checked)
                {
                    numSelected += 1;
                }
            }


            var cb = ((CheckBox)sender);
            if (numSelected > seatLimit)
            {
                cb.Checked = false;
                numSelected = seatLimit;
            }

            cb.BackColor = cb.Checked ? Color.LawnGreen : Color.White;

            countLabel.Text = numSelected.ToString();
        }

        public void clearSeatSelection()
        {
            foreach (var cb in checkboxes)
            {
                cb.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the price and VIP price from the database

            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            double price2 = 0.0;
            double vipPrice2 = 0.0;

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn3.Open();
                string sql = "SELECT price, vipPrice FROM djt_event WHERE eventID = @eventID";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);

                cmd.Parameters.AddWithValue("@eventID", _eventId);


                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    String price = myReader["price"].ToString();
                    String vipPrice = myReader["vipPrice"].ToString();

                     price2 = Convert.ToDouble(price);
                     vipPrice2 = Convert.ToDouble(vipPrice);

                  
                   

                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn3.Close();
            Console.WriteLine("Done.");


            double sum = 0.0;

            foreach (var checkbox in checkboxes)
            {
                if (checkbox.Checked)
                {

                    String checkboxTag = checkbox.Tag.ToString();
                    int tag = Convert.ToInt32(checkboxTag);
                    label26.Text = checkboxTag;


                    if (tag > 32)
                    {
                        label2.Text = "Bruh";
                        sum = sum + price2;
                        label25.Text = sum.ToString();
                    }
                    else
                    {
                        label2.Text = "VIP IN THE HOUSE";
                        sum = sum + vipPrice2;
                        label25.Text = sum.ToString();
                    }


                }
            }

            




        }

        private void seatsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
