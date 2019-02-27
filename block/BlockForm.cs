using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            label1.Text = (LoadFromDB("block1"));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Tex
            var test_block = new BlockData() {
                pos = new List<int>() {0, 0},
                name = "block2",
                distance_x = 0,
                distance_y = 0,
                objects = new List<BlockObj>() {new StringData() {
                    text = "1234 test",
                    pos = new List<int>() {0, 0}
                }}
            };
            SQLClass.Insert(string.Format("INSERT INTO `block_blocks`(`block1`, `json`) VALUES ('{0}','{1}')", "block2", 
                ""))
        }
    }
}
