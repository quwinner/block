using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MySql.Data;
using MySql.Data.MySqlClient;

namespace block
{
    public partial class CatUserControl : UserControl
    {
        public CatUserControl(List<string> cat)
        {
            InitializeComponent();
        }

        private void CatUserControl_Load(object sender, EventArgs e)
        {
            List<String> categories = SQLClass.Select("SELECT Name FROM Categories ORDER BY Name");
            for (int i = 0; i < categories.Count; i++ )
            {
                Label label = new Label();
                label.Size = new Size(100, 30);
                label.Location = new Point(20, 50 + 30 * i);
                label.Text = categories[i].ToString();
                label.Click += new System.EventHandler(lable_cat_Click);
                this.Controls.Add(label);
            }
        }
        public void lable_cat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).Text);
        }
    }
}
