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
    }
}
