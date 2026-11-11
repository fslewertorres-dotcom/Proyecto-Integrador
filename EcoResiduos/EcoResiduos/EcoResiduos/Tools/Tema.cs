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

        /// <summary>Borde de las listas desplegables: gris verdoso normal, verde cuando tienen el foco.</summary>
        private static readonly Color BordeLista = Color.FromArgb(178, 192, 183);

        /// <summary>
        /// Las listas desplegables planas (FlatStyle.Flat) no dibujan borde y se pierden sobre el fondo blanco.
        /// Aquí se les dibuja un borde de 1 px por fuera, en el contenedor que las tiene (igual que el de las cajas de texto).
        /// </summary>
        public static void BordearListas(Control raiz)
        {
            foreach (Control control in raiz.Controls)
            {
                if (control is ComboBox lista && lista.FlatStyle == FlatStyle.Flat)
                {
                    lista.Enter += (s, e) => lista.Parent?.Invalidate(BordeDe(lista));
                    lista.Leave += (s, e) => lista.Parent?.Invalidate(BordeDe(lista));
                    raiz.Paint += (s, e) =>
                    {
                        if (!lista.Visible) return;
                        Rectangle r = BordeDe(lista);
                        using Pen lapiz = new Pen(lista.Focused ? Verde : BordeLista);
                        e.Graphics.DrawRectangle(lapiz, r.X, r.Y, r.Width - 1, r.Height - 1);
                    };
                }
                if (control.HasChildren) BordearListas(control);
            }
        }

        private static Rectangle BordeDe(ComboBox lista)
        {
            Rectangle r = lista.Bounds;
            r.Inflate(1, 1);
            return r;
        }

        /// <summary>
        /// Las columnas de texto indicadas toman el ancho de su contenido más largo (se ven completas);
        /// las demás se reparten el espacio restante sin quedar más angostas que su encabezado.
        /// Se llama después de asignar el DataSource.
        /// </summary>
        public static void AjustarColumnas(DataGridView tabla, params string[] columnasDeTexto)
        {
            foreach (DataGridViewColumn columna in tabla.Columns)
            {
                if (columnasDeTexto.Contains(columna.Name))
                {
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    columna.MinimumWidth = columna.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                    columna.FillWeight = columna.Name == "Id" ? 60 : 100;
                }
            }
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
