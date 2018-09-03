using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcroniUI
{
    public partial class Master : Template
    {
        public Master()
        {
            InitializeComponent();
            using (GraphicsPath ellipse = new GraphicsPath())
            {
                Rectangle imgUsu = ImgUsu.ClientRectangle;
                ellipse.AddEllipse(0, 0, imgUsu.Width, imgUsu.Height);
                ImgUsu.Region = new Region(ellipse);
            }
            using (GraphicsPath ellipse = new GraphicsPath())
            {
                Rectangle btnConfig = this.btnConfig.ClientRectangle;
                ellipse.AddEllipse(0, 0, btnConfig.Width, btnConfig.Height);
                this.btnConfig.Region = new Region(ellipse);
            }
            foreach(Control c in pnlOptions.Controls)
            {
                Bunifu.Framework.UI.BunifuElipse ellipse = new Bunifu.Framework.UI.BunifuElipse();
                ellipse.ApplyElipse(c,2);
            }

        }

        private void CursorHand(object sender, EventArgs e)
        {
            Control Config = (Control)sender;
            Config.Cursor = Cursors.Hand;
        }

        
    }
}
