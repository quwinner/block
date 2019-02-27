using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace block
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SQLClass.OpenConnection();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            button1_Click((Control)sender);
        }
        public static void button1_Click(Control c)
        {
            SQLClass.Delete("DELETE FROM block WHERE name = '" + c.Name + "'");
            SQLClass.Insert("INSERT INTO block(`form`, `x`, `y`, `name`) VALUES"+
              "('" + c.FindForm().Name + "','" + c.Location.X + "','" + c.Location.Y + "','" + c.Name + "')");
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<String> block = SQLClass.Select("SELECT `form`, `x`, `y`, `name` FROM `block`");
            for (int i = 0; i < block.Count; i+= 4)
           {
               if (block[i].Contains(FindForm().Name))
               {
                   int x = Convert.ToInt32(block[i + 1]);
                   int y = Convert.ToInt32(block[i + 2]);

                   if(block[i + 3].Contains("pictureBox"))
                   {
                       PictureBox pictureBox = new PictureBox();
                       pictureBox = new System.Windows.Forms.PictureBox();
                       // 
                       // pictureBox3
                       // 
                       pictureBox.Load("https://st.depositphotos.com/1617983/5167/i/450/depositphotos_51675177-stock-photo-digital-background-with-cybernetic-particles.jpg");
                       pictureBox.Location = new System.Drawing.Point(x, y);
                       pictureBox.Name = block[i + 3];
                       pictureBox.Size = new System.Drawing.Size(142, 153);
                       pictureBox.TabIndex = 2;
                       pictureBox.TabStop = false;
                       pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                       pictureBox.Click += new System.EventHandler(button1_Click);


                       this.Controls.Add(pictureBox);
                   }

                   if (block[i + 3].Contains("button"))
                   {
                       Button button = new Button();
                       button.Location = new System.Drawing.Point(x, y);
                       button.Name = block[i + 3];
                       button.Size = new System.Drawing.Size(75, 23);
                       button.TabIndex = 3;
                       button.Text = "button1";
                       button.UseVisualStyleBackColor = true;
                       button.Click += new System.EventHandler(button1_Click);

                       this.Controls.Add(button);
                   }
                   
               }
           }
            button1_Click((Control)sender);  
        }
    }
}
