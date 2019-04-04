
﻿using System;
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
        const string FormName = "form2";
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

            List<string> paramsArt = new List<string>();
            paramsArt.Add("Война и мир");
            ArticleDetailsUserControl test = new ArticleDetailsUserControl(paramsArt);
            this.Controls.Add(test);

            //Список типов UserControl-ов
            List<Type> forms = new List<Type>();
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                forms.AddRange(from t in asm.GetTypes() where t.IsSubclassOf(typeof(UserControl)) select t);            
            }

            int i = 0;
            foreach (Type f in forms)
            {
                ArticlecontextMenuStrip1.Items.Add(f.Name);
                if (f.Name == "AdsUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += AdsUserControl.AddNewBlock;
                }
                else if (f.Name == "ArticleDetailsUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += ArticleDetailsUserControl.AddNewBlock;
                }
                else if (f.Name == "ArticlePreviewUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += ArticlePreviewUserControl.AddNewBlock;
                }
                else if (f.Name == "AuthenticationUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += AuthenticationUserControl.AddNewBlock;
                }
                else if (f.Name == "CategoriesUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += CategoriesUserControl.AddNewBlock;
                }
                else if (f.Name == "UserControlAutorsList")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += UserControlAutorsList.AddNewBlock;
                }
                else if (f.Name == "UserControlMainAuthor")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += UserControlMainAuthor.AddNewBlock;
                }
                else if (f.Name == "UserControlSearch")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += UserControlSearch.AddNewBlock;
                }
                i++;
            }
        }

        public static void AddDeleteMenu(object sender)
        {
            ((UserControl)sender).ContextMenuStrip = BlockForm.DeleteMenuStrip;
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
            MessageBox.Show("5");
        }

        /// <summary>
        /// Открываем форму наперстков
        /// </summary>
        private void Naperstki_Click(object sender, EventArgs e)
        {
            NaperstkiForm df = new NaperstkiForm();
            df.ShowDialog();
        }

        private void AboutMeClick(object sender, EventArgs e)
        {
            AboutMeForm df = new AboutMeForm();
            df.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //SQLClass.Delete("DELETE FROM `block_blocks` WHERE 1");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //SQLClass.Delete("DELETE FROM `block_blocks` WHERE 1");
        }

        /// <summary>
        /// Добавление информации о блоке в БД
        /// </summary>
        public static void InsertBlockToDB(object sender, UserControl a1, string par)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            Program.CONTROLY.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name,Params) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "','" + par +"')");

            List < String > str  = SQLClass.Select("SELECT MAX(id) FROM block");
            a1.Tag = str[0];
        }       

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            MessageBox.Show(pb.Location.X.ToString());
            SQLClass.Insert("INSERT INTO `block`(`form`,`Parent`, `x`, `y`, `name`) VALUES ('"+this.Name+"','" + pb.Parent.Name + "'," + pb.Location.X + ", " + pb.Location.Y + ",'" + pb.Name + "')");


        }

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            pb.Visible = false;
            SQLClass.Delete("DELETE FROM `block` WHERE `name` = '"+ pb.Name +"' AND form = '"+ pb.FindForm().Name +"'");
        }



        private void BlockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SQLClass.Delete("DELETE FROM block WHERE  form = '" + this.Name + "'");
        }

        private void setUCParams(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            List<string> dnonil = new List<string>();

            switch (pb.Name)
            {
                case "AdsUserControl":
                    AdsUserControl pb1 = (AdsUserControl)pb;
                    dnonil.Add(pb1.amount.ToString());
                    dnonil.Add(pb1.ParamsAds.Count.ToString());
                    break;
                case "ArticleDetailsUserControl":
                    ArticleDetailsUserControl pb2 = (ArticleDetailsUserControl)pb;
                    dnonil.Add(pb2.ListOfArticles[0]);
                    break;
                case "ArticlePreviewUserControl":
                    ArticlePreviewUserControl pb3 = (ArticlePreviewUserControl)pb;
                    dnonil.Add(pb3.Article);
                    dnonil.Add("5");
                    break;
                case "CategoriesUserControl":
                    CategoriesUserControl pb4 = (CategoriesUserControl)pb;
                    dnonil.Add("1");
                    dnonil.Add(pb4.asd[0]);
                    break;
                case "UserControlAutorsList":
                    UserControlAutorsList pb5 = (UserControlAutorsList)pb;
                    dnonil.Add("1");
                    dnonil.Add(" ");
                    break;
                case "UserControlMainAuthor":
                    UserControlMainAuthor pb6 = (UserControlMainAuthor)pb;
                    dnonil.Add(pb6.par[0]);
                    break;
                case "UserControlSearch":
                    UserControlSearch pb7 = (UserControlSearch)pb;
                    dnonil.Add(" ");
                    break;

            }

            UCParameters p = new UCParameters(pb.GetType().ToString(), pb.Size, pb.Location, dnonil);
            p.ShowDialog();
            p.Size = p.UCSize;
            pb.Location = p.UCLocation;
            if (pb.Name == "ArticlePreviewUserControl")
            {
                ArticlePreviewUserControl pb2 = (ArticlePreviewUserControl)pb;


                pb2.Article = p.ParamsList[0];
                pb2.linkLabel1.Text = pb2.Article;
                List<string> kart = SQLClass.Select("SELECT `Picture` FROM `Articles1` WHERE `Header` = '"+ pb2.Article + "'");
                pb2.pictureBox1.Load(kart[0]);

                List<string> likes = SQLClass.Select("SELECT `LikesCount`, `DisCount` FROM `Likes` WHERE `Article` = '" + pb2.Article + "'");
                pb2.LikeCount.Text = likes[0];
                pb2.DisLikeCount.Text = likes[1];
                pb2.like = Convert.ToInt32(likes[0]);
                pb2.dislike = Convert.ToInt32(likes[1]);

            }
            else if (pb.Name == "ArticleDetailsUserControl")
            {
                ArticleDetailsUserControl pb2 = (ArticleDetailsUserControl)pb;
                pb2.ListOfArticles = p.ParamsList;
                pb2.ArticleLabel.Text = p.ParamsList[0];
                List<string> kart = SQLClass.Select("SELECT Picture, Text, Author  FROM Articles1 WHERE Header = '" + pb2.ArticleLabel.Text + "'");
                pb2.ArticlePicture.Load(kart[0]);
                pb2.ArticleTextLabel.Text = kart[1];
                pb2.AuthorsNameLabel.Text = kart[2];
            }
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

        private void ArticlecontextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
