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
        public DragAndDrop Drag = new DragAndDrop();

        public List<string> ListOfArticles;
        public ArticleDetailsUserControl(List<string> Articles)
        {
            InitializeComponent();
            BlockForm.AddDeleteMenu(this);
            Drag.AddDNDFunctions(this);

            ListOfArticles = Articles;

            int x = 356;
            int y = 376;

            try
            {
                x = Convert.ToInt32(Articles[1]);
                y = Convert.ToInt32(Articles[2]);
            } catch (ArgumentOutOfRangeException)
            {
                // Используем тандартный размер
            }
            

            this.Size = new Size(x, y);
            
            List<string> result = SQLClass.Select("SELECT Author, Category, Text, Picture FROM " + "Articles1" + " WHERE `Header` = '" + Articles[0] + "'");

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
                new Size(), new Point(), new List<string>());
            p.ParamsList.Add("Война и мир");
            p.ShowDialog();
            ArticleDetailsUserControl a1 = new ArticleDetailsUserControl(p.ParamsList);
            string Buff = "";
            foreach (string Param in p.ParamsList)
            {
                Buff += Param + ',';
            }
            BlockForm.InsertBlockToDB(sender, a1, Buff);
        }

        private void ArticleDetailsUserControl_Load(object sender, EventArgs e)
        {
            if (Program.ShowColor == true)
            {
                this.BackColor = SystemColors.ActiveBorder;

            }
        }

        private void ArticleTextLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
