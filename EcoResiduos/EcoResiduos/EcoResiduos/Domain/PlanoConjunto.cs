namespace EcoResiduos.Domain
{
    /// <summary>Rectángulo en metros (origen arriba a la izquierda, Y crece hacia abajo como en la pantalla).</summary>
    public struct Rectangulo
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Ancho { get; set; }
        public double Alto { get; set; }

        public Rectangulo(double x, double y, double ancho, double alto)
        {
            X = x;
            Y = y;
            Ancho = ancho;
            Alto = alto;
        }

        public double CentroX { get { return X + Ancho / 2; } }
        public double CentroY { get { return Y + Alto / 2; } }
    }

    /// <summary>Una casa del conjunto: su número, la hilera, la vía a la que da y su lote.</summary>
    public class Casa
    {
        public int Numero { get; set; }
        public int Hilera { get; set; }
        public int Via { get; set; }
        public Rectangulo Lote { get; set; }

        public Casa(int numero, int hilera, int via, Rectangulo lote)
        {
            Numero = numero;
            Hilera = hilera;
            Via = via;
            Lote = lote;
        }
    }

    public class ZonaComun
    {
        public string Nombre { get; set; }
        public TipoPunto Tipo { get; set; }
        public Rectangulo Area { get; set; }

        public ZonaComun(string nombre, TipoPunto tipo, Rectangulo area)
        {
            Nombre = nombre;
            Tipo = tipo;
            Area = area;
        }
    }

    /// <summary>
    /// Geometría fija del conjunto (96 casas de 6 × 16 m en 8 hileras de 12, 4 vías internas).
    /// Los puntos de recolección y las vías del grafo están en los .txt; aquí solo está lo que se dibuja
    /// y lo que usa el cálculo de la ubicación óptima.
    /// </summary>
    public static class PlanoConjunto
    {
        public const double LoteAncho = 120;
        public const double LoteAlto = 160;
        public const double FrenteCasa = 6;
        public const double FondoCasa = 16;
        public const int CasasPorHilera = 12;

        /// <summary>Y superior de cada hilera. Entre cada par hay una vía de 6 m.</summary>
        private static readonly double[] YHileras = { 0, 22, 38, 60, 76, 98, 114, 136 };
        /// <summary>Y del centro de cada vía interna.</summary>
        public static readonly double[] YVias = { 19, 57, 95, 133 };

        public static readonly Rectangulo ViaPrincipal = new Rectangulo(0, 0, 8, 160);
        public static readonly Rectangulo Sendero = new Rectangulo(80, 16, 4, 120);

        public static readonly Rectangulo[] Hileras = CrearHileras();
        public static readonly Casa[] Casas = CrearCasas();

        public static readonly ZonaComun[] ZonasComunes =
        {
            new ZonaComun("Piscina", TipoPunto.Piscina, new Rectangulo(84, 4, 36, 32)),
            new ZonaComun("Gimnasio", TipoPunto.Gimnasio, new Rectangulo(84, 40, 36, 22)),
            new ZonaComun("Zona de asados", TipoPunto.ZonaAsados, new Rectangulo(84, 68, 36, 34)),
            new ZonaComun("Parque infantil", TipoPunto.ParqueInfantil, new Rectangulo(84, 108, 36, 38)),
        };

        public static Rectangulo ViaInterna(int indice)
        {
            return new Rectangulo(8, YVias[indice] - 3, 74, 6);
        }

        private static Rectangulo[] CrearHileras()
        {
            Rectangulo[] hileras = new Rectangulo[YHileras.Length];
            for (int i = 0; i < YHileras.Length; i++)
                hileras[i] = new Rectangulo(8, YHileras[i], FrenteCasa * CasasPorHilera, FondoCasa);
            return hileras;
        }

        private static Casa[] CrearCasas()
        {
            Casa[] casas = new Casa[YHileras.Length * CasasPorHilera];
            int n = 0;
            for (int h = 0; h < YHileras.Length; h++)
            {
                for (int c = 0; c < CasasPorHilera; c++)
                {
                    Rectangulo lote = new Rectangulo(8 + c * FrenteCasa, YHileras[h], FrenteCasa, FondoCasa);
                    // Las hileras 1-2 dan a la vía 1, 3-4 a la vía 2, etc.
                    casas[n] = new Casa(n + 1, h + 1, h / 2 + 1, lote);
                    n++;
                }
            }
            return casas;
        }
    }
}
