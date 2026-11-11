using EcoResiduos.Contracts;

namespace EcoResiduos.Domain
{
    public class Contenedor : IEntity<long>, IFactory<Contenedor>, ISerialize<Contenedor>
    {
        public long Id { get; set; }
        public long PuntoId { get; set; }
        public TipoResiduo Tipo { get; set; }
        public double CapacidadLitros { get; set; }
        public double NivelLitros { get; set; }
        /// <summary>Litros por hora en promedio semanal. El modelo la multiplica por factores de hora y día.</summary>
        public double TasaBaseLitrosHora { get; set; }

        public double Porcentaje => CapacidadLitros <= 0 ? 0 : NivelLitros / CapacidadLitros * 100;
        public double LitrosLibres => Math.Max(0, CapacidadLitros - NivelLitros);

        public static Contenedor Create(string textCsv) => Deserialize(textCsv);

        public static Contenedor Deserialize(string textCsv)
        {
            string[] m = Formato.Campos(textCsv, 6, nameof(Contenedor));
            return new Contenedor
            {
                Id = long.Parse(m[0]),
                PuntoId = long.Parse(m[1]),
                Tipo = Enum.Parse<TipoResiduo>(m[2].Trim()),
                CapacidadLitros = Formato.LeerNum(m[3]),
                NivelLitros = Formato.LeerNum(m[4]),
                TasaBaseLitrosHora = Formato.LeerNum(m[5])
            };
        }

        public static string Serialize(Contenedor c) =>
            string.Join(Formato.Separador, c.Id, c.PuntoId, c.Tipo, Formato.Num(c.CapacidadLitros),
                        Formato.Num(c.NivelLitros), Formato.Num(c.TasaBaseLitrosHora));

        public override string ToString() => $"{Id} - {Formato.Nombre(Tipo)} ({Porcentaje:0}%)";
    }
}
