using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace block
{
    public class Menus
    {
        public static void InitAddUserControls(ref ContextMenuStrip menu)
        {
            //Список типов UserControl-ов
            List<Type> forms = new List<Type>();
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                forms.AddRange(from t in asm.GetTypes() where t.IsSubclassOf(typeof(UserControl)) select t);
            }

            int i = 0;
            foreach (Type f in forms)
            {
                menu.Items.Add(f.Name);
                if (f.Name == "AdsUserControl")
                {
                    menu.Items[i].Click += AdsUserControl.AddNewBlock;
                }
                else if (f.Name == "ArticleDetailsUserControl")
                {
                    menu.Items[i].Click += ArticleDetailsUserControl.AddNewBlock;
                }
                else if (f.Name == "ArticlePreviewUserControl")
                {
                    menu.Items[i].Click += ArticlePreviewUserControl.AddNewBlock;
                }
                else if (f.Name == "AuthenticationUserControl")
                {
                    menu.Items[i].Click += AuthenticationUserControl.AddNewBlock;
                }
                else if (f.Name == "CategoriesUserControl")
                {
                    menu.Items[i].Click += CategoriesUserControl.AddNewBlock;
                }
                else if (f.Name == "UserControlAutorsList")
                {
                    menu.Items[i].Click += UserControlAutorsList.AddNewBlock;
                }
                else if (f.Name == "UserControlMainAuthor")
                {
                    menu.Items[i].Click += UserControlMainAuthor.AddNewBlock;
                }
                else if (f.Name == "UserControlSearch")
                {
                    menu.Items[i].Click += UserControlSearch.AddNewBlock;
                }
                i++;
            }
        }


        /// <summary>
        /// Функция указания текущих параметров перед показом формы UCParameters.
        /// </summary>
        public static void SetUCParametersToCurrent(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            List<string> dnonil = new List<string>();

            switch (pb.Name)
            {
                case "AdsUserControl":
                    AdsUserControl pb1 = (AdsUserControl)pb;
                    dnonil.Add(pb1.amount.ToString());
                    dnonil.Add(pb1.ParamsAds.Count.ToString());
                    break;
                case "ArticleDetailsUserControl":
                    ArticleDetailsUserControl pb2 = (ArticleDetailsUserControl)pb;
                    dnonil.Add(pb2.ListOfArticles[0]);
                    break;
                case "ArticlePreviewUserControl":
                    ArticlePreviewUserControl pb3 = (ArticlePreviewUserControl)pb;
                    dnonil.Add(pb3.Article);
                    dnonil.Add("5");
                    break;
                case "CategoriesUserControl":
                    CategoriesUserControl pb4 = (CategoriesUserControl)pb;
                    dnonil.Add("1");
                    dnonil.Add(pb4.asd[0]);
                    break;
                case "UserControlAutorsList":
                    UserControlAutorsList pb5 = (UserControlAutorsList)pb;
                    dnonil.Add("1");
                    dnonil.Add(" ");
                    break;
                case "UserControlMainAuthor":
                    UserControlMainAuthor pb6 = (UserControlMainAuthor)pb;
                    dnonil.Add(pb6.par[0]);
                    break;
                case "UserControlSearch":
                    UserControlSearch pb7 = (UserControlSearch)pb;
                    dnonil.Add(" ");
                    break;

            }

            UCParameters p = new UCParameters(pb.GetType().ToString());
            p.ShowDialog();
            p.Size = p.UCSize;
            pb.Location = p.UCLocation;
            if (pb.Name == "ArticlePreviewUserControl")
            {
                ArticlePreviewUserControl pb2 = (ArticlePreviewUserControl)pb;


                pb2.Article = p.ParamsList[0];
                pb2.linkLabel1.Text = pb2.Article;
                List<string> kart = SQLClass.Select("SELECT `Picture` FROM `Articles1` WHERE `Header` = '" + pb2.Article + "'");
                pb2.pictureBox1.Load(kart[0]);

                List<string> likes = SQLClass.Select("SELECT `LikesCount`, `DisCount` FROM `Likes` WHERE `Article` = '" + pb2.Article + "'");
                pb2.LikeCount.Text = likes[0];
                pb2.DisLikeCount.Text = likes[1];
                pb2.like = Convert.ToInt32(likes[0]);
                pb2.dislike = Convert.ToInt32(likes[1]);

            }
            else if (pb.Name == "ArticleDetailsUserControl")
            {
                ArticleDetailsUserControl pb2 = (ArticleDetailsUserControl)pb;
                pb2.ListOfArticles = p.ParamsList;
                pb2.ArticleLabel.Text = p.ParamsList[0];
                List<string> kart = SQLClass.Select("SELECT Picture, Text, Author  FROM Articles1 WHERE Header = '" + pb2.ArticleLabel.Text + "'");
                pb2.ArticlePicture.Load(kart[0]);
                pb2.ArticleTextLabel.Text = kart[1];
                pb2.AuthorsNameLabel.Text = kart[2];
            }
        }


        public static void AddDeleteMenu(object sender)
        {
            ((UserControl)sender).ContextMenuStrip = BlockForm.DeleteMenuStrip;
        }

        /// <summary>
        /// Функция сохранения юзерконтрола на форму и базу.
        /// </summary>
        public static void SaveUserControl(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            string FormName = pb.FindForm().Name;
            MessageBox.Show(pb.Location.X.ToString());
            SQLClass.Insert("INSERT INTO `block`(`form`,`Parent`, `x`, `y`, `name`) VALUES ('" + FormName + "','" + pb.Parent.Name + "'," + pb.Location.X + ", " + pb.Location.Y + ",'" + pb.Name + "')");
        }


        /// <summary>
        /// Добавление информации о блоке в БД
        /// </summary>
        public static void InsertBlockToDB(object sender, UserControl a1, string par)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            c.Controls.Add(a1);
            Program.CONTROLY.Add(a1);
            SQLClass.Insert("INSERT INTO block(form,Parent,x,y,name,Params) VALUES ('" +
                c.FindForm().Name + "', '" + c.Name + "', '" + a1.Location.X + "','" + a1.Location.Y + "','" + a1.Name + "','" + par + "')");

            List<String> str = SQLClass.Select("SELECT MAX(id) FROM block");
            a1.Tag = str[0];
        }

        /// <summary>
        /// Функция удаления юзерконтрола из формы и базы.
        /// </summary>
        public static void DeleteUserControl(object sender, EventArgs e)
        {
            UserControl pb = (UserControl)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            pb.Visible = false;
            SQLClass.Delete("DELETE FROM `block` WHERE `name` = '" + pb.Name + "' AND form = '" + pb.FindForm().Name + "'");
        }
    }
}
