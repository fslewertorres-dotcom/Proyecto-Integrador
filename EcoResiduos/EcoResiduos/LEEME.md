# EcoResiduos · Conjunto Portal del Viento (Aguachica, Cesar)

Sistema de gestión de residuos para un conjunto de 96 casas: prioriza los contenedores según cuándo se van a llenar, calcula la ruta del operario y mide indicadores de gestión.

## Cómo abrirlo
1. Abrir `EcoResiduos.slnx` con Visual Studio (.NET 10).
2. **F5**. Los datos de ejemplo (`EcoResiduos/Data/*.txt`) se copian solos junto al `.exe`.
3. Usuarios de prueba (se crean la primera vez):
   - `admin` / `admin123` → Administrador (ve todo).
   - `operario` / `operario123` → Operario (solo ve el mapa y registra recolecciones).

> ⚠️ El código se escribió sin poder compilarlo. Si Visual Studio marca algún error, casi seguro es algo pequeño: copien el mensaje exacto y se corrige rápido.

> Los cambios se guardan en `bin/Debug/net10.0-windows/Data`. Para volver a los datos originales, borren esa carpeta y compilen otra vez.

## Estructura (la misma del proyecto de Estructura de Datos)
| Carpeta | Contenido |
|---|---|
| `Contracts/` | Interfaces: `IEntity`, `IFactory`, `ISerialize`, `IRepository`, `IUnitOfWork`, `IDataStore` |
| `Domain/` | Entidades: `PuntoRecoleccion`, `Contenedor`, `Via`, `Recoleccion`, `Usuario` → `Administrador` / `Operario`; `PlanoConjunto` (geometría) y `ConstantesModelo` (supuestos) |
| `DynamicStructure/` | **Estructuras propias**: `Lista` (doblemente enlazada), `ColaPrioridad` (min-heap), `Grafo` (+ Dijkstra), `Ordenamiento` (QuickSort, búsqueda binaria y lineal) |
| `Persistence/` | `DataStore<T>`: lee y escribe los `.txt` (sincrónico y **asíncrono**) |
| `Infraestructure/` | `Repository<T,E>` (Lista + `Dictionary` como índice), `Contexto` (Singleton), `Sesion` |
| `Services/` | Prioridad, rutas, recolección, indicadores, autenticación, rendimiento |
| `Services/Calculo/` | **Módulo de cálculo**: `ModeloGeneracion` G(lugar, día, hora), `Prediccion` (integral con Simpson), `ModeloCosto` T(d,n) y C(d,n), `Optimizacion` (gradiente) |
| `Tools/` | `Tool` (ayudas) y `Tema` (colores y estilos de todo el programa) |
| `Exceptions/` | Excepciones propias (`ValidacionException`, `DatosInvalidosException`…) |
| `Presentation/` | Formularios WinForms, `PanelMapa` (dibuja el plano y anima el recorrido) y `GraficoNivel` |
| `Herramientas/` | Script de Python que generó los datos de ejemplo |

## Guion sugerido para la presentación
1. **Login como `operario`** → solo aparecen Archivo y Operación (polimorfismo de `Usuario`). Cerrar e **ingresar como `admin`**.
2. **Operación → Mapa y ruta del día** (lunes 7:00):
   - Pestaña **Prioridad**: es la **cola de prioridad**. El aprovechable de la vía 2 está al 94 % → *Más del 80 %*.
   - **Calcular ruta del día** → Dijkstra + vecino más cercano. Son 8 paradas (los 4 puntos ecológicos y las 4 zonas sociales) y unos 557 m. Las paradas quedan numeradas en el mapa, y la pestaña **Recorrido paso a paso** explica cada tramo.
   - **▶ Recoger ruta** → el cuadrito del operario recorre la ruta; en cada parada vacía los contenedores (el punto se pone verde con ✓) y la lista marca el avance. La barra de velocidad acelera o frena la animación.
   - **Avanzar 120 horas** (hasta el sábado) → los contenedores se llenan; se vuelve a calcular la ruta.
   - Pasar el mouse sobre un punto muestra sus contenedores.
3. **Análisis → Módulo de cálculo**: predicción de llenado (resultado y gráfico) y ubicación óptima (★ y el camino morado en el mapa).
4. **Análisis → Histórico**: ordenar con QuickSort y buscar un día con búsqueda binaria.
5. **Análisis → Indicadores**: aprovechamiento, kg/casa/día, ruta de hoy vs. ronda tradicional (785 m → 557 m, 29 % menos) y frecuencia por punto.
6. **Análisis → Comparación de algoritmos**: tiempos y comparaciones contra n·log₂n y log₂n.

## Qué cubre de cada materia
| Materia | Dónde está |
|---|---|
| **Programación III** | POO (herencia y polimorfismo en `Usuario`, interfaces genéricas), arquitectura en capas, `try/catch` + excepciones propias + `ErrorProvider`, `async/await` (guardar, calcular la ruta, indicadores), `Timer` para la animación, persistencia en `.txt`, refactorizaciones marcadas con `REFACTOR:` |
| **Estructura de Datos** | Lista enlazada, heap, grafo, Dijkstra, pila (`Stack` al reconstruir caminos), QuickSort, búsqueda binaria, `Dictionary` (estructura seleccionada) |
| **Cálculo Multivariable** | Coordenadas del plano, función de varias variables G(lugar, día, hora), T(d,n) y C(d,n) de la ruta, descenso del gradiente para la ubicación óptima, integral en el tiempo (Simpson) para predecir el llenado. Desarrollo completo en `Documentos/DesarrolloMatematico.md` |
| **Administración** | Roles (organizar), ruta paso a paso (dirigir), indicadores de control, ruta optimizada vs. tradicional. Ver `Documentos/Administracion.md` |
| **Metodología** | Datos de fuentes oficiales y supuestos documentados en `ConstantesModelo.cs`; escenarios simulables. Ver `Documentos/Metodologia.md` |

## Complejidad (para el análisis Big-O)
| Operación | Estructura | Complejidad |
|---|---|---|
| Agregar al final | Lista enlazada | O(1) |
| Buscar / eliminar por valor | Lista enlazada | O(n) |
| Recorrer con `foreach` | Lista enlazada | O(n) (antes O(n²) con `ElementAt`) |
| `GetById` / `Exist` | `Dictionary` | O(1) promedio |
| Encolar / desencolar | Heap | O(log n) |
| Priorizar n contenedores | Heap | O(n log n) |
| Dijkstra | Grafo + heap | O((V + E) log V) |
| Ruta del día (k paradas) | Vecino más cercano | O(k · (V + E) log V) |
| QuickSort | Arreglo | O(n log n) promedio, O(n²) peor caso |
| Búsqueda binaria / lineal | Arreglo ordenado | O(log n) / O(n) |

## Reparto del trabajo
Cada uno debe poder explicar su parte en la sustentación.

**Persona 1 – Login e interfaz**
- [x] `FrUsuarios` + `ServicioUsuarios`: crear, editar y eliminar usuarios (no deja borrar al único administrador ni a sí mismo).
- [ ] Crear el repositorio en GitHub y subir esta base (primer commit).

**Persona 2 – Estructuras y ruta**
- [x] `FrRendimiento`: Análisis → Comparación de algoritmos (n = 1.000, 10.000 y 100.000).
- [x] `Documentos/AnalisisBigO.md` (falta copiar las medidas de su PC en la sección 4).

**Persona 3 – Mapa y cálculo**
- [x] `Documentos/DesarrolloMatematico.md`: cada ejercicio resuelto a mano, con comandos de GeoGebra y comparación con el programa.
- [x] El mapa dibuja el camino del descenso del gradiente hasta la ★.

**Persona 4 – Datos, formularios y parte escrita**
- [x] `FrVias` + `ServicioVias`: Configuración → Vías (calcula la distancia con las coordenadas y avisa si un punto queda sin camino).
- [x] `Documentos/Metodologia.md` y `Documentos/Administracion.md`.

## Supuestos del modelo (`Domain/ConstantesModelo.cs`)
| Dato | Valor | Fuente |
|---|---|---|
| Casas | 96 de 6 × 16 m | Información del conjunto |
| Distribución | 8 hileras × 12 casas, 4 vías | Estimado de las imágenes |
| Personas por hogar | 3,5 | DANE, CNPV 2018 (Cesar) |
| kg por persona al día | 0,64 | 24,8 M t/año × 47 % hogares ÷ 50 M hab (MinAmbiente / DANE) |
| Composición | 44 % orgánico, 38 % aprovechable, 18 % no aprovechable | Banco Mundial, citado por MinAmbiente |
| Densidad | 0,2 kg/L | Supuesto (valor típico 0,15–0,30) |
| Ocupación por vía | ×1,10 · ×0,95 · ×1,00 · ×0,88 | Supuesto (para que las vías no sean idénticas) |
| Zonas comunes y curvas horarias | Ver `ModeloGeneracion.cs` | Propuesta del equipo |
| Velocidad del operario / tiempo por contenedor / costo hora | 48 m/min · 2 min · $9.000 | Supuesto |

El histórico de ejemplo simula 4 semanas (12 oct – 9 nov 2026) con rondas a las 7:00 (contenedores ≥ 50 %) y a las 17:00 (≥ 80 %).
