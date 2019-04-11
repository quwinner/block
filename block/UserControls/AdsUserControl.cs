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
    public partial class AdsUserControl : UserControl
    {
        public int progal = 0;
        public int amount = 6;
        public DragAndDrop Drag = new DragAndDrop();
        public List<string> ParamsAds;

        public static List<string> URLs = new List<string>()
        {
            "http://rustrade.org.uk/rus/wp-content/uploads/dodo-pizza.jpg",
            "https://i.simpalsmedia.com/joblist.md/360x200/f0eeb7ea787a8cc8370e29638d582f31.png",
            "https://www.sostav.ru/images/news/2018/02/21/13349a407abf5ee3d8c795fc78694299.jpg",
            "https://static.tildacdn.com/tild6533-3365-4438-a364-613965626338/cover-6.jpg",
            "https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg",
            "https://ksonline.ru/wp-content/uploads/2017/03/DODO-2.jpg",
            "https://habrastorage.org/webt/xx/lz/vh/xxlzvhhsgwbifo9tl1lpjsuwooa.png"
        };

        public AdsUserControl(List<string> ParamsAds)
        {
            
            InitializeComponent();

            Menus.AddDeleteMenu(this);
            Drag.AddDNDFunctions(this);

            progal = ParamsAds.Count;
            amount = Math.Min(Convert.ToInt32(ParamsAds[0]), ParamsAds.Count - 1);


            this.ParamsAds = ParamsAds;

            int x = 0;
            int y = 0;
            Random rnd = new Random();
            

            for (int i = 0; i < amount; i++)
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
                        pic.Load(URLs[rnd.Next(0, Convert.ToInt32(Math.Min(
                            amount, URLs.Count
                            )))]);
                    } catch (Exception)
                    {
                        i++;
                        continue;
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
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;



            List<string> paramsArt = new List<string>();
            paramsArt.Add("5");
            //paramsArt.Add("5");
            paramsArt.AddRange(URLs);

            UCParameters p = new UCParameters("block.AdsUserControl", paramsArt);
            p.ShowDialog();

            if (p.ParamsList != new List<string>())
            {
                AdsUserControl a1 = new AdsUserControl(p.ParamsList);
                string shsvfhksv = "";
                foreach (string asd in paramsArt)
                {
                    shsvfhksv += asd + ',';
                }
                Menus.InsertBlockToDB(sender, a1, shsvfhksv);
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
