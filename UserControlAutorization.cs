using System;
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
    public partial class UserControlAutorization : UserControl
    {
        public UserControlAutorization()
        {
            InitializeComponent();
        }

        public static void button1_Click(object sender, EventArgs e)
        {
            String login = "";
            String parol = "";
            Button button = (Button)sender;
            Panel dfdfs = (Panel)button.Parent;
            foreach (Control ahggh in dfdfs.Controls)
            {
                if (ahggh.Name == "loginTextBox")
                {
                    login = "Login " + ahggh.Text;
                }
                if (ahggh.Name == "passTextBox")
                {
                    parol = " Password " + ahggh.Text;
                }
            }

            MessageBox.Show(login + parol);
        }
        public static Panel CreateAuthorizationPanel()
        {

            Panel panel = new System.Windows.Forms.Panel();

            Button button = new System.Windows.Forms.Button();
            button.Location = new System.Drawing.Point(66, 89);
            button.Name = "button4";
            button.Size = new System.Drawing.Size(75, 23);
            button.Dock = DockStyle.Bottom;
            button.TabIndex = 0;
            button.Text = "button4";
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(button1_Click);

            Label login = new Label();
            login.Location = new System.Drawing.Point(401, 305);
            login.BackColor = Color.Transparent;
            login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            login.Name = "LoginLabel";
            login.Text = "Login";
            login.Dock = DockStyle.Top;
            login.Size = new System.Drawing.Size(100, 20);
            login.TabIndex = 1;

            TextBox loginTextBox = new TextBox();
            loginTextBox.Location = new System.Drawing.Point(401, 330);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Dock = DockStyle.Top;
            loginTextBox.Size = new System.Drawing.Size(100, 20);
            loginTextBox.TabIndex = 2;

            Label password = new Label();
            password.BackColor = Color.Transparent;
            password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            password.Location = new System.Drawing.Point(401, 360);
            password.Name = "passwordLabel";
            password.Text = "Password";
            password.Dock = DockStyle.Top;
            password.Size = new System.Drawing.Size(100, 20);
            password.TabIndex = 3;


            TextBox passTextBox = new TextBox();
            passTextBox.Location = new System.Drawing.Point(401, 400);
            passTextBox.Name = "passTextBox";
            passTextBox.Dock = DockStyle.Top;
            passTextBox.Size = new System.Drawing.Size(100, 20);
            passTextBox.TabIndex = 4;


            PictureBox pb = new PictureBox();
            pb.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTDIg4TNoQGKlIqG7rvgNr0nRKb41tejx8mpGaiqkHqEHrNG12-");

            //panel.BackColor = System.Drawing.Color.Yellow;
            panel.BackgroundImage = pb.Image;
            panel.Location = new System.Drawing.Point(6, 5);
            panel.Name = "panel4";
            panel.Dock = DockStyle.Left;
            panel.Size = new System.Drawing.Size(200, 234);
            panel.TabIndex = 3;

            panel.Controls.Add(button);
            panel.Controls.Add(passTextBox);
            panel.Controls.Add(password);
            panel.Controls.Add(loginTextBox);
            panel.Controls.Add(login);

            return panel;
        }
        private void UserControlAutorization_Load(object sender, EventArgs e)
        {

            this.Controls.Add(CreateAuthorizationPanel());
        }
    }
}
