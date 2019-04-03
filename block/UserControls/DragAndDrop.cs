using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace block
{
    public class DragAndDrop
    {
        public bool IsDragging = false;
        public Point DragCursorPosition;
        public Point DragUCPosition;

        public void FormTest_MouseDown(object sender, MouseEventArgs e)
        {
            IsDragging = true;
            DragCursorPosition = Cursor.Position;
            DragUCPosition = ((UserControl) sender).Location;
        }

        public void FormTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursorPosition));
                ((UserControl) sender).Location = Point.Add(DragUCPosition, new Size(dif));
            }
        }

        /// <summary>
        /// Когда отпускаем мышку, сохраняем координаты ЮзерКонтрола в БД
        /// </summary>
        public void FormTest_MouseUp(object sender, MouseEventArgs e)
        {
            IsDragging = false;
            foreach (UserControl uc in /*Program.CONTROLY*/ ((Control)sender).FindForm().Controls)
            {
                if (sender.Equals(uc))
                {
                    switch (uc.Name)
                    {
                        case "AdsUserControl":
                            AdsUserControl NewPreview = (AdsUserControl)sender;
                            string param = "";
                            foreach (string pr in NewPreview.ParamsAds)
                            {
                                param += pr + ",";
                            }
                            SQLClass.Update("UPDATE block SET" +
                            " Params = " + param +
                        " WHERE id = '" + uc.Tag + "'");
                            break;
                        case "ArticleDetailsUserControl":
                            ArticleDetailsUserControl NewPreview2 = (ArticleDetailsUserControl)sender;
                            string param2 = "";
                            foreach (string pr in NewPreview2.ListOfArticles)
                            {
                                param2 += pr + ",";
                            }
                            SQLClass.Update("UPDATE block SET" +
                            " Params = " + param2 +
                        " WHERE id = '" + uc.Tag + "'");
                            break;
                        case "ArticlePreviewUserControl":
                            ArticlePreviewUserControl NewPreview3 = (ArticlePreviewUserControl)sender;
                            string param3 = "";
                            foreach (string pr in NewPreview3.asd)
                            {
                                param3 += pr + ",";
                            }
                            SQLClass.Update("UPDATE block SET" +
                            " Params = " + param3 +
                        " WHERE id = '" + uc.Tag + "'");
                            break;
                        case "CategoriesUserControl":
                            CategoriesUserControl NewPreview4 = (CategoriesUserControl)sender;
                            string param4 = "";
                            foreach (string pr in NewPreview4.asd)
                            {
                                param4 += pr + ",";
                            }
                            SQLClass.Update("UPDATE block SET" +
                            " Params = " + param4 +
                        " WHERE id = '" + uc.Tag + "'");
                            break;
                        case "UserControlAutorsList":
                            UserControlAutorsList NewPreview5 = (UserControlAutorsList)sender;
                            string param5 = "";
                            foreach (string pr in NewPreview5.asd)
                            {
                                param5 += pr + ",";
                            }
                            SQLClass.Update("UPDATE block SET" +
                            " Params = " + param5 +
                        " WHERE id = '" + uc.Tag + "'");
                            break;
                        case "UserControlMainAuthor":
                            UserControlMainAuthor NewPreview6 = (UserControlMainAuthor)sender;
                            string param6 = "";
                            foreach (string pr in NewPreview6.par)
                            {
                                param6 += pr + ",";
                            }
                            SQLClass.Update("UPDATE block SET" +
                            " Params = " + param6 +
                        " WHERE id = '" + uc.Tag + "'");
                            break;
                        case "UserControlSearch":
                            UserControlMainAuthor NewPreview7 = (UserControlMainAuthor)sender;
                            string param7 = "";
                            foreach (string pr in NewPreview7.par)
                            {
                                param7 += pr + ",";
                            }
                            SQLClass.Update("UPDATE block SET" +
                            " Params = " + param7 +
                        " WHERE id = '" + uc.Tag + "'");
                            break;
                    }
                    SQLClass.Update("UPDATE block SET" +
                        " x = " + ((UserControl) sender).Location.X.ToString() + "," +
                        " y = " + ((UserControl) sender).Location.Y.ToString() +
                    " WHERE id = '" + uc.Tag + "'");
                }
            }
        }

        /// <summary>
        /// Добавление к ЮзерКонтролу контекстного меню, функций для DND и т.д.
        /// </summary>
        /// <param name="sender"></param>
        public void AddDNDFunctions(object sender)
        {
            ((UserControl) sender).MouseDown += new MouseEventHandler(FormTest_MouseDown);
            ((UserControl) sender).MouseMove += new MouseEventHandler(FormTest_MouseMove);
            ((UserControl) sender).MouseUp += new MouseEventHandler(FormTest_MouseUp);

            ((UserControl) sender).ContextMenuStrip = Program.UserControlCMS;
        }
    }
}
