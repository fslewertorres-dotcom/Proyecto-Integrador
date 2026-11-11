using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;
using EcoResiduos.Presentation;
using EcoResiduos.Services;
using EcoResiduos.Tools;

namespace EcoResiduos
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
            catch (EcoResiduosException ex)
            {
                MessageBox.Show($"No se pudieron cargar los datos:\n\n{ex.Message}", "EcoResiduos",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ciclo de sesiones: login → ventana principal. Si el usuario usa Archivo → Salir,
            // se cierra la sesión y vuelve a aparecer el login. Si cierra el login o la ventana con la X, el programa termina.
            while (true)
            {
                using (var login = new FrLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                }

                bool volverAlLogin;
                using (var principal = new FrMain())
                {
                    Application.Run(principal);
                    volverAlLogin = principal.VolverAlLogin;
                }

                Sesion.Cerrar();
                if (!volverAlLogin) return;
            }
        }
    }
}
