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
    public partial class Main : Form
    {
        public Dictionary<String, Tuple<bool, MenuForm>> _forms;
        public Dictionary<String, Panel> _panels;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * When creating new forms:
             *  set the Tag property to the text you want to be displayed in the menu,
             *  create a panel, name it something relevant, and resize it to 760x522
             *  In the new form code, inherit from MenuForm and provide an implementation of MainPanel that points to the panel you created
             *
             * If done correctly, a menu item should be generated and if clicked on, the corresponding panel should be displayed
             */

            // Order specified here determines the order in the menu and which is displayed on startup
            _forms = new Dictionary<String, Tuple<bool, MenuForm>>()
            {
                // set bool to true of it needs a menu item.  otherwise it will be hidden.
                {"Home", new Tuple<bool, MenuForm>(true, new Home())},
                {"ShowEvents", new Tuple<bool, MenuForm>(true, new ShowEvents(this))},
                {"MembershipForm", new Tuple<bool, MenuForm>(true, new MembershipForm())},
                {"ReservationForm", new Tuple<bool, MenuForm>(false, new ReservationForm())},
                
            };

            // Add all panels to dictionary
            _panels = new Dictionary<string, Panel>();

            foreach (Tuple<bool, MenuForm> menuForm in _forms.Values)
            {
                // Since all forms inherit from abstract class MenuForm,
                //  we know that they all must contain an implementation of MainPanel
                Panel panel = menuForm.Item2.MainPanel;

                // Add panels to main form
                this.Controls.Add(panel);
                panel.Location = new Point(12, 27);
                panel.Hide(); // hide all by default

                // menu item text is stored in Tag
                var title = panel.Tag.ToString();

                // the menuForm.Item1 is a bool indicating whether or not the form should be shown in the menu
                if (menuForm.Item1)
                {
                    // Dynamically generate toolStrinMenuItem(s)
                    var menuItem = new ToolStripMenuItem(title);
                    menuItem.Click += this.toolStripMenuItem_Click;
                    menuStrip1.Items.Add(menuItem);
                }

                _panels[title] = panel;

            }

            // first panel is shown by default
            _panels.Values.First().Show();
            
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            var title = ((ToolStripMenuItem)sender).Text;
            showPanel(title);
        }

        public void showPanel(string title)
        {
            // hide all panels and show panel that corresponds with menu selection
            foreach (Panel panel in _panels.Values)
            {
                panel.Hide();
            }

            _panels[title].Show();
        }
    }
}
