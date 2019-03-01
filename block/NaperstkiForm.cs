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
        public NaperstkiForm()
        {
            InitializeComponent();
            SQLClass.OpenConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            Panel panel = new System.Windows.Forms.Panel();
            Button button = new System.Windows.Forms.Button();
            TextBox textBox1 = new TextBox();

            button.Location = new System.Drawing.Point(66, 89);
            button.Name = "button4";
            button.Size = new System.Drawing.Size(75, 23);
            button.Dock = DockStyle.Bottom;
            button.TabIndex = 0;
            button.Text = "button4";
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(button1_Click);

            textBox1.Location = new System.Drawing.Point(401, 305);
            textBox1.Name = "textBox1";
            textBox1.Dock = DockStyle.Top;
            textBox1.Size = new System.Drawing.Size(100, 20);
            textBox1.TabIndex = 0;


            panel.BackColor = System.Drawing.Color.Yellow;
            panel.Controls.Add(button);
            panel.Controls.Add(textBox1);
            panel.Location = mesto;
            panel.Name = "panel4";
            panel.Dock = sdsasd;
            panel.Size = razmer;
            panel.TabIndex = 3;

            this.Controls.Add(panel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Panel dfdfs = (Panel)button.Parent;
            foreach (Control ahggh in dfdfs.Controls)
            {
                if (ahggh.Name == "textBox1")
                {
                    MessageBox.Show(ahggh.Text);
                }
            }
        }

        public void button1_Click1(object sender, EventArgs e)
        {
            button1_Click1((Control)sender);
        }

        /// <summary>
        /// Сохранение расположения блока в БД
        /// </summary>
        /// <param name="c"></param>
        public static void button1_Click1(Control c)
        {
            SQLClass.Delete("DELETE FROM block WHERE name = '" + c.Name + "'");
            SQLClass.Insert("INSERT INTO block(`form`, `x`, `y`, `name`) VALUES" +
              "('" + c.FindForm().Name + "','" + c.Location.X + "','" + c.Location.Y + "','" + c.Name + "')");
        }

        /// <summary>
        /// Запрашиваем из базы расположение блока
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
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
                        pictureBox.Click += new System.EventHandler(button1_Click1);

                        this.Controls.Add(pictureBox);
                    }

                    if (block[i + 3].Contains("button"))
                    {
                        Button button = new Button();
                        button.Location = new Point(x, y);
                        button.Name = block[i + 3];
                        button.Size = new Size(75, 23);
                        button.Click += new System.EventHandler(button1_Click1);

                        this.Controls.Add(button);
                    }

                }
            }
            button1_Click1((Control)sender);
        }
    }
}
