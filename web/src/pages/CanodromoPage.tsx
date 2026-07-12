import { useState, useEffect } from 'react';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

interface VehiculoRetenido {
  id:           number;
  actaId:       string;
  placa:        string;
  fechaIngreso: string;
  fechaSalida:  string | null;
  diasCobrados: number;
  costoTotal:   number;
  estado:       string;
}

const colorEstado: Record<string, string> = {
  RETENIDO:             '#FEE2E2',
  APTO_PARA_LIBERACION: '#FEF3C7',
  LIBERADO:             '#DCFCE7',
};

const textoEstado: Record<string, string> = {
  RETENIDO:             '🔴 Retenido',
  APTO_PARA_LIBERACION: '🟡 Apto para liberación',
  LIBERADO:             '🟢 Liberado',
};

export default function CanodromoPage() {
  const [busqueda,     setBusqueda]     = useState('');
  const [todos,        setTodos]        = useState<VehiculoRetenido[]>([]);
  const [resultado,    setResultado]    = useState<VehiculoRetenido | null>(null);
  const [noEncontrado, setNoEncontrado] = useState(false);
  const [loading,      setLoading]      = useState(false);
  const [error,        setError]        = useState<number | null>(null);
  const [cargando,     setCargando]     = useState(true);

  // Cargar todos los vehículos al montar el componente
  useEffect(() => {
    cargarTodos();
  }, []);

  const cargarTodos = async () => {
    setCargando(true);
    setError(null);
    try {
      const { data } = await axiosClient.get('/api/v1/canodromos');
      setTodos(Array.isArray(data) ? data : []);
    } catch (err: any) {
      setError(err.response?.status ?? 0);
    } finally {
      setCargando(false);
    }
  };

  const buscar = () => {
    if (!busqueda.trim()) return;
    setLoading(true);
    setResultado(null);
    setNoEncontrado(false);

    // Filtrar localmente por placa
    const encontrado = todos.find(
      v => v.placa.toUpperCase() === busqueda.toUpperCase().trim()
    );

    setTimeout(() => {
      if (encontrado) {
        setResultado(encontrado);
      } else {
        setNoEncontrado(true);
      }
      setLoading(false);
    }, 400);
  };

  return (
    <div style={{ maxWidth: '600px', margin: '3rem auto', padding: '0 1rem' }}>
      <h1 style={{ fontSize: '1.5rem', marginBottom: '.5rem', fontWeight: 800, color: '#0F172A' }}>
        Consulta de Vehículos en el Canódromo
      </h1>
      <p style={{ color: '#64748B', marginBottom: '1.5rem', fontSize: '.9rem' }}>
        Verifica si tu vehículo está retenido ingresando la placa.
      </p>

      {/* Error cargando todos */}
      {error && !cargando && (
        <ErrorMessage status={error} onRetry={cargarTodos} />
      )}

      {/* Input de búsqueda */}
      <div style={{ display: 'flex', gap: '.5rem', marginBottom: '1.5rem' }}>
        <input
          value={busqueda}
          onChange={e => setBusqueda(e.target.value)}
          onKeyDown={e => e.key === 'Enter' && buscar()}
          placeholder="Ej: A234567"
          disabled={cargando}
          style={{
            flex: 1, padding: '.6rem 1rem',
            border: '1px solid #D1D5DB', borderRadius: '6px',
            fontSize: '.9rem'
          }}
        />
        <button
          onClick={buscar}
          disabled={cargando || loading}
          style={{
            padding: '.6rem 1.25rem',
            background: cargando ? '#93B9E0' : '#0F539C',
            color: 'white', border: 'none', borderRadius: '6px',
            cursor: cargando ? 'not-allowed' : 'pointer', fontWeight: 600
          }}
        >
          {cargando ? 'Cargando...' : 'Buscar'}
        </button>
      </div>

      {/* Cargando datos iniciales */}
      {cargando && <LoadingSpinner />}

      {/* Spinner de búsqueda */}
      {loading && !cargando && <LoadingSpinner />}

      {/* No encontrado */}
      {noEncontrado && !loading && (
        <div style={{
          background: '#F0FDF4', border: '1px solid #BBF7D0',
          borderRadius: '8px', padding: '1.25rem',
          color: '#15803D', fontSize: '.9rem'
        }}>
          ✅ El vehículo con placa <strong>{busqueda.toUpperCase()}</strong> no
          se encuentra retenido en el Canódromo.
        </div>
      )}

      {/* Resultado */}
      {resultado && !loading && (
        <div style={{
          border: '1px solid #E2E8F0', borderRadius: '10px',
          overflow: 'hidden', background: 'white',
          boxShadow: '0 1px 4px rgba(0,0,0,.06)'
        }}>
          {/* Header con estado */}
          <div style={{
            background: colorEstado[resultado.estado] ?? '#F1F5F9',
            padding: '.85rem 1.25rem',
            borderBottom: '1px solid #E2E8F0',
            fontWeight: 700, fontSize: '.9rem'
          }}>
            {textoEstado[resultado.estado] ?? resultado.estado}
          </div>

          {/* Datos del vehículo */}
          <div style={{ padding: '1.25rem' }}>
            {[
              { label: 'Placa',           valor: resultado.placa },
              { label: 'Fecha de Ingreso', valor: new Date(resultado.fechaIngreso).toLocaleDateString('es-DO', { year: 'numeric', month: 'long', day: 'numeric' }) },
              { label: 'Días Retenido',   valor: `${resultado.diasCobrados} días` },
            ].map(item => (
              <div key={item.label} style={{
                display: 'flex', justifyContent: 'space-between',
                padding: '.6rem 0', borderBottom: '1px solid #F1F5F9',
                fontSize: '.88rem'
              }}>
                <span style={{ color: '#64748B' }}>{item.label}</span>
                <span style={{ fontWeight: 600, color: '#0F172A' }}>{item.valor}</span>
              </div>
            ))}

            {/* Costo de estadía */}
            <div style={{
              marginTop: '1rem',
              background: '#FFF7ED', border: '1px solid #FED7AA',
              borderRadius: '8px', padding: '1rem'
            }}>
              <div style={{ fontSize: '.75rem', fontWeight: 700, color: '#92400E', textTransform: 'uppercase', letterSpacing: '.06em', marginBottom: '.4rem' }}>
                💰 Costo de Estadía Acumulado
              </div>
              <div style={{ fontSize: '1.4rem', fontWeight: 800, color: '#EA580C' }}>
                RD$ {resultado.costoTotal.toLocaleString('es-DO', { minimumFractionDigits: 2 })}
              </div>
              <div style={{ fontSize: '.75rem', color: '#92400E', marginTop: '.25rem' }}>
                RD$200.00 × {resultado.diasCobrados} días
                {resultado.diasCobrados >= 60 && ' · (tope máximo de 60 días alcanzado)'}
              </div>
            </div>

            {/* Alerta si está listo para liberar */}
            {resultado.estado === 'APTO_PARA_LIBERACION' && (
              <div style={{
                marginTop: '1rem', background: '#FEF3C7',
                border: '1px solid #FDE68A', borderRadius: '6px',
                padding: '.85rem 1rem', fontSize: '.85rem', color: '#92400E'
              }}>
                ⚠️ Tu vehículo está listo para ser retirado. Dirígete al
                Canódromo con el comprobante de pago de tu multa.
              </div>
            )}
          </div>
        </div>
      )}

      {/* Total de vehículos retenidos */}
      {!cargando && !error && todos.length > 0 && (
        <p style={{
          marginTop: '2rem', fontSize: '.75rem',
          color: '#94A3B8', textAlign: 'center'
        }}>
          {todos.length} vehículo{todos.length !== 1 ? 's' : ''} actualmente
          en el Canódromo
        </p>
      )}
    </div>
  );
}