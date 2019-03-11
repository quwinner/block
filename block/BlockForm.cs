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
        public static ContextMenuStrip Delete;

        public BlockForm(string FormName)
        {
            InitializeComponent();
            this.FormName = FormName;
            Delete = DeletecontextMenuStrip1;
        }

        private string LoadFromDB(string block)
        {
            var aaa = SQLClass.Select(string.Format("SELECT `json` FROM `block_blocks` WHERE `block1`='{0}'", block));
            return aaa[0];
        }

        public void BlockForm_Load(object sender, EventArgs e)
        {
            Program.UserControlCMS = contextMenuStrip1;
            //File.WriteAllText("test.json", SQLClass.Select("SELECT * FROM `block_blocks` WHERE 1")[1]);
            //label1.Text = (LoadFromDB("block1"));
            //Panel panel1 = CreateStatPanel();
            //flowLayoutPanel1.Controls.Add(panel1);
            ArticleDetailsUserControl test = new ArticleDetailsUserControl("Война и мир");
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
                    ArticlecontextMenuStrip1.Items[i].Click += label4_Click;
                    i++;
                }
                if (f.Name == "ArticlePreviewUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += articlePreview_Click;
                    i++;
                }
                if (f.Name == "AuthenticationUserControl")
                {
                    ArticlecontextMenuStrip1.Items[i].Click += author_Click;
                    i++;
                }

            }

        }

        public static void deletemenu(object sender)
        {
            ((UserControl)sender).ContextMenuStrip = BlockForm.Delete;
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

        private void label4_Click(object sender, EventArgs e)
        {
            ArticlePreviewUserControl a1 = new ArticlePreviewUserControl("Война и мир");
            flowLayoutPanel1.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO `block`(`form`, `x`, `y`, `name`) VALUES ('" + this.Name + "','" + a1.Location.X + "','" + a1.Location.Y + "','"+ a1.Name +"')");
        }

        private void articlePreview_Click(object sender, EventArgs e)
        {
            ArticleDetailsUserControl a1 = new ArticleDetailsUserControl("Война и мир");
            flowLayoutPanel1.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO `block`(`form`, `x`, `y`, `name`) VALUES ('" + this.Name + "','" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }

        private void author_Click(object sender, EventArgs e)
        {
            AuthenticationUserControl a1 = new AuthenticationUserControl();
            flowLayoutPanel1.Controls.Add(a1);
            SQLClass.Insert("INSERT INTO `block`(`form`, `x`, `y`, `name`) VALUES ('" + this.Name + "','" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "')");
        }

        private void createBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new ArticlePreviewUserControl("Война и мир"));
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            MessageBox.Show(pb.Location.X.ToString());
            SQLClass.Insert("INSERT INTO `block`(`form`, `x`, `y`, `name`) VALUES ('" + pb.Parent.Name + "'," + pb.Location.X + ", " + pb.Location.Y + ",'" + pb.Name + "')");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            pb.Visible = false;
            SQLClass.Delete("DELETE FROM `block` WHERE `name` = '"+ pb.Name +"' AND 'form' = '"+ pb.FindForm() +"'");
        }
    }
}
