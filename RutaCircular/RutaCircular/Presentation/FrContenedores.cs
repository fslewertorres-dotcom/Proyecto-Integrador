using RutaCircular.Domain;
using RutaCircular.Exceptions;
using RutaCircular.Infraestructure;
using RutaCircular.Tools;

namespace RutaCircular.Presentation
{
    public partial class FrContenedores : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;
        private bool _cargando;

        public FrContenedores()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvContenedores);
            cbTipo.DataSource = Enum.GetValues<TipoResiduo>();
            cbPunto.DisplayMember = nameof(PuntoRecoleccion.Nombre);
            cbPunto.ValueMember = nameof(PuntoRecoleccion.Id);
            cbPunto.DataSource = _ctx.Puntos.GetAll().Where(p => p.TieneContenedores).ToList();
            CargarTabla();
            if (_ctx.Contenedores.Count == 0) Limpiar();
        }

        private void CargarTabla()
        {
            _cargando = true;
            dgvContenedores.DataSource = _ctx.Contenedores.GetAll()
                .Select(c => new
                {
                    c.Id,
                    Punto = _ctx.Puntos.GetById(c.PuntoId)?.Nombre ?? "¿?",
                    Tipo = Formato.Nombre(c.Tipo),
                    Capacidad = c.CapacidadLitros,
                    Nivel = Math.Round(c.NivelLitros, 1),
                    Llenado = $"{c.Porcentaje:0} %",
                    TasaBase = c.TasaBaseLitrosHora
                })
                .ToList();
            _cargando = false;
        }

        private void dgvContenedores_SelectionChanged(object? sender, EventArgs e)
        {
            if (_cargando || dgvContenedores.CurrentRow == null) return;
            long id = Convert.ToInt64(dgvContenedores.CurrentRow.Cells["Id"].Value);
            Contenedor? c = _ctx.Contenedores.GetById(id);
            if (c == null) return;

            Tool.AsignarSeguro(numId, c.Id);
            cbPunto.SelectedValue = c.PuntoId;
            cbTipo.SelectedItem = c.Tipo;
            Tool.AsignarSeguro(numCapacidad, c.CapacidadLitros);
            Tool.AsignarSeguro(numNivel, c.NivelLitros);
            Tool.AsignarSeguro(numTasa, c.TasaBaseLitrosHora);
            errorProvider.Clear();
        }

        private bool Validar()
        {
            errorProvider.Clear();
            bool valido = true;
            if (numId.Value <= 0)
            {
                errorProvider.SetError(numId, "El Id debe ser mayor que cero.");
                valido = false;
            }
            if (cbPunto.SelectedValue == null)
            {
                errorProvider.SetError(cbPunto, "Seleccione el punto donde está el contenedor.");
                valido = false;
            }
            if (numNivel.Value > numCapacidad.Value)
            {
                errorProvider.SetError(numNivel, "El nivel no puede ser mayor que la capacidad.");
                valido = false;
            }
            return valido;
        }

        private Contenedor LeerFormulario() => new()
        {
            Id = (long)numId.Value,
            PuntoId = (long)cbPunto.SelectedValue!,
            Tipo = (TipoResiduo)cbTipo.SelectedItem!,
            CapacidadLitros = (double)numCapacidad.Value,
            NivelLitros = (double)numNivel.Value,
            TasaBaseLitrosHora = (double)numTasa.Value
        };

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                _ctx.Contenedores.Add(LeerFormulario());
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
                _ctx.Contenedores.Update(LeerFormulario());
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
                if (!_ctx.Contenedores.Exist(id))
                    throw new ValidacionException($"No existe un contenedor con el Id {id}.");
                if (_ctx.Recolecciones.GetAll().Find(r => r.ContenedorId == id) != null)
                    throw new ValidacionException("El contenedor tiene recolecciones en el histórico; no se puede eliminar.");

                if (!Tool.Confirmar($"¿Eliminar el contenedor {id}?")) return;
                _ctx.Contenedores.Delete(id);
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
            Tool.AsignarSeguro(numId, Contexto.SiguienteId(_ctx.Contenedores.GetAll()));
            if (cbPunto.Items.Count > 0) cbPunto.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
            numCapacidad.Value = 120;
            numNivel.Value = 0;
            numTasa.Value = 0;
            errorProvider.Clear();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            try
            {
                await _ctx.Contenedores.CommitAsync();
                MessageBox.Show("Contenedores guardados en contenedores.txt.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
