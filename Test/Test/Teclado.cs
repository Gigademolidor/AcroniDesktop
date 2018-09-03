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
    class Teclado

    {
        public Teclado()
        {
        }
        public object BackgroundModeSize { get; set; }
        public List<Keycaps> Keycaps { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Material { get; set; }
        public Image BackgroundImage { get; set; }
        public bool hasRestPads { get; set; }
        public string NickName { get; set; }
        public bool isMechanicalKeyboard { get; set; }
        

    }
}
