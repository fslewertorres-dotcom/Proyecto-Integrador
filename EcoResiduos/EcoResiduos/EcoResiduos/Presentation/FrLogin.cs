using EcoResiduos.Domain;
using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;
using EcoResiduos.Services;

namespace EcoResiduos.Presentation
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
            catch (EcoResiduosException ex)
            {
                lblMensaje.Text = ex.Message;
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }
    }
}
