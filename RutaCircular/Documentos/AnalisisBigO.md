# Análisis de estructuras de datos y complejidad — Ruta Circular

**Responsable:** Persona 2 · **Materia:** Estructura de Datos (RAP-02)

## 1. Memoria (RAA 1)

En C# hay dos clases de tipos, y eso explica por qué cada estructura ocupa lo que ocupa:

- **Tipos valor** (`int`, `long`, `double`, `DateTime`, `struct` como `Rectangulo`): guardan el dato directamente. Dentro de un arreglo quedan seguidos en memoria.
- **Tipos referencia** (las clases `Contenedor`, `Node<T>`, `Recoleccion`): la variable guarda una referencia de 8 bytes (en 64 bits) y el objeto vive en el *heap* administrado, que limpia el recolector de basura.

| Estructura | Cómo está en memoria | Consecuencia |
|---|---|---|
| Arreglo (`T[]`) | Bloque contiguo | Acceso por índice O(1). Su tamaño es fijo: crecer exige copiarlo |
| `Lista<T>` (enlazada) | Nodos sueltos; cada uno tiene dato + `Next` + `Back` | Agregar al final O(1) sin copiar nada, pero cada nodo gasta unos 40 bytes extra y llegar al elemento *i* es O(n) |
| `ColaPrioridad<T>` | Dos arreglos (elementos y prioridades) | Se duplica cuando se llena, así que agregar cuesta O(1) amortizado |
| `Grafo` | `Dictionary<long, Lista<Arista>>` | Memoria O(V + E) |
| `Dictionary<K,V>` | Tabla hash (arreglo de cubetas) | Acceso O(1) promedio |

**Decisión de diseño:** el histórico se guarda en la `Lista` porque solo crece al final, en O(1) y sin copiar. Para **ordenar y buscar** se copia a un arreglo (`ToArray()`, O(n)), porque QuickSort y la búsqueda binaria necesitan acceso por índice en O(1).

## 2. Estructuras usadas y justificación (RAA 3 y RAA 4)

| Estructura | Lineal / no lineal | Propia o .NET | Dónde se usa | Por qué esta y no otra |
|---|---|---|---|---|
| Lista doblemente enlazada | Lineal | **Propia** | Caché de todas las entidades, histórico | Agregar O(1), recorrer en orden, paginación adelante y atrás |
| Min-heap (cola de prioridad) | No lineal (árbol binario en un arreglo) | **Propia** | Prioridad de contenedores, Dijkstra | Sacar siempre el más urgente en O(log n). Una lista ordenada insertaría en O(n) |
| Grafo con lista de adyacencia | No lineal | **Propia** | Vías internas del conjunto | El plano es poco denso (17 nodos, 19 aristas): la matriz tendría 17² = 289 celdas; la lista, 38 entradas |
| `Dictionary<K,V>` | Tabla hash | **.NET (seleccionada)** | Índice por Id en `Repository`, conteo por punto en los indicadores | `GetById` pasa de O(n) a O(1) promedio |
| `Stack<T>` (pila) | Lineal | .NET | Reconstruir el camino en Dijkstra | Los "previos" salen del destino al origen; la pila los invierte (LIFO) |

## 3. Complejidad de cada operación

### 3.1 Lista enlazada
| Operación | Complejidad | Motivo |
|---|---|---|
| `Add` | O(1) | Se guarda un puntero al último nodo |
| `ElementAt(i)`, `Set(i)` | O(n) | Hay que caminar desde la cabeza |
| `Delete(dato)` | O(n) | Primero hay que buscarlo |
| `foreach` | O(n) | Avanza de nodo en nodo |

**La refactorización más importante.** Antes, el proyecto recorría con `for (i…) ElementAt(i)`. Como cada `ElementAt(i)` camina *i* pasos, el total era:

  0 + 1 + 2 + … + (n−1) = n(n−1)/2 → **O(n²)**.

Con `foreach` (la lista implementa `IEnumerable<T>`) el recorrido es **O(n)**. Para 10.000 registros son unos 50 millones de pasos contra 10.000.

### 3.2 Min-heap
Es un árbol binario completo guardado en un arreglo: el padre de *i* está en (i−1)/2 y sus hijos en 2i+1 y 2i+2. Como es completo, su altura es ⌊log₂ n⌋.
- **Encolar:** se pone al final y "sube" mientras sea menor que su padre. Como mucho recorre la altura: **O(log n)**.
- **Desencolar:** el último pasa a la raíz y "baja" hacia el hijo menor: **O(log n)**.
- **Priorizar n contenedores:** n encolar + n desencolar = **O(n log n)**.

### 3.3 Grafo, Dijkstra y ruta
- **Dijkstra con heap:** cada arista puede encolar un nodo (E operaciones de O(log V)) → **O((V + E) log V)**. Si un nodo sale con una distancia vieja, se ignora (eliminación perezosa).
- **Ruta del día (vecino más cercano):** con *k* paradas se corre Dijkstra *k + 1* veces → **O(k (V + E) log V)**.
- **¿Por qué no la ruta perfecta?** Es el problema del viajante: probar todos los órdenes cuesta **O(k!)**. Con 8 puntos son 40.320 órdenes; con 15, más de un billón. La heurística da una buena ruta en una fracción de ese tiempo.

### 3.4 `Dictionary`
- **Promedio O(1):** la función hash lleva directo a la cubeta.
- **Peor caso O(n):** si todas las claves chocan en la misma cubeta. Con claves `long` o `string` esto no pasa en la práctica.

### 3.5 QuickSort (propio)
- **Promedio:** cada partición recorre el arreglo, O(n), y lo divide en dos mitades: T(n) = 2T(n/2) + n = **O(n log n)**.
- **Peor caso:** si el pivote siempre queda en un extremo, T(n) = T(n−1) + n = **O(n²)**.
- **Por qué el pivote va en el centro:** el histórico casi siempre viene **ordenado por fecha**. Con el pivote en el extremo, un arreglo ya ordenado es justo el peor caso. Con el pivote central, ese caso se vuelve el mejor.
- **Pila de llamadas:** la recursión se hace solo sobre la parte más pequeña, así que la profundidad es O(log n) y no hay desbordamiento.
- **No es estable:** dos registros con la misma clave pueden quedar en cualquier orden.

### 3.6 Búsqueda binaria vs lineal
- **Lineal:** revisa uno por uno; en promedio n/2 comparaciones → **O(n)**.
- **Binaria:** cada comparación descarta la mitad: T(n) = T(n/2) + 1 = **O(log n)**. Para n = 100.000, como mucho ⌈log₂ 100.000⌉ = 17 comparaciones.
- **Requisito:** el arreglo debe estar ordenado por la misma clave. Por eso el formulario del histórico ordena por fecha antes de buscar.
- **Variante usada:** devuelve la *primera* posición con fecha ≥ la buscada (*lower bound*), para encontrar la primera recolección del día.

## 4. Resultados experimentales

Se miden en **Análisis → Comparación de algoritmos** con 1.000 búsquedas. Las columnas teóricas ya están calculadas; **llenen las medidas con lo que muestre el programa en su computador**.

| n | n·log₂n | Comparaciones QuickSort | QS ÷ n·log₂n | QuickSort (ms) | Array.Sort (ms) |
|---|---|---|---|---|---|
| 1.000 | 9.966 | | | | |
| 10.000 | 132.877 | | | | |
| 100.000 | 1.660.964 | | | | |

| n | n/2 | Lineal (comp./búsqueda) | log₂n | Binaria (comp./búsqueda) |
|---|---|---|---|---|
| 1.000 | 500 | | 10,0 | |
| 10.000 | 5.000 | | 13,3 | |
| 100.000 | 50.000 | | 16,6 | |

**Cómo leerlos**
- Si "QS ÷ n·log₂n" se mantiene casi constante cuando n crece ×10, se confirma que QuickSort es O(n log n).
- La búsqueda lineal debe crecer ×10 cada vez; la binaria apenas sube unas 3 comparaciones.
- Los milisegundos dependen del equipo; **las comparaciones no**. Por eso el análisis se apoya en las comparaciones.

## 5. Conclusiones
1. Escoger bien la estructura cambia el orden de complejidad, no solo la velocidad. Los dos ejemplos del proyecto: pasar de O(n²) a O(n) al recorrer la lista, y de O(n) a O(1) al buscar por Id.
2. El heap es la estructura adecuada para "atender primero lo más urgente". Además, la misma estructura sirve para la prioridad de los contenedores y para Dijkstra.
3. Para la ruta se aceptó una heurística, porque la solución exacta crece factorialmente.
4. Ordenar una vez (O(n log n)) y luego hacer muchas búsquedas binarias (O(log n) cada una) sale mucho más barato que hacer muchas búsquedas lineales.
