using RutaCircular.Contracts;
using RutaCircular.Domain;
using RutaCircular.DynamicStructure;
using RutaCircular.Exceptions;

namespace RutaCircular.Infraestructure
{
    /// <summary>
    /// Punto único de acceso a los datos (Singleton, como RepositorioEstudiantes del proyecto anterior).
    /// Los archivos están en la carpeta Data junto al .exe.
    /// </summary>
    public sealed class Contexto
    {
        private static Contexto? _instancia;
        public static Contexto Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Contexto(Path.Combine(AppContext.BaseDirectory, "Data"));
                return _instancia;
            }
        }

        public string CarpetaDatos { get; }
        public Repository<Usuario, long> Usuarios { get; }
        public Repository<PuntoRecoleccion, long> Puntos { get; }
        public Repository<Contenedor, long> Contenedores { get; }
        public Repository<Via, long> Vias { get; }
        public Repository<Recoleccion, long> Recolecciones { get; }

        /// <summary>
        /// Reloj de simulación. Todas las predicciones y recolecciones usan esta hora
        /// (no la del PC), para poder simular días y fines de semana en la presentación.
        /// </summary>
        public DateTime Reloj { get; set; }

        /// <summary>Ubicaciones calculadas con el gradiente, para dibujarlas en el mapa.</summary>
        public List<Coordenada> UbicacionesOptimas { get; } = new List<Coordenada>();

        /// <summary>Puntos por los que pasó el descenso del gradiente (se dibujan en el mapa).</summary>
        public List<Coordenada> TrayectoriaGradiente { get; } = new List<Coordenada>();

        private readonly string _rutaReloj;

        private Contexto(string carpeta)
        {
            CarpetaDatos = carpeta;
            Directory.CreateDirectory(carpeta);
            Usuarios = new Repository<Usuario, long>(Ruta("usuarios.txt"), "# Id;Rol;NombreUsuario;NombreCompleto;HashSHA256");
            Puntos = new Repository<PuntoRecoleccion, long>(Ruta("puntos.txt"), "# Id;Nombre;Tipo;X(m);Y(m);CasasAtendidas");
            Contenedores = new Repository<Contenedor, long>(Ruta("contenedores.txt"), "# Id;PuntoId;TipoResiduo;CapacidadLitros;NivelLitros;TasaBaseLitrosHora");
            Vias = new Repository<Via, long>(Ruta("vias.txt"), "# Id;OrigenId;DestinoId;DistanciaMetros");
            Recolecciones = new Repository<Recoleccion, long>(Ruta("recolecciones.txt"), "# Id;ContenedorId;Fecha;Litros;OperarioId");
            _rutaReloj = Ruta("reloj.txt");
            Reloj = LeerReloj();
        }

        private string Ruta(string archivo) => Path.Combine(CarpetaDatos, archivo);

        private DateTime LeerReloj()
        {
            try
            {
                if (File.Exists(_rutaReloj))
                {
                    string? linea = File.ReadLines(_rutaReloj).FirstOrDefault(l => !string.IsNullOrWhiteSpace(l));
                    if (linea != null) return Formato.LeerFecha(linea);
                }
            }
            catch (FormatException)
            {
                // Si el archivo está dañado se arranca desde hoy a las 7:00
            }
            return DateTime.Today.AddHours(7);
        }

        public Task GuardarRelojAsync() => File.WriteAllTextAsync(_rutaReloj, Formato.Fecha(Reloj) + Environment.NewLine);

        /// <summary>Guarda todos los archivos en paralelo (Task.WhenAll).</summary>
        public async Task GuardarTodoAsync()
        {
            await Task.WhenAll(
                Usuarios.CommitAsync(),
                Puntos.CommitAsync(),
                Contenedores.CommitAsync(),
                Vias.CommitAsync(),
                Recolecciones.CommitAsync(),
                GuardarRelojAsync());
        }

        /// <summary>Versión sincrónica (se usa al cerrar el programa).</summary>
        public void GuardarTodo()
        {
            Usuarios.Commit();
            Puntos.Commit();
            Contenedores.Commit();
            Vias.Commit();
            Recolecciones.Commit();
            File.WriteAllText(_rutaReloj, Formato.Fecha(Reloj) + Environment.NewLine);
        }

        /// <summary>Arma el grafo con los puntos (nodos) y las vías (aristas).</summary>
        public Grafo ConstruirGrafo()
        {
            var grafo = new Grafo();
            foreach (PuntoRecoleccion p in Puntos.GetAll())
                grafo.AgregarNodo(p.Id);

            foreach (Via v in Vias.GetAll())
            {
                if (!Puntos.Exist(v.OrigenId) || !Puntos.Exist(v.DestinoId))
                    throw new DatosInvalidosException($"La vía {v.Id} conecta un punto que no existe ({v.OrigenId} - {v.DestinoId}).");
                grafo.AgregarArista(v.OrigenId, v.DestinoId, v.DistanciaMetros);
            }
            return grafo;
        }

        public PuntoRecoleccion ObtenerAcopio() =>
            Puntos.GetAll().Find(p => p.Tipo == TipoPunto.Acopio)
            ?? throw new DatosInvalidosException("No hay ningún punto de tipo Acopio en puntos.txt.");

        public Lista<Contenedor> ContenedoresDe(long puntoId)
        {
            var resultado = new Lista<Contenedor>();
            foreach (Contenedor c in Contenedores.GetAll())
                if (c.PuntoId == puntoId) resultado.Add(c);
            return resultado;
        }

        public string Describir(Contenedor c)
        {
            string punto = Puntos.GetById(c.PuntoId)?.Nombre ?? $"Punto {c.PuntoId}";
            return $"{punto} · {Formato.Nombre(c.Tipo)}";
        }

        /// <summary>Siguiente Id libre (el mayor + 1).</summary>
        public static long SiguienteId<T>(Lista<T> lista) where T : IEntity<long>
        {
            long mayor = 0;
            foreach (T e in lista)
                if (e.Id > mayor) mayor = e.Id;
            return mayor + 1;
        }
    }
}
