using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
   
    public partial class NaperstkiForm : Form
    {
        public bool _moving;
        public Point _startLocation;
        string saddsa = "reg&ff&386;55&200;234";

        public NaperstkiForm()
        {
            InitializeComponent();
            SQLClass.OpenConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reg(saddsa);
            reg("reg&Left&6;5&200;234");
        }

        #region Drag-n-drop для картинок

        /// <summary>
        /// Нажал мышку - начался Drag-n-drop
        /// </summary>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {            
            _moving = true;
            _startLocation = e.Location;           
        }

        /// <summary>
        /// Отпустил мышку - кончился Drag-n-drop
        /// </summary>
        public void pictureBoxPoint_MouseUp(object sender, MouseEventArgs e)
        {
            _moving = false;
        }

        /// <summary>
        /// Перемещение картинок Drag-n-drop
        /// </summary>
        public void pictureBoxPoint_MouseMove(Control sender, MouseEventArgs e)
        {
            if (_moving)
            {
                sender.Left += e.Location.X - _startLocation.X;
                sender.Top += e.Location.Y - _startLocation.Y;

                if (sender.Location.X < 0)
                {
                    sender.Location = new Point(0, sender.Location.Y);
                }
                else if (sender.Location.X > this.Size.Width - 10)
                {
                    sender.Location = new Point(this.Size.Width - 10, sender.Location.Y);
                }

                if (sender.Location.Y < 0)
                {
                    sender.Location = new Point(sender.Location.X, 0);
                }
                else if (sender.Location.Y > this.Size.Height - 10)
                {
                    sender.Location = new Point(sender.Location.X, this.Size.Height - 10);
                }
            }
        }

        /// <summary>
        /// Перемещение картинок Drag-n-drop
        /// </summary>
        private void pictureBoxPoint_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPoint_MouseMove((Control)sender, e);
        }

        #endregion

        void reg(string sasdasd)
        {
            DockStyle sdsasd = new DockStyle();
            string[] sad = sasdasd.Split('&');
            switch (sad[1])
            {
                case "Right":
                    sdsasd = DockStyle.Right;
                    break;
                case "Top":
                    sdsasd = DockStyle.Top;
                    break;
                case "Left":
                    sdsasd = DockStyle.Left;
                    break;
                case "Fill":
                    sdsasd = DockStyle.Fill;
                    break;
                case "Bottom":
                    sdsasd = DockStyle.Bottom;
                    break;
                default:
                    break;
            }

            string[] sdf = sad[2].Split(';');
            string[] sdfg = sad[3].Split(';');
            Point mesto = new Point(Convert.ToInt32(sdf[0]), Convert.ToInt32(sdf[1]));
            Size razmer = new Size(Convert.ToInt32(sdfg[0]), Convert.ToInt32(sdfg[1]));
            
            Panel panel1 = CreateAuthorizationPanel();
            this.Controls.Add(panel1);
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

        #region Работа с БД
        /// <summary>
        /// Сохранение расположения блока в БД
        /// </summary>
        public void SaveBlockData(object sender, EventArgs e)
        {
            SaveBlockData((Control)sender);
        }

        /// <summary>
        /// Сохранение расположения блока в БД
        /// </summary>
        /// <param name="c"></param>
        public static void SaveBlockData(Control c)
        {
            SQLClass.Delete("DELETE FROM block WHERE name = '" + c.Name + "'");
            SQLClass.Insert("INSERT INTO block(`form`, `x`, `y`, `name`) VALUES" +
              "('" + c.FindForm().Name + "','" + c.Location.X + "','" + c.Location.Y + "','" + c.Name + "')");
        }

        /// <summary>
        /// Запрашиваем из базы расположение блока
        /// </summary>
        private void getBlockDataFromDB(object sender, EventArgs e)
        {
            List<String> block = SQLClass.Select("SELECT `form`, `x`, `y`, `name` FROM `block`");
            for (int i = 0; i < block.Count; i += 4)
            {
                if (block[i].Contains(FindForm().Name))
                {
                    int x = Convert.ToInt32(block[i + 1]);
                    int y = Convert.ToInt32(block[i + 2]);

                    if (block[i + 3].Contains("pictureBox"))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Load("https://st.depositphotos.com/1617983/5167/i/450/depositphotos_51675177-stock-photo-digital-background-with-cybernetic-particles.jpg");
                        pictureBox.Location = new Point(x, y);
                        pictureBox.Size = new Size(142, 153);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Click += new System.EventHandler(SaveBlockData);

                        this.Controls.Add(pictureBox);
                    }

                    if (block[i + 3].Contains("button"))
                    {
                        Button button = new Button();
                        button.Location = new Point(x, y);
                        button.Name = block[i + 3];
                        button.Size = new Size(75, 23);
                        button.Click += new System.EventHandler(SaveBlockData);

                        this.Controls.Add(button);
                    }
                }
            }

            SaveBlockData((Control)sender);
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
