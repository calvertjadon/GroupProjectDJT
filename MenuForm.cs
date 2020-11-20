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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MenuForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}