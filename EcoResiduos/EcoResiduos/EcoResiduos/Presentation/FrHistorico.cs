using System.Diagnostics;
using EcoResiduos.Domain;
using EcoResiduos.DynamicStructure;
using EcoResiduos.Infraestructure;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>
    /// Histórico de recolecciones: ordenamiento con nuestro QuickSort y búsqueda binaria por fecha.
    /// Se trabaja sobre un ARREGLO (copia de la lista enlazada) porque QuickSort y la búsqueda binaria
    /// necesitan acceso por índice en O(1), que la lista enlazada no tiene.
    /// </summary>
    public partial class FrHistorico : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;
        private Recoleccion[] _datos = Array.Empty<Recoleccion>();

        public FrHistorico()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvHistorico);
            cbCampo.Items.AddRange(new object[] { "Fecha", "Litros", "Contenedor" });
            cbSentido.Items.AddRange(new object[] { "Ascendente", "Descendente" });
            cbCampo.SelectedIndex = 0;
            cbSentido.SelectedIndex = 0;
            Recargar();
        }

        private void Recargar()
        {
            _datos = _ctx.Recolecciones.GetAll().ToArray();
            Mostrar();
            if (_datos.Length > 0) dtpFecha.Value = _datos[^1].Fecha.Date;
            lblInfo.Text = $"{_datos.Length} recolecciones en el histórico.";
        }

        private void Mostrar()
        {
            dgvHistorico.DataSource = _datos
                .Select(r => new
                {
                    r.Id,
                    Fecha = r.Fecha.ToString("yyyy-MM-dd HH:mm"),
                    Dia = Formato.Nombre(r.Fecha.DayOfWeek),
                    Contenedor = r.ContenedorId,
                    Descripcion = DescribirContenedor(r.ContenedorId),
                    r.Litros,
                    Kg = Math.Round(r.Kg, 1),
                    Operario = r.OperarioId
                })
                .ToList();
        }

        private string DescribirContenedor(long id)
        {
            Contenedor? c = _ctx.Contenedores.GetById(id);
            return c == null ? "(eliminado)" : _ctx.Describir(c);
        }

        private Comparison<Recoleccion> Comparador()
        {
            Comparison<Recoleccion> comparar = cbCampo.SelectedIndex switch
            {
                1 => (a, b) => a.Litros.CompareTo(b.Litros),
                2 => (a, b) => a.ContenedorId.CompareTo(b.ContenedorId),
                _ => (a, b) => a.Fecha.CompareTo(b.Fecha)
            };
            if (cbSentido.SelectedIndex == 1)
                return (a, b) => comparar(b, a);
            return comparar;
        }

        private void btnOrdenar_Click(object? sender, EventArgs e)
        {
            try
            {
                var sw = Stopwatch.StartNew();
                long comparaciones = Ordenamiento.QuickSort(_datos, Comparador());
                sw.Stop();
                Mostrar();
                double nLogN = _datos.Length * Math.Log2(Math.Max(2, _datos.Length));
                lblInfo.Text = $"QuickSort ordenó {_datos.Length} registros por {cbCampo.Text.ToLower()} con " +
                               $"{comparaciones:N0} comparaciones en {sw.Elapsed.TotalMilliseconds:0.###} ms " +
                               $"(referencia n·log₂n ≈ {nLogN:N0}).";
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            if (_datos.Length == 0) return;
            try
            {
                // La búsqueda binaria SOLO funciona si el arreglo está ordenado por la misma clave.
                Ordenamiento.QuickSort(_datos, (a, b) => a.Fecha.CompareTo(b.Fecha));
                cbCampo.SelectedIndex = 0;
                cbSentido.SelectedIndex = 0;
                Mostrar();

                DateTime dia = dtpFecha.Value.Date;
                int pos = Ordenamiento.BusquedaBinaria(_datos, dia, r => r.Fecha, out int comparaciones);

                if (pos < _datos.Length && _datos[pos].Fecha.Date == dia)
                {
                    dgvHistorico.ClearSelection();
                    dgvHistorico.Rows[pos].Selected = true;
                    dgvHistorico.CurrentCell = dgvHistorico.Rows[pos].Cells[0];
                    lblInfo.Text = $"Primera recolección del {dia:dd/MM/yyyy}: fila {pos + 1}. " +
                                   $"Búsqueda binaria: {comparaciones} comparaciones " +
                                   $"(una búsqueda lineal habría usado {pos + 1}).";
                }
                else
                {
                    lblInfo.Text = $"No hay recolecciones el {dia:dd/MM/yyyy} ({comparaciones} comparaciones).";
                }
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void btnRecargar_Click(object? sender, EventArgs e) => Recargar();
    }
}
