using System;
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
    public partial class UCParameters : Form
    {
        public string parent;
        public string form_name;

        public Size size_Userconrla;
        public Point locetion_userconrla;
        ///////////////////////////////////////////////////////////////

        public int koli_vo;
        public int progal;
        public string zagal;
        public string sersh_zapros;
        public string login;
        public string poridok_sortir;
        /// <summary>
        /// //////////////////////////////////////////////////
        /// </summary>
        public static int sdf;
        public List<string> qq = new List<string>();

        public UCParameters(String typ, Size qw, Point qwq, List<string> par, string ww, string wwqq)
        {
            InitializeComponent();
            parent = ww;
            form_name = wwqq;
            size_Userconrla = qw;
            locetion_userconrla = qwq;
            switch (typ)
            {
                case "block.AdsUserControl":
                    koli_vo = Convert.ToInt32(par[0]);
                    progal = Convert.ToInt32(par[1]);
                    break;
                case "block.ArticleDetailsUserControl":
                    zagal = par[0];
                    break;
                case "block.ArticlePreviewUserControl":
                    sersh_zapros = par[0];
                    koli_vo = Convert.ToInt32(par[1]);
                    break;
                case "block.CategoriesUserControl":
                    koli_vo = Convert.ToInt32(par[0]);
                    poridok_sortir = par[1];
                    break;
                case "block.UserControlAutorsList":
                    koli_vo = Convert.ToInt32(par[0]);
                    poridok_sortir = par[1];
                    progal = Convert.ToInt32(par[2]);
                    break;
                case "block.UserControlMainAuthor":
                    login = par[0];
                    break;
                case "block.UserControlSearch":
                    sersh_zapros = par[0];
                    break;
                    
            }

            List<string> Params = SQLClass.Select("SELECT params FROM block_blocks WHERE name ='" + typ + "'");
            if (Params.Count == 0)
            {
                return;
            }

            int Y = 50;
            string[] paramsArray = Params[0].Split(new char[] { ',' });

            foreach (string parametr in paramsArray)
            {
                Label label1 = new Label();
                TextBox textBox1 = new TextBox();

                label1.Location = new System.Drawing.Point(12, Y);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(150, 30);
                label1.TabIndex = 0;
                label1.Text = parametr;
                
 
                textBox1.Location = new System.Drawing.Point(20 + label1.Size.Width, Y);
                textBox1.Name = parametr;
                switch (parametr)
                {
                    case "Высота":
                        textBox1.Text = size_Userconrla.Height.ToString();
                        break;
                    case "Ширина":
                        textBox1.Text = size_Userconrla.Width.ToString();
                        break;
                    case "X":
                        textBox1.Text = locetion_userconrla.X.ToString();
                        break;
                    case "Y":
                        textBox1.Text = locetion_userconrla.Y.ToString();
                        break;
                    case "Количество":
                        textBox1.Text = koli_vo.ToString();
                        break;
                    case "Прогал":
                        textBox1.Text = progal.ToString();
                        break;
                    case "заголовок":
                        textBox1.Text = zagal;
                        break;
                    case "Поисковый запрос":
                        textBox1.Text = sersh_zapros;
                        break;
                    case "Логин":
                        textBox1.Text = login;
                        break;
                    case "Порядок сортировки":
                        textBox1.Text = poridok_sortir;
                        break;
                }
                textBox1.Size = new System.Drawing.Size(144, 20);
                textBox1.TabIndex = 1;

                Y += 30;
                this.Controls.Add(label1);
                this.Controls.Add(textBox1);
            }
        }

        void parametriSave()
        {
            List<string> toSave = new List<string>{
                koli_vo.ToString(),
                progal.ToString(),
                zagal,
                sersh_zapros,
                login,
                poridok_sortir
            };
            SQLClass.Insert("INSERT INTO `block`(`form`, `Parent`, `x`, `y`, `name`, `Params`) VALUES ('" + form_name + "','" + parent + "', 0, 1, 'хз','" + toSave.ToString() + "')");
        }

        private void parametri_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach (Control contr in this.Controls)
            {
                if (contr.GetType().Name == "TextBox")
                {
                    qq.Add(contr.Text);
                }
            }


            foreach (Control contr in this.Controls)
            {
                switch (contr.Name)
                {
                    case "Высота":
                        size_Userconrla.Height = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Ширина":
                        size_Userconrla.Width = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "X":
                        locetion_userconrla.X = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Y":
                        locetion_userconrla.Y = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Количество":
                        koli_vo = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Прогал":
                        progal = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "заголовок":
                        zagal = contr.Text;
                        break;
                    case "Поисковый запрос":
                        sersh_zapros = contr.Text;
                        break;
                    case "Логин":
                        login = contr.Text;
                        break;
                    case "Порядок сортировки":
                        poridok_sortir = contr.Text;
                        break;

                }
            }
            this.Close();
        }
    }
}
   
