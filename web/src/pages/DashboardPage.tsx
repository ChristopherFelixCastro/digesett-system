import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import axiosClient from '../api/axiosClient';
import EstadoBadge from '../components/EstadoBadge';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';
import { puedeImpugnar } from '../utils/impugnacion';

interface Acta {
  id:                   string;
  placa:                string;
  estado:               string;
  montoBase:            number;
  montoRecargo:         number;
  fechaEmision:         string;
  fechaLimitePago:      string;
  reincidente:          boolean;
  identificacionPendiente: boolean;
}

export default function DashboardPage() {
  const [actas,   setActas]   = useState<Acta[]>([]);
  const [loading, setLoading] = useState(true);
  const [error,   setError]   = useState<number | null>(null);
  const [impugnando, setImpugnando] = useState<string | null>(null);
  const [motivoImpugnacion, setMotivoImpugnacion] = useState('');

  const { auth, logout } = useAuth();
  const navigate = useNavigate();

  useEffect(() => {
    cargarActas();
  }, []);

  const cargarActas = async () => {
    setLoading(true);
    setError(null);
    try {
      const { data } = await axiosClient.get('/api/v1/actas');
      setActas(Array.isArray(data) ? data : data.actas ?? []);
    } catch (err: any) {
      setError(err.response?.status ?? 0);
    } finally {
      setLoading(false);
    }
  };

  const handleImpugnar = async (actaId: string) => {
    if (!motivoImpugnacion.trim()) return;
    try {
      await axiosClient.post('/api/v1/impugnaciones', {
        actaId,
        motivo: motivoImpugnacion
      });
      setImpugnando(null);
      setMotivoImpugnacion('');
      cargarActas();
    } catch {
      alert('No se pudo registrar la impugnación. Intenta de nuevo.');
    }
  };

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  const totalPendiente = actas
    .filter(a => a.estado === 'PENDIENTE' || a.estado === 'EMITIDA')
    .reduce((sum, a) => sum + a.montoBase + a.montoRecargo, 0);

  return (
    <div style={{ maxWidth: '900px', margin: '0 auto', padding: '2rem 1rem' }}>

      {/* Header del dashboard */}
      <div style={{
        display: 'flex', justifyContent: 'space-between',
        alignItems: 'flex-start', marginBottom: '2rem',
        flexWrap: 'wrap', gap: '1rem'
      }}>
        <div>
          <h1 style={{ fontSize: '1.5rem', fontWeight: 800, color: '#0F172A' }}>
            Mi Dashboard
          </h1>
          <p style={{ color: '#64748B', fontSize: '.88rem', marginTop: '.25rem' }}>
            Bienvenido, <strong>{auth.rol}</strong> — Gestiona tus multas e impugnaciones
          </p>
        </div>
        <button
          onClick={handleLogout}
          style={{
            background: '#FEE2E2', color: '#991B1B',
            border: '1px solid #FECACA', borderRadius: '6px',
            padding: '.5rem 1rem', cursor: 'pointer',
            fontSize: '.83rem', fontWeight: 600
          }}
        >
          Cerrar Sesión
        </button>
      </div>

      {/* Tarjeta resumen */}
      {!loading && !error && (
        <div style={{
          display: 'grid', gridTemplateColumns: 'repeat(3, 1fr)',
          gap: '1rem', marginBottom: '2rem'
        }}>
          {[
            {
              label: 'Total de Actas',
              value: actas.length,
              color: '#0F539C', bg: '#EFF6FF'
            },
            {
              label: 'Pendientes de Pago',
              value: actas.filter(a =>
                a.estado === 'PENDIENTE' || a.estado === 'EMITIDA'
              ).length,
              color: '#991B1B', bg: '#FEE2E2'
            },
            {
              label: 'Monto Total Pendiente',
              value: `RD$ ${totalPendiente.toLocaleString('es-DO', { minimumFractionDigits: 2 })}`,
              color: '#92400E', bg: '#FEF3C7'
            },
          ].map(card => (
            <div key={card.label} style={{
              background: card.bg, borderRadius: '8px',
              padding: '1.25rem', border: `1px solid ${card.color}22`
            }}>
              <div style={{
                fontSize: '.75rem', fontWeight: 600,
                color: card.color, textTransform: 'uppercase',
                letterSpacing: '.06em', marginBottom: '.5rem'
              }}>
                {card.label}
              </div>
              <div style={{
                fontSize: '1.4rem', fontWeight: 800, color: card.color
              }}>
                {card.value}
              </div>
            </div>
          ))}
        </div>
      )}

      {/* Estados */}
      {loading && <LoadingSpinner />}
      {error   && <ErrorMessage status={error} onRetry={cargarActas} />}

      {/* Lista de actas */}
      {!loading && !error && actas.length === 0 && (
        <div style={{
          textAlign: 'center', padding: '3rem',
          background: 'white', borderRadius: '8px',
          border: '1px solid #E2E8F0', color: '#64748B'
        }}>
          ✅ No tienes multas registradas en el sistema.
        </div>
      )}

      {!loading && !error && actas.map(acta => (
        <div key={acta.id} style={{
          background: 'white', border: '1px solid #E2E8F0',
          borderRadius: '10px', marginBottom: '1rem',
          overflow: 'hidden',
          boxShadow: '0 1px 4px rgba(0,0,0,.06)'
        }}>
          {/* Header del acta */}
          <div style={{
            padding: '.85rem 1.25rem',
            background: '#F8FAFC',
            borderBottom: '1px solid #E2E8F0',
            display: 'flex', justifyContent: 'space-between',
            alignItems: 'center', flexWrap: 'wrap', gap: '.5rem'
          }}>
            <div style={{ display: 'flex', alignItems: 'center', gap: '.75rem' }}>
              <span style={{
                fontFamily: 'monospace', fontSize: '.78rem',
                color: '#64748B', background: '#F1F5F9',
                padding: '.2rem .5rem', borderRadius: '4px'
              }}>
                #{acta.id.substring(0, 8).toUpperCase()}
              </span>
              <EstadoBadge estado={acta.estado} />
              {acta.reincidente && (
                <span style={{
                  background: '#FEF3C7', color: '#92400E',
                  fontSize: '.68rem', fontWeight: 700,
                  padding: '.18rem .5rem', borderRadius: '3px'
                }}>
                  ⚠️ REINCIDENTE
                </span>
              )}
            </div>
            <span style={{ fontSize: '.78rem', color: '#64748B' }}>
              {new Date(acta.fechaEmision).toLocaleDateString('es-DO', {
                year: 'numeric', month: 'long', day: 'numeric'
              })}
            </span>
          </div>

          {/* Cuerpo del acta */}
          <div style={{ padding: '1.25rem' }}>
            <div style={{
              display: 'grid', gridTemplateColumns: 'repeat(3, 1fr)',
              gap: '1rem', marginBottom: '1rem'
            }}>
              <div>
                <div style={{ fontSize: '.72rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase' }}>Placa</div>
                <div style={{ fontWeight: 700, color: '#0F172A' }}>{acta.placa || 'N/A'}</div>
              </div>
              <div>
                <div style={{ fontSize: '.72rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase' }}>Multa Base</div>
                <div style={{ fontWeight: 700, color: '#0F172A' }}>
                  RD$ {acta.montoBase.toLocaleString('es-DO')}
                </div>
              </div>
              <div>
                <div style={{ fontSize: '.72rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase' }}>Total a Pagar</div>
                <div style={{ fontWeight: 800, fontSize: '1.1rem', color: '#CE1126' }}>
                  RD$ {(acta.montoBase + acta.montoRecargo).toLocaleString('es-DO')}
                </div>
              </div>
            </div>

            {/* Fecha límite */}
            {(acta.estado === 'PENDIENTE' || acta.estado === 'EMITIDA') && (
              <div style={{
                fontSize: '.78rem', color: '#92400E',
                background: '#FEF3C7', padding: '.4rem .75rem',
                borderRadius: '4px', marginBottom: '1rem', display: 'inline-block'
              }}>
                ⏰ Fecha límite de pago: {new Date(acta.fechaLimitePago).toLocaleDateString('es-DO')}
              </div>
            )}

            {/* Botones de acción */}
            <div style={{ display: 'flex', gap: '.75rem', flexWrap: 'wrap' }}>
              {(acta.estado === 'PENDIENTE' || acta.estado === 'EMITIDA') && (
                <button
                  onClick={() => navigate(`/pagar/${acta.id}`)}
                  style={{
                    background: '#0F539C', color: 'white',
                    border: 'none', borderRadius: '6px',
                    padding: '.5rem 1.25rem', cursor: 'pointer',
                    fontWeight: 600, fontSize: '.85rem'
                  }}
                >
                  💳 Pagar Multa
                </button>
              )}

              {(acta.estado === 'PENDIENTE' || acta.estado === 'EMITIDA') &&
               puedeImpugnar(acta.fechaEmision) && (
                <button
                  onClick={() => setImpugnando(acta.id)}
                  style={{
                    background: 'white', color: '#92400E',
                    border: '1px solid #FCD34D', borderRadius: '6px',
                    padding: '.5rem 1.25rem', cursor: 'pointer',
                    fontWeight: 600, fontSize: '.85rem'
                  }}
                >
                  📋 Impugnar
                </button>
              )}

              {acta.estado === 'PAGADA' && (
                <span style={{
                  color: '#15803D', fontSize: '.85rem',
                  fontWeight: 600, display: 'flex',
                  alignItems: 'center', gap: '.35rem'
                }}>
                  ✅ Multa pagada
                </span>
              )}
            </div>

            {/* Modal de impugnación */}
            {impugnando === acta.id && (
              <div style={{
                marginTop: '1rem', padding: '1rem',
                background: '#FFFBEB', border: '1px solid #FCD34D',
                borderRadius: '8px'
              }}>
                <p style={{ fontSize: '.85rem', fontWeight: 600, marginBottom: '.5rem' }}>
                  Describe el motivo de tu impugnación:
                </p>
                <textarea
                  value={motivoImpugnacion}
                  onChange={e => setMotivoImpugnacion(e.target.value)}
                  placeholder="Explica por qué consideras que esta multa es incorrecta..."
                  rows={3}
                  style={{
                    width: '100%', padding: '.65rem',
                    border: '1px solid #D1D5DB', borderRadius: '6px',
                    fontSize: '.85rem', resize: 'vertical', marginBottom: '.75rem'
                  }}
                />
                <div style={{ display: 'flex', gap: '.5rem' }}>
                  <button
                    onClick={() => handleImpugnar(acta.id)}
                    style={{
                      background: '#92400E', color: 'white',
                      border: 'none', borderRadius: '6px',
                      padding: '.5rem 1rem', cursor: 'pointer',
                      fontWeight: 600, fontSize: '.83rem'
                    }}
                  >
                    Confirmar Impugnación
                  </button>
                  <button
                    onClick={() => { setImpugnando(null); setMotivoImpugnacion(''); }}
                    style={{
                      background: 'white', color: '#64748B',
                      border: '1px solid #D1D5DB', borderRadius: '6px',
                      padding: '.5rem 1rem', cursor: 'pointer',
                      fontSize: '.83rem'
                    }}
                  >
                    Cancelar
                  </button>
                </div>
              </div>
            )}
          </div>
        </div>
      ))}
    </div>
  );
}