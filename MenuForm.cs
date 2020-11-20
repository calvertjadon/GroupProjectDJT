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
        public virtual Panel MainPanel { get; }

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

    public class PanelMenuForm : MenuForm
    {
        // this is just a dumb windows form thing apparently
        // https://stackoverflow.com/questions/1620847/how-can-i-get-visual-studio-2008-windows-forms-designer-to-render-a-form-that-im/2406058#2406058
    }
}