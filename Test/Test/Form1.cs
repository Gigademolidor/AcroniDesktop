using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcroniControls;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Normal");
            comboBox1.Items.Add("Ajustar");
            comboBox1.Items.Add("Zoom");
            comboBox1.Items.Add("Centralizar");
        
         }
        
        
        Button b;
        bool naofez = true;
        public Color Colorpicker { get; set; }
        List<byte> IE = new List<byte>();
        List<object> Fonte = new List<object>();
        Teclado keyboard = new Teclado();
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox2.Image);
            Color c = b.GetPixel(e.X, e.Y);
            Colorpicker = c;
        }

        private void btnAbstractus_Click(object sender, EventArgs e)
        {
            if (b != null)
                b.Cursor = Cursors.Default;
            b = (Button)sender;
            if (b.BackColor == Colorpicker)
                b.BackColor = Color.Transparent;
            else
                b.BackColor = Colorpicker;
            if(b.BackColor.B>230&&b.BackColor.G<200&&b.BackColor.R<200)
                button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 50, (b.BackColor.G + 50), (b.BackColor.B));
            else if (b.BackColor.G > 230 && b.BackColor.B < 200 && b.BackColor.R < 200)
                button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 50, (b.BackColor.G), (b.BackColor.B+50));
            else if (b.BackColor.R > 230 && b.BackColor.B < 200 && b.BackColor.G < 200)
                button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R, (b.BackColor.G+50), (b.BackColor.B + 50));
            else if(b.BackColor.G<200 && b.BackColor.B<200 && b.BackColor.R<200)
            button1.BackColor = Color.FromArgb(b.BackColor.A-60, b.BackColor.R+50, (b.BackColor.G+50), (b.BackColor.B+50));
            else if(b.BackColor.G<200&&b.BackColor.B<200&&b.BackColor.R<210)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 40, (b.BackColor.G + 50), (b.BackColor.B + 50));
            else if(b.BackColor.G<200&&b.BackColor.B<210&&b.BackColor.R<210)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 40, (b.BackColor.G + 50), (b.BackColor.B + 40));
            else if(b.BackColor.G<210&&b.BackColor.B<210&&b.BackColor.R<210)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 40, (b.BackColor.G + 40), (b.BackColor.B + 40));
            else if(b.BackColor.G<210&&b.BackColor.B<210&&b.BackColor.R<220)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 30, (b.BackColor.G + 40), (b.BackColor.B + 40));
            else if(b.BackColor.G<210&&b.BackColor.B<220&&b.BackColor.R<220)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 30, (b.BackColor.G + 40), (b.BackColor.B + 30));
            else if(b.BackColor.G<220&&b.BackColor.B<220&&b.BackColor.R<220)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 30, (b.BackColor.G + 30), (b.BackColor.B + 30));
            else if(b.BackColor.G<220&&b.BackColor.B<220&&b.BackColor.R<230)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 20, (b.BackColor.G + 30), (b.BackColor.B + 30));
            else if (b.BackColor.G < 220 && b.BackColor.B < 230 && b.BackColor.R < 230)
            button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 20, (b.BackColor.G + 30), (b.BackColor.B + 20));
            else if (b.BackColor.G < 230 && b.BackColor.B < 230 && b.BackColor.R < 230)
                button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R + 20, (b.BackColor.G + 20), (b.BackColor.B + 20));
            else
                button1.BackColor = Color.FromArgb(b.BackColor.A - 60, b.BackColor.R, (b.BackColor.G), (b.BackColor.B));
  






        }

        private void Form1_Load(object sender, EventArgs e)
        {

            using (InstalledFontCollection col = new InstalledFontCollection())
            {
                foreach (FontFamily fa in col.Families)
                {
                    cmbFont.Items.Add(fa.Name);
                    if (naofez)
                    {
                        Fonte.Add(fa.Name);
                    }
                }
                naofez = false;
                
            }
        }
        private void removeCmbBox()
        {
            foreach (string c in Fonte)
            {
                cmbFont.Items.Remove(c);
            }
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Kbtn)
                {
                    c.Font = new System.Drawing.Font(cmbFont.Text, 6.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex a = new Regex(textBox1.Text, RegexOptions.IgnoreCase);
            removeCmbBox();
            Form1_Load(sender, e);
            if (textBox1.Text != "")
            {
                foreach (string c in Fonte)
                {
                    if (!(a.IsMatch(c)))
                    {
                        cmbFont.Items.Remove(c);
                    }

                }
            }
            cmbFont.DroppedDown = true;

        }

        private void btnFontePersonalizada_Click(object sender, EventArgs e)
        {

        }
        

        private void btnImagemTeclado_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectImg = new OpenFileDialog();
            SelectImg.Title = "Selecionar imagem";
            SelectImg.CheckFileExists = true;
            SelectImg.CheckPathExists = true;
            SelectImg.ReadOnlyChecked = true;
            SelectImg.ShowReadOnly = true;
            SelectImg.RestoreDirectory = true;
            SelectImg.InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\Pictures";
            SelectImg.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.bmp)|*.bmp|(*.svg)|*.svg|(*.tif)|*.tif|Todos os arquivos|*.*";
            if (SelectImg.ShowDialog() == DialogResult.OK)
            {
                Image fundoteclado = Image.FromFile(SelectImg.FileName);
                pictureBox1.Image = fundoteclado;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Normal":
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    break;
                case "Ajustar":
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case "Zoom":
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case "Centralizar":
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
            }
        }
        private void btnComprimir_Click(object sender, EventArgs e)
        {
            keyboard.Name = "FX-4370";
            keyboard.NickName = "flex";
            keyboard.Material = "Madeira";
            keyboard.isMechanicalKeyboard = true;
            keyboard.hasRestPads = false;
            keyboard.BackgroundImage = pictureBox1.Image;
            keyboard.BackgroundModeSize = pictureBox1.SizeMode;
            keyboard.ID = "ID";
            keyboard.Keycaps = new List<Keycaps>();
            foreach (Control tecla in this.Controls)
                if(tecla is Kbtn)
                {
                    {
                        keyboard.Keycaps.Add(new Keycaps { ID = tecla.Name, Text = tecla.Text, Font = tecla.Font, Color = tecla.BackColor });
                    }
                }
            using (FileStream savearchive = new FileStream(@"C:\Users\Public\fax.acr", FileMode.OpenOrCreate))
            {
                BinaryFormatter Serialize = new BinaryFormatter();
                Serialize.Serialize(savearchive, keyboard);
            }

        }
        private void btnLer_Click(object sender, EventArgs e)
        {

            using (FileStream openarchive = new FileStream(@"C:\Users\Public\fax.acr", FileMode.Open))
            {
                BinaryFormatter ofByteArrayToObject = new BinaryFormatter();
                keyboard = (Teclado)ofByteArrayToObject.Deserialize(openarchive);

            }
            pictureBox1.Image = keyboard.BackgroundImage;
            pictureBox1.SizeMode = (PictureBoxSizeMode) keyboard.BackgroundModeSize;
            foreach (Control control in this.Controls)
            {
                if (control is Kbtn)
                {
                    foreach (Keycaps tecla in this.keyboard.Keycaps)
                    {
                        if (control.Name.Equals(tecla.ID))
                        {
                            control.Name = tecla.ID;
                            control.Font = tecla.Font;
                            control.BackColor = tecla.Color;
                            control.Text = tecla.Text;
                            break;
                        }
                    }
                }
                }
            }
        }
    }

