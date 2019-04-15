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
    public partial class UserControlAutorsList : UserControl
    {
        public List<String> authorsList = new List<string> { "Жулик", "Вор", "Единорос" };
        public int prog = 5;
        public List<string> asd;
        public DragAndDrop Drag = new DragAndDrop();

        public UserControlAutorsList(List<string> par)
        {
            InitializeComponent();
            asd = par;
            if(asd.Count >= 1)
            authorsList = SQLClass.Select("SELECT `UserName` FROM `Authors` LIMIT 0," + asd[0]);
            //if(asd.Count >= 2)
            if (asd.Count >= 3)
            prog = Convert.ToInt32(asd[2]);

            Menus.AddDeleteMenu(this);
            Drag.AddDNDFunctions(this);
        }

        /// <summary>
        /// Добавление UserControl со списком авторов
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.UserControlAutorsList", new List<string>() { });
            p.ShowDialog();
            UserControlAutorsList a1 = new UserControlAutorsList(new List<string> {p.Amount.ToString(), p.SortOrder, p.DistanceBetween.ToString() });
            string shsvfhksv = "";
            foreach (string asd in new List<string> { p.Amount.ToString(), p.SortOrder, p.DistanceBetween.ToString()})
            {
                shsvfhksv += asd + ',';
            }
            Menus.InsertBlockToDB(sender, a1, shsvfhksv);
        }        

        public void UserControlAutorsList_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(labelPopular);
            this.Controls.Add(labelAll);
            if (Program.ShowColor == true)
            {
                this.BackColor = SystemColors.ActiveBorder;
            }
            int authorsY = 50;
            for (int artIndex = 0; artIndex < authorsList.Count; artIndex++)
            {
                Label label1 = new Label();
                label1.Location = new Point(0, authorsY);
                label1.Size = new Size(100, 20);
                label1.Text = authorsList[artIndex].ToString();
                label1.Click += new System.EventHandler(Search_CLick);
                this.Controls.Add(label1);
                authorsY += prog + 20;           
            }
        }

              

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
        
        }

        public void Search_CLick(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).Text);

        }

        private void labelPopular_Click(object sender, EventArgs e)
        {

        }

        private void labelAll_Click(object sender, EventArgs e)
        {

        }
    }

      
    }

