import { useState } from 'react';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

interface ActaResultado {
  id: string;
  placa: string | null;
  estado: string | null;
  montoBase: number;
  montoRecargo: number;
  fechaHecho: string | null;
  fechaEmision: string | null;
  fechaLimitePago: string | null;
  reincidente: boolean;
  conductorCedula: string | null;
  conductorNombre: string | null;
  tipoInfraccionDesc: string | null;
}

export default function ConsultaPage() {
  const [busqueda, setBusqueda] = useState('');
  const [tipo, setTipo] = useState<'cedula' | 'placa'>('cedula');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<number | null>(null);
  const [resultados, setResultados] = useState<ActaResultado[]>([]);
  const [consultado, setConsultado] = useState(false);

  const buscar = async () => {
    if (!busqueda.trim()) return;
    setLoading(true);
    setError(null);
    setResultados([]);
    setConsultado(false);

    try {
      const params = tipo === 'cedula'
        ? { cedula: busqueda.trim() }
        : { placa: busqueda.trim() };
      const { data } = await axiosClient.get('/api/public/actas', { params });
      setResultados(Array.isArray(data) ? data : []);
    } catch (err: any) {
      if (err.isOffline) setError(0);
      else setError(err.response?.status ?? 0);
    } finally {
      setLoading(false);
      setConsultado(true);
    }
  };

  const badgeEstilo = (estado: string | null) => {
    const estilos: Record<string, { bg: string; color: string }> = {
      PENDIENTE: { bg: '#FEF3C7', color: '#92400E' },
      EMITIDA:   { bg: '#DBEAFE', color: '#1E40AF' },
      PAGADA:    { bg: '#D1FAE5', color: '#065F46' },
      ANULADA:   { bg: '#FEE2E2', color: '#991B1B' },
    };
    return estilos[estado ?? ''] ?? { bg: '#F3F4F6', color: '#374151' };
  };

  const formatearMonto = (monto: number) =>
    `RD$ ${monto.toLocaleString('es-DO', { minimumFractionDigits: 2 })}`;

  return (
    <div className="consulta-page">
      <section className="consulta-hero">
        <p className="eyebrow">Servicios en línea</p>
        <h1>Consulta pública de multas</h1>
        <p>Consulta las multas registradas por cédula o placa. Los datos provienen directamente del sistema DIGESETT.</p>
      </section>

      <section className="consulta-panel">
        <div className="consulta-panel__heading">
          <span>01</span>
          <div>
            <h2>Datos de consulta</h2>
            <p>Selecciona el tipo de documento e ingresa el número a consultar.</p>
          </div>
        </div>

        <div className="consulta-options" role="group" aria-label="Tipo de consulta">
          <button
            onClick={() => { setTipo('cedula'); setResultados([]); setConsultado(false); }}
            className={tipo === 'cedula' ? 'selected' : ''}
          >
            <span>CI</span>
            <div>
              <strong>Por cédula</strong>
              <small>Identidad del ciudadano</small>
            </div>
          </button>
          <button
            onClick={() => { setTipo('placa'); setResultados([]); setConsultado(false); }}
            className={tipo === 'placa' ? 'selected' : ''}
          >
            <span>PL</span>
            <div>
              <strong>Por placa</strong>
              <small>Registro del vehículo</small>
            </div>
          </button>
        </div>

        <div className="consulta-search">
          <input
            value={busqueda}
            onChange={e => setBusqueda(e.target.value)}
            onKeyDown={e => e.key === 'Enter' && buscar()}
            placeholder={tipo === 'cedula' ? '000-0000000-0' : 'Ej: A012345'}
          />
          <button
            className="consulta-search__button"
            onClick={buscar}
            disabled={loading}
          >
            {loading ? 'Consultando...' : 'Consultar'}
          </button>
        </div>
      </section>

      {loading && <LoadingSpinner />}

      {error !== null && (
        <ErrorMessage
          status={error === 0 ? undefined : error}
          offline={error === 0}
          onRetry={buscar}
        />
      )}

      {consultado && !loading && error === null && resultados.length === 0 && (
        <section className="consulta-result">
          <div className="consulta-result__bar">
            <span>Resultado de la consulta</span>
            <strong>Sin resultados</strong>
          </div>
          <div className="consulta-result__body" style={{ textAlign: 'center', padding: '2rem', color: '#64748B' }}>
            No se encontraron multas para {tipo === 'cedula' ? 'la cédula' : 'la placa'} ingresada.
          </div>
        </section>
      )}

      {consultado && !loading && error === null && resultados.length > 0 && (
        <section className="consulta-result">
          <div className="consulta-result__bar">
            <span>Resultado de la consulta</span>
            <strong>{resultados.length} multa(s) encontrada(s)</strong>
          </div>
          <div className="consulta-result__body">
            {resultados[0].conductorNombre && (
              <div className="consulta-result__identity">
                <span>CI</span>
                <div>
                  <small>Conductor</small>
                  <h2>{resultados[0].conductorNombre}</h2>
                  <p style={{ color: '#64748B', fontSize: '.82rem', margin: 0 }}>
                    Cédula: {resultados[0].conductorCedula}
                  </p>
                </div>
              </div>
            )}

            {resultados.map(acta => (
              <div
                key={acta.id}
                style={{
                  border: '1px solid #E2E8F0',
                  borderRadius: '8px',
                  marginTop: '1rem',
                  overflow: 'hidden'
                }}
              >
                <div style={{
                  padding: '.75rem 1rem',
                  background: '#F8FAFC',
                  borderBottom: '1px solid #E2E8F0',
                  display: 'flex', justifyContent: 'space-between',
                  alignItems: 'center', flexWrap: 'wrap', gap: '.5rem'
                }}>
                  <div style={{ display: 'flex', alignItems: 'center', gap: '.65rem' }}>
                    <span style={{
                      fontFamily: 'monospace', fontSize: '.75rem',
                      color: '#64748B', background: '#F1F5F9',
                      padding: '.2rem .5rem', borderRadius: '4px'
                    }}>
                      #{acta.id.substring(0, 8).toUpperCase()}
                    </span>
                    <span style={{
                      display: 'inline-block', padding: '.15rem .6rem',
                      borderRadius: '4px', fontSize: '.72rem', fontWeight: 700,
                      background: badgeEstilo(acta.estado).bg,
                      color: badgeEstilo(acta.estado).color
                    }}>
                      {acta.estado}
                    </span>
                    {acta.reincidente && (
                      <span style={{
                        background: '#FEF3C7', color: '#92400E',
                        fontSize: '.65rem', fontWeight: 700,
                        padding: '.15rem .45rem', borderRadius: '3px'
                      }}>
                        REINCIDENTE
                      </span>
                    )}
                  </div>
                  <span style={{ fontSize: '.75rem', color: '#64748B' }}>
                    {acta.fechaHecho ? new Date(acta.fechaHecho).toLocaleDateString('es-DO') : '-'}
                  </span>
                </div>

                <div style={{ padding: '1rem' }}>
                  <div style={{
                    display: 'grid', gridTemplateColumns: 'repeat(2, 1fr)',
                    gap: '.75rem', marginBottom: '.75rem'
                  }}>
                    <div>
                      <div style={{ fontSize: '.68rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase' }}>Placa</div>
                      <div style={{ fontWeight: 700, color: '#0F172A' }}>{acta.placa || 'N/A'}</div>
                    </div>
                    <div>
                      <div style={{ fontSize: '.68rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase' }}>Infracción</div>
                      <div style={{ fontWeight: 600, color: '#0F172A', fontSize: '.85rem' }}>{acta.tipoInfraccionDesc || 'N/A'}</div>
                    </div>
                    <div>
                      <div style={{ fontSize: '.68rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase' }}>Multa Base</div>
                      <div style={{ fontWeight: 700, color: '#0F172A' }}>{formatearMonto(acta.montoBase)}</div>
                    </div>
                    <div>
                      <div style={{ fontSize: '.68rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase' }}>Total</div>
                      <div style={{ fontWeight: 800, fontSize: '1rem', color: '#CE1126' }}>
                        {formatearMonto(acta.montoBase + acta.montoRecargo)}
                      </div>
                    </div>
                  </div>

                  {(acta.estado === 'PENDIENTE' || acta.estado === 'EMITIDA') && acta.fechaLimitePago && (
                    <div style={{
                      fontSize: '.75rem', color: '#92400E',
                      background: '#FEF3C7', padding: '.35rem .7rem',
                      borderRadius: '4px', display: 'inline-block'
                    }}>
                      Fecha límite de pago: {new Date(acta.fechaLimitePago).toLocaleDateString('es-DO')}
                    </div>
                  )}

                  {acta.estado === 'PAGADA' && (
                    <div style={{ fontSize: '.82rem', color: '#065F46', fontWeight: 600 }}>
                      Multa pagada
                    </div>
                  )}
                </div>
              </div>
            ))}
          </div>
        </section>
      )}
    </div>
  );
}
