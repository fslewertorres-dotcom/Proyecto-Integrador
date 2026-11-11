using System.Text;
using EcoResiduos.Services;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>
    /// Comparación práctica de algoritmos: mide tiempos y cuenta comparaciones para varios tamaños
    /// y los compara con la teoría (n·log₂n, n/2, log₂n).
    /// </summary>
    public partial class FrRendimiento : Form
    {
        private readonly List<FilaResultado> _filas = new();

        public FrRendimiento()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvResultados);
        }

        public class FilaResultado
        {
            public int N { get; set; }
            public double QuickSortMs { get; set; }
            public long ComparacionesQS { get; set; }
            public double NLog2N { get; set; }
            public double QSsobreNLogN { get; set; }
            public double ArraySortMs { get; set; }
            public double LinealPorBusqueda { get; set; }
            public double MitadDeN { get; set; }
            public double BinariaPorBusqueda { get; set; }
            public double Log2N { get; set; }
            public double LinealMs { get; set; }
            public double BinariaMs { get; set; }
        }

        private async void btnEjecutar_Click(object? sender, EventArgs e)
        {
            var tamanos = new List<int>();
            if (chk1000.Checked) tamanos.Add(1_000);
            if (chk10000.Checked) tamanos.Add(10_000);
            if (chk100000.Checked) tamanos.Add(100_000);
            if (tamanos.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un tamaño.", "Comparación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int consultas = (int)numConsultas.Value;

            btnEjecutar.Enabled = false;
            progreso.Visible = true;
            try
            {
                _filas.Clear();
                dgvResultados.DataSource = null;

                // Calentamiento: la primera ejecución incluye la compilación JIT y daría tiempos inflados.
                await ServicioRendimiento.CompararAsync(500, 10);

                foreach (int n in tamanos)
                {
                    lblEstado.Text = $"Midiendo n = {n:N0}...";
                    ResultadoRendimiento r = await ServicioRendimiento.CompararAsync(n, consultas);
                    if (!r.OrdenCorrecto)
                        throw new InvalidOperationException("QuickSort no dejó el arreglo ordenado.");

                    _filas.Add(new FilaResultado
                    {
                        N = r.N,
                        QuickSortMs = Math.Round(r.MsQuickSort, 3),
                        ComparacionesQS = r.ComparacionesQuickSort,
                        NLog2N = Math.Round(r.NLog2N),
                        QSsobreNLogN = Math.Round(r.ComparacionesQuickSort / r.NLog2N, 2),
                        ArraySortMs = Math.Round(r.MsArraySort, 3),
                        LinealPorBusqueda = Math.Round((double)r.ComparacionesLineal / r.Consultas, 1),
                        MitadDeN = r.N / 2.0,
                        BinariaPorBusqueda = Math.Round((double)r.ComparacionesBinaria / r.Consultas, 1),
                        Log2N = Math.Round(r.Log2N, 1),
                        LinealMs = Math.Round(r.MsLineal, 3),
                        BinariaMs = Math.Round(r.MsBinaria, 3)
                    });
                    dgvResultados.DataSource = null;
                    dgvResultados.DataSource = _filas.ToList();
                }
                lblEstado.Text = "Listo.";
                txtConclusion.Text = Conclusiones(consultas);
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error.";
                Tool.MostrarError(ex);
            }
            finally
            {
                progreso.Visible = false;
                btnEjecutar.Enabled = true;
            }
        }

        private string Conclusiones(int consultas)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Datos: recolecciones generadas al azar (semilla fija = resultados repetibles). Búsquedas por tamaño: {consultas}.");
            sb.AppendLine();
            sb.AppendLine("ORDENAMIENTO");
            sb.AppendLine("  Si QuickSort es O(n log n), la columna 'QSsobreNLogN' (comparaciones ÷ n·log₂n) debe mantenerse casi constante.");
            foreach (FilaResultado f in _filas)
                sb.AppendLine($"    n = {f.N,7:N0}: {f.ComparacionesQS,12:N0} comparaciones → {f.QSsobreNLogN:0.00} × n·log₂n");
            for (int i = 1; i < _filas.Count; i++)
            {
                FilaResultado a = _filas[i - 1], b = _filas[i];
                double crecimientoTeorico = b.NLog2N / a.NLog2N;
                double crecimientoReal = (double)b.ComparacionesQS / a.ComparacionesQS;
                sb.AppendLine($"  De n = {a.N:N0} a {b.N:N0}: la teoría dice ×{crecimientoTeorico:0.0}; las comparaciones crecieron ×{crecimientoReal:0.0}.");
            }
            sb.AppendLine("  Array.Sort de .NET también es O(n log n) (IntroSort) pero está más optimizado, por eso suele ser más rápido.");
            sb.AppendLine();
            sb.AppendLine("BÚSQUEDA");
            foreach (FilaResultado f in _filas)
                sb.AppendLine($"    n = {f.N,7:N0}: lineal ≈ {f.LinealPorBusqueda,9:N1} comparaciones (n/2 = {f.MitadDeN:N0}) · " +
                              $"binaria ≈ {f.BinariaPorBusqueda:0.0} (log₂n = {f.Log2N:0.0})");
            sb.AppendLine("  La lineal crece igual que n; la binaria apenas crece (cada comparación descarta la mitad).");
            sb.AppendLine("  Por eso el histórico se ordena primero (O(n log n), una sola vez) y luego cada búsqueda cuesta O(log n).");
            sb.AppendLine();
            sb.AppendLine("Nota: los milisegundos dependen del computador; las comparaciones no. Por eso el análisis se apoya en las comparaciones.");
            return sb.ToString();
        }
    }
}
