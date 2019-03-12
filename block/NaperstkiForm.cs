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
            
            AuthenticationUserControl panel1 = new AuthenticationUserControl();
            this.Controls.Add(panel1);
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
