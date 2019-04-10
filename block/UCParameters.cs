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
    public partial class UCParameters : Form
    {
        public const int LabelOffest = 30;

        public String UCName = "";
        public Size UCSize = new Size(0, 0);
        public Point UCLocation = new Point(0, 0);
        

        #region Параметры

        public int Amount;
        public int DistanceBetween;
        public string Header;
        public string SerachQuery;
        public string UserName;
        public string SortOrder;

        public List<string> ParamsList = new List<string>();

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UCName"></param>
        /// <param name="UCSize"></param>
        /// <param name="UCLocation"></param>
        /// <param name="par"></param>
        public UCParameters(string Name1, List<String> par)
        {
            InitializeComponent();
            UCName = Name1;
            ParamsList = par;
        }

        private void parametri_Load(object sender, EventArgs e)
        {
            switch (UCName)
            {
                case "block.AdsUserControl":
                    Amount = Convert.ToInt32(ParamsList[0]);
                    DistanceBetween = Convert.ToInt32(ParamsList[1]);
                    break;
                case "block.ArticleDetailsUserControl":
                    Header = ParamsList[0];
                    Header = ParamsList[0];
                    break;
                case "block.ArticlePreviewUserControl":
                    SerachQuery = ParamsList[0];
                    Amount = Convert.ToInt32(ParamsList[1]);
                    break;
                case "block.CategoriesUserControl":
                    Amount = Convert.ToInt32(ParamsList[0]);
                    SortOrder = ParamsList[1];
                    break;
                case "block.UserControlAutorsList":
                    if (ParamsList.Count < 3)
                    {
                        break;
                    }
                    Amount = Convert.ToInt32(ParamsList[0]);
                    SortOrder = ParamsList[1];
                    DistanceBetween = Convert.ToInt32(ParamsList[2]);
                    break;
                case "block.UserControlMainAuthor":
                    UserName = ParamsList[0];
                    break;
                case "block.UserControlSearch":
                    SerachQuery = ParamsList[0];
                    break;
                case "block.AuthenticationUserControl":
                    

                    break;
                default:
                    throw new Exception("Неправильный UCName " + UCName);
            }


            List<string> ParamsStr = SQLClass.Select("SELECT params FROM block_blocks WHERE name ='" + UCName + "'");
            if (ParamsStr.Count == 0)
            {
                throw new Exception("Нету парамов");
            }

            int Y = 50;
            List<string> ParamsListFromDB = ParamsStr[0].Split(new char[] { ',' }).ToList();

            foreach (string ParamName in ParamsListFromDB)
            {
                Label ParamLabel = new Label
                {
                    Location = new Point(12, Y),
                    Name = "label1",
                    Size = new Size(150, 30),
                    TabIndex = 0,
                    Text = ParamName
                };

                TextBox ParamInput = new TextBox
                {
                    Location = new Point(20 + ParamLabel.Size.Width, Y),
                    Name = ParamName
                };

                switch (ParamName.Trim())
                {
                    case "Высота":
                        ParamInput.Text = Math.Max(this.UCSize.Height, 80).ToString();
                        break;
                    case "Ширина":
                        ParamInput.Text = Math.Max(this.UCSize.Width, 120).ToString();
                        break;
                    case "X":
                        ParamInput.Text = this.UCLocation.X.ToString();
                        break;
                    case "Y":
                        ParamInput.Text = this.UCLocation.Y.ToString();
                        break;
                    case "Количество":
                        ParamInput.Text = Amount.ToString();
                        break;
                    case "Прогал":
                        ParamInput.Text = DistanceBetween.ToString();
                        break;
                    case "заголовок":
                        ParamInput.Text = Header;
                        break;
                    case "Поисковый запрос":
                        ParamInput.Text = SerachQuery;
                        break;
                    case "Логин":
                        ParamInput.Text = UserName;
                        break;
                    case "Порядок сортировки":
                        ParamInput.Text = SortOrder;
                        break;
                }
                ParamInput.Size = new Size(144, 20);
                ParamInput.TabIndex = 1;

                Y += LabelOffest;
                this.Controls.Add(ParamLabel);
                this.Controls.Add(ParamInput);
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            ParamsList.Clear();
            foreach (Control contr in this.Controls)
            {
                if (contr.GetType().Name == "TextBox")
                {
                    ParamsList.Add(contr.Text);
                }
            }
           

            foreach (Control contr in this.Controls)
            {
                switch (contr.Name)
                {
                    case "Высота":
                        UCSize.Height = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Ширина":
                        UCSize.Width = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "X":
                        UCLocation.X = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Y":
                        UCLocation.Y = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Количество":
                        Amount = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "Прогал":
                        DistanceBetween = Math.Abs(Convert.ToInt32(contr.Text));
                        break;
                    case "заголовок":
                        Header = contr.Text;
                        break;
                    case "Поисковый запрос":
                        SerachQuery = contr.Text;
                        break;
                    case "Логин":
                        UserName = contr.Text;
                        break;
                    case "Порядок сортировки":
                        SortOrder = contr.Text;
                        break;
                }
            }
            
            this.Close();
        }

        private void UCParameters_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveButtonClick(sender, null);
        }
    }
}
   
