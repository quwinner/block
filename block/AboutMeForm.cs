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
    public partial class AboutMeForm : Form
    {

        public AboutMeForm()
        {
            InitializeComponent();
            this.ContextMenuStrip = Program.AddNewUserControlCMS;
            Program.CONTROLY = AboutMeForm.read(this);
        }

        /// <summary>
        /// Читаем из БД список юзерКонтролов, лежащих на форме
        /// </summary>
        /// <param name="Name">Форма</param>
        public static List<UserControl> read(Control Name)
        {
            List<UserControl> control = new List<UserControl>();

            List<string> user = SQLClass.Select(
                "SELECT form, x, y, name FROM block WHERE form = '" + 
                Name.FindForm().Name + "'");

            for (int i = 0; i < user.Count; i += 4)
            {
                int x = Convert.ToInt32(user[i + 1]);
                int y = Convert.ToInt32(user[i + 2]);

                if (user[i + 3] == "ArticlePreviewUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    paramsArt.Add("Война и мир");
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else if (user[i + 3] == "ArticleDetailsUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    paramsArt.Add("Война и мир");
                    ArticleDetailsUserControl preview = new ArticleDetailsUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else if (user[i + 3] == "AuthenticationUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    AuthenticationUserControl preview = new AuthenticationUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else if (user[i + 3] == "UserControlAutorsList")
                {
                    List<string> paramsArt = new List<string>();
                    UserControlAutorsList preview = new UserControlAutorsList(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else if (user[i + 3] == "CategoriesUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    CategoriesUserControl preview = new CategoriesUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else if (user[i + 3] == "UserControlSearch")
                {
                    List<string> paramsArt = new List<string>();
                    UserControlSearch preview = new UserControlSearch(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else if (user[i + 3] == "AdsUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    AdsUserControl preview = new AdsUserControl(paramsArt, 4, 4)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else if (user[i + 3] == "UserControlMainAuthor")
                {
                    List<string> paramsArt = new List<string>();
                    paramsArt.Add("Жуков");
                    UserControlMainAuthor preview = new UserControlMainAuthor(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }

                else
                {
                    MessageBox.Show(user[i + 3]);
                }
            }

            return control;
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
            GC.Collect();
        }
    }
}
