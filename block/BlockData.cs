using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace block
{
    public class BlockObj
    {
        BlockObj(ArticlePreviewPicture ctr)
        {
            this.Type = "ArticlePreviewPicture";
            Data = ctr.Data;
        }


        public string Type;
        public string Name;
        public JObject Data;
    }
}
