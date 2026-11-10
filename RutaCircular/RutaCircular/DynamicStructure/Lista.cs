using System.Collections;
using RutaCircular.Contracts;

namespace RutaCircular.DynamicStructure
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Back { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public class Paginator<T>
    {
        public T Data { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }

        public Paginator(T data, int page, int totalPage)
        {
            Data = data;
            Page = page;
            TotalPage = totalPage;
        }
    }

    /// <summary>
    /// Lista doblemente enlazada propia (la del proyecto de Estructura de Datos, mejorada).
    /// REFACTOR respecto a la versión anterior:
    ///  1. Implementa IEnumerable&lt;T&gt;: recorrerla con foreach es O(n). Antes se recorría con
    ///     for + ElementAt(i), y como ElementAt camina desde la cabeza, el recorrido completo era O(n²).
    ///  2. Ya no exige "where T : class": ahora sirve también para long, double, etc. (la usa el grafo).
    ///  3. Al eliminar se actualiza el nodo actual del paginador (antes podía quedar apuntando a un nodo borrado).
    /// Complejidad: Add O(1), Delete O(n), ElementAt O(n), recorrido O(n).
    /// </summary>
    public class Lista<T> : IListOperation<T>, IEnumerable<T>
    {
        private Node<T>? _head;
        private Node<T>? _last;
        private Node<T>? _current;
        private int _count;
        private int _index;

        public int Count => _count;
        public bool IsEmpty => _head == null;

        // ------------------ Paginación (igual que antes) ------------------
        public Paginator<T>? moveToHead()
        {
            if (IsEmpty) return null;
            _current = _head;
            _index = 0;
            return new Paginator<T>(_current!.Data, _index + 1, Count);
        }

        public Paginator<T>? moveToLast()
        {
            if (IsEmpty) return null;
            _current = _last;
            _index = Count - 1;
            return new Paginator<T>(_current!.Data, _index + 1, Count);
        }

        public Paginator<T>? moveToRigth()
        {
            if (IsEmpty || _current == null || _current == _last) return null;
            _index++;
            _current = _current.Next!;
            return new Paginator<T>(_current.Data, _index + 1, Count);
        }

        public Paginator<T>? moveToLeft()
        {
            if (IsEmpty || _current == null || _current == _head) return null;
            _index--;
            _current = _current.Back!;
            return new Paginator<T>(_current.Data, _index + 1, Count);
        }

        // ------------------ Operaciones básicas ------------------
        public void Add(T data)
        {
            var n = new Node<T>(data);
            if (_head == null)
            {
                _head = n;
                _last = n;
                _current = n;
            }
            else
            {
                n.Back = _last;
                _last!.Next = n;
                _last = n;
            }
            _count++;
        }

        public void Delete(int position)
        {
            if (position < 0 || position >= _count) return;
            Node<T> temp = _head!;
            for (int i = 0; i < position; i++)
                temp = temp.Next!;
            Desenlazar(temp, position);
        }

        public void Delete(T data)
        {
            var comparador = EqualityComparer<T>.Default;
            Node<T>? temp = _head;
            int posicion = 0;
            while (temp != null && !comparador.Equals(temp.Data, data))
            {
                temp = temp.Next;
                posicion++;
            }
            if (temp != null)
                Desenlazar(temp, posicion);
        }

        private void Desenlazar(Node<T> nodo, int posicion)
        {
            if (nodo.Back == null) _head = nodo.Next; else nodo.Back.Next = nodo.Next;
            if (nodo.Next == null) _last = nodo.Back; else nodo.Next.Back = nodo.Back;

            // Mantener coherente el nodo actual del paginador
            if (nodo == _current)
            {
                if (nodo.Next != null) _current = nodo.Next;
                else { _current = nodo.Back; _index--; }
            }
            else if (posicion < _index)
            {
                _index--;
            }
            if (_index < 0) _index = 0;
            _count--;
        }

        public T? ElementAt(int position)
        {
            if (position < 0 || position >= _count) return default;
            Node<T> temp = _head!;
            for (int i = 0; i < position; i++)
                temp = temp.Next!;
            return temp.Data;
        }

        public void Set(int index, T data)
        {
            if (index < 0 || index >= _count) return;
            Node<T> temp = _head!;
            for (int i = 0; i < index; i++)
                temp = temp.Next!;
            temp.Data = data;
        }

        public void Clear()
        {
            _head = _last = _current = null;
            _count = 0;
            _index = 0;
        }

        /// <summary>Búsqueda lineal O(n): devuelve el primer elemento que cumple la condición.</summary>
        public T? Find(Predicate<T> condicion)
        {
            foreach (T dato in this)
                if (condicion(dato)) return dato;
            return default;
        }

        public int IndexOf(Predicate<T> condicion)
        {
            int i = 0;
            foreach (T dato in this)
            {
                if (condicion(dato)) return i;
                i++;
            }
            return -1;
        }

        /// <summary>Copia la lista a un arreglo (los algoritmos de ordenamiento trabajan sobre arreglos).</summary>
        public T[] ToArray()
        {
            var arreglo = new T[_count];
            int i = 0;
            foreach (T dato in this)
                arreglo[i++] = dato;
            return arreglo;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? temp = _head;
            while (temp != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
