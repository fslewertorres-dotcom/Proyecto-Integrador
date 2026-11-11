# Desarrollo matemático — EcoResiduos

**Responsable:** Persona 3 · **Materia:** Cálculo Multivariable (RAP-01)

Cada ejercicio se resuelve a mano, se verifica en GeoGebra y se compara con lo que calcula el programa.
En el programa solo se muestran los resultados (**Análisis → Módulo de cálculo** y el resumen de la ruta en el mapa); este documento tiene el desarrollo completo para la sustentación.
Los datos de ejemplo corresponden al reloj inicial: **lunes 9 de noviembre de 2026, 7:00**.

---

## 1. Representación espacial (RAA 1)

- **Sistema de coordenadas:** el lote es un rectángulo de 120 × 160 m. El origen está en la esquina superior izquierda, con *x* hacia la derecha y *y* hacia abajo (igual que la pantalla).
- **Casas:** cada casa *i* es un rectángulo de 6 × 16 m. Se representa por su centro:
  xᵢ = 11 + 6j (j = 0…11) y yᵢ = (y de la hilera) + 8.
- **Vías:** cada vía es un segmento entre dos puntos. Su longitud es la norma del vector:
  ‖B − A‖ = √((x_B − x_A)² + (y_B − y_A)²).
  Ejemplo: del cruce de la vía 1 (4, 19) al punto ecológico (12, 19), ‖(8, 0)‖ = **8 m**.
  Del cruce (82, 19) a la piscina (88, 20), √(6² + 1²) = **6,08 m** (igual a `vias.txt`).

---

## 2. Función de varias variables: generación G(lugar, día, hora)

**G(lugar, día, h) = tasaBase · Fh(lugar, h) · Fd(lugar, día)** [L/h]

**Fh** es una suma de "campanas" en las horas pico, con g(h; μ, σ) = e^(−(h−μ)²/(2σ²)). Para un punto ecológico:

  Fh_cruda(h) = 0,3 + 1,0·g(h; 7; 1,5) + 1,2·g(h; 19,5; 2)

Se **normaliza** dividiendo entre su promedio del día, (1/24)∫₀²⁴ Fh_cruda dh = 0,7043. Así, el promedio de Fh es 1 y el promedio semanal de G es la tasa base.

**Fd** (punto ecológico): domingo y sábado 1,3, entre semana 1,0. Su promedio es 7,6/7 = 1,0857.

**Ejemplo a mano** (punto ecológico, sábado 19:30):
- tasaBase de un punto ecológico (sus 3 contenedores, promedio de las 4 vías) = 11,015 L/h.
- Fh_cruda(19,5) = 0,3 + 1,0·g(19,5; 7; 1,5) + 1,2·1 ≈ 0,3 + 0 + 1,2 = 1,5 → Fh = 1,5 / 0,7043 = **2,130**.
- Fd(sábado) = 1,3 / 1,0857 = **1,197**.
- G = 11,015 × 2,130 × 1,197 = **28,09 L/h**.

**GeoGebra:**
```
g(h, m, s) = exp(-(h - m)^2 / (2 s^2))
F(h) = (0.3 + g(h, 7, 1.5) + 1.2 g(h, 19.5, 2)) / 0.7043
Integral(F, 0, 24)        → 24   (comprueba que el promedio es 1)
11.015 * F(19.5) * 1.3 / 1.0857   → 28.09
```

---

## 3. Funciones de costo y derivadas parciales (RAA 2)

T(d, n) = d / v + n·tv    C(d, n) = T(d, n)/60 · costoHora
con v = 48 m/min, tv = 2 min y costoHora = $9.000.

- **Ruta del lunes** (d = 557 m, n = 14 contenedores): T = 557/48 + 14·2 = 11,60 + 28 = **39,6 min** y C = 39,6/60 · 9.000 = **$5.941**.
- **Derivadas parciales:**
  - ∂T/∂d = 1/v = 0,0208 min/m
  - ∂T/∂n = tv = 2 min
  - ∂C/∂d = $3,13 por metro
  - ∂C/∂n = $300 por contenedor
- **Interpretación:** (∂T/∂n)/(∂T/∂d) = 2 · 48 = **96 m**. Vaciar un contenedor más "cuesta" lo mismo que caminar 96 m más.

---

## 4. Optimización con gradiente: ubicación del punto ecológico (RAA 2)

**Problema:** ¿dónde poner el punto ecológico de la vía 1 para que las 24 casas caminen lo menos posible?

f(x, y) = Σᵢ wᵢ [(x − xᵢ)² + (y − yᵢ)²], con wᵢ = 2,24 kg/día por casa.

**Gradiente:**
- ∂f/∂x = 2Σwᵢ(x − xᵢ)
- ∂f/∂y = 2Σwᵢ(y − yᵢ)

**Punto crítico (∇f = 0):** x* = Σwᵢxᵢ / Σwᵢ, y* = Σwᵢyᵢ / Σwᵢ. Como todos los pesos son iguales, es el promedio de las coordenadas.
- x: los centros van de 11 a 77 de 6 en 6 → x* = (11 + 77)/2 = **44**.
- y: 12 casas en y = 8 (hilera 1) y 12 en y = 30 (hilera 2) → y* = (8 + 30)/2 = **19**.
- **Óptimo: (44, 19)**, la mitad de la vía 1. El punto actual está en (12, 19), a la entrada.

**¿Es un mínimo?** La matriz Hessiana es
```
H = | 2Σw   0  |  = | 107,52    0    |
    |  0   2Σw |    |   0     107,52 |
```
Su determinante es positivo y f_xx > 0, así que es un **mínimo** (de hecho, el mínimo global, porque f es convexa).

**Resultados:**

| | Ubicación actual (12, 19) | Óptimo (44, 19) |
|---|---|---|
| f(x, y) | 84.618 | 29.568 |
| Distancia promedio casa → punto | 35,24 m | 21,98 m |

Cada hogar caminaría en promedio **38 % menos**.

**Descenso del gradiente** (lo que hace el programa): (x, y) ← (x, y) − α∇f con α = 1/(4Σw). En cada paso se avanza **la mitad** de lo que falta. Partiendo de (12, 19), la distancia al óptimo es 32 m: 16, 8, 4… El paso cae por debajo de 0,0001 m en **19 iteraciones**. El mapa dibuja ese camino con puntos morados.

**Todo el conjunto (96 casas):** el óptimo es (44, 76) y la distancia promedio pasa de 94,1 m (si el punto estuviera en el acopio) a 44,45 m. Aun así, el acopio se deja en la entrada, para que el camión de la empresa de aseo no tenga que entrar al conjunto. Es una restricción práctica que el modelo matemático no incluye.

**GeoGebra (vista 3D):**
```
f(x, y) = Sum(Sequence(2.24 ((x - (11 + 6i))^2 + (y - 8)^2), i, 0, 11)) + Sum(Sequence(2.24 ((x - (11 + 6i))^2 + (y - 30)^2), i, 0, 11))
Solve({Derivative(f, x) = 0, Derivative(f, y) = 0}, {x, y})     → {{x = 44, y = 19}}
f(12, 19)   → 84618       f(44, 19)   → 29568
```

---

## 5. Predicción de llenado: integral en el tiempo (RAA 3)

**Problema:** ¿en cuántas horas se llena el contenedor 122 (vía 2, aprovechable)?
- Nivel: 226,45 de 240 L → libres = **13,55 L**.
- Tasa base: 4,05 L/h. Tasa en este momento (lunes 7:00, hora pico): G = 6,886 L/h.

Se busca T tal que **∫₀ᵀ G(t) dt = 13,55**.

G cambia con la hora, así que no tiene una antiderivada sencilla. Se usa la **regla de Simpson** en tramos de 15 min:

  ∫ₐᵇ G dt ≈ (b − a)/6 · [G(a) + 4G((a+b)/2) + G(b)]

Primer tramo (7:00 a 7:15) ≈ 1,715 L. Se suman tramos hasta llegar a 13,55 L y, dentro del último, se interpola linealmente. Resultado: **T = 2,71 h** (se llena hacia las 9:43).

**Comparación:** con tasa constante, 13,55 / 4,05 = **3,35 h**. Ese cálculo sobreestima el tiempo porque ignora que a las 7:00 es hora pico. Por eso la prioridad usa la integral.

**GeoGebra:**
```
G(t) = 4.05 * F(7 + t) * 1 / 1.0857        (lunes: Fd = 1/1.0857)
NSolve(Integral(G, 0, T) = 13.55, T)     → T ≈ 2.71
```

---

## 6. Resumen: resultado a mano contra el programa

| Ejercicio | A mano | Programa | Dónde verlo |
|---|---|---|---|
| G(punto ecológico, sábado, 19:30) | 28,09 L/h | (interno: alimenta la predicción) | Predicción |
| T(557, 14) y C(557, 14) | 39,6 min · $5.941 | 40 min · $5.941 | Mapa → tarjetas Tiempo y Costo |
| Óptimo de la vía 1 | (44, 19) | (44, 19) · 38 % menos | Ubicación óptima |
| Llenado del contenedor 122 | 2,71 h | ≈ 2,7 h | Predicción |

> Si ya simularon horas o vaciaron contenedores, los números de la predicción cambian. Para reproducir esta tabla usen los datos originales (borren `bin/Debug/net10.0-windows/Data` y compilen de nuevo).
