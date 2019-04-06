﻿using System;
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
        public List<string> asd;
        public DragAndDrop Drag = new DragAndDrop();

        public UserControlAutorsList(List<string> par)
        {
            InitializeComponent();
            asd = par;
            Menus.AddDeleteMenu(this);
            Drag.AddDNDFunctions(this);
        }

        /// <summary>
        /// Добавление UserControl со списком авторов
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.UserControlAutorsList", new List<string>());
            p.ShowDialog();
            UserControlAutorsList a1 = new UserControlAutorsList(p.ParamsList);
            string shsvfhksv = "";
            foreach (string asd in p.ParamsList)
            {
                shsvfhksv += asd + ',';
            }
            Menus.InsertBlockToDB(sender, a1, shsvfhksv);
        }



        private void UserControlAutorsList_Load(object sender, EventArgs e)
        {
            List<String> authorsList = new List<string>{ "Жулик", "Вор", "Единорос" };

            if (Program.ShowColor == true)
            {
                this.BackColor = SystemColors.ActiveBorder;
                
            }
            int authorsY = 75;
            for (int artIndex = 0; artIndex < authorsList.Count; artIndex += 1)
            {
                Label label1 = new Label();
                label1.Location = new Point(0, authorsY);
                label1.Size = new Size(100, 20);
                label1.Text = authorsList[artIndex].ToString();
                //label1.Click += new System.EventHandler(Search_CLick);
                this.Controls.Add(label1);
                authorsY += 25;
           
            }
        }

              

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //MessageBox.Show();
           
        }

        private void labelPopular_Click(object sender, EventArgs e)
        {

        }
    }

      
    }

