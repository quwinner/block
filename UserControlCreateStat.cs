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
    public partial class UserControlCreateStat : UserControl
    {
        public UserControlCreateStat()
        {
            InitializeComponent();
        }
        public static Panel CreateStatPanel()
        {
            Panel panel = new System.Windows.Forms.Panel();
            panel.Size = new System.Drawing.Size(300, 300);

            PictureBox pb = new PictureBox();
            pb.Load("https://static6.depositphotos.com/1017817/585/i/450/depositphotos_5850017-stock-photo-spring-background-with-leaves-and.jpg");

            PictureBox fon = new PictureBox();
            fon.Location = new System.Drawing.Point(0, 0);
            fon.Name = "picture";
            fon.Size = new System.Drawing.Size(200, 200);
            fon.TabIndex = 0;
            fon.Image = pb.Image;

            PictureBox like = new PictureBox();
            like.Load("http://zabavnik.club/wp-content/uploads/2018/05/like_9_14194312.png");

            PictureBox dislike = new PictureBox();
            dislike.Load("https://image.freepik.com/icones-gratis/nao-gosto-no-facebook-polegar-para-baixo-simbolo-de-destaque_318-37193.jpg");


            LinkLabel label1 = new LinkLabel();
            label1.Location = new Point(5, 210);
            label1.Size = new Size(50, 20);
            label1.Text = "Article";

            PictureBox likesPB = new PictureBox();
            likesPB.Size = new Size(20, 20);
            likesPB.Location = new Point(110, 210);
            likesPB.Image = like.Image;
            likesPB.SizeMode = PictureBoxSizeMode.StretchImage;

            Label likesLabel = new Label();
            likesLabel.Location = new Point(135, 210);
            likesLabel.Size = new Size(20, 20);
            likesLabel.Text = "89";

            PictureBox dislikesPB = new PictureBox();
            dislikesPB.Size = new Size(20, 20);
            dislikesPB.Location = new Point(155, 210);
            dislikesPB.Image = dislike.Image;
            dislikesPB.SizeMode = PictureBoxSizeMode.StretchImage;

            Label dislikesLabel = new Label();
            dislikesLabel.Location = new Point(180, 210);
            dislikesLabel.Size = new Size(20, 20);
            dislikesLabel.Text = "89";



            panel.Controls.Add(fon);
            panel.Controls.Add(label1);
            panel.Controls.Add(likesLabel);
            panel.Controls.Add(likesPB);
            panel.Controls.Add(dislikesPB);
            panel.Controls.Add(dislikesLabel);

            return panel;
        }
        private void UserControlCreateStat_Load(object sender, EventArgs e)
        {
            this.Controls.Add(CreateStatPanel());
        }
    }
}
