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
            List<string> parametry = new List<string>();
            parametry.Add("Война и мир");
            AuthenticationUserControl abc = new AuthenticationUserControl(parametry);
            this.Controls.Add(abc);

            List<string> paramsArt = new List<string>();
            paramsArt.Add("Война и мир");
            ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
            {
                Location = new Point(300, 0)
            };
            this.Controls.Add(preview);
        }
    }
}
