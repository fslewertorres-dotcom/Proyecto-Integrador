# Protocolo de investigación — EcoResiduos

**Responsable:** Persona 4 · **Materia:** Metodología de la Investigación (RAP-04)

**Título:** Sistema de priorización y ruteo de la recolección interna de residuos sólidos para un conjunto residencial de 96 viviendas en Aguachica, Cesar: estudio de caso prospectivo basado en modelación y simulación.

---

## 1. Planteamiento del problema
En los conjuntos residenciales, la recolección interna de residuos suele hacerse con **rondas fijas**: el operario visita todos los puntos a la misma hora, sin saber cuáles están llenos. Esto produce dos fallas a la vez:
- recorridos y tiempo desperdiciados en contenedores casi vacíos;
- contenedores que se desbordan entre una ronda y otra, sobre todo los orgánicos y los de las zonas sociales en fin de semana.

A esto se suma una baja separación en la fuente: en Colombia la tasa de reciclaje rondaba el 11,8 % en 2019 (MinAmbiente). Aun así, la mayor parte de los residuos de los hogares es orgánica o aprovechable.

El conjunto de estudio aún **está en construcción** (96 casas de un piso, piscina, gimnasio, zona de asados y parque infantil). Esto permite diseñar la gestión de residuos **antes** de que el conjunto sea habitado, en lugar de corregirla después.

## 2. Pregunta de investigación
¿En qué medida un sistema de software que prioriza los contenedores según su llenado proyectado y calcula la ruta de recolección interna reduce la distancia recorrida y los desbordamientos, frente a una ronda fija, en un conjunto residencial de 96 viviendas en Aguachica, Cesar?

## 3. Objetivos
**General:** desarrollar y evaluar, mediante simulación, un sistema de software para priorizar y planear la recolección interna de residuos sólidos en un conjunto residencial de 96 viviendas.

**Específicos:**
1. Estimar la generación de residuos del conjunto por tipo (orgánico, aprovechable, no aprovechable) a partir de fuentes oficiales.
2. Modelar matemáticamente la generación según el lugar, el día y la hora, y predecir cuándo se llena cada contenedor.
3. Implementar un software que priorice los contenedores y calcule la ruta del operario sobre el plano del conjunto.
4. Comparar la ruta optimizada con una ronda fija mediante indicadores de eficiencia, aprovechamiento y sostenibilidad.

## 4. Justificación
- **Ambiental:** recoger a tiempo evita desbordamientos, olores y plagas; facilitar la separación aumenta lo que se puede aprovechar.
- **Económica:** menos distancia y tiempo por ronda significa menor costo operativo para la copropiedad.
- **Normativa:** el código de colores de la Resolución 2184 de 2019 y la Política Nacional para la Gestión Integral de Residuos (CONPES 3874 de 2016) promueven la separación en la fuente y el aprovechamiento.
- **Académica:** integra programación, estructuras de datos, cálculo multivariable y administración en un problema real del municipio.

## 5. Antecedentes
> Revisen el resumen de cada trabajo y agreguen en una o dos líneas qué encontraron y qué aporta a este proyecto. Conviene sumar 1 a 3 antecedentes más (por ejemplo, sobre ruteo de recolección con grafos o sobre conjuntos residenciales).

1. **Validación y mejora del plan de gestión integral de residuos sólidos del municipio de Río de Oro, departamento del Cesar** (Universidad Industrial de Santander). Antecedente regional sobre la planeación de la gestión de residuos en un municipio vecino de Aguachica.
2. **Alternativas para el manejo de los residuos sólidos generados en un municipio de la región Caribe colombiana** (Zenodo). Antecedente sobre alternativas de manejo en un contexto regional similar.
3. **Superintendencia de Servicios Públicos Domiciliarios (2019)**, informe sobre Aseo Urbano S.A.S. E.S.P. en Aguachica. Reporta que el relleno sanitario Las Bateas recibió en promedio 91,2 t/día en 2017 y 84,9 t/día en 2018, todas procedentes de Aguachica.

## 6. Marco referencial
**Marco teórico**
- **Gestión integral de residuos sólidos (GIRS):** abarca todo el ciclo, desde la generación y la separación hasta la recolección, el aprovechamiento y la disposición.
- **Economía circular:** mantener los materiales en uso el mayor tiempo posible.
- **Jerarquía de residuos:** primero prevenir, luego reutilizar, reciclar o compostar, y solo al final disponer.
- **Problema de ruteo:** la ruta óptima que visita varios puntos es el problema del viajante, que no tiene una solución rápida exacta; por eso se usan heurísticas.

**Marco conceptual**
- *Residuo aprovechable* (caneca blanca), *orgánico aprovechable* (caneca verde), *no aprovechable* (caneca negra).
- *Punto ecológico*, *cuarto de acopio*, *ronda de recolección*.
- *Generación per cápita*, *densidad del residuo*.

**Marco legal**
- Resolución 2184 de 2019: código de colores para la separación en la fuente.
- CONPES 3874 de 2016: Política Nacional para la Gestión Integral de Residuos Sólidos.
- Decreto 2981 de 2013: prestación del servicio público de aseo.
- Ley 675 de 2001: régimen de propiedad horizontal (cómo se organiza el conjunto).
- Ley 1581 de 2012: protección de datos personales.

## 7. Diseño metodológico
| Elemento | Decisión |
|---|---|
| **Enfoque** | Cuantitativo |
| **Alcance** | Descriptivo y propositivo |
| **Diseño** | No experimental; estudio de caso prospectivo con **simulación de escenarios** (ronda fija contra ruta priorizada) |
| **Unidad de análisis** | El sistema de recolección interna del conjunto |
| **Población** | 96 viviendas, 21 contenedores, 9 puntos de recolección (4 puntos ecológicos, 4 zonas comunes y 1 acopio) |
| **Muestra** | No se muestrea: se modela el **total** de la población (censo), porque es pequeña y los datos provienen de fuentes secundarias y simulación |
| **Periodo simulado** | 4 semanas (12 oct – 9 nov 2026) más los escenarios que se simulen en la presentación |

> El conjunto no está habitado, así que no hay residentes a quienes medir. Por eso la generación se estima con fuentes oficiales y el comportamiento se simula. Este enfoque fue aprobado por el docente de la materia.

## 8. Variables
| Variable | Tipo | Definición operacional | Unidad | Fuente |
|---|---|---|---|---|
| Estrategia de recolección | Independiente | Ronda fija (todos los puntos) o ruta priorizada (los urgentes + las zonas sociales) | Categórica | Software |
| Distancia por ronda | Dependiente | Suma de las aristas de la ruta (Dijkstra) | m | Software |
| Tiempo por ronda | Dependiente | T(d, n) = d/v + n·tv | min | Software |
| Desbordamientos | Dependiente | Litros que no caben en el contenedor durante la simulación | L | Software |
| Porcentaje de aprovechamiento | Dependiente | kg (blanco + verde) ÷ kg totales | % | Histórico |
| Generación por vivienda | Interviniente | kg/persona/día × personas/hogar | kg/día | DANE, MinAmbiente |
| Lugar, día y hora | Interviniente | Factores de la función G(lugar, día, hora) | — | Modelo |

## 9. Técnicas e instrumentos
1. **Revisión documental**, con una ficha de fuentes (fuente, año, dato extraído, cómo se usa). Fuentes: DANE, MinAmbiente, Superservicios y normas.
2. **Matriz de supuestos**, que documenta cada valor supuesto y su justificación (`ConstantesModelo.cs` y el `LEEME.md`).
3. **Modelación y simulación**: el software EcoResiduos (modelo de generación, predicción con integrales, prioridad, ruta).
4. **Registro sistematizado**: los archivos `.txt` del software (puntos, contenedores, vías, histórico de recolecciones).
5. *(Opcional)* **Encuesta corta** a hogares de un conjunto similar para contrastar los hábitos de separación (Anexo A).

## 10. Procedimiento
1. **Revisión documental** y construcción de la matriz de supuestos.
2. **Modelación del conjunto:** plano en coordenadas, grafo de vías, contenedores y tasas de generación.
3. **Desarrollo del software** (Programación III y Estructura de Datos).
4. **Simulación:** 4 semanas de histórico y escenarios adicionales (por ejemplo, un fin de semana).
5. **Cálculo de indicadores** y comparación de las dos estrategias.
6. **Análisis**, conclusiones y propuesta.

## 11. Criterios de rigor
- **Validez:** las cifras base vienen de fuentes oficiales (DANE, MinAmbiente, Superservicios).
- **Confiabilidad:** la simulación usa datos y semillas fijas, así que cualquiera puede repetirla y obtener lo mismo.
- **Consistencia interna:**
  - cada cálculo numérico del software se compara con su solución analítica (ver `DesarrolloMatematico.md`);
  - la generación simulada (2,22 kg/casa/día) coincide con la referencia (2,24).
- **Transparencia:** todos los supuestos están escritos y se pueden cambiar.
- **Limitaciones:**
  - la generación de las zonas comunes y las curvas horarias son supuestos del equipo;
  - la composición de los residuos es una referencia mundial;
  - los resultados deben validarse cuando el conjunto esté habitado.

## 12. Consideraciones éticas
- No se recolectan datos personales de residentes. Si se aplica la encuesta opcional, será anónima, voluntaria y con consentimiento informado (Ley 1581 de 2012).
- Las contraseñas del software se guardan con hash SHA-256, nunca en texto plano.
- Todas las fuentes se citan (normas APA).
- Los datos simulados se presentan como simulados, nunca como mediciones reales.

## 13. Sistematización y análisis
- Los datos quedan en archivos `.txt`. El software calcula los indicadores (Análisis → Indicadores) para el periodo que se elija.
- El análisis es descriptivo:
  - totales y porcentajes por tipo de residuo;
  - frecuencia de recolección por punto;
  - diferencia porcentual de distancia y tiempo entre las dos estrategias.

## 14. Resultados preliminares (simulación del 13 oct al 8 nov de 2026, 27 días)
| Indicador | Resultado |
|---|---|
| Recolecciones registradas | 232 (≈ 60 por semana) |
| Residuos recogidos | 6.325 kg |
| Composición | 41,6 % orgánico · 38,7 % aprovechable · 19,7 % no aprovechable |
| Potencial de aprovechamiento (blanco + verde) | 80,3 % |
| Generación por vivienda | 2,22 kg/día (referencia: 2,24) |
| Ruta del lunes 9 de noviembre, 7:00 | Priorizada: 557 m (8 paradas, 14 contenedores) · ronda fija: 785 m (21 contenedores) → **29 % menos distancia** |

**Recolecciones por punto:**

| Punto | Recolecciones | Por semana | kg |
|---|---|---|---|
| Punto ecológico Vía 1 | 51 | 13,2 | 1.610,6 |
| Punto ecológico Vía 2 | 43 | 11,1 | 1.373,6 |
| Punto ecológico Vía 3 | 46 | 11,9 | 1.468,7 |
| Punto ecológico Vía 4 | 44 | 11,4 | 1.307,1 |
| Zona de asados | 16 | 4,1 | 234,2 |
| Piscina | 12 | 3,1 | 172,1 |
| Parque infantil | 12 | 3,1 | 78,5 |
| Gimnasio | 8 | 2,1 | 80,7 |

## 15. Conclusiones preliminares
1. Priorizar por llenado proyectado reduce el recorrido de la ronda (29 % en el escenario del lunes), porque solo se visitan los puntos que lo necesitan; las zonas sociales se revisan en cada ronda por ser áreas de uso común.
2. Más del 80 % de lo que genera el conjunto es aprovechable o compostable. La separación en la fuente es la mayor oportunidad de mejora.
3. Las zonas sociales generan poco en volumen, pero se concentran en el fin de semana. Una ronda fija las atiende de más entre semana y de menos el sábado y el domingo.
4. Estos resultados vienen de un modelo y deben validarse con mediciones reales cuando el conjunto esté habitado.

## Referencias
> Pásenlas a formato APA 7 y verifiquen cada enlace.
- DANE (2018). *Censo Nacional de Población y Vivienda 2018 – Cesar*. https://www.dane.gov.co/files/censo2018/informacion-tecnica/presentaciones-territorio/050919-CNPV-presentacion-Cesar.pdf
- Ministerio de Ambiente y Desarrollo Sostenible. *Guía de residuos sólidos*. https://www.minambiente.gov.co/wp-content/uploads/2022/12/Guia_Residuos-Solidos_Digital.pdf
- Superintendencia de Servicios Públicos Domiciliarios (2019). *Informe de visita – Aseo Urbano S.A.S. E.S.P., Aguachica*. https://www.superservicios.gov.co/sites/default/files/inline-files/aseo_urbano_s.a.s._e.s.p._-aguachica.pdf
- Universidad Industrial de Santander. *Validación y mejora del plan de gestión integral de residuos sólidos del municipio de Río de Oro, departamento del Cesar*. https://noesis.uis.edu.co/items/17f9ee69-ef7f-40b5-a519-1a477b4f9ca2/full
- *Alternativas para el manejo de los residuos sólidos generados en un municipio de la región Caribe colombiana*. https://zenodo.org/records/4281422
- Resolución 2184 de 2019; CONPES 3874 de 2016; Decreto 2981 de 2013; Ley 675 de 2001; Ley 1581 de 2012.

---

## Anexo A. Encuesta corta (opcional, anónima)
*Consentimiento: "Esta encuesta es anónima y voluntaria. Los datos se usan solo con fines académicos."*
1. ¿Cuántas personas viven en su hogar? ___
2. ¿Separa los residuos en su casa? ☐ Siempre ☐ A veces ☐ Nunca
3. ¿Conoce el código de colores blanco, verde y negro? ☐ Sí ☐ No
4. ¿Cuántas bolsas de basura saca su hogar en una semana? ___
5. ¿Qué días genera más basura? ☐ Entre semana ☐ Fin de semana ☐ Igual
6. ¿Ha visto contenedores desbordados en su conjunto? ☐ Frecuentemente ☐ A veces ☐ Nunca
