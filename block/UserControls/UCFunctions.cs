using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace block
{
    /// <summary>
    /// Класс с функциями для UserControl-ов
    /// </summary>
    class UCFunctions
    {
        #region Функции по части Drag-n-drop

        public static bool dragging = false;
        public static Point dragCursorPoint;
        public static Point dragFormPoint;

        public static void FormTest_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = ((UserControl)sender).Location;
        }

        public static void FormTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                ((UserControl)sender).Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        /// <summary>
        /// Когда отпускаем мышку, сохраняем координаты ЮзерКонтрола в БД
        /// </summary>
        public static void FormTest_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            foreach (UserControl uc in Program.CONTROLY)
            {
                if (sender.Equals(uc))
                {
                    SQLClass.Update("UPDATE block SET" +
                        " x = " + ((UserControl)sender).Location.X.ToString() + "," +
                        " y = " + ((UserControl)sender).Location.Y.ToString() +
                    " WHERE name = '" + uc.Name + "'" +
                        " AND form = '" + uc.FindForm().Name + "'" +
                        " AND Parent = '" + uc.Parent.Name + "'");
                }
            }
        }

        /// <summary>
        /// Добавление к ЮзерКонтролу контекстного меню, функций для DND и т.д.
        /// </summary>
        /// <param name="sender"></param>
        public static void AddDNDFunctions(object sender)
        {
            ((UserControl)sender).MouseDown += new MouseEventHandler(FormTest_MouseDown);
            ((UserControl)sender).MouseMove += new MouseEventHandler(FormTest_MouseMove);
            ((UserControl)sender).MouseUp += new MouseEventHandler(FormTest_MouseUp);

            ((UserControl)sender).ContextMenuStrip = Program.UserControlCMS;
        }
        #endregion
        
        /// <summary>
        /// Читаем из БД список юзерКонтролов, лежащих на форме
        /// </summary>
        /// <param name="Name">Форма</param>
        public static List<UserControl> read(Control Name)
        {
            List<UserControl> control = new List<UserControl>();

            List<string> user = SQLClass.Select(
                "SELECT form, x, y, name, Params FROM block WHERE form = '" +
                Name.FindForm().Name + "'");

            for (int i = 0; i < user.Count; i += 5)
            {
                //Вычисляем координаты
                int x = Convert.ToInt32(user[i + 1]);
                int y = Convert.ToInt32(user[i + 2]);

                #region Реклама
                if (user[i + 3] == "AdsUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    paramsArt.Add("http://rustrade.org.uk/rus/wp-content/uploads/dodo-pizza.jpg");
                    paramsArt.Add("https://i.simpalsmedia.com/joblist.md/360x200/f0eeb7ea787a8cc8370e29638d582f31.png");
                    paramsArt.Add("https://www.sostav.ru/images/news/2018/02/21/13349a407abf5ee3d8c795fc78694299.jpg");
                    paramsArt.Add("https://static.tildacdn.com/tild6533-3365-4438-a364-613965626338/cover-6.jpg");
                    paramsArt.Add("https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg");
                    paramsArt.Add("https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/8e66cfee-bd1c-493d-aa25-0b23639901ec.jpg");
                    AdsUserControl preview = new AdsUserControl(paramsArt, 4, 4)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }
                #endregion
                #region Чтение статьи
                else if (user[i + 3] == "ArticleDetailsUserControl")
                {
                    string[] ss = user[i + 4].Split(',');
                    List<string> paramsArt = new List<string>();
                    paramsArt.Add(ss[0]);
                    ArticleDetailsUserControl preview = new ArticleDetailsUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }
                #endregion
                #region Предпросмотр статьи
                else if (user[i + 3] == "ArticlePreviewUserControl")
                {
                    List<string> paramsArt = new List<string>();
                    string[] ss = user[i + 4].Split(',');
                    paramsArt.Add(ss[0]);
                    ArticlePreviewUserControl preview = new ArticlePreviewUserControl(paramsArt)
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }
                #endregion
                #region Аутентификация
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
                #endregion
                #region Категории
                else if (user[i + 3] == "CategoriesUserControl")
                {
                    CategoriesUserControl preview = new CategoriesUserControl(new List<string>() { "5", "По алфавиту" })
                    {
                        Location = new Point(x, y)
                    };

                    Name.Controls.Add(preview);
                    control.Add(preview);
                }
                #endregion
                #region Список авторов
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
                #endregion
                #region Автор
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
                #endregion
                #region Поиск
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
                #endregion

                else
                {
                    MessageBox.Show(user[i + 3]);
                }
            }

            return control;
        }

    
    }
}
