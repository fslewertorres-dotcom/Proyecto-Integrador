using EcoResiduos.Contracts;

namespace EcoResiduos.Domain
{
    /// <summary>Registro histórico: un contenedor se vació en cierta fecha.</summary>
    public class Recoleccion : IEntity<long>, IFactory<Recoleccion>, ISerialize<Recoleccion>
    {
        public long Id { get; set; }
        public long ContenedorId { get; set; }
        public DateTime Fecha { get; set; }
        public double Litros { get; set; }
        public long OperarioId { get; set; }

        public double Kg => Litros * ConstantesModelo.DensidadKgPorLitro;

        public static Recoleccion Create(string textCsv) => Deserialize(textCsv);

        public static Recoleccion Deserialize(string textCsv)
        {
            string[] m = Formato.Campos(textCsv, 5, nameof(Recoleccion));
            return new Recoleccion
            {
                Id = long.Parse(m[0]),
                ContenedorId = long.Parse(m[1]),
                Fecha = Formato.LeerFecha(m[2]),
                Litros = Formato.LeerNum(m[3]),
                OperarioId = long.Parse(m[4])
            };
        }

        public static string Serialize(Recoleccion r) =>
            string.Join(Formato.Separador, r.Id, r.ContenedorId, Formato.Fecha(r.Fecha), Formato.Num(r.Litros), r.OperarioId);
    }
}
