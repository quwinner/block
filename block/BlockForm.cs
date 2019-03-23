
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
        string FormName = "form_main";
        public static int like = 89;
        public static int dislike = 89;
        public static ContextMenuStrip DeleteMenuStrip;

        public BlockForm(string FormName)
        {
            InitializeComponent();
            this.FormName = FormName;
            DeleteMenuStrip = UCContextMenuStrip;
            AboutMeForm.read(this);
        }

        private string LoadFromDB(string block)
        {
            var aaa = SQLClass.Select(string.Format("SELECT `json` FROM `block_blocks` WHERE `block1`='{0}'", block));
            return aaa[0];
        }

        private void search_Click(object sender, EventArgs e)
        {
            List<string> paramsArt = new List<string>();
            UserControlSearch a1 = new UserControlSearch(paramsArt);
            flowLayoutPanel1.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO `block`(`form`,`Parent`, `x`, `y`, `name`) VALUES ('" + this.Name + "', 'null', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }

        public void BlockForm_Load(object sender, EventArgs e)
        {
            Program.UserControlCMS = UCContextMenuStrip;
            Program.AddNewUserControlCMS = ArticlecontextMenuStrip1;
            //File.WriteAllText("test.json", SQLClass.Select("SELECT * FROM `block_blocks` WHERE 1")[1]);
            //label1.Text = (LoadFromDB("block1"));
            //Panel panel1 = CreateStatPanel();
            //flowLayoutPanel1.Controls.Add(panel1);
            List<string> paramsArt = new List<string>();
            paramsArt.Add("Война и мир");
            ArticleDetailsUserControl test = new ArticleDetailsUserControl(paramsArt);
            flowLayoutPanel1.Controls.Add(test);


            List<Type> forms = new List<Type>();
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                forms.AddRange(from t in asm.GetTypes() where t.IsSubclassOf(typeof(UserControl)) select t);
            }
            int i =0;
            foreach (Type f in forms)
            {
                ArticlecontextMenuStrip1.Items.Add(f.Name);
                if(f.Name == "ArticleDetailsUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += ArticleDetailsClick;
                }
                else if (f.Name == "ArticlePreviewUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += articlePreview_Click;
                }
                else if (f.Name == "AuthenticationUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += author_Click;
                }
                else if (f.Name == "UserControlAutorsList")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += authorsList_Click;
                }
                else if (f.Name == "CategoriesUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += cat_Click;
                }
                else if (f.Name == "UserControlSearch")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += search_Click;
                }
                else if (f.Name == "AdsUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += ads_click;
                }
                else if (f.Name == "UserControlMainAuthor")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += Main_author_Click;
                }
                i++;
            }

        }

        /// <summary>
        /// Инфа об авторе
        /// </summary>
        private void Main_author_Click(object sender, EventArgs e)
        {
            List<string> parametry = new List<string>();
            parametry.Add("Жуков");
            UserControlMainAuthor a1 = new UserControlMainAuthor(parametry);
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" + 
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
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

        private void label2_Click(object sender, EventArgs e)
        {
            SQLClass.Delete("DELETE FROM `block_blocks` WHERE 1");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SQLClass.Delete("DELETE FROM `block_blocks` WHERE 1");
        }

        /// <summary>
        /// Реклама
        /// </summary>
        private void ads_click(object sender, EventArgs e)
        {
            List<string> paramsArt = new List<string>();
            paramsArt.Add("http://rustrade.org.uk/rus/wp-content/uploads/dodo-pizza.jpg");
            paramsArt.Add("https://i.simpalsmedia.com/joblist.md/360x200/f0eeb7ea787a8cc8370e29638d582f31.png");
            paramsArt.Add("https://www.sostav.ru/images/news/2018/02/21/13349a407abf5ee3d8c795fc78694299.jpg");
            paramsArt.Add("https://static.tildacdn.com/tild6533-3365-4438-a364-613965626338/cover-6.jpg");
            paramsArt.Add("https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg");
            paramsArt.Add("https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg");
            AdsUserControl a1 = new AdsUserControl(paramsArt);

            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }

        private void ArticleDetailsClick(object sender, EventArgs e)
        {
            UCParameters p = new UCParameters("block.ArticleDetailsUserControl", new Size(), new Point(), new List<string>(), ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Name, this.Name);
            p.qq.Add("Война и мир");
            p.ShowDialog();
            ArticlePreviewUserControl a1 = new ArticlePreviewUserControl(p.qq);

            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }

        private void articlePreview_Click(object sender, EventArgs e)
        {
            UCParameters p = new UCParameters("block.ArticlePreviewUserControl", new Size(), new Point(), new List<string>(), ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Name, this.Name);
            p.qq.Add("Война и мир");
            p.ShowDialog();
            ArticleDetailsUserControl a1 = new ArticleDetailsUserControl(p.qq);

            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }

        /// <summary>
        /// Категории
        /// </summary>
        private void cat_Click(object sender, EventArgs e)
        {
            UCParameters p = new UCParameters("block.CategoriesUserControl", new Size(), new Point(), new List<string>(), ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Name, this.Name);
            p.ShowDialog();
            CategoriesUserControl a1 = new CategoriesUserControl(p.qq);

            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }
        private void authorsList_Click(object sender, EventArgs e)
        {
            UCParameters p = new UCParameters("block.UserControlAutorsList", new Size(), new Point(), new List<string>(), ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Name, this.Name);
            p.ShowDialog();
            UserControlAutorsList a1 = new UserControlAutorsList(p.qq);

            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }

        private void author_Click(object sender, EventArgs e)
        {
            UCParameters p = new UCParameters("block.AuthenticationUserControl", new Size(), new Point(), new List<string>(), ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.Name, this.Name);
            p.ShowDialog();
            AuthenticationUserControl a1 = new AuthenticationUserControl(p.qq);

            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            MessageBox.Show(pb.Location.X.ToString());
            SQLClass.Insert("INSERT INTO `block`(`form`,`Parent`, `x`, `y`, `name`) VALUES ('"+this.Name+"','" + pb.Parent.Name + "'," + pb.Location.X + ", " + pb.Location.Y + ",'" + pb.Name + "')");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            pb.Visible = false;
            SQLClass.Delete("DELETE FROM `block` WHERE `name` = '"+ pb.Name +"' AND form = '"+ pb.FindForm() +"'");
        }



        private void BlockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SQLClass.Delete("DELETE FROM block WHERE  form = '" + this.Name + "'");
        }

        private void настроитьПараметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters(pb.GetType().ToString(), pb.Size, pb.Location, new List<string>(), pb.Parent.Name, this.Name);
            p.ShowDialog();
            pb.Size = p.size_Userconrla;
            pb.Location = p.locetion_userconrla;
        }
    }
}
