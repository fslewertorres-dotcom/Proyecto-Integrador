using System.Security.Cryptography;
using System.Text;
using RutaCircular.Contracts;

namespace RutaCircular.Domain
{
    /// <summary>
    /// Clase abstracta: no existe un "usuario" genérico, solo Administrador u Operario.
    /// Cada hija decide qué puede hacer (polimorfismo), y el menú principal se arma con eso.
    /// </summary>
    public abstract class Usuario : IEntity<long>, IFactory<Usuario>, ISerialize<Usuario>
    {
        public long Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        /// <summary>Nunca se guarda la contraseña, solo su hash SHA-256.</summary>
        public string HashContrasena { get; set; } = string.Empty;

        public abstract string Rol { get; }
        public abstract bool PuedeConfigurar { get; }
        public abstract bool PuedeRegistrarRecolecciones { get; }
        public abstract bool PuedeVerAnalisis { get; }

        public void EstablecerContrasena(string contrasena) => HashContrasena = CalcularHash(contrasena);

        public bool VerificarContrasena(string contrasena) =>
            string.Equals(HashContrasena, CalcularHash(contrasena), StringComparison.OrdinalIgnoreCase);

        public static string CalcularHash(string texto)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
            return Convert.ToHexString(hash);
        }

        public static Usuario Create(string textCsv) => Deserialize(textCsv);

        public static Usuario Deserialize(string textCsv)
        {
            string[] m = Formato.Campos(textCsv, 5, nameof(Usuario));
            Usuario usuario;
            string rol = m[1].Trim();
            if (rol == "Administrador")
                usuario = new Administrador();
            else if (rol == "Operario")
                usuario = new Operario();
            else
                throw new FormatException($"Rol desconocido: {m[1]}");
            usuario.Id = long.Parse(m[0]);
            usuario.NombreUsuario = m[2].Trim();
            usuario.NombreCompleto = m[3].Trim();
            usuario.HashContrasena = m[4].Trim();
            return usuario;
        }

        public static string Serialize(Usuario u) =>
            string.Join(Formato.Separador, u.Id, u.Rol, u.NombreUsuario, u.NombreCompleto, u.HashContrasena);

        public override string ToString() => $"{NombreCompleto} ({Rol})";
    }

    public class Administrador : Usuario
    {
        public override string Rol => "Administrador";
        public override bool PuedeConfigurar => true;
        public override bool PuedeRegistrarRecolecciones => true;
        public override bool PuedeVerAnalisis => true;
    }

    public class Operario : Usuario
    {
        public override string Rol => "Operario";
        public override bool PuedeConfigurar => false;
        public override bool PuedeRegistrarRecolecciones => true;
        public override bool PuedeVerAnalisis => false;
    }
}
