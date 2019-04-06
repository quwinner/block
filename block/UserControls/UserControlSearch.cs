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
        public DragAndDrop Drag = new DragAndDrop();

        public UserControlSearch(List<string> SearchParams)
        {
            InitializeComponent();
            Drag.AddDNDFunctions(this);
            Menus.AddDeleteMenu(this);

        }

        /// <summary>
        /// Добавление UserControl поиска
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.UserControlSearch", new List<string>());
            p.ShowDialog();
            UserControlSearch a1 = new UserControlSearch(p.ParamsList);
            string shsvfhksv = "";
            foreach (string asd in p.ParamsList)
            {
                shsvfhksv += asd + ',';
            }
            Menus.InsertBlockToDB(sender, a1, shsvfhksv);
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
