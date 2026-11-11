namespace EcoResiduos.Exceptions
{
    /// <summary>Excepción base del sistema. Todas las propias heredan de esta.</summary>
    public class EcoResiduosException : Exception
    {
        public EcoResiduosException(string mensaje) : base(mensaje) { }
        public EcoResiduosException(string mensaje, Exception interna) : base(mensaje, interna) { }
    }

    /// <summary>Un archivo .txt tiene una línea con formato incorrecto.</summary>
    public class DatosInvalidosException : EcoResiduosException
    {
        public DatosInvalidosException(string mensaje) : base(mensaje) { }
        public DatosInvalidosException(string mensaje, Exception interna) : base(mensaje, interna) { }
    }

    /// <summary>Usuario o contraseña incorrectos.</summary>
    public class AutenticacionException : EcoResiduosException
    {
        public AutenticacionException(string mensaje) : base(mensaje) { }
    }

    /// <summary>Una regla de negocio no se cumple (Id repetido, valores negativos, etc.).</summary>
    public class ValidacionException : EcoResiduosException
    {
        public ValidacionException(string mensaje) : base(mensaje) { }
    }
}
