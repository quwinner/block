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
    public partial class AdsUserControl : UserControl
    {
        public int progal = 0;
        public DragAndDrop Drag = new DragAndDrop();
        public List<string> ParamsAds;

        public AdsUserControl(List<string> ParamsAds)
        {
            InitializeComponent();

            BlockForm.AddDeleteMenu(this);
            Drag.AddDNDFunctions(this);

            progal = ParamsAds.Count;

            this.ParamsAds = ParamsAds;

            int x = 0;
            int y = 0;
            Random rnd = new Random();

            for (int i = 0; i < this.ParamsAds.Count(); i++)
            {
                if (ParamsAds.Count > 0)
                {
                    PictureBox pic = new PictureBox
                    {
                        Location = new Point(x, y),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    try
                    {
                        pic.Load(ParamsAds[rnd.Next(0, ParamsAds.Count)]);                        
                    } catch (InvalidOperationException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    this.Controls.Add(pic);
                    y += progal + pic.Height;
                }
            }
        }

        /// <summary>
        /// Добавление UserControl с рекламой
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            List<string> paramsArt = new List<string>
            {
                "http://rustrade.org.uk/rus/wp-content/uploads/dodo-pizza.jpg",
                "https://i.simpalsmedia.com/joblist.md/360x200/f0eeb7ea787a8cc8370e29638d582f31.png",
                "https://www.sostav.ru/images/news/2018/02/21/13349a407abf5ee3d8c795fc78694299.jpg",
                "https://static.tildacdn.com/tild6533-3365-4438-a364-613965626338/cover-6.jpg",
                "https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg",
                "https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg"
            };

            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.AdsUserControl",
                new Size(), new Point(), new List<string>() { "0", "0" });
            p.ShowDialog();
            if (p.ParamsList != new List<string>())
            {
                AdsUserControl a1 = new AdsUserControl(paramsArt);
                string shsvfhksv = "";
                foreach (string asd in paramsArt)
                {
                    shsvfhksv += asd + ',';
                }
                BlockForm.InsertBlockToDB(sender, a1, shsvfhksv);
            }
        }

        private void AdsUserControl_Load(object sender, EventArgs e)
        {
            //BlockForm.InsertBlockToDB(sender, a1);
           
          /*  String pars = "";
            foreach (string str in paramsArt)
            {
                pars += "pic = " + str + ", ";
            }
            pars += " kol = 5";

            SQLClass.Insert("UPDATE block SET Params = '" + pars + "' WHERE name = 'AdsUserControl' AND x = " + a1.Location.X);
        */
        }       
    }
}
