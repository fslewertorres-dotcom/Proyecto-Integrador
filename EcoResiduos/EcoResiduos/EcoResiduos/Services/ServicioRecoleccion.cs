using EcoResiduos.Domain;
using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;
using EcoResiduos.Services.Calculo;

namespace EcoResiduos.Services
{
    /// <summary>Operaciones del día a día: vaciar contenedores y simular el paso del tiempo.</summary>
    public class ServicioRecoleccion
    {
        private readonly Contexto _ctx;

        public ServicioRecoleccion(Contexto contexto)
        {
            _ctx = contexto;
        }

        /// <summary>Vacía un contenedor y deja el registro en el histórico (con la hora del reloj de simulación).</summary>
        public Recoleccion Registrar(Contenedor contenedor, long operarioId)
        {
            if (contenedor.NivelLitros <= 0)
                throw new ValidacionException($"El contenedor {contenedor.Id} ya está vacío.");

            var recoleccion = new Recoleccion
            {
                Id = Contexto.SiguienteId(_ctx.Recolecciones.GetAll()),
                ContenedorId = contenedor.Id,
                Fecha = _ctx.Reloj,
                Litros = Math.Round(contenedor.NivelLitros, 2),
                OperarioId = operarioId
            };
            _ctx.Recolecciones.Add(recoleccion);
            contenedor.NivelLitros = 0;
            _ctx.Contenedores.Update(contenedor);
            return recoleccion;
        }

        public Task GuardarAsync() =>
            Task.WhenAll(_ctx.Recolecciones.CommitAsync(), _ctx.Contenedores.CommitAsync(), _ctx.GuardarRelojAsync());

        /// <summary>
        /// Avanza el reloj y llena los contenedores con la integral de la generación.
        /// Devuelve los litros que se desbordaron (lo que no cupo).
        /// </summary>
        public double SimularTiempo(double horas)
        {
            if (horas <= 0) throw new ValidacionException("Las horas a simular deben ser mayores que cero.");
            double desbordado = 0;
            foreach (Contenedor c in _ctx.Contenedores.GetAll())
            {
                PuntoRecoleccion? punto = _ctx.Puntos.GetById(c.PuntoId);
                if (punto == null) continue;
                double generado = Prediccion.LitrosGenerados(punto.Tipo, c.TasaBaseLitrosHora, _ctx.Reloj, horas);
                double nuevo = c.NivelLitros + generado;
                if (nuevo > c.CapacidadLitros)
                {
                    desbordado += nuevo - c.CapacidadLitros;
                    nuevo = c.CapacidadLitros;
                }
                c.NivelLitros = Math.Round(nuevo, 2);
            }
            _ctx.Reloj = _ctx.Reloj.AddHours(horas);
            return desbordado;
        }
    }
}
