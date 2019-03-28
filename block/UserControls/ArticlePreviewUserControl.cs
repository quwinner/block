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

        public static bool dragging = false;
        public static Point dragCursorPoint;
        public static Point dragFormPoint;

        private int like = 0;
        private int dislike = 0;
        private bool changed = false;
        private bool like_pressed = false;
        private bool dislike_pressed = false;


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
            GC.Collect(2);
            
            if (Articles.Count == 0)
            {
                return;
            }
            Article = Articles[0];

            try
            {
                List<String> url_pic = SQLClass.Select(string.Format("SELECT `Picture` FROM `Articles1` WHERE `Header`='{0}'", Article));
                pictureBox1.Load(url_pic[0]);
            }
            catch (Exception) { }

            try
            {
                List<String> likes_dislikes = SQLClass.Select(string.Format("SELECT `LikesCount`, `DisCount` FROM `Likes` WHERE `Article`='{0}'", Article));
                like = Int32.Parse(likes_dislikes[0]);
                dislike = Int32.Parse(likes_dislikes[1]);
            }
            catch (Exception) { }

            linkLabel1.Text = Article;
            LikeCount.Text = like.ToString();
            DisLikeCount.Text = dislike.ToString();

            ArticlePreviewUserControl.AddDNDFunctions(this);
            BlockForm.AddDeleteMenu(this);

        }


        /// <summary>
        /// Добавление UserControl с инфой о статье в режиме предпросмотра
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.ArticlePreviewUserControl",
                new Size(), new Point(), new List<string>() { "dfg","sd","23"},
                c.Name, c.FindForm().Name);
            p.ShowDialog();
            p.qq.Add("Война и мир");
            ArticlePreviewUserControl a1 = new ArticlePreviewUserControl(p.qq);
            BlockForm.InsertBlockToDB(sender, a1);
        }


        public JObject Data
        {
            get
            {
                return new JObject(new Dictionary<string, dynamic> {
                    {"Article", linkLabel1.Name},
                    {"Likes", LikeCount.Text},
                    {"DisLikes", DisLikeCount.Text},
                    {"URL", URL_}
                });
            }
            set
            {
                linkLabel1.Text = value["Article"].ToString();
                LikeCount.Text = value["Likes"].ToString();
                DisLikeCount.Text = value["DisLikes"].ToString();
                pictureBox1.Load(value["URL"].ToString());
            }
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

        public static void FormTest_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = ((UserControl)sender).Location;
        }

        public static void FormTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                ((UserControl)sender).Location = Point.Add(dragFormPoint, new Size(dif));                
            }
        }

        public static void FormTest_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            foreach (UserControl uc in Program.CONTROLY)
            {
                if (sender.Equals(uc))
                {
                    SQLClass.Update("UPDATE block SET x = " + ((UserControl)sender).Location.X.ToString() +
                        " WHERE name = '" + uc.Name + "' AND form = '" + uc.FindForm().Name + "'");
                }
            }
        }

        /// <summary>
        /// Добавление к ЮзерКонтролу контекстного меню, функций для DND и т.д.
        /// </summary>
        /// <param name="sender"></param>
        public static void AddDNDFunctions(object sender)
        {
            ((UserControl)sender).MouseDown += new MouseEventHandler(ArticlePreviewUserControl.FormTest_MouseDown);
            ((UserControl)sender).MouseMove += new MouseEventHandler(ArticlePreviewUserControl.FormTest_MouseMove);
            ((UserControl)sender).MouseUp += new MouseEventHandler(ArticlePreviewUserControl.FormTest_MouseUp);

            ((UserControl)sender).ContextMenuStrip = Program.UserControlCMS;
        }

        private void ArticlePreviewUserControl_Load(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
