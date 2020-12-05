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
	public partial class ReservationDetails : PanelMenuForm
	{
		public override Panel MainPanel => reservaionDetailsPanel;
		public string memberid_ = "0";
		double sum_;
        private string _eventId;

        public Boolean showCancelButton
        {
            set
            {
                cancelReservationButton.Visible = value;
            }
        }

        public Boolean showFinalizeButton
        {
            set
            {
                button1.Visible = value;
            }
        }

		public int ReservationId {
			get;
			set;
		}

		public string EventName
		{
			set
			{
				eventNameLabel.Text = $@"Event: {value}";
			}
		}

        public string EventId
        {
            get => _eventId;
            set
            {
                eventIdLabel.Text = $@"Event ID: {value}";
                _eventId = value;
            }
        }

		public string EventDate
		{
			set
			{
				eventDateLabel.Text = $@"Date: {value}";
			}
		}

		public List<string> Seats
		{
			set
			{
				seatsReservedLabel.Text = "Seats Reserved: " + (String.Join(", ", value));

            }
		}

		public double sum
		{


			get
			{
				return sum_;
			}




			set
			{
				label1.Text = "Current cost of reservation: $" + value.ToString();

                if (_parent.MemberId > 0)
                {
                    label1.Text += Environment.NewLine + "10% off!";
                }

				sum_ = value;
			}
		}

		public string memberID
		{
			


			get
			{
				return memberid_;
			}
			

			set
			{
				memberid_ = value;
				if (memberID == "0")
				{
					label3.Text = "You are not logged in";
				}
				else
				{
					label3.Text = memberid_ + " is your membership id ";
					//apply discount 
					//sum_ = sum_ * 0.90;
					//label1.Text = sum_.ToString();
				}
			}
		}


		private Main _parent;

		public ReservationDetails(Main parent)
		{
			InitializeComponent();

			_parent = parent;

			label3.Text = "You are not logged in";

		

			//create a reservation


		}

        private void cancelReservationButton_Click(object sender, EventArgs e)
		{
            if (canCancel(ReservationId))
            {
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to cancel this reservation?",
                    " This cannot be undone!",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    deleteReservation();
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                MessageBox.Show("Sorry, you can only cancel a reservation two days prior.");
            }

        }

        private bool canCancel(int reservationId)
        {
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);


            Console.WriteLine("Connecting to MySQL...");
            conn3.Open();
            string sql = $@"SELECT
	e.date
FROM
	djt_reservation r
INNER JOIN
	djt_event e
ON
	r.eventID = e.eventID
WHERE
	r.id = @reservationId;";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);

            cmd.Parameters.AddWithValue("@reservationId", reservationId.ToString());

            MySqlDataReader myReader = cmd.ExecuteReader();

            myReader.Read();

            DateTime dt = DateTime.Parse(myReader["date"].ToString());
            DateTime today = DateTime.Now;


            myReader.Close();
            conn3.Close();

            return (dt - today).Days > 2;
        }

		private void deleteReservation()
		{
			string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
			MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);


            Console.WriteLine("Connecting to MySQL...");
            conn3.Open();
            string sql = $@"DELETE FROM djt_seat_reservation WHERE reservationId=@reservationId;";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);

            cmd.Parameters.AddWithValue("@reservationId", ReservationId.ToString());

            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
            }

            myReader.Close();


            // delete reservation
            sql = @"DELETE FROM djt_reservation WHERE id=@reservationId";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);

            cmd.Parameters.AddWithValue("@reservationId", ReservationId);

            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
            }

            myReader.Close();
            conn3.Close();

            MessageBox.Show("Reservation Deleted Successfully!");

            ((Profile)_parent._forms["Profile"].Second).loadEventHistory();

            _parent.showPanel("Profile");

            ShowEvents ShowEventsForm = (ShowEvents)_parent._forms["ShowEvents"].Second;
            ShowEventsForm.populateDataGrid();

			try
			{

				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void reservaionDetailsPanel_Paint(object sender, PaintEventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";

			MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO djt_reservation (eventID, memberID) VALUES (@eventID, @memberID)";

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@eventID", EventId);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            try
            {

                string sql = "SELECT id FROM djt_reservation ORDER BY id DESC LIMIT 1";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);


                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {

                    ReservationId = Int32.Parse(myReader["id"].ToString());



                }
                myReader.Close();




            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }




            var checkboxes = ((ReservationForm) _parent._forms["ReservationForm"].Second).checkboxes;
			var checked_ids = new List<string>();

			foreach (var checkBox in checkboxes)
            {
                if (checkBox.Checked)
                {
                    checked_ids.Add(checkBox.Tag.ToString());
                }
            }

			foreach (string seatId in checked_ids)
            {
				// create seat reservation for every checked seat
				try
                {
                    string sql = "INSERT INTO djt_seat_reservation (reservationId, seatId) VALUES (@reservationId, @seatId)";

                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@reservationId", ReservationId);
                    cmd.Parameters.AddWithValue("@seatId", seatId);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
			}

            conn.Close();
            Console.WriteLine("Done.");   //insert into resevation


            ShowEvents ShowEventsForm = (ShowEvents)_parent._forms["ShowEvents"].Second;
            ShowEventsForm.populateDataGrid();

            Profile ProfileForm = (Profile)_parent._forms["Profile"].Second;
            ProfileForm.loadEventHistory();

            if (_parent.MemberId > 0)
            {
				_parent.showPanel("Profile");
			}
            else
            {
				_parent.showPanel("Upcoming Events");
                MessageBox.Show($@"Your reservation Id is: {ReservationId}");
            }
			

		}
    }
}
