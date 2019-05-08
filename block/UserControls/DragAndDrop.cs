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
            foreach (Control uc in /*Program.CONTROLY*/ ((Control)sender).FindForm().Controls)
            {
                UserControl ActualUC;

                try
                {
                    ActualUC = (UserControl)uc;
                } 
                catch (Exception)
                {
                    continue;
                }

                if (sender.Equals(ActualUC))
                {
                    string paramsAsString = "";

                    switch (ActualUC.GetType().Name)
                    {
                        case "AdsUserControl":
                            AdsUserControl NewPreview = (AdsUserControl)sender;
                            foreach (string pr in NewPreview.ParamsAds)
                            {
                                paramsAsString += pr + ",";
                            }
                            break;
                        case "ArticleDetailsUserControl":
                            ArticleDetailsUserControl NewPreview2 = (ArticleDetailsUserControl)sender;
                            foreach (string pr in NewPreview2.ListOfArticles)
                            {
                                paramsAsString += pr + ",";
                            }
                            break;
                        case "ArticlePreviewUserControl":
                            ArticlePreviewUserControl NewPreview3 = (ArticlePreviewUserControl)sender;
                            foreach (string pr in NewPreview3.asd)
                            {
                                paramsAsString += pr + ",";
                            }
                            break;
                        case "CategoriesUserControl":
                            CategoriesUserControl NewPreview4 = (CategoriesUserControl)sender;
                            foreach (string pr in NewPreview4.asd)
                            {
                                paramsAsString += pr + ",";
                            }
                            break;
                        case "UserControlAutorsList":
                            UserControlAutorsList NewPreview5 = (UserControlAutorsList)sender;
                            foreach (string pr in NewPreview5.asd)
                            {
                                paramsAsString += pr + ",";
                            }
                            break;
                        case "UserControlMainAuthor":
                            UserControlMainAuthor NewPreview6 = (UserControlMainAuthor)sender;
                            foreach (string pr in NewPreview6.par)
                            {
                                paramsAsString += pr + ",";
                            }
                            break;
                        case "UserControlSearch":
                            UserControlSearch NewPreview7 = (UserControlSearch)sender;
                            /*foreach (string pr in NewPreview7.as)
                            {
                                param7 += pr + ",";
                            }*/
                            break;
                    }

                    SQLClass.Update("UPDATE block SET" +
                        " x = " + ((UserControl) sender).Location.X.ToString() + "," +
                        " y = " + ((UserControl) sender).Location.Y.ToString() +
                    " WHERE id = '" + uc.Tag + "'");

                    if (paramsAsString.Length > 0)
                    {
                        SQLClass.Update("UPDATE block SET" +
                            " Params = '" + paramsAsString +
                            "' WHERE id = '" + uc.Tag + "'");
                    }
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
