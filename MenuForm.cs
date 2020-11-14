using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProjectDJT
{
    public abstract class MenuForm : Form
    {
        public abstract Panel MainPanel { get; }
    }
}