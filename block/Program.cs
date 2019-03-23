﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    static class Program
    {
        /// <summary>
        /// Контекстное меню ЮзерКонтролов
        /// </summary>
        public static ContextMenuStrip UserControlCMS;
        /// <summary>
        /// Контекстное меню добавления ЮзерКонтролов
        /// </summary>
        public static ContextMenuStrip AddNewUserControlCMS;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLClass.OpenConnection();
            Application.Run(new BlockForm("form2"));
        }
    }
}
