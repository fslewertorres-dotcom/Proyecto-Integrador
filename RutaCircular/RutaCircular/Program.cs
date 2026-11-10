using RutaCircular.Exceptions;
using RutaCircular.Infraestructure;
using RutaCircular.Presentation;
using RutaCircular.Services;
using RutaCircular.Tools;

namespace RutaCircular
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cualquier excepción que se escape de un evento se muestra en un mensaje en vez de cerrar el programa.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => Tool.MostrarError(e.Exception);

            try
            {
                Contexto contexto = Contexto.Instancia;   // carga los .txt
                new ServicioAutenticacion(contexto.Usuarios).CrearUsuariosPorDefecto();
            }
            catch (RutaCircularException ex)
            {
                MessageBox.Show($"No se pudieron cargar los datos:\n\n{ex.Message}", "Ruta Circular",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var login = new FrLogin())
            {
                if (login.ShowDialog() != DialogResult.OK) return;
            }

            Application.Run(new FrMain());
        }
    }
}
