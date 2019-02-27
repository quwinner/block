using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace block
{
    /// <summary>
    /// Базовый класс для всех объектов
    /// </summary>
    class ObjBase {
        public List<int> pos;
    }

    class StringData : ObjBase
    {
        public string text;
        public string color;
    }

    class PictureBoxData : ObjBase
    {
        public string url;

        /// <summary>
        /// Тип стреча картинки
        /// </summary>
        public string stretch;
    }

    public class BlockObj
    {
        BlockObj(object asd)
        {
            if (asd.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                type = "textbox",
                data = new 
            }
        }
        public string type;
        public ObjBase data;
    }

    /// <summary>
    /// Информация о блоке
    /// </summary>
    public class BlockData
    {
        public string name;

        /// <summary>
        /// Позиция относительно формы где находится блок
        /// </summary>
        public List<int> pos;

        public int distance_x;
        public int distance_y;

        /// <summary>
        /// Массив BlockObj-ов
        /// </summary>
        public List<BlockObj> objects;
    }
}
