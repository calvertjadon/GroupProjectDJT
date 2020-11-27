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
    public partial class ShowEvents : PanelMenuForm
    {
        public override Panel MainPanel => showEventsPanel;
        private Main _parent;

        public ShowEvents(Main parent)
        {
            InitializeComponent();

            _parent = parent;

            dataGridView1.Rows.Clear();
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String eventID;
            String name;
            String description;
            String time;
            String price;
            String vipPrice;
            String date;



            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn3.Open();
                string sql = "SELECT eventID, name, description, date,time, price, vipPrice FROM djt_event";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);




                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    eventID = myReader["eventID"].ToString();
                    name = myReader["name"].ToString();
                    description = myReader["description"].ToString();
                    date = myReader["date"].ToString() + "$";
                    time = myReader["time"].ToString();
                    price = myReader["price"].ToString();
                    vipPrice = myReader["vipPrice"].ToString();
                    date = date.Substring(0, 10); //cuts off annoying timestamp 

                    price = "$" + price;
                    vipPrice = "$" + vipPrice;


                    dataGridView1.Rows.Add(eventID, name, description, date, time, price, vipPrice); //adds to datagridview
                   


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowEvents_Load(object sender, EventArgs e)
        {

          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var reservationForm = ((ReservationForm) _parent._forms["ReservationForm"].Item2);

            string EventId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string EventTitle = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            reservationForm.EventId = EventId;
            reservationForm.EventTitle = EventTitle;
            reservationForm.clearSeatSelection();

            _parent.showPanel("Seats");

        }

        private void showEventsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
