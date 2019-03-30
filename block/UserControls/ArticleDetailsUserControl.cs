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
        public Size size_Userconrla;
        public Point locetion_userconrla;
        
        public List<string> asd;
        public ArticleDetailsUserControl(List<string> Articles)
        {
            InitializeComponent();
            GC.Collect(50);
            BlockForm.AddDeleteMenu(this);
            UCFunctions.AddDNDFunctions(this);

            asd = Articles;

            try
            {
                this.Size = new Size(Convert.ToInt32(Articles[1]), Convert.ToInt32(Articles[2]));
            }
            catch (Exception) { }
            
            List<String> result = SQLClass.Select("SELECT Author, Category, Text, Picture FROM " + "Articles1" + " WHERE `Header` = '" + Articles[0] + "'");
            AuthorsNameLabel.Text = result[0];
            ArticleLabel.Text = Articles[0];
            ArticleTextLabel.Text = result[2];
            ArticlePicture.Load(result[3]);
        }

        /// <summary>
        /// Добавление UserControl с детальной инфой о статье
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.ArticleDetailsUserControl", 
                new Size(), new Point(), new List<string>(), 
                c.Name, c.FindForm().Name);
            p.ParamsList.Add("Война и мир");
            p.ShowDialog();
            ArticleDetailsUserControl a1 = new ArticleDetailsUserControl(p.ParamsList);
            BlockForm.InsertBlockToDB(sender, a1);
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
