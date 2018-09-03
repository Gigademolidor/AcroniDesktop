using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    [Serializable]
    class Keycaps
    {
        public string ID{get;set;}
        public Color Color { get; set; }
        public object Switch { get; set; }
        public string Text { get; set; }
        public Image Icon { get; set; }
        public Font Font { get; set; }
    }
}
