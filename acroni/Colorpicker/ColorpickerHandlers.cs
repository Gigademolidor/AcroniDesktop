﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acroni.Colorpicker
{
    class ColorpickerHandlers
    {
        internal static int NoOfColorsVisibleOnDisplay { get; set; }
        internal static bool IsChosen { get; set; } = true;
        internal static Color ChosenColor { get; set; }
        internal static String nome_usuario { get; set; }
        internal static String nome_conexao { get; set; } = "Data Source = "+ Environment.MachineName +"\\SQLEXPRESS; Initial Catalog = ACRONI_SQL; User ID = Acroni; Password = acroni7";
    }
}
