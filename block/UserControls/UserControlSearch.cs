using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    public partial class UserControlSearch : UserControl
    {
        public UserControlSearch(List<string> SearchParams)
        {
            InitializeComponent();
            UCFunctions.AddDNDFunctions(this);
            BlockForm.AddDeleteMenu(this);
        }

        /// <summary>
        /// Добавление UserControl поиска
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.UserControlSearch",
                new Size(), new Point(), new List<string> {"Введите запрос"},
                c.Name, c.FindForm().Name);
            p.ShowDialog();
            UserControlSearch a1 = new UserControlSearch(p.ParamsList);
            string shsvfhksv = "";
            foreach (string asd in p.qq)
            {
                shsvfhksv += asd + ',';
            }
            BlockForm.InsertBlockToDB(sender, a1, shsvfhksv);
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserControlSearch_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
