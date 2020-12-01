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
                MessageBox.Show("Reservation ID must be a number!");
            }

            
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
