using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace block
{
    static class Program
    {
        /// <summary>
        /// Контекстное меню ЮзерКонтролов
        /// </summary>
        public static ContextMenuStrip UserControlCMS;

        public static bool ShowColor = true;
        /// <summary>
        /// Контекстное меню добавления ЮзерКонтролов
        /// </summary>
        public static ContextMenuStrip AddNewUserControlCMS;


        public static List<UserControl> CONTROLY = new List<UserControl>();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLClass.OpenConnection();
            Application.Run(new BlockForm());
        }
    }
}
