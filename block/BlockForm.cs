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

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace block
{
    public partial class BlockForm : Form
    {
        string FormName = "form_main";
        public static int like = 89;
        public static int dislike = 89;

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

        public void BlockForm_Load(object sender, EventArgs e)
        {
            //File.WriteAllText("test.json", SQLClass.Select("SELECT * FROM `block_blocks` WHERE 1")[1]);
            //label1.Text = (LoadFromDB("block1"));
            //Panel panel1 = CreateStatPanel();
            //flowLayoutPanel1.Controls.Add(panel1);
            Panel shit = shenie_statey("тест випки");
            flowLayoutPanel1.Controls.Add(shit);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            /*var test_block = new BlockData() {
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
                test_block_json));*/
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



            LinkLabel label1 = new LinkLabel();
            label1.Location = new Point(5, 210);
            label1.Size = new Size(50, 20);
            label1.Text = "Article";

            PictureBox likesPB = new PictureBox();
            likesPB.Size = new Size(20, 20);
            likesPB.Location = new Point(110, 210);
            likesPB.Image = Properties.Resources.like;
            likesPB.Name = "likesPB";
            likesPB.SizeMode = PictureBoxSizeMode.StretchImage;
            likesPB.Click += new System.EventHandler(like_click);
            likesPB.Tag = "like";

            Label likesLabel = new Label();
            likesLabel.Location = new Point(135, 210);
            likesLabel.Size = new Size(20, 20);
            likesLabel.Text = like.ToString();
            likesLabel.Name = "likesLabel";

            PictureBox dislikesPB = new PictureBox();
            dislikesPB.Size = new Size(20, 20);
            dislikesPB.Location = new Point(155, 210);
            dislikesPB.Image = Properties.Resources.dislike;
            dislikesPB.Name = "dislikesPB";
            dislikesPB.SizeMode = PictureBoxSizeMode.StretchImage;
            dislikesPB.Click += new System.EventHandler(like_click);
            dislikesPB.Tag = "dislike";

            Label dislikesLabel = new Label();
            dislikesLabel.Location = new Point(180, 210);
            dislikesLabel.Size = new Size(20, 20);
            dislikesLabel.Text = dislike.ToString();
            dislikesLabel.Name = "dislikesLabel";



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
            /*var res = SQLClass.Select(string.Format("SELECT json FROM `block_blocks` WHERE name='{0}'", "block2"));
            var res_decoded = JsonConvert.DeserializeObject<BlockData>(res[0]);
            foreach (JObject abc1 in res_decoded.Objects)
            {
                BlockObj abc = abc1.ToObject<BlockObj>();
                //BlockObj abc = JsonConvert.DeserializeObject < BlockObj >( abc1);
                if (abc.Data.Type == "System.Windows.Forms.PictureBox")
                {
                    if (abc.Data.Name == "pictureBox1")
                    {
                        PictureBoxData pbd = abc1["Data"].ToObject<PictureBoxData>();

                        pictureBox1.Load(pbd.URL);

                        pictureBox1.Location = new Point(abc.Data.Location[0], abc.Data.Location[1]);
                        //PictureBoxData pbd = abc.ToObject<PictureBoxData>();
                        //pictureBox1.Image = PictureBoxData.GetActualControl(pbd).Image;
                        //pictureBox1 = ((PictureBoxData)(abc.Data)).GetActualControl();
                    }
                }
            }*/
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SQLClass.Delete("DELETE FROM `block_blocks` WHERE 1");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new ArticlePreviewPicture("Война и мир"));
        }
        public static Panel shenie_statey(string text_N)
        {

            MySqlCommand cmd = new MySqlCommand("SELECT Header, Author, Category, Text, Picture FROM " + "Articles1" + " WHERE `Header` = '" + text_N + "'", SQLClass.CONN);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();


            Panel osnov = new Panel();
            TableLayoutPanel osnov2 = new TableLayoutPanel();
            Panel golova = new Panel();
            Panel dly_text = new Panel();
            PictureBox kartinka = new PictureBox();
            Label avtor = new Label();
            Label kategor = new Label();
            Label oglavlenie = new Label();
            Label text_stati = new Label();


            osnov.Controls.Add(osnov2);
            osnov.Location = new System.Drawing.Point(383, 3);
            osnov.Name = "panel1";
            osnov.Size = new System.Drawing.Size(294, 836);
            osnov.TabIndex = 6;
            osnov.BackColor = Color.Azure;
            //osnov.Dock = System.Windows.Forms.DockStyle.Fill;

            kartinka.Dock = System.Windows.Forms.DockStyle.Fill;
            kartinka.Location = new System.Drawing.Point(3, 83);
            kartinka.Name = "pictureBox2";
            kartinka.Size = new System.Drawing.Size(288, 160);
            kartinka.SizeMode = PictureBoxSizeMode.Zoom;
            kartinka.TabIndex = 2;
            kartinka.TabStop = false;
            if (rdr[4].ToString() != "")
            {
                try
                {
                    kartinka.Load(rdr[4].ToString());
                }
                catch(Exception)
                {
                    kartinka.Load("https://travel-vse.ru/wp-content/uploads/2018/12/10-7.jpg");
                }
            }
            else
            {
                kartinka.Load("https://whatzup.com/content/viewer/web/images/loading.gif");
            }

            osnov2.ColumnCount = 1;
            osnov2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            osnov2.Controls.Add(golova, 0, 0);
            osnov2.Controls.Add(kartinka, 0, 1);
            osnov2.Controls.Add(dly_text, 0, 2);
            osnov2.Dock = System.Windows.Forms.DockStyle.Fill;
            osnov2.Location = new System.Drawing.Point(0, 0);
            osnov2.Name = "tableLayoutPanel1";
            osnov2.RowCount = 3;
            osnov2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            osnov2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            osnov2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            osnov2.Size = new System.Drawing.Size(294, 336);
            osnov2.TabIndex = 0;


            golova.Controls.Add(avtor);
            golova.Controls.Add(oglavlenie);
            golova.Controls.Add(kategor);
            golova.Dock = System.Windows.Forms.DockStyle.Fill;
            golova.Location = new System.Drawing.Point(3, 3);
            golova.Name = "panel2";
            golova.Size = new System.Drawing.Size(288, 74);
            golova.TabIndex = 0;


            kategor.AutoSize = true;
            kategor.Location = new System.Drawing.Point(18, 7);
            kategor.Name = "label3";
            kategor.Size = new System.Drawing.Size(35, 13);
            kategor.TabIndex = 0;
            kategor.Text = rdr[2].ToString();


            oglavlenie.AutoSize = true;
            oglavlenie.Location = new System.Drawing.Point(18, 43);
            oglavlenie.Name = "label4";
            oglavlenie.Size = new System.Drawing.Size(35, 13);
            oglavlenie.TabIndex = 1;
            oglavlenie.Text = rdr[0].ToString();


            avtor.AutoSize = true;
            avtor.Location = new System.Drawing.Point(232, 7);
            avtor.Name = "label5";
            avtor.Size = new System.Drawing.Size(35, 13);
            avtor.TabIndex = 2;
            avtor.Text = rdr[1].ToString();


            dly_text.Controls.Add(text_stati);
            dly_text.Dock = System.Windows.Forms.DockStyle.Fill;
            dly_text.Location = new System.Drawing.Point(3, 249);
            dly_text.Name = "panel3";
            dly_text.AutoScroll = true;
            dly_text.Size = new System.Drawing.Size(288, 84);
            dly_text.TabIndex = 1;


            text_stati.Dock = System.Windows.Forms.DockStyle.Fill;
            text_stati.Location = new System.Drawing.Point(0, 0);
            text_stati.Name = "label6";
            text_stati.AutoSize = true;
            text_stati.TabIndex = 0;
            text_stati.Text = rdr[3].ToString();

            rdr.Close();
            return osnov;
        }

        static void like_click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Name == "likesPB")
            {
                Panel dfdfs = (Panel)(((PictureBox)sender).Parent);

                if (((PictureBox)sender).Tag.ToString() == "like")
                {
                    ((PictureBox)sender).Image = Properties.Resources.like2;
                    ((PictureBox)sender).Tag = "like2";
                    like = like + 1;

                    foreach (Control ahggh in dfdfs.Controls)
                    {
                        if (ahggh.Name == "dislikesPB" && ahggh.Tag == "disLike2")
                        {
                            ((PictureBox)ahggh).Image = Properties.Resources.dislike;
                            ((PictureBox)ahggh).Tag = "dislike";
                            dislike = dislike - 1;
                        }
                    }
                }
                else
                {
                    ((PictureBox)sender).Image = Properties.Resources.like;
                    ((PictureBox)sender).Tag = "like";
                    like = like - 1;
                }

                foreach (Control ahggh in dfdfs.Controls)
                {
                    if (ahggh.Name == "likesLabel")
                    {
                        ahggh.Text = like.ToString();
                    }
                }
            }

            else if (((PictureBox)sender).Name == "dislikesPB")
            {
                Panel dfdfs = (Panel)(((PictureBox)sender).Parent);

                if (((PictureBox)sender).Tag.ToString() == "dislike")
                {
                    ((PictureBox)sender).Image = Properties.Resources.disLike2;
                    ((PictureBox)sender).Tag = "dislike2";
                    dislike = dislike + 1;

                    foreach (Control ahggh in dfdfs.Controls)
                    {
                        if (ahggh.Name == "likesPB" && ahggh.Tag == "like2")
                        {
                            ((PictureBox)ahggh).Image = Properties.Resources.like;
                            ((PictureBox)ahggh).Tag = "like";
                            like = like - 1;
                        }
                    }
                }
                else
                {
                    ((PictureBox)sender).Image = Properties.Resources.dislike;
                    ((PictureBox)sender).Tag = "dislike";
                    dislike = dislike - 1;
                }
                foreach (Control ahggh in dfdfs.Controls)
                {
                    if (ahggh.Name == "dislikesLabel")
                    {
                        ahggh.Text = dislike.ToString();
                    }
                }
            }


        }
    }
}
