# Genera los .txt de RutaCircular/Data con el mismo modelo de generación del programa.
# Uso:  python generar_datos.py ../RutaCircular/Data
import math, datetime as dt, random, sys
OUT = sys.argv[1]
random.seed(2026)

# ---------- Modelo (idéntico a ModeloGeneracion.cs) ----------
def g(h, mu, s): return math.exp(-((h-mu)**2)/(2*s*s))
RAW_H = {
 'PuntoEcologico': lambda h: 0.3 + 1.0*g(h,7,1.5) + 1.2*g(h,19.5,2),
 'Piscina':        lambda h: 0.05 + g(h,14,2.5),
 'Gimnasio':       lambda h: 0.05 + g(h,6.5,1) + g(h,19,1.5),
 'ZonaAsados':     lambda h: 0.02 + g(h,13,1.5) + 1.2*g(h,19.5,1.5),
 'ParqueInfantil': lambda h: 0.05 + g(h,16.5,1.5),
}
# índice 0=domingo ... 6=sábado (como DayOfWeek de .NET)
RAW_D = {
 'PuntoEcologico': [1.3,1,1,1,1,1,1.3],
 'Piscina':        [2.5,.7,.7,.7,.7,.7,2.5],
 'Gimnasio':       [.5,1,1,1,1,1,.5],
 'ZonaAsados':     [3,.2,.2,.2,.2,1.2,3],
 'ParqueInfantil': [1.6,1,1,1,1,1,1.6],
}
MEAN_H = {k: sum(f((i+0.5)*24/2400) for i in range(2400))/2400 for k,f in RAW_H.items()}
MEAN_D = {k: sum(v)/7 for k,v in RAW_D.items()}
def dow(t): return (t.weekday()+1) % 7   # python lunes=0 -> .NET domingo=0
def tasa(tipo, base, t):
    h = t.hour + t.minute/60 + t.second/3600
    return base * RAW_H[tipo](h)/MEAN_H[tipo] * RAW_D[tipo][dow(t)]/MEAN_D[tipo]

# ---------- Constantes ----------
KG_PERSONA, PERSONAS, DENS = 0.64, 3.5, 0.2
COMP = {'Organico':0.44,'Aprovechable':0.38,'NoAprovechable':0.18}
kg_pe = 24*PERSONAS*KG_PERSONA
def base_pe(t): return round(kg_pe*COMP[t]/DENS/24, 2)

# ---------- Puntos ----------
puntos = [(1,'Cuarto de acopio','Acopio',4,156,0)]
vy = [19,57,95,133]
for k in range(4):
    puntos.append((11+k, f'Punto ecológico Vía {k+1}', 'PuntoEcologico', 12, vy[k], 24))
puntos += [(21,'Piscina','Piscina',88,20,0),(22,'Gimnasio','Gimnasio',88,50,0),
           (23,'Zona de asados','ZonaAsados',88,85,0),(24,'Parque infantil','ParqueInfantil',88,122,0)]
for k in range(4):
    puntos.append((31+k, f'Cruce Vía {k+1} - Vía principal','Interseccion',4,vy[k],0))
for k in range(4):
    puntos.append((41+k, f'Cruce Vía {k+1} - Sendero','Interseccion',82,vy[k],0))
P = {p[0]:p for p in puntos}

pares = [(31,32),(32,33),(33,34),(34,1)]
for k in range(4): pares += [(31+k,11+k),(11+k,41+k)]
pares += [(41,42),(42,43),(43,44),(41,21),(42,22),(43,23),(44,24)]
vias = []
for i,(a,b) in enumerate(pares, start=1):
    d = math.hypot(P[a][3]-P[b][3], P[a][4]-P[b][4])
    vias.append((i,a,b,round(d,2)))

# ---------- Contenedores ----------
cont = []  # id, punto, tipo, cap, base, tipoPunto
FACT = [1.10, 0.95, 1.00, 0.88]   # supuesto: ocupación/habitantes distinta por vía
for k in range(4):
    pid = 11+k
    cont += [(pid*10+1,pid,'Organico',240,round(base_pe('Organico')*FACT[k],2),'PuntoEcologico'),
             (pid*10+2,pid,'Aprovechable',240,round(base_pe('Aprovechable')*FACT[k],2),'PuntoEcologico'),
             (pid*10+3,pid,'NoAprovechable',120,round(base_pe('NoAprovechable')*FACT[k],2),'PuntoEcologico')]
cont += [(211,21,'Aprovechable',120,0.8,'Piscina'),(212,21,'NoAprovechable',120,0.5,'Piscina'),
         (221,22,'Aprovechable',120,0.4,'Gimnasio'),(222,22,'NoAprovechable',60,0.2,'Gimnasio'),
         (231,23,'Organico',120,0.8,'ZonaAsados'),(232,23,'Aprovechable',120,0.6,'ZonaAsados'),(233,23,'NoAprovechable',120,0.5,'ZonaAsados'),
         (241,24,'Aprovechable',60,0.3,'ParqueInfantil'),(242,24,'NoAprovechable',60,0.3,'ParqueInfantil')]

# ---------- Simulación del histórico ----------
inicio = dt.datetime(2026,10,12,0,0); fin = dt.datetime(2026,11,9,7,0)
nivel = {c[0]: c[3]*random.uniform(0,0.3) for c in cont}
recs = []; paso = dt.timedelta(minutes=15); t = inicio
while t < fin:
    if t.minute == 0 and t.hour in (7,17):
        umbral = 0.5 if t.hour == 7 else 0.8
        for c in cont:
            if nivel[c[0]] >= umbral*c[3]:
                recs.append((len(recs)+1, c[0], t.strftime('%Y-%m-%d %H:%M'), round(nivel[c[0]],2), 2))
                nivel[c[0]] = 0.0
    mid = t + paso/2
    for c in cont:
        nivel[c[0]] = min(c[3], nivel[c[0]] + tasa(c[5], c[4], mid)*0.25)
    t += paso

with open(f'{OUT}/puntos.txt','w',encoding='utf-8') as f:
    f.write('# Id;Nombre;Tipo;X(m);Y(m);CasasAtendidas\n')
    for p in puntos: f.write(';'.join(map(str,p))+'\n')
with open(f'{OUT}/vias.txt','w',encoding='utf-8') as f:
    f.write('# Id;OrigenId;DestinoId;DistanciaMetros\n')
    for v in vias: f.write(';'.join(map(str,v))+'\n')
with open(f'{OUT}/contenedores.txt','w',encoding='utf-8') as f:
    f.write('# Id;PuntoId;TipoResiduo;CapacidadLitros;NivelLitros;TasaBaseLitrosHora\n')
    for c in cont: f.write(f'{c[0]};{c[1]};{c[2]};{c[3]};{round(nivel[c[0]],2)};{c[4]}\n')
with open(f'{OUT}/recolecciones.txt','w',encoding='utf-8') as f:
    f.write('# Id;ContenedorId;Fecha;Litros;OperarioId\n')
    for r in recs: f.write(';'.join(map(str,r))+'\n')
with open(f'{OUT}/reloj.txt','w',encoding='utf-8') as f:
    f.write(fin.strftime('%Y-%m-%d %H:%M')+'\n')

# ---------- Verificaciones ----------
dias = (fin-inicio).total_seconds()/86400
pe_l = sum(r[3] for r in recs if r[1]//10 in (11,12,13,14))
tot_l = sum(r[3] for r in recs)
apro_l = sum(r[3] for r in recs if r[1]%10==2 or (r[1]//10 in (21,22,24) and r[1]%10==1))
print('recolecciones', len(recs), 'dias', round(dias,2))
print('kg/casa/dia (PE)', round(pe_l*DENS/96/dias,3), 'esperado', round(PERSONAS*KG_PERSONA,3))
print('% aprovechable', round(apro_l/tot_l*100,1))
print('MEAN_H', {k:round(v,4) for k,v in MEAN_H.items()})
for c in cont: print(c[0], c[2], f'{nivel[c[0]]/c[3]*100:.0f}%', c[4])
