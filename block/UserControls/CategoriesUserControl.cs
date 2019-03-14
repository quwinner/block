using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MySql.Data;
using MySql.Data.MySqlClient;

namespace block
{
    public partial class CategoriesUserControl : UserControl
    {
        /// <summary>
        /// Конструктор который заполняет <see cref="tableLayoutPanel1"/> 
        /// </summary>
        /// <param name="Categories">
        /// Список категорий для отображения на <see cref="tableLayoutPanel1"/>,
        /// Если равен null или не указан, берутся все категории из базы
        /// </param>
        /// <param name="AmountOfCategories">
        /// Лимит на количество категорий для загрузки из базы. 
        /// </param>
        public CategoriesUserControl(List<string> Categories = null, int AmountOfCategories = 50)
        {
            InitializeComponent();
            if (Categories == null)
            {
                Categories = SQLClass.Select(string.Format("SELECT Name FROM Categories ORDER BY Name LIMIT {0}", AmountOfCategories));
            }
            tableLayoutPanel1.RowCount = Categories.Count;
            for (int i = 0; i < Categories.Count; i++)
            {
                Label label = new Label
                {
                    Size = new Size(100, 30),
                    Text = Categories[i].ToString()
                };
                label.Click += new EventHandler(lable_cat_Click);
                
                tableLayoutPanel1.SetRow(label, i);
            }
        }

        public void lable_cat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).Text);
        }
    }
}
