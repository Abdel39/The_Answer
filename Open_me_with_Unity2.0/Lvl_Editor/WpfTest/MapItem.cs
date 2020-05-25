using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
   
    class MapItem
    {
        private Bitmap image;
        private string blockName;

        public MapItem(Bitmap image, string blockName)
        {
            this.Image = image;
            this.BlockName = blockName;
        }

        public Bitmap Image { get => image; set => image = value; }
        public string BlockName { get => blockName; set => blockName = value; }
    }
}
