import { useState } from 'react';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage   from '../components/ErrorMessage';

interface VehiculoRetenido {
  placa:          string;
  marca:          string;
  modelo:         string;
  estado:         string;
  fecha_ingreso:  string;
  dias_retenido:  number;
  costo_estadia:  number;
}

// TODO: reemplazar con datos reales del endpoint GET /api/v1/canodromos/{placa}
const DATOS_MOCK: Record<string, VehiculoRetenido> = {
  'A123456': {
    placa:         'A123456',
    marca:         'Toyota',
    modelo:        'Corolla',
    estado:        'RETENIDO',
    fecha_ingreso: '2025-08-01',
    dias_retenido: 15,
    costo_estadia: 3000.00,
  },
  'B789012': {
    placa:         'B789012',
    marca:         'Honda',
    modelo:        'Civic',
    estado:        'APTO_PARA_LIBERACION',
    fecha_ingreso: '2025-07-20',
    dias_retenido: 27,
    costo_estadia: 5400.00,
  },
};

const colorEstado: Record<string, string> = {
  RETENIDO:              '#FEE2E2',
  APTO_PARA_LIBERACION:  '#FEF3C7',
  LIBERADO:              '#DCFCE7',
};

const textoEstado: Record<string, string> = {
  RETENIDO:             '🔴 Retenido',
  APTO_PARA_LIBERACION: '🟡 Apto para liberación',
  LIBERADO:             '🟢 Liberado',
};

export default function CanodromoPage() {
  const [busqueda,  setBusqueda]  = useState('');
  const [loading,   setLoading]   = useState(false);
  const [error,     setError]     = useState<number | null>(null);
  const [resultado, setResultado] = useState<VehiculoRetenido | null>(null);
  const [noEncontrado, setNoEncontrado] = useState(false);

  const buscar = async () => {
    if (!busqueda.trim()) return;
    setLoading(true);
    setError(null);
    setResultado(null);
    setNoEncontrado(false);

    // Simular delay de red
    await new Promise(r => setTimeout(r, 600));

    // TODO: reemplazar con llamada real:
    // const { data } = await axiosClient.get(`/api/v1/canodromos/${busqueda}`);
    const encontrado = DATOS_MOCK[busqueda.toUpperCase()];

    if (encontrado) {
      setResultado(encontrado);
    } else {
      setNoEncontrado(true);
    }

    setLoading(false);
  };

  return (
    <div style={{ maxWidth: '600px', margin: '3rem auto', padding: '0 1rem' }}>
      <h1 style={{ fontSize: '1.5rem', marginBottom: '.5rem' }}>
        Consulta de Vehículos en el Canódromo
      </h1>
      <p style={{ color: '#64748B', marginBottom: '1.5rem', fontSize: '.9rem' }}>
        Verifica si tu vehículo está retenido ingresando la placa o número de chasis.
      </p>

      {/* Input de búsqueda */}
      <div style={{ display: 'flex', gap: '.5rem', marginBottom: '1.5rem' }}>
        <input
          value={busqueda}
          onChange={e => setBusqueda(e.target.value)}
          onKeyDown={e => e.key === 'Enter' && buscar()}
          placeholder="Ej: A123456"
          style={{
            flex: 1, padding: '.6rem 1rem',
            border: '1px solid #d1d5db', borderRadius: '6px',
            fontSize: '.9rem'
          }}
        />
        <button
          onClick={buscar}
          disabled={loading}
          style={{
            padding: '.6rem 1.25rem', background: '#ea580c',
            color: 'white', border: 'none', borderRadius: '6px',
            cursor: 'pointer', fontWeight: 600
          }}
        >
          Buscar
        </button>
      </div>

      {/* Estados */}
      {loading && <LoadingSpinner />}
      {error   && <ErrorMessage status={error} onRetry={buscar} />}

      {/* No encontrado */}
      {noEncontrado && !loading && (
        <div style={{
          background: '#F0FDF4', border: '1px solid #BBF7D0',
          borderRadius: '8px', padding: '1.25rem',
          color: '#15803D', fontSize: '.9rem'
        }}>
          ✅ El vehículo <strong>{busqueda.toUpperCase()}</strong> no se encuentra
          retenido en el Canódromo.
        </div>
      )}

      {/* Resultado */}
      {resultado && !loading && (
        <div style={{
          border: '1px solid #e2e8f0', borderRadius: '8px',
          overflow: 'hidden', background: 'white'
        }}>
          {/* Header con estado */}
          <div style={{
            background: colorEstado[resultado.estado] ?? '#F1F5F9',
            padding: '.85rem 1.25rem',
            borderBottom: '1px solid #e2e8f0',
            fontWeight: 600, fontSize: '.9rem'
          }}>
            {textoEstado[resultado.estado] ?? resultado.estado}
          </div>

          {/* Datos */}
          <div style={{ padding: '1.25rem' }}>
            <p><strong>Placa:</strong> {resultado.placa}</p>
            <p><strong>Vehículo:</strong> {resultado.marca} {resultado.modelo}</p>
            <p><strong>Fecha de Ingreso:</strong> {new Date(resultado.fecha_ingreso).toLocaleDateString('es-DO')}</p>
            <p><strong>Días Retenido:</strong> {resultado.dias_retenido} días</p>

            <hr style={{ margin: '1rem 0', border: 'none', borderTop: '1px solid #e2e8f0' }} />

            <div style={{
              background: '#FFF7ED', border: '1px solid #FED7AA',
              borderRadius: '6px', padding: '.85rem 1rem'
            }}>
              <p style={{ margin: 0, fontWeight: 600, color: '#C2410C' }}>
                💰 Costo de Estadía Acumulado
              </p>
              <p style={{ margin: '.25rem 0 0', fontSize: '1.2rem', fontWeight: 700, color: '#ea580c' }}>
                RD$ {resultado.costo_estadia.toLocaleString('es-DO', { minimumFractionDigits: 2 })}
              </p>
              <p style={{ margin: '.25rem 0 0', fontSize: '.78rem', color: '#92400E' }}>
                RD$200.00 × {resultado.dias_retenido} días
                {resultado.dias_retenido >= 60 && ' (tope máximo alcanzado)'}
              </p>
            </div>

            {resultado.estado === 'APTO_PARA_LIBERACION' && (
              <div style={{
                marginTop: '1rem', background: '#FEF3C7',
                border: '1px solid #FDE68A', borderRadius: '6px',
                padding: '.85rem 1rem', fontSize: '.85rem', color: '#92400E'
              }}>
                ⚠️ Tu vehículo está listo para ser retirado. Dirígete al Canódromo
                con el comprobante de pago de tu multa.
              </div>
            )}
          </div>
        </div>
      )}

      {/* Nota de datos simulados */}
      <p style={{
        marginTop: '2rem', fontSize: '.75rem',
        color: '#94A3B8', textAlign: 'center'
      }}>
        * Prueba con las placas: A123456 o B789012
      </p>
    </div>
  );
}