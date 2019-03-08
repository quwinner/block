using System;
using System.Windows.Forms;

namespace block
{
    public partial class AuthenticationUserControl : UserControl
    {
        public AuthenticationUserControl()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(loginTextBox.Text);
            MessageBox.Show(passwordTextBox.Text);
        }
    }
}
