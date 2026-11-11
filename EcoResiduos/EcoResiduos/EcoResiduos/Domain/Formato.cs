using System.Globalization;

namespace EcoResiduos.Domain
{
    /// <summary>
    /// Ayudas para leer y escribir los .txt siempre igual, sin importar la configuración regional del PC.
    /// REFACTOR: en el proyecto anterior se usaba ',' como separador y la configuración local
    /// (en Colombia los decimales usan coma), lo que dañaba los archivos.
    /// </summary>
    public static class Formato
    {
        public const char Separador = ';';
        public const string FormatoFecha = "yyyy-MM-dd HH:mm";
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        public static string Num(double valor) => valor.ToString("0.##", Inv);
        public static double LeerNum(string texto) => double.Parse(texto.Trim(), NumberStyles.Float, Inv);
        public static string Fecha(DateTime fecha) => fecha.ToString(FormatoFecha, Inv);
        public static DateTime LeerFecha(string texto) => DateTime.ParseExact(texto.Trim(), FormatoFecha, Inv);

        /// <summary>Divide una línea y verifica que tenga la cantidad de campos esperada.</summary>
        public static string[] Campos(string linea, int esperados, string entidad)
        {
            string[] campos = linea.Split(Separador);
            if (campos.Length < esperados)
                throw new FormatException($"{entidad}: se esperaban {esperados} campos y llegaron {campos.Length}.");
            return campos;
        }

        public static string Nombre(TipoResiduo tipo)
        {
            switch (tipo)
            {
                case TipoResiduo.Organico:
                    return "Orgánico";
                case TipoResiduo.Aprovechable:
                    return "Aprovechable";
                case TipoResiduo.NoAprovechable:
                    return "No aprovechable";
                default:
                    return tipo.ToString();
            }
        }

        public static string Nombre(TipoPunto tipo)
        {
            switch (tipo)
            {
                case TipoPunto.PuntoEcologico:
                    return "Punto ecológico";
                case TipoPunto.Piscina:
                    return "Piscina";
                case TipoPunto.Gimnasio:
                    return "Gimnasio";
                case TipoPunto.ZonaAsados:
                    return "Zona de asados";
                case TipoPunto.ParqueInfantil:
                    return "Parque infantil";
                case TipoPunto.Acopio:
                    return "Cuarto de acopio";
                case TipoPunto.Interseccion:
                    return "Intersección";
                default:
                    return tipo.ToString();
            }
        }

        public static string Nombre(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Tuesday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miércoles";
                case DayOfWeek.Thursday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sábado";
                default:
                    return "Domingo";
            }
        }
    }
}
