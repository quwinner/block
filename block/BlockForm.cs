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
            
            Panel panel_osnov = reklama(4, 5);
            flowLayoutPanel1.Controls.Add(panel_osnov);
        }

        /// <summary>
        /// Создание блока рекламы
        /// </summary>
        /// <param name="kol_vo">Сколько реклам</param>
        /// <param name="rastoy">Расстояние между PictureBox</param>
        /// <param name="d">Адреса картинок</param>
        /// <returns></returns>
        static public Panel reklama(int kol_vo = 1, int rastoy = 0, string d = "")
        {
            string[,] dany = {
                              {"https://dodopizza.ru/ulyanovsk?utm_source=yandex&utm_medium=YaPepP445&utm_campaign=35015617&yclid=940349662605377322" , "http://s1.1zoom.me/b5050/594/Fast_food_Pizza_Tomatoes_489103_2880x1800.jpg"},
                              {"https://ru.wikipedia.org/wiki/%D0%96%D1%83%D0%BA%D0%BE%D0%B2,_%D0%93%D0%B5%D0%BE%D1%80%D0%B3%D0%B8%D0%B9_%D0%9A%D0%BE%D0%BD%D1%81%D1%82%D0%B0%D0%BD%D1%82%D0%B8%D0%BD%D0%BE%D0%B2%D0%B8%D1%87", "https://www.colors.life/upload/blogs/6b/15/6b155cc2566442f616c9676557adc62c_RSZ_690.jpeg"},
                              {"http://www.actualinstaller.ru", "http://www.actualinstaller.ru/images/box.jpg"},
                              {"https://ru.wikipedia.org/wiki/%D0%9D%D0%B5%D1%87%D1%82%D0%BE_(%D1%84%D0%B8%D0%BB%D1%8C%D0%BC,_1982)", "https://citifox.ru/wp-content/uploads/2017/01/Screenshot_3-9.png"},
                              };
            Panel panel_osnov = new Panel();
            panel_osnov.Location = new System.Drawing.Point(125, 3);
            panel_osnov.Name = "panel1";
            panel_osnov.AutoScroll = true;
            panel_osnov.Size = new System.Drawing.Size(250, 300);
            panel_osnov.TabIndex = 2;

            for (int i = 0; i < kol_vo; i++)
            {
                PictureBox rek = new PictureBox();
                rek.Location = new System.Drawing.Point(0, (120 + rastoy) * i);
                rek.Name = i.ToString();
                rek.Tag = dany[i, 0];
                rek.Load(dany[i, 1]);
                rek.SizeMode = PictureBoxSizeMode.StretchImage;
                rek.Click += new System.EventHandler(BlockForm.nash_na_rekl);
                rek.Size = new System.Drawing.Size(250, 120);
                rek.TabStop = false;
                panel_osnov.Controls.Add(rek);
            }

            return panel_osnov;
        }

        static public void nash_na_rekl(object sender, EventArgs e)
        {
            PictureBox sa = (PictureBox)sender;
            System.Diagnostics.Process.Start(sa.Tag.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var test_block = new BlockData() {
                Location = new int[] { 0, 0 },
                Name = "block2",
                Distance = new int[] {0, 0},
                Objects = new List<dynamic>() {new BlockObj(new TextBox() {
                    Text = "testing"
                }), new BlockObj(new TextBox() {
                    Text = "red text",
                    BackColor = Color.Red
                })}
            };
            var test_block_json = JsonConvert.SerializeObject(test_block);
            SQLClass.Insert(string.Format("INSERT INTO `block_blocks`(`block1`, `json`) VALUES ('{0}','{1}')", "block2",
                test_block_json));
            File.WriteAllText("1234.json", test_block_json);
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
}
}
