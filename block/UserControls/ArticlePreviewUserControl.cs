using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace block
{
    /// <summary>
    /// UserControl статьи в режиме предпросмотра
    /// </summary>
    public partial class ArticlePreviewUserControl : UserControl
    {
        public List<string> asd;

        public string Article;
        public DragAndDrop Drag = new DragAndDrop();

        public int like = 0;
        public int dislike = 0;
        public bool changed = false;
        public bool like_pressed = false;
        public bool dislike_pressed = false;


        private string URL_;
        /*public ArticlePreviewUserControl(List <string> paramet)
        {
            InitializeComponent();
            like = Convert.ToInt32(paramet[2]);
            dislike = Convert.ToInt32(paramet[3]);
            URL_ = paramet[0];

            pictureBox1.LoadAsync(URL_);
            linkLabel1.Text = paramet[1];
            LikeCount.Text = like.ToString();
            DisLikeCount.Text = dislike.ToString();
            DisLikePB.Image = Properties.Resources.dislike;
            LikePB.Image = Properties.Resources.like;

            
        }*/

        public ArticlePreviewUserControl(List<string> Articles)
        {
            InitializeComponent();
            Drag.AddDNDFunctions(this);
            Menus.AddDeleteMenu(this);

            GC.Collect(2);
            
            if (Articles.Count == 0)
            {
                return;
            }
            Article = Articles[0];
            asd = Articles;


            List<String> url_pic = SQLClass.Select(string.Format("SELECT `Picture` FROM `Articles1` WHERE `Header`='{0}'", Article));
            if (url_pic.Count == 1)
            {
                pictureBox1.Load(url_pic[0]);
            }
            

            List<string> likes_dislikes = SQLClass.Select(string.Format("SELECT `LikesCount`, `DisCount` FROM `Likes` WHERE `Article`='{0}'", Article));
            if (likes_dislikes.Count == 2)
            {
                like = Int32.Parse(likes_dislikes[0]);
                dislike = Int32.Parse(likes_dislikes[1]);
            }

            linkLabel1.Text = Article;
            LikeCount.Text = like.ToString();
            DisLikeCount.Text = dislike.ToString();
        }


        /// <summary>
        /// Добавление UserControl с инфой о статье в режиме предпросмотра
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.ArticlePreviewUserControl");
            p.ShowDialog();
            p.ParamsList.Add("Война и мир");
            ArticlePreviewUserControl a1 = new ArticlePreviewUserControl(p.ParamsList);
            string shsvfhksv = "";
            foreach (string asd in p.ParamsList)
            {
                shsvfhksv += asd + ',';
            }
            Menus.InsertBlockToDB(sender, a1, shsvfhksv);
        }

        /// <summary>
        /// Показывает детали статьи
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new DetailsForm(new ArticleDetailsUserControl(new List<string> { Article })).ShowDialog();
        }

        #region Логика лайков (не работает пока)
        private void LikePB_Click(object sender, EventArgs e)
        {
            if (!like_pressed)
            {
                if (!dislike_pressed)
                {
                    like_pressed = true;
                    LikePB.Image = Properties.Resources.like_pressed;
                    like += 1;
                }
                else
                {
                    dislike_pressed = false;
                    like_pressed = true;

                    LikePB.Image = Properties.Resources.like_pressed;
                    like += 1;

                    DisLikePB.Image = Properties.Resources.dislike;
                    dislike -= 1;
                    changed = false;
                }
            }
            else
            {
                LikePB.Image = Properties.Resources.like;
                like -= 1;
            }

            LikeCount.Text = like.ToString();
            DisLikeCount.Text = dislike.ToString();
        }

        private void DisLikePB_Click(object sender, EventArgs e)
        {
            if (!dislike_pressed)
            {
                if (!like_pressed)
                {
                    dislike_pressed = true;
                    DisLikePB.Image = Properties.Resources.dislike_pressed;
                    dislike += 1;
                }

                like_pressed = false;
                dislike_pressed = true;

                DisLikePB.Image = Properties.Resources.dislike_pressed;
                dislike += 1;

                LikePB.Image = Properties.Resources.like;
                like -= 1;
            }
            else
            {
                DisLikePB.Image = Properties.Resources.dislike;
                dislike -= 1;
            }

            LikeCount.Text = like.ToString();
            DisLikeCount.Text = dislike.ToString();
        }
        #endregion

        private void ArticlePreviewUserControl_Load(object sender, EventArgs e)
        {
            if (Program.ShowColor == true)
            {
                this.BackColor = SystemColors.ActiveBorder;

            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
