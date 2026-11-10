# Análisis administrativo — Ruta Circular

**Responsable:** Persona 4 · **Materia:** Fundamentos de Administración (RAP-05)

---

## 1. Caracterización de la organización
**Organización:** Conjunto residencial cerrado **Portal del Viento** (Aguachica, Cesar), en construcción.
- 96 casas de un piso (6 × 16 m).
- Zonas comunes: piscina, gimnasio, zona de asados y parque infantil.

**Forma jurídica:** propiedad horizontal (Ley 675 de 2001). La copropiedad es una persona jurídica que administra los bienes comunes. Sus órganos son:

| Actor | Rol en la gestión de residuos |
|---|---|
| **Asamblea de copropietarios** | Aprueba el presupuesto y las normas de convivencia (por ejemplo, el reglamento de separación) |
| **Consejo de administración** | Hace seguimiento a la gestión y aprueba las mejoras |
| **Administrador** | Planea, organiza y controla el servicio. **Usuario "Administrador" del software** |
| **Operario de aseo** | Hace la recolección interna. **Usuario "Operario" del software** |
| **Residentes** | Generan los residuos y los separan en la fuente |
| **Prestador del servicio de aseo** | Recoge en el cuarto de acopio y lleva al relleno sanitario Las Bateas |
| **Recicladores / asociaciones** | Recogen el material aprovechable |

## 2. Enfoque administrativo que sustenta la propuesta
- **Teoría de sistemas:** el conjunto es un sistema.
  - Entradas: residuos de 96 hogares y zonas comunes.
  - Procesos: separación, recolección y acopio.
  - Salidas: material aprovechable y residuos a disposición.
  - Retroalimentación: los indicadores.
- **Administración por procesos y mejora continua (PHVA):** planear la ronda, hacerla, verificar con indicadores y actuar ajustando la frecuencia o los puntos.
- **Tendencias actuales:**
  - gestión basada en datos (decidir con información, no por costumbre);
  - economía circular;
  - uso de TIC para automatizar decisiones operativas.

## 3. Diagnóstico
**Eficiencia y eficacia**
- **Eficacia:** lograr que ningún contenedor se desborde y que todos los residuos lleguen al acopio.
- **Eficiencia:** lograrlo con el menor recorrido, tiempo y costo.
- La ronda fija puede ser eficaz, pero **no es eficiente**: en el escenario del lunes recorre 785 m y tarda unos 58 min para vaciar los 21 contenedores. La ruta priorizada recorre 557 m y tarda unos 40 min: atiende los 14 contenedores que lo necesitan (incluidas las zonas sociales).

**Recursos**
| Recurso | Descripción |
|---|---|
| Humanos | Un operario de aseo; el administrador |
| Físicos | 21 contenedores (240, 120 y 60 L), 4 puntos ecológicos, cuarto de acopio de 32,4 m³, carro de recolección |
| Tecnológicos | Software Ruta Circular (un computador en la administración) |
| Financieros | Cuota de administración (rubro de aseo) |

**Áreas funcionales:** operaciones (recolección), administrativa y financiera (presupuesto y costos), comunicación con residentes (campañas de separación) y control (indicadores).

**Entorno (DOFA)**
| | |
|---|---|
| **Fortalezas:** conjunto nuevo (se diseña desde cero), escala pequeña, software propio | **Debilidades:** no hay datos reales de generación todavía; depende de la disciplina de los residentes |
| **Oportunidades:** normas nacionales que promueven el aprovechamiento; recicladores en la región; posibles ingresos por material aprovechable | **Amenazas:** baja cultura de separación; dependencia del prestador del servicio de aseo; aumento de generación en temporadas |

**TIC:** el software convierte datos (niveles, tasas, plano) en decisiones (qué recoger y por dónde ir) y deja trazabilidad (histórico).

## 4. Sostenibilidad
- **Ambiental:** menos desbordamientos y más aprovechamiento (más del 80 % de lo generado es blanco o verde).
- **Económica:** menor tiempo de ronda, lo que libera tiempo del operario para otras tareas.
- **Social:** zonas comunes limpias y mejor convivencia.
- **ODS:** 11 (ciudades y comunidades sostenibles) y 12 (producción y consumo responsables).

## 5. Creatividad, innovación y emprendimiento
- **Innovación de proceso:** pasar de rondas por costumbre a rondas por prioridad, con una predicción matemática del llenado.
- **Innovación de diseño:** la gestión de residuos se planea antes de que el conjunto se habite.
- **Oportunidad de emprendimiento:** el mismo software se puede ofrecer a otros conjuntos de Aguachica como servicio. Basta con cambiar el plano y los contenedores.

## 6. Proceso administrativo aplicado (PODC)
| Fase | Qué se hace en Ruta Circular | Soporte en el software |
|---|---|---|
| **Planeación** | Metas (cero desbordamientos, más aprovechamiento), ubicación de los puntos ecológicos | Módulo de cálculo (predicción y ubicación óptima) |
| **Organización** | Roles y responsabilidades: administrador configura, operario ejecuta; distribución de contenedores por punto | Login con roles; Puntos, Contenedores, Vías, Usuarios |
| **Dirección** | Orden de trabajo diaria al operario (la ruta paso a paso); campañas de separación a residentes | Mapa y ruta del día |
| **Control** | Medir, comparar con las metas y corregir | Histórico e Indicadores |

## 7. Plan de implementación
| Fase | Actividades | Responsable | Tiempo |
|---|---|---|---|
| 1. Preparación | Aprobación del consejo; compra de contenedores; adecuación del acopio | Administrador | Antes de la entrega de las casas |
| 2. Puesta en marcha | Cargar el plano y los contenedores; capacitar al operario | Administrador | Semana 1 |
| 3. Sensibilización | Campaña del código de colores para residentes | Administrador y consejo | Semanas 1 a 4 |
| 4. Operación | Ruta diaria según prioridad; registro de cada recolección | Operario | Continuo |
| 5. Control y mejora | Revisión mensual de indicadores; ajuste de tasas con datos reales | Administrador y consejo | Mensual |

## 8. Indicadores de control
| Indicador | Fórmula | Meta propuesta | Frecuencia | Valor simulado |
|---|---|---|---|---|
| Aprovechamiento | kg (blanco + verde) ÷ kg totales × 100 | ≥ 80 % | Mensual | 80,3 % |
| Generación por vivienda | kg de puntos ecológicos ÷ 96 ÷ días | ≤ 2,24 kg/día | Mensual | 2,22 kg/día |
| Eficiencia de la ruta | (1 − d priorizada ÷ d ronda fija) × 100 | ≥ 25 % | Semanal | 29 % |
| Contenedores sobre el 80 % | Cantidad al momento de la ronda | 0 obligatorios sin atender | Diaria | Ver Indicadores |
| Frecuencia por punto | Recolecciones ÷ semanas | Según demanda (no fija) | Semanal | 2,1 a 13,2 por semana |

## 9. Análisis de viabilidad e impacto
- **Técnica:** viable. Un computador básico y el software (sin licencias, sin base de datos).
- **Económica:** el costo principal es el tiempo del operario. En el escenario del lunes, la ronda pasa de unos 58 min ($8.753) a unos 40 min ($5.941), con un costo hora supuesto de $9.000. *Nota: la ronda fija vacía los 21 contenedores y la priorizada los 14 que lo necesitan (urgentes y zonas sociales); los demás se atienden cuando se acercan a llenarse.*
- **Impacto:** menos desbordamientos y olores; más material aprovechable entregado a los recicladores; información para decidir.

## 10. Propuesta de mejora
1. Adoptar la ruta priorizada en lugar de la ronda fija.
2. Hacer una campaña de separación con el código de colores desde la entrega de las casas.
3. Mover los puntos ecológicos hacia la mitad de cada vía (el óptimo calculado), lo que reduce un 38 % la distancia promedio que camina cada hogar.
4. Reemplazar los supuestos por mediciones reales durante los primeros 3 meses de ocupación.
5. A futuro, sensores de nivel en los contenedores para alimentar el software automáticamente.
