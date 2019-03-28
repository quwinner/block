using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    /// <summary>
    /// UserControl авторизации
    /// </summary>
    public partial class AuthenticationUserControl : UserControl
    {
        public List<string> asd;
        public AuthenticationUserControl(List<string> parametrs)
        {
            InitializeComponent();
            ArticlePreviewUserControl.AddDNDFunctions(this);
            BlockForm.AddDeleteMenu(this);
        }

        /// <summary>
        /// Добавление UserControl с аутентификацией
        /// </summary>
        public static void AddNewBlock(object sender, EventArgs e)
        {
            Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            UCParameters p = new UCParameters("block.AuthenticationUserControl",
                new Size(), new Point(), new List<string>(),
                c.Name, c.FindForm().Name
            );
            p.ShowDialog();
            AuthenticationUserControl a1 = new AuthenticationUserControl(p.qq);
            a1.Location = p.locetion_userconrla;

            BlockForm.InsertBlockToDB(sender, a1);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(loginTextBox.Text);
            MessageBox.Show(passwordTextBox.Text);
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void AuthenticationUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
