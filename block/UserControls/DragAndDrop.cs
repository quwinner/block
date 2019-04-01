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
            foreach (UserControl uc in Program.CONTROLY)
            {
                if (sender.Equals(uc))
                {
                    SQLClass.Update("UPDATE block SET" +
                        " x = " + ((UserControl) sender).Location.X.ToString() + "," +
                        " y = " + ((UserControl) sender).Location.Y.ToString() +
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
        public void AddDNDFunctions(object sender)
        {
            ((UserControl) sender).MouseDown += new MouseEventHandler(FormTest_MouseDown);
            ((UserControl) sender).MouseMove += new MouseEventHandler(FormTest_MouseMove);
            ((UserControl) sender).MouseUp += new MouseEventHandler(FormTest_MouseUp);

            ((UserControl) sender).ContextMenuStrip = Program.UserControlCMS;
        }
    }
}
