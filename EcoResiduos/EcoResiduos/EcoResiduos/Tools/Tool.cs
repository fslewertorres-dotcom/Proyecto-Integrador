using EcoResiduos.Exceptions;

namespace EcoResiduos.Tools
{
    internal static class Tool
    {
        /// <summary>
        /// Abre un formulario hijo del MDI centrado en la ventana principal, o lo trae al frente si ya está abierto.
        /// Los formularios hijos tienen un tamaño fijo para que sus tablas y gráficos se vean bien.
        /// </summary>
        public static void openForm<TForm>(Form parent) where TForm : Form, new()
        {
            TForm? form = Application.OpenForms.OfType<TForm>().FirstOrDefault();
            if (form == null || form.IsDisposed)
            {
                form = new TForm();
                form.MdiParent = parent;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = PosicionCentrada(parent, form);
                Tema.BordearListas(form);
                form.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Normal;
                form.BringToFront();
                form.Activate();   // dispara Activated (el mapa se actualiza al volver a él)
            }
        }

        /// <summary>Calcula la posición para que el formulario quede en el centro del área del MDI.</summary>
        private static Point PosicionCentrada(Form parent, Form hijo)
        {
            MdiClient? area = parent.Controls.OfType<MdiClient>().FirstOrDefault();
            if (area == null) return new Point(10, 10);
            int x = Math.Max(0, (area.ClientSize.Width - hijo.Width) / 2);
            int y = Math.Max(0, (area.ClientSize.Height - hijo.Height) / 2);
            return new Point(x, y);
        }

        /// <summary>Muestra un error de forma amigable. Las excepciones propias se muestran como advertencia.</summary>
        public static void MostrarError(Exception ex)
        {
            if (ex is ValidacionException || ex is AutenticacionException)
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (ex is EcoResiduosException)
                MessageBox.Show(ex.Message, "Error en los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show($"Ocurrió un error inesperado:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string mensaje) =>
            MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        /// <summary>Asigna un valor a un NumericUpDown sin salirse de su mínimo y máximo.</summary>
        public static void AsignarSeguro(NumericUpDown control, double valor)
        {
            decimal v = (decimal)valor;
            if (v < control.Minimum) v = control.Minimum;
            if (v > control.Maximum) v = control.Maximum;
            control.Value = v;
        }

        /// <summary>
        /// REFACTOR de showProgressbar: antes usaba Thread.Sleep en un ciclo y congelaba la ventana.
        /// Ahora es asíncrono: muestra una barra en la barra de estado mientras corre el trabajo.
        /// </summary>
        public static async Task MostrarProgresoAsync(StatusStrip strip, string mensaje, Func<Task> trabajo)
        {
            var label = new ToolStripStatusLabel(mensaje);
            var barra = new ToolStripProgressBar { Style = ProgressBarStyle.Marquee, MarqueeAnimationSpeed = 30 };
            strip.Items.Add(label);
            strip.Items.Add(barra);
            try
            {
                await trabajo();
            }
            finally
            {
                strip.Items.Remove(label);
                strip.Items.Remove(barra);
            }
        }
    }
}
