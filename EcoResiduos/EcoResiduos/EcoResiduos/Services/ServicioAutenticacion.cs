using EcoResiduos.Domain;
using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;

namespace EcoResiduos.Services
{
    public class ServicioAutenticacion
    {
        private readonly Repository<Usuario, long> _usuarios;

        public ServicioAutenticacion(Repository<Usuario, long> usuarios)
        {
            _usuarios = usuarios;
        }

        /// <summary>La primera vez que se ejecuta el programa no hay usuarios: se crean dos de prueba.</summary>
        public void CrearUsuariosPorDefecto()
        {
            if (_usuarios.Count > 0) return;

            Administrador admin = new Administrador();
            admin.Id = 1;
            admin.NombreUsuario = "admin";
            admin.NombreCompleto = "Administración del conjunto";
            admin.EstablecerContrasena("admin123");

            Operario operario = new Operario();
            operario.Id = 2;
            operario.NombreUsuario = "operario";
            operario.NombreCompleto = "Operario de aseo";
            operario.EstablecerContrasena("operario123");

            _usuarios.Add(admin);
            _usuarios.Add(operario);
            _usuarios.Commit();
        }

        public Usuario Autenticar(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrEmpty(contrasena))
                throw new ValidacionException("Escriba el usuario y la contraseña.");

            Usuario? usuario = _usuarios.GetAll().Find(u =>
                u.NombreUsuario.Equals(nombreUsuario.Trim(), StringComparison.OrdinalIgnoreCase));

            if (usuario == null || !usuario.VerificarContrasena(contrasena))
                throw new AutenticacionException("Usuario o contraseña incorrectos.");

            Sesion.Iniciar(usuario);
            return usuario;
        }
    }
}
