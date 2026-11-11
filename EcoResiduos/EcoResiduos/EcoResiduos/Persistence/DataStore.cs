using System.Text;
using EcoResiduos.Contracts;
using EcoResiduos.DynamicStructure;
using EcoResiduos.Exceptions;

namespace EcoResiduos.Persistence
{
    /// <summary>
    /// Guarda y carga cualquier entidad en un archivo de texto, una línea por objeto.
    /// Las líneas vacías o que empiezan con '#' se ignoran (sirven de encabezado).
    /// </summary>
    public class DataStore<T> : IDataStore<T> where T : class, IFactory<T>, ISerialize<T>
    {
        private static readonly Encoding Utf8SinBom = new UTF8Encoding(false);
        private readonly string _path;
        private readonly string? _encabezado;

        public DataStore(string path, string? encabezado = null)
        {
            _path = path;
            _encabezado = encabezado;
        }

        public Lista<T> LoadAll()
        {
            var lista = new Lista<T>();
            if (!File.Exists(_path)) return lista;

            try
            {
                using var sr = new StreamReader(_path, Encoding.UTF8);
                int numeroLinea = 0;
                while (!sr.EndOfStream)
                {
                    string linea = sr.ReadLine() ?? string.Empty;
                    numeroLinea++;
                    if (string.IsNullOrWhiteSpace(linea) || linea.TrimStart().StartsWith('#'))
                        continue;

                    try
                    {
                        lista.Add(T.Create(linea));
                    }
                    catch (Exception ex) when (ex is FormatException || ex is OverflowException || ex is ArgumentException)
                    {
                        throw new DatosInvalidosException(
                            $"Error en el archivo {Path.GetFileName(_path)}, línea {numeroLinea}: {ex.Message}", ex);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new EcoResiduosException($"No se pudo leer {Path.GetFileName(_path)}: {ex.Message}", ex);
            }
            return lista;
        }

        public void SaveAll(Lista<T> list)
        {
            try
            {
                CrearCarpeta();
                File.WriteAllText(_path, ConstruirTexto(list), Utf8SinBom);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                throw new EcoResiduosException($"No se pudo guardar {Path.GetFileName(_path)}: {ex.Message}", ex);
            }
        }

        /// <summary>Versión asíncrona: la ventana no se congela mientras se escribe el archivo.</summary>
        public async Task SaveAllAsync(Lista<T> list)
        {
            try
            {
                CrearCarpeta();
                string texto = ConstruirTexto(list);
                await File.WriteAllTextAsync(_path, texto, Utf8SinBom);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                throw new EcoResiduosException($"No se pudo guardar {Path.GetFileName(_path)}: {ex.Message}", ex);
            }
        }

        private string ConstruirTexto(Lista<T> list)
        {
            var sb = new StringBuilder();
            if (_encabezado != null) sb.AppendLine(_encabezado);
            // REFACTOR: antes se recorría con for + ElementAt(i) → O(n²). Ahora foreach → O(n).
            foreach (T dato in list)
                sb.AppendLine(T.Serialize(dato));
            return sb.ToString();
        }

        private void CrearCarpeta()
        {
            string? carpeta = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(carpeta)) Directory.CreateDirectory(carpeta);
        }
    }
}
