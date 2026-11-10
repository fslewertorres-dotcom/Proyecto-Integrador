using RutaCircular.Domain;
using RutaCircular.Exceptions;
using RutaCircular.Infraestructure;
using RutaCircular.Tools;

namespace RutaCircular.Presentation
{
    public partial class FrPuntos : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;
        private bool _cargando;

        public FrPuntos()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvPuntos);
            cbTipo.DataSource = Enum.GetValues<TipoPunto>();
            CargarTabla();
            if (_ctx.Puntos.Count == 0) Limpiar();
        }

        private void CargarTabla()
        {
            _cargando = true;
            dgvPuntos.DataSource = _ctx.Puntos.GetAll()
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    Tipo = Formato.Nombre(p.Tipo),
                    X = p.X,
                    Y = p.Y,
                    Casas = p.CasasAtendidas
                })
                .ToList();
            _cargando = false;
        }

        private void dgvPuntos_SelectionChanged(object? sender, EventArgs e)
        {
            if (_cargando || dgvPuntos.CurrentRow == null) return;
            long id = Convert.ToInt64(dgvPuntos.CurrentRow.Cells["Id"].Value);
            PuntoRecoleccion? p = _ctx.Puntos.GetById(id);
            if (p == null) return;

            Tool.AsignarSeguro(numId, p.Id);
            txtNombre.Text = p.Nombre;
            cbTipo.SelectedItem = p.Tipo;
            Tool.AsignarSeguro(numX, p.X);
            Tool.AsignarSeguro(numY, p.Y);
            Tool.AsignarSeguro(numCasas, p.CasasAtendidas);
            errorProvider.Clear();
        }

        private bool Validar()
        {
            errorProvider.Clear();
            bool valido = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Escriba el nombre del punto.");
                valido = false;
            }
            else if (txtNombre.Text.Contains(Formato.Separador))
            {
                errorProvider.SetError(txtNombre, "El nombre no puede tener ';' (es el separador del archivo).");
                valido = false;
            }
            if (numId.Value <= 0)
            {
                errorProvider.SetError(numId, "El Id debe ser mayor que cero.");
                valido = false;
            }
            return valido;
        }

        private PuntoRecoleccion LeerFormulario() => new()
        {
            Id = (long)numId.Value,
            Nombre = txtNombre.Text.Trim(),
            Tipo = (TipoPunto)cbTipo.SelectedItem!,
            X = (double)numX.Value,
            Y = (double)numY.Value,
            CasasAtendidas = (int)numCasas.Value
        };

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                _ctx.Puntos.Add(LeerFormulario());
                CargarTabla();
            }
            catch (RutaCircularException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                _ctx.Puntos.Update(LeerFormulario());
                CargarTabla();
            }
            catch (RutaCircularException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            long id = (long)numId.Value;
            try
            {
                if (!_ctx.Puntos.Exist(id))
                    throw new ValidacionException($"No existe un punto con el Id {id}.");
                if (_ctx.ContenedoresDe(id).Count > 0)
                    throw new ValidacionException("El punto tiene contenedores. Elimínelos primero.");
                foreach (Via v in _ctx.Vias.GetAll())
                    if (v.OrigenId == id || v.DestinoId == id)
                        throw new ValidacionException($"El punto está conectado por la vía {v.Id}. Elimine la vía primero.");

                if (!Tool.Confirmar($"¿Eliminar el punto {id}?")) return;
                _ctx.Puntos.Delete(id);
                CargarTabla();
                Limpiar();
            }
            catch (RutaCircularException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => Limpiar();

        private void Limpiar()
        {
            Tool.AsignarSeguro(numId, Contexto.SiguienteId(_ctx.Puntos.GetAll()));
            txtNombre.Clear();
            cbTipo.SelectedIndex = 0;
            numX.Value = numX.Minimum;
            numY.Value = numY.Minimum;
            numCasas.Value = numCasas.Minimum;
            errorProvider.Clear();
            txtNombre.Focus();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            try
            {
                await _ctx.Puntos.CommitAsync();
                MessageBox.Show("Puntos guardados en puntos.txt.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
