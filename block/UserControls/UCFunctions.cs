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
        /// <summary>
        /// Функция со стака которая делит одномерный массив в массивы 
        /// размером <paramref name="chunk_size"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        private static List<List<T>> Split<T>(List<T> source, int chunk_size)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunk_size)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        /// <summary>
        /// Переписанная функция чтения из базы.
        /// </summary>
        /// <param name="FormName">Имя нужной формы</param>
        /// <returns>Лист контролов</returns>
        public static List<UserControl> ReadFromDB(string FormName)
        {
            List<string> ListDB = SQLClass.Select(
                "SELECT form, x, y, name, Params, id FROM block WHERE form = '" + FormName + "'");

            List<UserControl> ListOfControls = new List<UserControl>();

            foreach (List<string> Row in Split(ListDB, 6))
            {
                // Вспомогательные переменные для того чтобы не писать Row[...]
                string form = Row[0] ?? throw new NullReferenceException("form = null");
                int x = Convert.ToInt32(Row[1]);
                int y = Convert.ToInt32(Row[2]);
                string name = Row[3] ?? throw new NullReferenceException("name = null");
                List<string> Params = Row[4].Split(',').ToList() ?? throw new NullReferenceException("Params = null");
                string id = Row[5];

                switch (name)
                {
                    case "AdsUserControl":
                        AdsUserControl NewAds = new AdsUserControl(Params)
                        {
                            Location = new Point(x, y),
                            Tag = id
                        };
                        ListOfControls.Add(NewAds);
                        break;
                    case "ArticlePreviewUserControl":
                        ArticlePreviewUserControl NewPreview = new ArticlePreviewUserControl(Params)
                        {
                            Location = new Point(x, y),
                            Tag = id
                        };
                        ListOfControls.Add(NewPreview);
                        break;
                    case "AuthenticationUserControl":
                        AuthenticationUserControl NewAuth = new AuthenticationUserControl(Params)
                        {
                            Location = new Point(x, y),
                            Tag = id
                        };
                        ListOfControls.Add(NewAuth);
                        break;
                    case "CategoriesUserControl":
                        CategoriesUserControl NewCateg = new CategoriesUserControl(Params)
                        {
                            Location = new Point(x, y),
                            Tag = id
                        };
                        ListOfControls.Add(NewCateg);
                        break;
                    case "UserControlAutorsList":
                        UserControlAutorsList NewAuthorList = new UserControlAutorsList(Params)
                        {
                            Location = new Point(x, y),
                            Tag = id
                        };
                        ListOfControls.Add(NewAuthorList);
                        break;
                    case "UserControlMainAuthor":
                        UserControlMainAuthor NewMainAuthor = new UserControlMainAuthor(Params)
                        {
                            Location = new Point(x, y),
                            Tag = id
                        };
                        ListOfControls.Add(NewMainAuthor);
                        break;
                    case "UserControlSearch":
                        CategoriesUserControl NewSearch = new CategoriesUserControl(Params)
                        {
                            Location = new Point(x, y),
                            Tag = id
                        };
                        ListOfControls.Add(NewSearch);
                        break;
                    default:
                        throw new Exception(string.Format("'{0}' это неправильное название блока", name));
                }
            }

            return ListOfControls;
        }
    }
}
