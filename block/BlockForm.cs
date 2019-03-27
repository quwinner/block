
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

            Program.UserControlCMS = UCContextMenuStrip;
            Program.AddNewUserControlCMS = ArticlecontextMenuStrip1;
            this.ContextMenuStrip = Program.AddNewUserControlCMS;
            DeleteMenuStrip = UCContextMenuStrip;
            Program.CONTROLY = AboutMeForm.read(this);
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
            SQLClass.Delete("DELETE FROM `block_blocks` WHERE 1");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SQLClass.Delete("DELETE FROM `block_blocks` WHERE 1");
        }

        /// <summary>
        /// Добавление информации о блоке в БД
        /// </summary>
        public static void InsertBlockToDB(object sender, UserControl a1)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            Program.CONTROLY.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
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

        private void настроитьПараметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters(pb.GetType().ToString(), pb.Size, pb.Location, new List<string>(), pb.Parent.Name, this.Name);
            p.ShowDialog();
            pb.Size = p.size_Userconrla;
            pb.Location = p.locetion_userconrla;
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
