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

        public string EventId
        {
            set
            {
                eventIdLabel.Text = "Event ID: " + value;
                
            }
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

        private void seatsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //getting the price from the event database
            double price = 0.0;
            double vipPrice = 0.0;

            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn3.Open();
                string sql = "SELECT price, vipPrice, FROM djt_event WHERE eventID = @eventID";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);




                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

               


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
    }
}
