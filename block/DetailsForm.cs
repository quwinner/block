﻿using System;
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
    public partial class DetailsForm : Form
    {
        public DetailsForm(ArticleDetailsUserControl Details)
        {
            InitializeComponent();
            this.Controls.Add(Details);
            AboutMeForm.read(this);
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
