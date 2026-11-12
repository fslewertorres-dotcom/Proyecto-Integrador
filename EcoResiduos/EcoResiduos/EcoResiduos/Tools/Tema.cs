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

        // ========================= TAMAÑO DE LOS FORMULARIOS =========================
        // Los formularios se diseñaron en ~1000 × 560. En pantallas grandes se agrandan todos en la misma
        // proporción (controles, letras, tablas y dibujos) para que no se vean pequeños.

        /// <summary>Factor de agrandado actual (1 = tamaño de diseño).</summary>
        public static float Escala { get; private set; } = 1f;

        /// <summary>Tamaño de referencia del formulario más grande (el mapa, con bordes).</summary>
        private static readonly Size TamanoReferencia = new Size(1200, 625);
        private const float EscalaMaxima = 1.5f;

        /// <summary>Calcula el factor para que el formulario más grande ocupe cerca del 85 % del área disponible.</summary>
        public static void CalcularEscala(Size area)
        {
            float fx = area.Width * 0.85f / TamanoReferencia.Width;
            float fy = area.Height * 0.88f / TamanoReferencia.Height;
            Escala = Math.Clamp(Math.Min(fx, fy), 1f, EscalaMaxima);
        }

        /// <summary>Letra Segoe UI del tamaño indicado, ya agrandada según la escala.</summary>
        public static Font Fuente(float tamano, FontStyle estilo = FontStyle.Regular) =>
            new Font("Segoe UI", tamano * Escala, estilo);

        /// <summary>Medida en píxeles ya agrandada según la escala.</summary>
        public static int Px(float valor) => (int)Math.Round(valor * Escala);

        /// <summary>
        /// Agranda un formulario recién creado: posición y tamaño de cada control (Scale) y sus letras.
        /// Las tablas ya salen con letra y alto agrandados desde EstilizarTabla.
        /// </summary>
        public static void EscalarFormulario(Form form)
        {
            if (Escala <= 1.001f) return;

            // 1. Guardar las letras originales antes de tocar nada (los hijos heredan la letra del padre).
            var letras = new List<(Control control, Font letra)>();
            Recorrer(form, c => letras.Add((c, c.Font)));

            // 2. Sin autoescalado de WinForms: si no, al cambiar la letra volvería a mover los controles.
            Recorrer(form, c => { if (c is ContainerControl cc) cc.AutoScaleMode = AutoScaleMode.None; });

            // 3. Posiciones y tamaños
            form.Scale(new SizeF(Escala, Escala));

            // 4. Letras y altos que Scale no cambia
            foreach (var (control, letra) in letras)
                control.Font = new Font(letra.FontFamily, letra.Size * Escala, letra.Style);
            Recorrer(form, c =>
            {
                if (c is ListBox lista && lista.DrawMode == DrawMode.OwnerDrawFixed)
                    lista.ItemHeight = Px(lista.ItemHeight);
            });
        }

        private static void Recorrer(Control raiz, Action<Control> accion)
        {
            accion(raiz);
            foreach (Control hijo in raiz.Controls)
                Recorrer(hijo, accion);
        }

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
            tabla.ColumnHeadersHeight = Px(34);
            tabla.ColumnHeadersDefaultCellStyle.BackColor = VerdeOscuro;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = VerdeOscuro;
            tabla.ColumnHeadersDefaultCellStyle.Font = Fuente(9F, FontStyle.Bold);
            tabla.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            tabla.DefaultCellStyle.Font = Fuente(9F);
            tabla.DefaultCellStyle.ForeColor = Texto;
            tabla.DefaultCellStyle.SelectionBackColor = VerdeSeleccion;
            tabla.DefaultCellStyle.SelectionForeColor = Texto;
            tabla.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 251, 248);
            tabla.RowTemplate.Height = Px(28);
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
            // Si la tabla todavía no se muestra (constructor del formulario), se ajusta cuando aparezca:
            // para entonces el formulario ya tiene su tamaño final (ver EscalarFormulario).
            if (!tabla.IsHandleCreated)
            {
                void AlCrear(object? s, EventArgs e)
                {
                    tabla.HandleCreated -= AlCrear;
                    AjustarColumnas(tabla, columnasDeTexto);
                }
                tabla.HandleCreated += AlCrear;
                return;
            }

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
