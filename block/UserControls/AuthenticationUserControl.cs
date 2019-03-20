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
