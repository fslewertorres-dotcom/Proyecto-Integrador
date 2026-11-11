using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>
    /// Gráfico de barras sencillo: el nivel proyectado (%) de un contenedor cada 3 horas.
    /// Verde menos de 50 %, amarillo de 50 a 80 %, rojo 80 % o más.
    /// </summary>
    public class GraficoNivel : Panel
    {
        private double[] _valores = new double[0];
        private string[] _etiquetas = new string[0];

        public string Titulo { get; set; } = "Nivel proyectado en las próximas 24 horas";

        public GraficoNivel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        public void MostrarDatos(double[] porcentajes, string[] etiquetas)
        {
            _valores = porcentajes;
            _etiquetas = etiquetas;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using Font fuenteTitulo = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            using Font fuente = new Font("Segoe UI", 8.25F);
            using SolidBrush pincelTitulo = new SolidBrush(Tema.VerdeOscuro);
            using SolidBrush pincelTexto = new SolidBrush(Tema.TextoSuave);
            using Pen lineaGuia = new Pen(Tema.Borde);

            g.DrawString(Titulo, fuenteTitulo, pincelTitulo, 16, 12);

            // Zona del gráfico
            int izquierda = 50, arriba = 50, derecha = Width - 20, abajo = Height - 40;
            int alto = abajo - arriba;
            if (alto <= 0 || derecha <= izquierda) return;

            // Líneas guía: 0 %, 50 %, 80 % y 100 %
            int[] guias = { 0, 50, 80, 100 };
            foreach (int porcentaje in guias)
            {
                int y = abajo - alto * porcentaje / 100;
                g.DrawLine(lineaGuia, izquierda, y, derecha, y);
                g.DrawString(porcentaje + " %", fuente, pincelTexto, 8, y - 7);
            }

            if (_valores.Length == 0)
            {
                g.DrawString("Elija un contenedor y presione Predecir.", fuente, pincelTexto, izquierda + 10, arriba + alto / 2);
                return;
            }

            // Barras
            float anchoEspacio = (derecha - izquierda) / (float)_valores.Length;
            float anchoBarra = anchoEspacio * 0.6f;
            for (int i = 0; i < _valores.Length; i++)
            {
                double valor = Math.Max(0, Math.Min(100, _valores[i]));
                float altoBarra = (float)(alto * valor / 100);
                float x = izquierda + i * anchoEspacio + (anchoEspacio - anchoBarra) / 2;

                Color color = Tema.Verde;
                if (valor >= 80) color = Tema.Rojo;
                else if (valor >= 50) color = Tema.Amarillo;

                using (SolidBrush pincelBarra = new SolidBrush(color))
                    g.FillRectangle(pincelBarra, x, abajo - altoBarra, anchoBarra, altoBarra);

                string texto = valor.ToString("0") + "%";
                SizeF t = g.MeasureString(texto, fuente);
                g.DrawString(texto, fuente, pincelTexto, x + (anchoBarra - t.Width) / 2, abajo - altoBarra - 15);

                if (i < _etiquetas.Length)
                {
                    SizeF te = g.MeasureString(_etiquetas[i], fuente);
                    g.DrawString(_etiquetas[i], fuente, pincelTexto, x + (anchoBarra - te.Width) / 2, abajo + 6);
                }
            }
        }
    }
}
