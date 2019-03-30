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
    public struct Reklama
    {
        public List<string> kart;
        public int kolvo;
    }

    public partial class AdsUserControl : UserControl
    {
        public int progal = 0;
        public int kol_vo = 1;

        List<string> paramsAds;
        public AdsUserControl(List<string> ParamsAds, int kolvo, int progl)
        {
            InitializeComponent();
            BlockForm.AddDeleteMenu(this);
            UCFunctions.AddDNDFunctions(this);

            paramsAds = ParamsAds;
            progal = kolvo;
            kol_vo = progl;
            int x = 0;
            int y = 0;
            Random r = new Random();
            for (int i = 0; i < kol_vo; i++)
            {
                if (ParamsAds.Count > 0)
                {
                    PictureBox pic = new PictureBox();
                    pic.Location = new Point(x, y);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Load(ParamsAds[r.Next(0, ParamsAds.Count)]);
                    this.Controls.Add(pic);
                    y += progal + pic.Height;
                }
            }
        }

        public static Reklama readparam(String img)
        {
            String[] words = img.Split(new string[] { " = ", ",  ", "," }, StringSplitOptions.RemoveEmptyEntries);

            Reklama newRek = new Reklama();
            newRek.kart = new List<string>();

            for (int index = 0; index < words.Length; index++)
            {
                if (words[index] == "pic")
                {
                    newRek.kart.Add(words[index + 1]);
                }
                if (words[index] == "kol")
                {
                    newRek.kolvo = Convert.ToInt32(words[index + 1]);
                }
            }

            return newRek;
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
            
            AdsUserControl a1 = new AdsUserControl(paramsArt, 3, 0);
            
            BlockForm.InsertBlockToDB(sender, a1);
           
          /*  String pars = "";
            foreach (string str in paramsArt)
            {
                pars += "pic = " + str + ", ";
            }
            pars += " kol = 5";

            SQLClass.Insert("UPDATE block SET Params = '" + pars + "' WHERE name = 'AdsUserControl' AND x = " + a1.Location.X);
        */}

        private void AdsUserControl_Load(object sender, EventArgs e)
        {

        }

       
    }
}
