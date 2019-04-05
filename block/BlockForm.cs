
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace block
{
    public partial class BlockForm : Form
    {
        public static int like = 89;
        public static int dislike = 89;
        public static ContextMenuStrip DeleteMenuStrip;

        public BlockForm()
        {
            InitializeComponent();

            Program.UserControlCMS = UCContextMenuStrip;
            Program.AddNewUserControlCMS = ArticlecontextMenuStrip1;
            this.ContextMenuStrip = Program.AddNewUserControlCMS;
            DeleteMenuStrip = UCContextMenuStrip;
            this.Controls.AddRange(UCFunctions.ReadFromDB(this.Name).ToArray());
        }

        public void BlockForm_Load(object sender, EventArgs e)
        {
            //File.WriteAllText("test.json", SQLClass.Select("SELECT * FROM `block_blocks` WHERE 1")[1]);
            //label1.Text = (LoadFromDB("block1"));
            //Panel panel1 = CreateStatPanel();

            List<string> paramsArt = new List<string>();
            paramsArt.Add("Война и мир");
            ArticleDetailsUserControl test = new ArticleDetailsUserControl(paramsArt);
            this.Controls.Add(test);
            Menus.InitAddUserControls(ref ArticlecontextMenuStrip1);
        }

        /// <summary>
        /// Открываем форму наперстков
        /// </summary>
        private void Naperstki_Click(object sender, EventArgs e)
        {
            NaperstkiForm df = new NaperstkiForm();
            df.ShowDialog();
        }

        /// <summary>
        /// Открываем форму "Обо мне"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMeClick(object sender, EventArgs e)
        {
            AboutMeForm df = new AboutMeForm();
            df.ShowDialog();
        }

        private void MyPromoClick(object sender, EventArgs e)
        {
            MyPromotionsForm mpf = new MyPromotionsForm();
            mpf.ShowDialog();
        }

        private void ReadArticleClick(object sender, EventArgs e)
        {
            ReadArticleForm rf = new ReadArticleForm();
            rf.ShowDialog();
        }
    }
}
