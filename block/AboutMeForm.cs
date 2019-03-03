using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    public partial class AboutMeForm : Form
    {
        public AboutMeForm()
        {
            InitializeComponent();
        }

        private void AboutMeForm_Load(object sender, EventArgs e)
        {
            Panel panel1 = NaperstkiForm.CreateAuthorizationPanel();
            this.Controls.Add(panel1);
            Panel panel2 = BlockForm.CreateStatPanel();
            panel2.Location = new Point(300, 0);
            this.Controls.Add(panel2);
        }
    }
}
