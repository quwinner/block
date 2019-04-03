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
    public partial class ReadArticleForm : Form
    {
        public ReadArticleForm()
        {
            InitializeComponent();
            this.ContextMenuStrip = Program.AddNewUserControlCMS;
            this.Controls.AddRange(UCFunctions.ReadFromDB(this.Name).ToArray());
        }

        public static List<string> GetLikesDislikes(string Article)
        {
            var test = SQLClass.Select(string.Format("SELECT `LikesCount`, `DisCount` FROM `Likes` WHERE `Article`='{0}'", Article));
            return test;
        }

        public static Panel SearchArticles(string query, int max_articles = 5)
        {
            GetLikesDislikes(query);
            return null;
        }

        private void ReadArticleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
