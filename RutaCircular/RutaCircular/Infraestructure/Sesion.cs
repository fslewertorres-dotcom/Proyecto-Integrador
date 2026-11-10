using RutaCircular.Domain;

namespace RutaCircular.Infraestructure
{
    /// <summary>Guarda quién inició sesión, para que cualquier formulario lo consulte.</summary>
    public static class Sesion
    {
        public static Usuario? UsuarioActual { get; private set; }

        public static void Iniciar(Usuario usuario) => UsuarioActual = usuario;

        public static void Cerrar() => UsuarioActual = null;
    }
}
