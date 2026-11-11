using EcoResiduos.Domain;
using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;

namespace EcoResiduos.Services
{
    /// <summary>
    /// Reglas para administrar usuarios. El formulario solo muestra y captura datos;
    /// todas las validaciones están aquí (separación de responsabilidades).
    /// </summary>
    public class ServicioUsuarios
    {
        public const int LongitudMinimaContrasena = 6;
        public static readonly string[] Roles = { "Administrador", "Operario" };

        private readonly Repository<Usuario, long> _usuarios;

        public ServicioUsuarios(Repository<Usuario, long> usuarios)
        {
            _usuarios = usuarios;
        }

        public Usuario Crear(long id, string nombreUsuario, string nombreCompleto, string rol,
                             string contrasena, string confirmacion)
        {
            ValidarDatos(id, nombreUsuario, nombreCompleto, esNuevo: true);
            ValidarContrasena(contrasena, confirmacion);

            Usuario usuario = NuevaInstancia(rol);
            usuario.Id = id;
            usuario.NombreUsuario = nombreUsuario.Trim();
            usuario.NombreCompleto = nombreCompleto.Trim();
            usuario.EstablecerContrasena(contrasena);
            _usuarios.Add(usuario);
            return usuario;
        }

        /// <summary>Si la contraseña se deja vacía, se conserva la anterior.</summary>
        public Usuario Actualizar(long id, string nombreUsuario, string nombreCompleto, string rol,
                                  string contrasena, string confirmacion, Usuario usuarioActual)
        {
            Usuario anterior = _usuarios.GetById(id)
                ?? throw new ValidacionException($"No existe un usuario con el Id {id}.");
            ValidarDatos(id, nombreUsuario, nombreCompleto, esNuevo: false);

            if (anterior is Administrador && rol != "Administrador")
            {
                if (ContarAdministradores() == 1)
                    throw new ValidacionException("No se puede quitar el rol al único administrador.");
                if (anterior.Id == usuarioActual.Id)
                    throw new ValidacionException("No puede quitarse a sí mismo el rol de administrador.");
            }

            // El rol es una clase (Administrador u Operario), así que se crea un objeto nuevo del tipo correcto.
            Usuario actualizado = NuevaInstancia(rol);
            actualizado.Id = id;
            actualizado.NombreUsuario = nombreUsuario.Trim();
            actualizado.NombreCompleto = nombreCompleto.Trim();

            if (string.IsNullOrEmpty(contrasena) && string.IsNullOrEmpty(confirmacion))
            {
                actualizado.HashContrasena = anterior.HashContrasena;
            }
            else
            {
                ValidarContrasena(contrasena, confirmacion);
                actualizado.EstablecerContrasena(contrasena);
            }

            _usuarios.Update(actualizado);
            return actualizado;
        }

        public void Eliminar(long id, Usuario usuarioActual)
        {
            Usuario usuario = _usuarios.GetById(id)
                ?? throw new ValidacionException($"No existe un usuario con el Id {id}.");
            if (usuario.Id == usuarioActual.Id)
                throw new ValidacionException("No puede eliminar el usuario con el que inició sesión.");
            if (usuario is Administrador && ContarAdministradores() == 1)
                throw new ValidacionException("No se puede eliminar el único administrador.");
            _usuarios.Delete(id);
        }

        private void ValidarDatos(long id, string nombreUsuario, string nombreCompleto, bool esNuevo)
        {
            if (id <= 0) throw new ValidacionException("El Id debe ser mayor que cero.");
            if (esNuevo && _usuarios.Exist(id)) throw new ValidacionException($"Ya existe un usuario con el Id {id}.");

            string nombre = nombreUsuario.Trim();
            if (nombre.Length < 3) throw new ValidacionException("El nombre de usuario debe tener al menos 3 caracteres.");
            if (nombre.Contains(' ')) throw new ValidacionException("El nombre de usuario no puede tener espacios.");
            if (string.IsNullOrWhiteSpace(nombreCompleto)) throw new ValidacionException("Escriba el nombre completo.");
            if (nombre.Contains(Formato.Separador) || nombreCompleto.Contains(Formato.Separador))
                throw new ValidacionException("Los nombres no pueden tener ';' (es el separador del archivo).");

            Usuario? mismoNombre = _usuarios.GetAll().Find(u =>
                u.NombreUsuario.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (mismoNombre != null && mismoNombre.Id != id)
                throw new ValidacionException($"El nombre de usuario '{nombre}' ya está en uso.");
        }

        private static void ValidarContrasena(string contrasena, string confirmacion)
        {
            if (string.IsNullOrEmpty(contrasena) || contrasena.Length < LongitudMinimaContrasena)
                throw new ValidacionException($"La contraseña debe tener al menos {LongitudMinimaContrasena} caracteres.");
            if (contrasena != confirmacion)
                throw new ValidacionException("La contraseña y la confirmación no coinciden.");
        }

        private static Usuario NuevaInstancia(string rol)
        {
            switch (rol)
            {
                case "Administrador":
                    return new Administrador();
                case "Operario":
                    return new Operario();
                default:
                    throw new ValidacionException("Seleccione un rol válido.");
            }
        }

        private int ContarAdministradores()
        {
            int n = 0;
            foreach (Usuario u in _usuarios.GetAll())
                if (u is Administrador) n++;
            return n;
        }
    }
}
