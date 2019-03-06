using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    public partial class UserControlAbout : UserControl
    {
        public UserControlAbout()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void buttonMore_Click(object sender, EventArgs e)
        {
            AboutMeForm amf = new AboutMeForm();
            amf.ShowDialog();
        }
    }
}
