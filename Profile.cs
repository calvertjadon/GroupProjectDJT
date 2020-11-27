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
	public partial class Profile : PanelMenuForm
	{
		public override Panel MainPanel => profilePanel;

		private Main _parent;

		public Profile(Main parent)
		{
			InitializeComponent();

			_parent = parent;
		}

		public void LoadMember()
		{
			var MemberId = _parent.MemberId;

			//get the price and VIP price from the database

			string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
			MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);


			try
			{

				Console.WriteLine("Connecting to MySQL...");
				conn3.Open();
				string sql = "SELECT * FROM djt_member WHERE id = @memberId";
				MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);

				cmd.Parameters.AddWithValue("@memberId", MemberId);


				MySqlDataReader myReader = cmd.ExecuteReader();

				myReader.Read();
				string fName = myReader["fName"].ToString();
				string lName = myReader["lName"].ToString();
				string email = myReader["email"].ToString();
				string password = myReader["password"].ToString();
				string phone = myReader["phone"].ToString();

				firstNameTextBox.Text = fName;
				lastNameTextBox.Text = lName;
				emailTextBox.Text = email;
				passwordTextBox.Text = password;
				phoneTextBox.Text = phone;

				myReader.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			conn3.Close();
			Console.WriteLine("Done.");
		}

		public void loadEventHistory()
		{
			dataGridView1.Rows.Clear();

			var MemberId = _parent.MemberId;

			//get the price and VIP price from the database

			string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
			MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);


			try
			{

				Console.WriteLine("Connecting to MySQL...");
				conn3.Open();
				string sql = @"SELECT
								djt_reservation.id AS `Reservation ID`, 
								djt_event.`name` AS `Event`, 
								djt_event.eventID AS `Event ID`, 
								djt_event.date AS Date
							FROM
								djt_reservation
								INNER JOIN
								djt_event
								ON 
									djt_reservation.eventID = djt_event.eventID
								INNER JOIN
								djt_member
								ON 
									djt_reservation.memberID = djt_member.id
							WHERE
								memberID = @memberId;";
				MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);

				cmd.Parameters.AddWithValue("@memberId", MemberId);


				MySqlDataReader myReader = cmd.ExecuteReader();

				while (myReader.Read())
				{
					string ReservationID = myReader["Reservation ID"].ToString();
					string EventName = myReader["Event"].ToString();
					string EventID = myReader["Event ID"].ToString();
					string EventDate = myReader["Date"].ToString();

					dataGridView1.Rows.Add(ReservationID, EventName, EventDate, EventID); //adds to datagridview

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

		private void viewReservationDetailsButton_Click(object sender, EventArgs e)
		{
			var row = dataGridView1.SelectedRows[0];

			string ReservationID = row.Cells[0].Value.ToString();
			string EventName = row.Cells[1].Value.ToString();
			string EventDate = row.Cells[2].Value.ToString();
			string EventID = row.Cells[3].Value.ToString();

			MessageBox.Show($@"
RESERVATION ID:{ReservationID}
EVENT NAME: {EventName}
EVENT DATE: {EventDate}
EVENT ID: {EventID}
");
		}

        private void updateDetailsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
