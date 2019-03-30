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
            UCFunctions.AddDNDFunctions(this);

            paramsAds = ParamsAds;
            progal = kolvo;
            kol_vo = progl;
            Random r = new Random();
            for(int i = 0; i < kol_vo; i++)
            {
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Load(ParamsAds[r.Next(0, ParamsAds.Count)]);
                this.Controls.Add(pic);
            }
        }

        /// <summary>
        /// Добавление UserControl с рекламой
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.AdsUserControl",
                new Size(), new Point(), new List<string>() { "0", "0" },
                c.Name, c.FindForm().Name);
            p.ShowDialog();
            if (p.ParamsList != new List<string>())
            {
                AdsUserControl a1 = new AdsUserControl(p.ParamsList, p.Amount, p.DistanceBetween);
                BlockForm.InsertBlockToDB(sender, a1);
            }
        }
    }
}
