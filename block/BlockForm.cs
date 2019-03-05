using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace block
{
    public partial class BlockForm : Form
    {
        string FormName = "form_main";
        public BlockForm(string FormName)
        {
            InitializeComponent();
            this.FormName = FormName;
        }

        private string LoadFromDB(string block)
        {
            var aaa = SQLClass.Select(string.Format("SELECT `json` FROM `block_blocks` WHERE `block1`='{0}'", block));
            return aaa[0];
        }

        private void BlockForm_Load(object sender, EventArgs e)
        {
            //File.WriteAllText("test.json", SQLClass.Select("SELECT * FROM `block_blocks` WHERE 1")[1]);
            //label1.Text = (LoadFromDB("block1"));
            Panel panel1 = CreateStatPanel();
            flowLayoutPanel1.Controls.Add(panel1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var test_block = new BlockData() {
                Location = new int[] { 0, 0 },
                Name = "block2",
                Distance = new int[] {0, 0},
                Objects = new List<dynamic>() {
                    new BlockObj(textBox1),
                    new BlockObj(pictureBox1)
                }
            };
            var test_block_json = JsonConvert.SerializeObject(test_block);
            SQLClass.Insert(string.Format("INSERT INTO `block_blocks`(`name`, `json`) VALUES ('{0}','{1}')", "block2",
                test_block_json));
        }

        /// <summary>
        /// Открываем форму наперстков
        /// </summary>
        private void naperstki_Click(object sender, EventArgs e)
        {
            NaperstkiForm df = new NaperstkiForm();
            df.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutMeForm df = new AboutMeForm();
            df.ShowDialog();
        }
        public static Panel CreateStatPanel()
        {
            Panel panel = new System.Windows.Forms.Panel();
            panel.Size = new System.Drawing.Size(300, 300);

            PictureBox pb = new PictureBox();
            pb.Load("https://static6.depositphotos.com/1017817/585/i/450/depositphotos_5850017-stock-photo-spring-background-with-leaves-and.jpg");

            PictureBox fon = new PictureBox();
            fon.Location = new System.Drawing.Point(5, 6);
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

        private void label2_Click(object sender, EventArgs e)
        {
            var res = SQLClass.Select(string.Format("SELECT json FROM `block_blocks` WHERE name='{0}'", "block2"));
            var res_decoded = JsonConvert.DeserializeObject<BlockData>(res[0]);
            foreach (JObject abc1 in res_decoded.Objects)
            {
                BlockObj abc = abc1.ToObject<BlockObj>();
                //BlockObj abc = JsonConvert.DeserializeObject < BlockObj >( abc1);
                if (abc.Data.Name == "pictureBox1")
                {

                    PictureBoxData pbd = abc1["Data"].ToObject<PictureBoxData>();
                    PictureBox pbd2 = abc1["Data"].ToObject<PictureBox>();

                    pictureBox1.Location = new Point(abc.Data.Location[0], abc.Data.Location[1]);
                    //PictureBoxData pbd = abc.ToObject<PictureBoxData>();
                    //pictureBox1.Image = PictureBoxData.GetActualControl(pbd).Image;
                    //pictureBox1 = ((PictureBoxData)(abc.Data)).GetActualControl();
                }
            }
        }
    }
}
