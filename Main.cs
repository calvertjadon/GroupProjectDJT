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
    // custom mutable "tuple" class
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    public partial class Main : Form
    {
        public Dictionary<String, Pair<bool, MenuForm>> _forms;
        public Dictionary<String, Panel> _panels;

        public int MemberId = -1;

        public bool ShowLogoutMenuItem
        {
            set
            {
                // logout menu item will always be last item
                menuStrip1.Items[menuStrip1.Items.Count - 1].Visible = value;
            }
        }

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
            _forms = new Dictionary<String, Pair<bool, MenuForm>>()
            {
                // set bool to true of it needs a menu item.  otherwise it will be hidden.
                {"Home", new Pair<bool, MenuForm>(true, new Home())},
                {"ShowEvents", new Pair<bool, MenuForm>(true, new ShowEvents(this))},
                {"ReservationForm", new Pair<bool, MenuForm>(false, new ReservationForm())},
                {"MembershipForm", new Pair<bool, MenuForm>(true, new MembershipForm(this))},
                {"LoginForm", new Pair<bool, MenuForm>(true, new LoginForm(this))},
                {"Profile", new Pair<bool, MenuForm>(false, new Profile(this))},
                {"ReservationDetails", new Pair<bool, MenuForm>(false, new ReservationDetails(this))},

            };

            // Add all panels to dictionary
            _panels = new Dictionary<string, Panel>();

            foreach (Pair<bool, MenuForm> menuForm in _forms.Values)
            {
                // Since all forms inherit from abstract class MenuForm,
                //  we know that they all must contain an implementation of MainPanel
                Panel panel = menuForm.Second.MainPanel;

                // Add panels to main form
                this.Controls.Add(panel);
                panel.Location = new Point(12, 27);
                panel.Hide(); // hide all by default

                // menu item text is stored in Tag
                var title = panel.Tag.ToString();

                // Dynamically generate toolStrinMenuItem(s)
                var menuItem = new ToolStripMenuItem(title);
                menuItem.Click += this.toolStripMenuItem_Click;
                menuStrip1.Items.Add(menuItem);

                // the menuForm.Item1 is a bool indicating whether or not the form should be shown in the menu
                if (!menuForm.First)
                {
                    
                    menuItem.Visible = false;
                }

                _panels[title] = panel;

            }

            // Dynamically generate toolStrinMenuItem(s)
            var logoutMenuItem = new ToolStripMenuItem("Logout");
            logoutMenuItem.Click += this.logoutMember;
            logoutMenuItem.Visible = false;
            menuStrip1.Items.Add(logoutMenuItem);

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

        public void setMember(int memberId)
        {
            MemberId = memberId;

            _forms["LoginForm"].First = false;
            _forms["MembershipForm"].First = false;
            _forms["Profile"].First = true;
            ShowLogoutMenuItem = true;

            Profile ProfileForm = (Profile)_forms["Profile"].Second;
            ProfileForm.LoadMember();
            ProfileForm.loadEventHistory();

            refreshMenu();

            ShowEvents ShowEventsForm = (ShowEvents) _forms["ShowEvents"].Second;
            ShowEventsForm.populateDataGrid();

            showPanel("Upcoming Events");
        }

        private void logoutMember(object sender, EventArgs e)
        {
            MemberId = -1;

            _forms["LoginForm"].First = true;
            _forms["MembershipForm"].First = true;
            _forms["Profile"].First = false;
            ShowLogoutMenuItem = false;

            refreshMenu();

            ShowEvents ShowEventsForm = (ShowEvents)_forms["ShowEvents"].Second;
            ShowEventsForm.populateDataGrid();

            showPanel("Login");
        }

        public void refreshMenu()
        {
            for (int i = 0; i < _forms.Values.Count; i++)
            {
                Pair<bool, MenuForm> menuForm = _forms.Values.ToList()[i];

                Panel panel = menuForm.Second.MainPanel;
                var title = panel.Tag.ToString();

                menuStrip1.Items[i].Visible = menuForm.First;
            }
        }
    }
}
