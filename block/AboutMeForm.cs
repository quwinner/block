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
        public static  List<UserControl> control;
        public AboutMeForm()
        {
            InitializeComponent();
            this.ContextMenuStrip = Program.AddNewUserControlCMS;
        }

        private void AboutMeForm_Load(object sender, EventArgs e)
        {
           /* List<string> parametry = new List<string>();
            parametry.Add("Война и мир");
            AuthenticationUserControl abc = new AuthenticationUserControl(parametry);
            this.Controls.Add(abc);

            List<string> paramsArt = new List<string>();
            paramsArt.Add("Война и мир");
            ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
            {
                Location = new Point(300, 0)
            };
            this.Controls.Add(preview);*/
            read(this);
        }

        public static void read(Control Name)
        {
            List <string> user = SQLClass.Select("SELECT form, x, y, name FROM block WHERE form = '"+ Name.FindForm().Name +"'");
            
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
                }

                if (user[i + 3] == "ArticleDetailsUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    paramsArt.Add("Война и мир");
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                }

                if (user[i + 3] == "AuthenticationUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                }

                if (user[i + 3] == "UserControlAutorsList")
                {
                    List<string> paramsArt = new List<string>();
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                }

                if (user[i + 3] == "CatUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                }

                if (user[i + 3] == "UserControlSearch")
                {
                    List<string> paramsArt = new List<string>();
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                }

                if (user[i + 3] == "AdsUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                }

                if (user[i + 3] == "UserControlMainAuthor")
                {
                    List<string> paramsArt = new List<string>();
                    paramsArt.Add("Жуков");
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                }
                
            }
        }
    }
}
