using RutaCircular.Domain;
using RutaCircular.Exceptions;
using RutaCircular.Infraestructure;
using RutaCircular.Services;

namespace RutaCircular.Presentation
{
    public partial class FrLogin : Form
    {
        private readonly ServicioAutenticacion _autenticacion;

        public Usuario? UsuarioAutenticado { get; private set; }

        public FrLogin()
        {
            InitializeComponent();
            _autenticacion = new ServicioAutenticacion(Contexto.Instancia.Usuarios);
        }

        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            try
            {
                UsuarioAutenticado = _autenticacion.Autenticar(txtUsuario.Text, txtContrasena.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (RutaCircularException ex)
            {
                lblMensaje.Text = ex.Message;
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }
    }
}
