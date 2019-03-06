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
    public partial class ArticlePreviewPicture : UserControl
    {
        private string URL_;
        public ArticlePreviewPicture(string URL, string Article, int Likes, int DisLikes)
        {
            InitializeComponent();
            URL_ = URL;
            pictureBox1.Load(URL);
            linkLabel1.Text = Article;
            label2.Text = Likes.ToString();
            label3.Text = DisLikes.ToString();
            pictureBox3.Load("https://image.freepik.com/icones-gratis/nao-gosto-no-facebook-polegar-para-baixo-simbolo-de-destaque_318-37193.jpg");
            pictureBox2.Load("http://zabavnik.club/wp-content/uploads/2018/05/like_9_14194312.png");
        }

        public ArticlePreviewPicture(string Article)
        {
            InitializeComponent();
            var url_pic = SQLClass.Select(string.Format("SELECT `Picture` FROM `Articles1` WHERE `Header`='{0}'", Article));
            pictureBox1.Load(url_pic[0]);
        }

        public JObject Data
        {
            get
            {
                return new JObject(new Dictionary<string, dynamic> {
                    {"Article", linkLabel1.Name},
                    {"Likes", label2.Text},
                    {"DisLikes", label3.Text},
                    {"URL", URL_}
                });
            }
            set
            {
                linkLabel1.Text = value["Article"].ToString();
                label2.Text = value["Likes"].ToString();
                label3.Text = value["DisLikes"].ToString();
                pictureBox1.Load(value["URL"].ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
