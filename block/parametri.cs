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
    public partial class parametri : Form
    {
        public int visota = 50;
        public static int sdf;
        
        public parametri(String typ)
        {
            InitializeComponent();

            int Y = 50;
            List<string> Params = SQLClass.Select("SELECT params FROM block_blocks WHERE name ='" + typ + "'");
            string[] paramsArray = Params[0].Split(new char[] { ',' });

            foreach (string parametr in paramsArray)
            {
                Label label1 = new Label();
                TextBox textBox1 = new TextBox();

                label1.Location = new System.Drawing.Point(12, Y);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(150, 30);
                label1.TabIndex = 0;
                label1.Text = parametr;
                
 
                textBox1.Location = new System.Drawing.Point(20 + label1.Size.Width, Y);
                textBox1.Name = parametr;
                textBox1.Size = new System.Drawing.Size(144, 20);
                textBox1.TabIndex = 1;

                Y += 30;
                this.Controls.Add(label1);
                this.Controls.Add(textBox1);
            }
        }

        private void parametri_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control contr in this.Controls)
            {
                switch (contr.Name)
                {
                    case "Высота":
                        visota = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                }
            }
            this.Close();
        }
    }
}
   
