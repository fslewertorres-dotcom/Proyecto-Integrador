using EcoResiduos.Domain;
using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;
using EcoResiduos.Services;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>El administrador crea, modifica y elimina usuarios (por ejemplo, nuevos operarios).</summary>
    public partial class FrUsuarios : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;
        private readonly ServicioUsuarios _servicio;
        private bool _cargando;

        public FrUsuarios()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvUsuarios);
            _servicio = new ServicioUsuarios(_ctx.Usuarios);
            cbRol.Items.AddRange(ServicioUsuarios.Roles);
            CargarTabla();
            Limpiar();
        }

        private static Usuario UsuarioActual =>
            Sesion.UsuarioActual ?? throw new InvalidOperationException("No hay una sesión iniciada.");

        private void CargarTabla()
        {
            _cargando = true;
            // Nunca se muestra el hash de la contraseña
            dgvUsuarios.DataSource = _ctx.Usuarios.GetAll()
                .Select(u => new { u.Id, Usuario = u.NombreUsuario, Nombre = u.NombreCompleto, u.Rol })
                .ToList();
            _cargando = false;
        }

        private void dgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            if (_cargando || dgvUsuarios.CurrentRow == null) return;
            long id = Convert.ToInt64(dgvUsuarios.CurrentRow.Cells["Id"].Value);
            Usuario? u = _ctx.Usuarios.GetById(id);
            if (u == null) return;

            Tool.AsignarSeguro(numId, u.Id);
            txtUsuario.Text = u.NombreUsuario;
            txtNombre.Text = u.NombreCompleto;
            cbRol.SelectedItem = u.Rol;
            txtContrasena.Clear();
            txtConfirmar.Clear();
        }

        private string RolSeleccionado => cbRol.SelectedItem?.ToString() ?? string.Empty;

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            try
            {
                Usuario u = _servicio.Crear((long)numId.Value, txtUsuario.Text, txtNombre.Text, RolSeleccionado,
                                            txtContrasena.Text, txtConfirmar.Text);
                CargarTabla();
                Limpiar();
                MessageBox.Show($"Usuario '{u.NombreUsuario}' creado. Recuerde guardar.", "Usuarios",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (EcoResiduosException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            try
            {
                _servicio.Actualizar((long)numId.Value, txtUsuario.Text, txtNombre.Text, RolSeleccionado,
                                     txtContrasena.Text, txtConfirmar.Text, UsuarioActual);
                CargarTabla();
                txtContrasena.Clear();
                txtConfirmar.Clear();
            }
            catch (EcoResiduosException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            long id = (long)numId.Value;
            if (!Tool.Confirmar($"¿Eliminar el usuario {id}?")) return;
            try
            {
                _servicio.Eliminar(id, UsuarioActual);
                CargarTabla();
                Limpiar();
            }
            catch (EcoResiduosException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => Limpiar();

        private void Limpiar()
        {
            Tool.AsignarSeguro(numId, Contexto.SiguienteId(_ctx.Usuarios.GetAll()));
            txtUsuario.Clear();
            txtNombre.Clear();
            cbRol.SelectedItem = "Operario";
            txtContrasena.Clear();
            txtConfirmar.Clear();
            txtUsuario.Focus();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            try
            {
                await _ctx.Usuarios.CommitAsync();
                MessageBox.Show("Usuarios guardados en usuarios.txt.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}
