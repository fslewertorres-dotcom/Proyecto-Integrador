namespace EcoResiduos.Tools
{
    /// <summary>
    /// Colores y estilos del programa, en un solo lugar.
    /// Paleta "ecológica": verdes para la interfaz, ámbar para la ruta y rojo/amarillo para las alertas.
    /// </summary>
    internal static class Tema
    {
        public static readonly Color VerdeOscuro = Color.FromArgb(30, 86, 49);
        public static readonly Color Verde = Color.FromArgb(46, 125, 79);
        public static readonly Color VerdeClaro = Color.FromArgb(232, 243, 236);
        public static readonly Color VerdeSeleccion = Color.FromArgb(198, 228, 208);
        public static readonly Color Fondo = Color.FromArgb(244, 247, 243);
        public static readonly Color Borde = Color.FromArgb(222, 230, 224);
        public static readonly Color Texto = Color.FromArgb(31, 45, 36);
        public static readonly Color TextoSuave = Color.FromArgb(107, 123, 113);
        public static readonly Color Ambar = Color.FromArgb(242, 159, 5);
        public static readonly Color Rojo = Color.FromArgb(214, 69, 69);
        public static readonly Color Amarillo = Color.FromArgb(242, 201, 76);
        public static readonly Color Azul = Color.FromArgb(47, 102, 144);

        /// <summary>Le da a una tabla el estilo del programa: encabezado verde y filas alternas.</summary>
        public static void EstilizarTabla(DataGridView tabla)
        {
            tabla.BorderStyle = BorderStyle.None;
            tabla.BackgroundColor = Color.White;
            tabla.GridColor = Borde;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tabla.ColumnHeadersHeight = 34;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = VerdeOscuro;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = VerdeOscuro;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tabla.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            tabla.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            tabla.DefaultCellStyle.ForeColor = Texto;
            tabla.DefaultCellStyle.SelectionBackColor = VerdeSeleccion;
            tabla.DefaultCellStyle.SelectionForeColor = Texto;
            tabla.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 251, 248);
            tabla.RowTemplate.Height = 28;
            tabla.RowHeadersVisible = false;
        }

        /// <summary>Menú y barra de estado con los colores del programa.</summary>
        public static void EstilizarMenu(MenuStrip menu)
        {
            menu.Renderer = new ToolStripProfessionalRenderer(new ColoresMenu());
            menu.BackColor = VerdeOscuro;
            menu.Padding = new Padding(8, 4, 0, 4);
            foreach (ToolStripItem item in menu.Items)
            {
                item.ForeColor = Color.White;
                item.Font = new Font("Segoe UI", 9.75F);
                if (item is ToolStripMenuItem opcion)
                    foreach (ToolStripItem sub in opcion.DropDownItems)
                        sub.ForeColor = Texto;
            }
        }

        public static void EstilizarBarraEstado(StatusStrip barra)
        {
            barra.Renderer = new ToolStripProfessionalRenderer(new ColoresMenu());
            barra.SizingGrip = false;
            foreach (ToolStripItem item in barra.Items)
                item.ForeColor = Texto;
        }

        /// <summary>Colores que usa el menú (al pasar el mouse, al abrir, fondo de las listas, etc.).</summary>
        private class ColoresMenu : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin { get { return VerdeOscuro; } }
            public override Color MenuStripGradientEnd { get { return VerdeOscuro; } }
            public override Color MenuItemSelected { get { return VerdeClaro; } }
            public override Color MenuItemBorder { get { return Verde; } }
            public override Color MenuBorder { get { return Borde; } }
            public override Color MenuItemSelectedGradientBegin { get { return Verde; } }
            public override Color MenuItemSelectedGradientEnd { get { return Verde; } }
            public override Color MenuItemPressedGradientBegin { get { return Verde; } }
            public override Color MenuItemPressedGradientEnd { get { return Verde; } }
            public override Color ToolStripDropDownBackground { get { return Color.White; } }
            public override Color ImageMarginGradientBegin { get { return Color.White; } }
            public override Color ImageMarginGradientMiddle { get { return Color.White; } }
            public override Color ImageMarginGradientEnd { get { return Color.White; } }
            public override Color StatusStripGradientBegin { get { return VerdeClaro; } }
            public override Color StatusStripGradientEnd { get { return VerdeClaro; } }
            public override Color SeparatorDark { get { return Borde; } }
        }
    }
}
