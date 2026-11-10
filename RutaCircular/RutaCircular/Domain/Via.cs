using RutaCircular.Contracts;

namespace RutaCircular.Domain
{
    /// <summary>Tramo de vía entre dos puntos. Es una arista (no dirigida) del grafo.</summary>
    public class Via : IEntity<long>, IFactory<Via>, ISerialize<Via>
    {
        public long Id { get; set; }
        public long OrigenId { get; set; }
        public long DestinoId { get; set; }
        public double DistanciaMetros { get; set; }

        public static Via Create(string textCsv) => Deserialize(textCsv);

        public static Via Deserialize(string textCsv)
        {
            string[] m = Formato.Campos(textCsv, 4, nameof(Via));
            return new Via
            {
                Id = long.Parse(m[0]),
                OrigenId = long.Parse(m[1]),
                DestinoId = long.Parse(m[2]),
                DistanciaMetros = Formato.LeerNum(m[3])
            };
        }

        public static string Serialize(Via v) =>
            string.Join(Formato.Separador, v.Id, v.OrigenId, v.DestinoId, Formato.Num(v.DistanciaMetros));
    }
}
