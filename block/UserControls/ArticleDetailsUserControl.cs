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

        public ArticleDetailsUserControl(List<string> Articles)
        {
            InitializeComponent();

            List<String> result = SQLClass.Select("SELECT Author, Category, Text, Picture FROM " + "Articles1" + " WHERE `Header` = '" + Articles[0] + "'");
            AuthorsNameLabel.Text = result[0];
            ArticleLabel.Text = Articles[0];
            ArticleTextLabel.Text = result[2];
            ArticlePicture.Load(result[3]);
            BlockForm.deletemenu(this);
            ArticlePreviewUserControl.AddDNDFunctions(this);
        }

        private void ArticlePicture_Click(object sender, EventArgs e)
        {

        }

        private void ArticleLabel_Click(object sender, EventArgs e)
        {

        }

        private void ArticleTextLabel_Click(object sender, EventArgs e)
        {

        }
        
    }
}
