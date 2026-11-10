using RutaCircular.Domain;
using RutaCircular.Exceptions;
using RutaCircular.Infraestructure;
using RutaCircular.Services;
using RutaCircular.Tools;

namespace RutaCircular.Presentation
{
    /// <summary>Edición de las vías del conjunto (aristas del grafo).</summary>
    public partial class FrVias : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;
        private readonly ServicioVias _servicio;
        private bool _cargando;

        public FrVias()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvVias);
            _servicio = new ServicioVias(_ctx);
            ConfigurarCombo(cbOrigen);
            ConfigurarCombo(cbDestino);
            CargarTabla();
            Limpiar();
        }

        private void ConfigurarCombo(ComboBox combo)
        {
            combo.DisplayMember = nameof(PuntoRecoleccion.Nombre);
            combo.ValueMember = nameof(PuntoRecoleccion.Id);
            // Cada combo necesita su propia lista; si comparten la misma, al cambiar uno cambia el otro.
            combo.DataSource = _ctx.Puntos.GetAll().ToList();
        }

        private string NombrePunto(long id) => _ctx.Puntos.GetById(id)?.Nombre ?? $"¿{id}?";

        private void CargarTabla()
        {
            _cargando = true;
            dgvVias.DataSource = _ctx.Vias.GetAll()
                .Select(v => new
                {
                    v.Id,
                    Origen = NombrePunto(v.OrigenId),
                    Destino = NombrePunto(v.DestinoId),
                    Distancia = v.DistanciaMetros
                })
                .ToList();
            _cargando = false;
        }

        private void dgvVias_SelectionChanged(object? sender, EventArgs e)
        {
            if (_cargando || dgvVias.CurrentRow == null) return;
            long id = Convert.ToInt64(dgvVias.CurrentRow.Cells["Id"].Value);
            Via? v = _ctx.Vias.GetById(id);
            if (v == null) return;

            Tool.AsignarSeguro(numId, v.Id);
            cbOrigen.SelectedValue = v.OrigenId;
            cbDestino.SelectedValue = v.DestinoId;
            Tool.AsignarSeguro(numDistancia, v.DistanciaMetros);
        }

        private Via LeerFormulario() =>
            _servicio.Preparar((long)numId.Value,
                               cbOrigen.SelectedValue is long o ? o : 0,
                               cbDestino.SelectedValue is long d ? d : 0,
                               (double)numDistancia.Value);

        private void btnCalcularDistancia_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cbOrigen.SelectedValue is long o && cbDestino.SelectedValue is long d)
                    Tool.AsignarSeguro(numDistancia, _servicio.DistanciaEuclidiana(o, d));
            }
            catch (RutaCircularException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            try
            {
                _ctx.Vias.Add(LeerFormulario());
                CargarTabla();
                Limpiar();
            }
            catch (RutaCircularException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            try
            {
                _ctx.Vias.Update(LeerFormulario());
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
            if (!_ctx.Vias.Exist(id))
            {
                Tool.MostrarError(new ValidacionException($"No existe una vía con el Id {id}."));
                return;
            }
            if (!Tool.Confirmar($"¿Eliminar la vía {id}?")) return;
            try
            {
                _ctx.Vias.Delete(id);
                CargarTabla();
                Limpiar();
                AdvertirSiHayAislados();
            }
            catch (RutaCircularException ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void AdvertirSiHayAislados()
        {
            List<string> aislados = _servicio.PuntosInalcanzables();
            if (aislados.Count > 0)
                MessageBox.Show("Atención: ya no hay camino desde el acopio hasta:\n• " + string.Join("\n• ", aislados) +
                                "\n\nLa ruta del día fallará hasta que se conecten otra vez.",
                                "Vías", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLimpiar_Click(object? sender, EventArgs e) => Limpiar();

        private void Limpiar()
        {
            Tool.AsignarSeguro(numId, Contexto.SiguienteId(_ctx.Vias.GetAll()));
            if (cbOrigen.Items.Count > 0) cbOrigen.SelectedIndex = 0;
            if (cbDestino.Items.Count > 1) cbDestino.SelectedIndex = 1;
            numDistancia.Value = 0;
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            try
            {
                await _ctx.Vias.CommitAsync();
                MessageBox.Show("Vías guardadas en vias.txt. Cierre y vuelva a abrir el mapa para ver los cambios.",
                                "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
