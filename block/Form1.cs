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
   
    public partial class Form1 : Form
    {
        public bool _moving;
        public Point _startLocation;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            _moving = true;
            _startLocation = e.Location;
           
        }

        public void pictureBoxPoint_MouseUp(object sender, MouseEventArgs e)
        {
            _moving = false;
        }

        public void pictureBoxPoint_MouseMove(Control sender, MouseEventArgs e)
        {
           
            if (_moving)
            {
                //PictureBox sender = (PictureBox)sender;
                int r = 25;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxPoint_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxPoint_MouseMove((Control)sender, e);

        }
    }
}
