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
    public partial class UserControlMainAuthor : UserControl
    {
        public UserControlMainAuthor(List <string> parametries)
        {
            InitializeComponent();

            if (parametries.Count == 0)
            {
                return;
            }

            List<string> author = SQLClass.Select("SELECT UserName, `Likes`, `Dislikes`, " +
                "`Information_about_author`, `Pic` FROM `Authors` WHERE UserName = '" + parametries[0] + "'");

            label1.Text = author[0];
            label3.Text = author[1];
            label5.Text = author[2];
            label6.Text = author[3];

            PictureBox b = new PictureBox();
            b.Load(author[4]);

            pictureBox1.Image = b.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            statia();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public void statia()
        {
            List<string> stat = SQLClass.Select("SELECT Header FROM Articles1 WHERE Author = '" + label1.Text + "' LIMIT 5");
            for (int i = 0; i < stat.Count; i++)
            {
                Label labelstat = new Label();
                labelstat.Location = new Point(172, 110 + i * 20);
                labelstat.Size = new Size(150, 20);
                labelstat.Text = stat[i].ToString();
                this.Controls.Add(labelstat);
            }
        }
    }
}
