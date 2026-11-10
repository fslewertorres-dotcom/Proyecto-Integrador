using RutaCircular.Contracts;

namespace RutaCircular.Domain
{
    /// <summary>Nodo del plano: punto ecológico, zona común, cuarto de acopio o intersección de vías.</summary>
    public class PuntoRecoleccion : IEntity<long>, IFactory<PuntoRecoleccion>, ISerialize<PuntoRecoleccion>
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public TipoPunto Tipo { get; set; }
        /// <summary>Coordenadas en metros dentro del lote.</summary>
        public double X { get; set; }
        public double Y { get; set; }
        public int CasasAtendidas { get; set; }

        /// <summary>Las intersecciones y el acopio son nodos del grafo pero no tienen contenedores.</summary>
        public bool TieneContenedores
        {
            get { return Tipo != TipoPunto.Interseccion && Tipo != TipoPunto.Acopio; }
        }

        public bool EsZonaComun
        {
            get
            {
                return Tipo == TipoPunto.Piscina || Tipo == TipoPunto.Gimnasio
                    || Tipo == TipoPunto.ZonaAsados || Tipo == TipoPunto.ParqueInfantil;
            }
        }

        public static PuntoRecoleccion Create(string textCsv) => Deserialize(textCsv);

        public static PuntoRecoleccion Deserialize(string textCsv)
        {
            string[] m = Formato.Campos(textCsv, 6, nameof(PuntoRecoleccion));
            return new PuntoRecoleccion
            {
                Id = long.Parse(m[0]),
                Nombre = m[1].Trim(),
                Tipo = Enum.Parse<TipoPunto>(m[2].Trim()),
                X = Formato.LeerNum(m[3]),
                Y = Formato.LeerNum(m[4]),
                CasasAtendidas = int.Parse(m[5])
            };
        }

        public static string Serialize(PuntoRecoleccion p) =>
            string.Join(Formato.Separador, p.Id, p.Nombre, p.Tipo, Formato.Num(p.X), Formato.Num(p.Y), p.CasasAtendidas);

        public override string ToString() => $"{Id} - {Nombre}";
    }
}
