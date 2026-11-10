namespace RutaCircular.DynamicStructure
{
    /// <summary>
    /// Cola de prioridad implementada como MIN-HEAP binario sobre un arreglo.
    /// Sale primero el elemento con MENOR prioridad (menos horas para llenarse = más urgente).
    ///
    /// Para el nodo en la posición i:  padre = (i-1)/2,  hijo izquierdo = 2i+1,  hijo derecho = 2i+2.
    ///
    /// Complejidad:  Encolar O(log n) · Desencolar O(log n) · VerPrimero O(1).
    /// Se prefirió a una lista ordenada (insertar O(n)) porque los contenedores cambian de prioridad
    /// todo el tiempo y Dijkstra también la usa muchas veces.
    /// </summary>
    public class ColaPrioridad<T>
    {
        private T[] _elementos;
        private double[] _prioridades;
        private int _count;

        public ColaPrioridad(int capacidadInicial = 16)
        {
            if (capacidadInicial < 1) capacidadInicial = 1;
            _elementos = new T[capacidadInicial];
            _prioridades = new double[capacidadInicial];
        }

        public int Count => _count;
        public bool IsEmpty => _count == 0;

        public void Encolar(T elemento, double prioridad)
        {
            if (_count == _elementos.Length) Crecer();
            _elementos[_count] = elemento;
            _prioridades[_count] = prioridad;
            Subir(_count);
            _count++;
        }

        public T Desencolar() => Desencolar(out _);

        public T Desencolar(out double prioridad)
        {
            if (_count == 0) throw new InvalidOperationException("La cola de prioridad está vacía.");
            T primero = _elementos[0];
            prioridad = _prioridades[0];

            _count--;
            _elementos[0] = _elementos[_count];
            _prioridades[0] = _prioridades[_count];
            _elementos[_count] = default!;
            if (_count > 0) Bajar(0);
            return primero;
        }

        public T VerPrimero()
        {
            if (_count == 0) throw new InvalidOperationException("La cola de prioridad está vacía.");
            return _elementos[0];
        }

        /// <summary>Sube el elemento mientras sea menor que su padre.</summary>
        private void Subir(int i)
        {
            while (i > 0)
            {
                int padre = (i - 1) / 2;
                if (_prioridades[i] >= _prioridades[padre]) break;
                Intercambiar(i, padre);
                i = padre;
            }
        }

        /// <summary>Baja el elemento mientras alguno de sus hijos sea menor.</summary>
        private void Bajar(int i)
        {
            while (true)
            {
                int izq = 2 * i + 1;
                int der = izq + 1;
                int menor = i;
                if (izq < _count && _prioridades[izq] < _prioridades[menor]) menor = izq;
                if (der < _count && _prioridades[der] < _prioridades[menor]) menor = der;
                if (menor == i) break;
                Intercambiar(i, menor);
                i = menor;
            }
        }

        private void Intercambiar(int a, int b)
        {
            (_elementos[a], _elementos[b]) = (_elementos[b], _elementos[a]);
            (_prioridades[a], _prioridades[b]) = (_prioridades[b], _prioridades[a]);
        }

        private void Crecer()
        {
            Array.Resize(ref _elementos, _elementos.Length * 2);
            Array.Resize(ref _prioridades, _prioridades.Length * 2);
        }
    }
}
