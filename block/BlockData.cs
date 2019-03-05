using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    /// <summary>
    /// Базовый класс для всех объектов
    /// </summary>
    public class ObjBase {
        public static int[] ColorToARGBArray(Color Col)
        {
            return new int[] { Col.A, Col.R, Col.G, Col.B };
        }

        public static Color ARGBArrayToColor(int[] Col)
        {
            return Color.FromArgb(Col[0], Col[1], Col[2], Col[3]);
        }

        public static int[] PointToXYArray(Point PointIn)
        {
            return new int[] { PointIn.X, PointIn.Y };
        }

        public int[] Location;
        public string Name;
    }

    public class TextBoxData : ObjBase
    {
        public string Text;
        public int[] BackColor;
        public int[] ForeColor;


        public TextBox GetActualControl()
        {
            return new TextBox()
            {
                Text = this.Text,
                BackColor = ObjBase.ARGBArrayToColor(this.BackColor),
                ForeColor = ObjBase.ARGBArrayToColor(this.ForeColor),
                Location = new Point(Location[0], Location[1]),
                Name = this.Name
            };
        }
    }

    public class PictureBoxData : ObjBase
    {
        public string URL;

        /// <summary>
        /// Тип стреча картинки
        /// </summary>
        public string SizeMode;

        public static PictureBox GetActualControl(PictureBoxData pbd)
        {
            var sizemodes = new Dictionary<string, PictureBoxSizeMode> {
                {"AutoSize", PictureBoxSizeMode.AutoSize},
                {"CenterImage", PictureBoxSizeMode.CenterImage},
                {"Normal", PictureBoxSizeMode.Normal},
                {"StretchImage", PictureBoxSizeMode.StretchImage},
                {"Zoom", PictureBoxSizeMode.Zoom}
            };
            PictureBox pb = new PictureBox();
            if (pbd.URL != null)
            {
                pb.Load(pbd.URL);
            }
            if (pbd.SizeMode != null)
            {
                pb.SizeMode = sizemodes[pbd.SizeMode];
            }
            return pb;
        }
    }

    public class BlockObj
    {
        /// <summary>
        /// Конструктор для <see cref="BlockObj"/> для упрощения создания объектов
        /// </summary>
        /// <param name="ObjectIn">
        /// Контрол который нужно превратить в <see cref="BlockObj"/>
        /// </param>
        /// <param name="URL">
        /// Если <paramref name="ObjectIn"/> является картинкой, то вы должны добавить ссылку на неё.
        /// Если <paramref name="ObjectIn"/> не картинка, url игнорируется.
        /// </param>
        /// <example>
        /// Допустим переменная test является текстбоксом с текстом "testing":
        /// <code>
        /// BlockObj Out = new BlockObj(test);
        /// </code>
        /// В результате получается JSON в виде:
        /// <code>
        /// {  
        ///    "Type": "TextBox",
        ///    "Data": {  
        ///       "Text": "testing",
        ///       "Color": [255, 255, 255, 255],
        ///       "Location": [0, 0]
        ///     }
        /// }
        /// </code>
        /// </example>
        public BlockObj(Control ObjectIn, string URL = "")
        {
            if (ObjectIn == null)
            {
                return;
            }
            if (ObjectIn.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                Type = "TextBox";
                Data = new TextBoxData()
                {
                    Text = ((TextBox) ObjectIn).Text,
                    Name = ((TextBox) ObjectIn).Name,
                    BackColor = ObjBase.ColorToARGBArray(((TextBox) ObjectIn).BackColor),
                    ForeColor = ObjBase.ColorToARGBArray(((TextBox) ObjectIn).ForeColor),
                    Location = ObjBase.PointToXYArray(((TextBox) ObjectIn).Location)
                };
            }
            else if (ObjectIn.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                Type = "PictureBox";
                Data = new PictureBoxData()
                {
                    Name = ((PictureBox)ObjectIn).Name,
                    URL = "https://dodopizza-a.akamaihd.net/static/Img/Products/Pizza/ru-RU/6682b9fc-f254-4e32-b9db-31708b8cfc33.jpg",
                    SizeMode = ((PictureBox) ObjectIn).SizeMode.ToString(),
                    Location = ObjBase.PointToXYArray(((PictureBox) ObjectIn).Location)
                };
            }
        }
        public string Type;
        public ObjBase Data;
    }

    /// <summary>
    /// Информация о блоке
    /// </summary>
    public class BlockData
    {
        public string Name;

        /// <summary>
        /// Позиция относительно формы где находится блок
        /// </summary>
        public int[] Location;

        public int[] Distance;

        /// <summary>
        /// Массив BlockObj-ов
        /// </summary>
        public List<dynamic> Objects;
    }

    class NoBlocksToLoad : Exception {

    }

    public class FormData
    {
        public string Name;

        public List<string> Blocks = null;

        private List<BlockData> _loaded_blocks = null;

        public List<BlockData> LoadedBlocks {
            get {
                if (Blocks == null) {
                    throw new NoBlocksToLoad();
                }
                if (_loaded_blocks == null) {
                    foreach (string block_name in Blocks) {
                        var res = SQLClass.Select(string.Format("SELECT json FROM block_blocks WHERE name='{0}'", block_name));
                        _loaded_blocks.Add(JsonConvert.DeserializeObject<BlockData>(res[0]));
                    }
                }
                return _loaded_blocks;
            }
        }
    }
}
