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
        public int[] Location;
    }

    public class TextBoxData : ObjBase
    {
        public string Text;
        public int[] Color;
    }

    public class PictureBoxData : ObjBase
    {
        public string URL;

        /// <summary>
        /// Тип стреча картинки
        /// </summary>
        public string SizeMode;
    }

    public class BlockObj
    {
        public static int[] ColorToARGBArray(Color Col)
        {
            return new int[] { Col.A, Col.R, Col.G, Col.B };
        }

        public static int[] PointToXYArray(Point PointIn)
        {
            return new int[] { PointIn.X, PointIn.Y };
        }

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
            if (ObjectIn.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                Type = "TextBox";
                Data = new TextBoxData()
                {
                    Text = ((TextBox) ObjectIn).Text,
                    Color = ColorToARGBArray(((TextBox) ObjectIn).BackColor),
                    Location = PointToXYArray(((TextBox) ObjectIn).Location)
                };
            }
            else if (ObjectIn.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                Type = "PictureBox";
                Data = new PictureBoxData()
                {
                    URL = URL,
                    SizeMode = ((PictureBox)ObjectIn).SizeMode.ToString()
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
}
