﻿using System;
using System.Windows.Forms;

namespace block
{
    /// <summary>
    /// UserControl авторизации
    /// </summary>
    public partial class AuthenticationUserControl : UserControl
    {
        public AuthenticationUserControl()
        {
            InitializeComponent();

            BlockForm.deletemenu(this);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(loginTextBox.Text);
            MessageBox.Show(passwordTextBox.Text);
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }
    }
}