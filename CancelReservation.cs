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
	public partial class CancelReservation : PanelMenuForm
	{
		public override Panel MainPanel => cancelReservationPanel;

		private Main _parent;

		public CancelReservation(Main parent)
		{
			InitializeComponent();

			_parent = parent;
		}

		private void cancelReservationButton_Click(object sender, EventArgs e)
		{
			int reservationId;

			if (Int32.TryParse(reservationIdTextBox.Text, out reservationId))
            {

                if (canCancel(reservationId))
                {
					var confirmResult = MessageBox.Show(
                        "Are you sure you want to cancel this reservation?",
                        " This cannot be undone!",
                        MessageBoxButtons.YesNo
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        deleteReservation(reservationId);
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
			else
			{
				MessageBox.Show("Reservation ID must be a number!");
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

		private void deleteReservation(int ReservationId)
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
			reservationIdTextBox.Text = "";
		}
	}
}
