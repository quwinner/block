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
        public Form1()
        {
            InitializeComponent();
        }
        string saddsa = "reg&ff&386;55&200;234";
        private void Form1_Load(object sender, EventArgs e)
        {
            //reg(saddsa);
            //reg("reg&Left&6;5&200;234");
        }


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
                    if(ahggh.Name == "textBox1")
                    {
                        MessageBox.Show(ahggh.Text);
                    }
                }
            }

            private void button1_Click_1(object sender, EventArgs e)
            {
                reg("reg&Top&100;55&200;200");
            }
        }
    }

