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
    public partial class ArticleDetailsUserControl : UserControl
    {
        public ArticleDetailsUserControl(string Article)
        {
            InitializeComponent();

            List<String> result = SQLClass.Select("SELECT Author, Category, Text, Picture FROM " + "Articles1" + " WHERE `Header` = '" + Article + "'");
            AuthorsNameLabel.Text = result[0];
            ArticleTextLabel.Text = result[2];
            ArticlePicture.Load(result[3]);
        }

        private void ArticlePicture_Click(object sender, EventArgs e)
        {

        }
    }
}
