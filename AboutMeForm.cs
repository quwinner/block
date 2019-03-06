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
            UserControlAutorization uaf = new UserControlAutorization();

            this.Controls.Add(uaf);
            UserControlCreateStat uccs = new UserControlCreateStat();
            uccs.Location = new Point(300, 0);
            this.Controls.Add(uccs);
        }
    }
}
