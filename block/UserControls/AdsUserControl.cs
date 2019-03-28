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
        public int kol_vo = 1;

        List<string> paramsAds;
        public AdsUserControl(List<string> ParamsAds, int kolvo, int progl)
        {
            InitializeComponent();
            BlockForm.AddDeleteMenu(this);
            ArticlePreviewUserControl.AddDNDFunctions(this);

            paramsAds = ParamsAds;
            progal = kolvo;
            kol_vo = progl;
            Random r = new Random();
            for(int i = 0; i < kol_vo; i++)
            {
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Load(ParamsAds[r.Next(0, ParamsAds.Count)]);
                flowLayoutPanel1.Controls.Add(pic);
            }

            /*
            foreach (var PictureUrl in ParamsAds)
            {
                var pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Load(PictureUrl);
                flowLayoutPanel1.Controls.Add(pic);
            }
            */
        }

        /// <summary>
        /// Добавление UserControl с рекламой
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            List<string> paramsArt = new List<string>();
            paramsArt.Add("http://rustrade.org.uk/rus/wp-content/uploads/dodo-pizza.jpg");
            paramsArt.Add("https://i.simpalsmedia.com/joblist.md/360x200/f0eeb7ea787a8cc8370e29638d582f31.png");
            paramsArt.Add("https://www.sostav.ru/images/news/2018/02/21/13349a407abf5ee3d8c795fc78694299.jpg");
            paramsArt.Add("https://static.tildacdn.com/tild6533-3365-4438-a364-613965626338/cover-6.jpg");
            paramsArt.Add("https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg");
            paramsArt.Add("https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg");
            AdsUserControl a1 = new AdsUserControl(paramsArt, 1, 0);

            BlockForm.InsertBlockToDB(sender, a1);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
