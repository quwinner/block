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
    public partial class AdsUserControl : UserControl
    {
        List<string> paramsAds;
        public AdsUserControl(List<string> ParamsAds)
        {
            InitializeComponent();
            paramsAds = ParamsAds;
            foreach (var PictureUrl in ParamsAds)
            {
                var pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Load(PictureUrl);
                flowLayoutPanel1.Controls.Add(pic);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
