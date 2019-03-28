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
    }
}
