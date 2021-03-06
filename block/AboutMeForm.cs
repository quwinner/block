﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    public partial class AboutMeForm : Form
    {
        public AboutMeForm()
        {
            InitializeComponent();
            this.ContextMenuStrip = Program.AddNewUserControlCMS;
            
            foreach (Control Ctrl in this.Controls)
            {
                if(Ctrl.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    Ctrl.ContextMenuStrip = Program.AddNewUserControlCMS;

                }

            }
            this.Controls.AddRange(UCFunctions.ReadFromDB(this.Name).ToArray());
        }
                
        private void AboutMeForm_Load(object sender, EventArgs e)
        {
            List<string> parametry = new List<string>();
            parametry.Add("Война и мир");
            AuthenticationUserControl abc = new AuthenticationUserControl(parametry);
            this.Controls.Add(abc);

            List<string> paramsArt = new List<string>();
            paramsArt.Add("Война и мир");
            ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
            {
                Location = new Point(300, 0)
            };
            this.Controls.Add(preview);
        }

        private void collect_Gc(object sender, FormClosedEventArgs e)
        {
            this.Controls.Clear();
            //GC.Collect();
        }
    }
}
