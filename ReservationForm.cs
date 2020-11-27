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

        private void seatsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
