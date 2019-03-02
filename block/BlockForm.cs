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
                    pictureBox1.Location = new Point(abc.Data.Location[0], abc.Data.Location[1]);
                    PictureBoxData pbd = abc.ToObject<PictureBoxData>();
                    pictureBox1.Image = PictureBoxData.GetActualControl(pbd).Image;
                    //pictureBox1 = ((PictureBoxData)(abc.Data)).GetActualControl();
                }
            }
        }
    }
}
