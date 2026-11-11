namespace EcoResiduos.DynamicStructure
{
    /// <summary>
    /// Algoritmos propios de ordenamiento y búsqueda. Devuelven el número de comparaciones
    /// para poder compararlos en la práctica con el análisis Big-O.
    /// </summary>
    public static class Ordenamiento
    {
        /// <summary>
        /// QuickSort con partición de Hoare y pivote en el CENTRO.
        /// Promedio O(n log n), peor caso O(n²).
        /// Se usa el pivote central porque el histórico casi siempre viene ordenado por fecha:
        /// con el pivote en el extremo, un arreglo ya ordenado cae en el peor caso O(n²).
        /// Para no desbordar la pila, se hace recursión solo sobre la parte más pequeña.
        /// </summary>
        public static long QuickSort<T>(T[] arreglo, Comparison<T> comparar)
        {
            long comparaciones = 0;
            if (arreglo.Length > 1)
                QuickSort(arreglo, 0, arreglo.Length - 1, comparar, ref comparaciones);
            return comparaciones;
        }

        private static void QuickSort<T>(T[] a, int izq, int der, Comparison<T> comparar, ref long comps)
        {
            while (izq < der)
            {
                int p = Particion(a, izq, der, comparar, ref comps);
                if (p - izq < der - p)
                {
                    QuickSort(a, izq, p, comparar, ref comps);
                    izq = p + 1;
                }
                else
                {
                    QuickSort(a, p + 1, der, comparar, ref comps);
                    der = p;
                }
            }
        }

        private static int Particion<T>(T[] a, int izq, int der, Comparison<T> comparar, ref long comps)
        {
            T pivote = a[izq + (der - izq) / 2];
            int i = izq - 1;
            int j = der + 1;
            while (true)
            {
                do { i++; comps++; } while (comparar(a[i], pivote) < 0);
                do { j--; comps++; } while (comparar(a[j], pivote) > 0);
                if (i >= j) return j;
                (a[i], a[j]) = (a[j], a[i]);
            }
        }

        /// <summary>
        /// Búsqueda binaria O(log n). REQUIERE el arreglo ordenado por la misma clave.
        /// Devuelve la PRIMERA posición cuya clave es mayor o igual a la buscada
        /// (o arreglo.Length si no hay ninguna). Así sirve para buscar "la primera recolección de un día".
        /// </summary>
        public static int BusquedaBinaria<T, K>(T[] arreglo, K clave, Func<T, K> obtenerClave, out int comparaciones)
            where K : IComparable<K>
        {
            comparaciones = 0;
            int izq = 0, der = arreglo.Length;   // intervalo [izq, der)
            while (izq < der)
            {
                int medio = izq + (der - izq) / 2;
                comparaciones++;
                if (obtenerClave(arreglo[medio]).CompareTo(clave) < 0)
                    izq = medio + 1;
                else
                    der = medio;
            }
            return izq;
        }

        /// <summary>Búsqueda lineal O(n), para comparar contra la binaria.</summary>
        public static int BusquedaLineal<T, K>(T[] arreglo, K clave, Func<T, K> obtenerClave, out int comparaciones)
            where K : IComparable<K>
        {
            comparaciones = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                comparaciones++;
                if (obtenerClave(arreglo[i]).CompareTo(clave) >= 0) return i;
            }
            return arreglo.Length;
        }
    }
}
