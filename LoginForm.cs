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
    public partial class LoginForm : PanelMenuForm
    {
        public override Panel MainPanel => loginPanel;

        public LoginForm()
        {
            InitializeComponent();
        }
    }
}
