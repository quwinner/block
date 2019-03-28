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
        public List<string> asd;

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
        public CategoriesUserControl(List<string> CategoriesParams)
        {
            InitializeComponent();
            asd = CategoriesParams;
            BlockForm.AddDeleteMenu(this);
            ArticlePreviewUserControl.AddDNDFunctions(this);

            if (CategoriesParams.Count == 0)
            {
                return;
            }
            //Сюда бы значение по умолчанию
            List<string> Categories = SQLClass.Select("SELECT Name FROM Categories ORDER BY Name LIMIT 0," + CategoriesParams[0]);
            
            for (int i = 0; i < Categories.Count; i++)
            {
                Label label = new Label
                {
                    Size = new Size(100, 30),
                    Location = new Point(0, i * 30 + 30),
                    Text = Categories[i].ToString()
                };
                label.Click += new EventHandler(lable_cat_Click);
                
                this.Controls.Add(label);
            }
        }

        /// <summary>
        /// Добавление UserControl с категориями
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.CategoriesUserControl",
                new Size(), new Point(), new List<string>(),
                c.Name, c.FindForm().Name);
            p.ShowDialog();
            CategoriesUserControl a1 = new CategoriesUserControl(p.qq);
            BlockForm.InsertBlockToDB(sender, a1);
        }

        public void lable_cat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).Text);
        }

        private void CategoriesUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
