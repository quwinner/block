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
    public partial class MyPromotionsForm : Form
    {
        public MyPromotionsForm()
        {
            InitializeComponent();
            this.ContextMenuStrip = Program.AddNewUserControlCMS;
            this.Controls.AddRange(UCFunctions.ReadFromDB(this.Name).ToArray());

        }

        private void MyPromotionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
