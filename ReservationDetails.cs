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

		private Main _parent;

		public ReservationDetails(Main parent)
		{
			InitializeComponent();

			_parent = parent;
		}

		private void cancelReservationButton_Click(object sender, EventArgs e)
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
	}
}
