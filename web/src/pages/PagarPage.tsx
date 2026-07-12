import { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';

interface DetalleActa {
  id:           string;
  placa:        string;
  estado:       string;
  montoBase:    number;
  montoRecargo: number;
}

export default function PagarPage() {
  const { uuid }   = useParams<{ uuid: string }>();
  const navigate   = useNavigate();

  const [acta,      setActa]      = useState<DetalleActa | null>(null);
  const [loading,   setLoading]   = useState(true);
  const [pagando,   setPagando]   = useState(false);
  const [error,     setError]     = useState<string | null>(null);

  // Campos de tarjeta
  const [numero,    setNumero]    = useState('');
  const [nombre,    setNombre]    = useState('');
  const [expiracion, setExpiracion] = useState('');
  const [cvv,       setCvv]       = useState('');

  useEffect(() => {
    cargarActa();
  }, [uuid]);

  const cargarActa = async () => {
    try {
      const { data } = await axiosClient.get(`/api/v1/actas/${uuid}`);
      setActa(data);
    } catch {
      setError('No se pudo cargar el detalle de la multa.');
    } finally {
      setLoading(false);
    }
  };

  const handlePagar = async () => {
    if (!numero || !nombre || !expiracion || !cvv) {
      setError('Por favor completa todos los campos de la tarjeta.');
      return;
    }
    if (numero.replace(/\s/g, '').length !== 16) {
      setError('El número de tarjeta debe tener 16 dígitos.');
      return;
    }
    if (cvv.length !== 3) {
      setError('El CVV debe tener 3 dígitos.');
      return;
    }

    setPagando(true);
    setError(null);

    try {
      const { data } = await axiosClient.post('/pagos/procesar', {
        acta_uuid:       uuid,
        monto_multa:     acta?.montoBase    ?? 0,
        monto_recargo:   acta?.montoRecargo ?? 0,
        numero_tarjeta:  numero.replace(/\s/g, ''),
        nombre_titular:  nombre,
        cvv,
        fecha_vencimiento: expiracion,
      });

      navigate(`/recibo/${data.numero_transaccion}`, {
        state: {
          numero_transaccion: data.numero_transaccion,
          fecha_pago:         data.fecha_pago,
          monto_total:        data.monto_total,
          monto_multa:        acta?.montoBase    ?? 0,
          monto_recargo:      acta?.montoRecargo ?? 0,
          placa:              acta?.placa,
          acta_uuid:          uuid,
        }
      });

    } catch (err: any) {
      setError(err.response?.data?.error ?? 'No se pudo procesar el pago. Intenta de nuevo.');
    } finally {
      setPagando(false);
    }
  };

  // Formatear número de tarjeta con espacios cada 4 dígitos
  const formatearNumero = (val: string) => {
    const digits = val.replace(/\D/g, '').slice(0, 16);
    return digits.replace(/(.{4})/g, '$1 ').trim();
  };

  if (loading) return <div style={{ padding: '3rem' }}><LoadingSpinner /></div>;

  if (!acta) return (
    <div style={{ maxWidth: '500px', margin: '3rem auto', padding: '1rem', textAlign: 'center' }}>
      <p style={{ color: '#991B1B' }}>No se encontró el acta solicitada.</p>
      <button onClick={() => navigate('/dashboard')} style={{
        marginTop: '1rem', background: '#0F539C', color: 'white',
        border: 'none', borderRadius: '6px', padding: '.5rem 1.25rem', cursor: 'pointer'
      }}>
        Volver al Dashboard
      </button>
    </div>
  );

  const total = acta.montoBase + acta.montoRecargo;

  return (
    <div style={{ maxWidth: '520px', margin: '2.5rem auto', padding: '0 1rem' }}>

      {/* Botón volver */}
      <button
        onClick={() => navigate('/dashboard')}
        style={{
          background: 'none', border: 'none', cursor: 'pointer',
          color: '#0F539C', fontSize: '.85rem', fontWeight: 600,
          marginBottom: '1.25rem', display: 'flex', alignItems: 'center', gap: '.35rem'
        }}
      >
        ← Volver al Dashboard
      </button>

      <h1 style={{ fontSize: '1.4rem', fontWeight: 800, color: '#0F172A', marginBottom: '1.5rem' }}>
        Pago de Multa
      </h1>

      {/* Resumen del monto */}
      <div style={{
        background: '#EFF6FF', border: '1px solid #BFDBFE',
        borderRadius: '10px', padding: '1.25rem',
        marginBottom: '1.5rem'
      }}>
        <h3 style={{
          fontSize: '.75rem', fontWeight: 700, textTransform: 'uppercase',
          letterSpacing: '.08em', color: '#1D4ED8', marginBottom: '1rem'
        }}>
          Resumen del Cobro
        </h3>
        <div style={{ display: 'flex', flexDirection: 'column', gap: '.5rem' }}>
          <div style={{ display: 'flex', justifyContent: 'space-between', fontSize: '.88rem' }}>
            <span style={{ color: '#374151' }}>Placa:</span>
            <span style={{ fontWeight: 600 }}>{acta.placa}</span>
          </div>
          <div style={{ display: 'flex', justifyContent: 'space-between', fontSize: '.88rem' }}>
            <span style={{ color: '#374151' }}>Multa Base:</span>
            <span>RD$ {acta.montoBase.toLocaleString('es-DO')}</span>
          </div>
          {acta.montoRecargo > 0 && (
            <div style={{ display: 'flex', justifyContent: 'space-between', fontSize: '.88rem' }}>
              <span style={{ color: '#374151' }}>Recargos por Mora:</span>
              <span style={{ color: '#991B1B' }}>RD$ {acta.montoRecargo.toLocaleString('es-DO')}</span>
            </div>
          )}
          <hr style={{ border: 'none', borderTop: '1px solid #BFDBFE', margin: '.25rem 0' }} />
          <div style={{ display: 'flex', justifyContent: 'space-between' }}>
            <span style={{ fontWeight: 700, color: '#0F172A' }}>Total a Pagar:</span>
            <span style={{ fontWeight: 800, fontSize: '1.15rem', color: '#CE1126' }}>
              RD$ {total.toLocaleString('es-DO')}
            </span>
          </div>
        </div>
      </div>

      {/* Error */}
      {error && (
        <div style={{
          background: '#FEE2E2', border: '1px solid #FECACA',
          borderRadius: '6px', padding: '.75rem 1rem',
          color: '#991B1B', fontSize: '.85rem', marginBottom: '1rem'
        }}>
          ⚠️ {error}
        </div>
      )}

      {/* Formulario de tarjeta */}
      <div style={{
        background: 'white', border: '1px solid #E2E8F0',
        borderRadius: '10px', padding: '1.5rem',
        boxShadow: '0 1px 4px rgba(0,0,0,.06)'
      }}>
        <h3 style={{
          fontSize: '.75rem', fontWeight: 700, textTransform: 'uppercase',
          letterSpacing: '.08em', color: '#374151', marginBottom: '1.25rem'
        }}>
          💳 Datos de la Tarjeta
        </h3>

        <div style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>

          {/* Número de tarjeta */}
          <div>
            <label style={{ display: 'block', fontSize: '.82rem', fontWeight: 600, color: '#374151', marginBottom: '.35rem' }}>
              Número de Tarjeta
            </label>
            <input
              value={numero}
              onChange={e => setNumero(formatearNumero(e.target.value))}
              placeholder="0000 0000 0000 0000"
              maxLength={19}
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', letterSpacing: '.1em'
              }}
            />
          </div>

          {/* Nombre del titular */}
          <div>
            <label style={{ display: 'block', fontSize: '.82rem', fontWeight: 600, color: '#374151', marginBottom: '.35rem' }}>
              Nombre del Titular
            </label>
            <input
              value={nombre}
              onChange={e => setNombre(e.target.value.toUpperCase())}
              placeholder="NOMBRE APELLIDO"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', letterSpacing: '.05em'
              }}
            />
          </div>

          {/* Expiración y CVV */}
          <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '1rem' }}>
            <div>
              <label style={{ display: 'block', fontSize: '.82rem', fontWeight: 600, color: '#374151', marginBottom: '.35rem' }}>
                Fecha de Expiración
              </label>
              <input
                value={expiracion}
                onChange={e => {
                  const val = e.target.value.replace(/\D/g, '').slice(0, 4);
                  setExpiracion(val.length >= 3 ? `${val.slice(0,2)}/${val.slice(2)}` : val);
                }}
                placeholder="MM/AA"
                maxLength={5}
                style={{
                  width: '100%', padding: '.65rem 1rem',
                  border: '1px solid #D1D5DB', borderRadius: '6px', fontSize: '.9rem'
                }}
              />
            </div>
            <div>
              <label style={{ display: 'block', fontSize: '.82rem', fontWeight: 600, color: '#374151', marginBottom: '.35rem' }}>
                CVV
              </label>
              <input
                value={cvv}
                onChange={e => setCvv(e.target.value.replace(/\D/g, '').slice(0, 3))}
                placeholder="000"
                maxLength={3}
                type="password"
                style={{
                  width: '100%', padding: '.65rem 1rem',
                  border: '1px solid #D1D5DB', borderRadius: '6px', fontSize: '.9rem'
                }}
              />
            </div>
          </div>

        </div>

        {/* Botón pagar */}
        <button
          onClick={handlePagar}
          disabled={pagando}
          style={{
            width: '100%', marginTop: '1.5rem',
            padding: '.85rem', background: pagando ? '#93B9E0' : '#0F539C',
            color: 'white', border: 'none', borderRadius: '6px',
            fontSize: '1rem', fontWeight: 700,
            cursor: pagando ? 'not-allowed' : 'pointer'
          }}
        >
          {pagando ? '⏳ Procesando pago...' : `💳 Pagar RD$ ${total.toLocaleString('es-DO')}`}
        </button>

        {pagando && <div style={{ marginTop: '1rem' }}><LoadingSpinner /></div>}

        <p style={{ marginTop: '1rem', fontSize: '.75rem', color: '#94A3B8', textAlign: 'center' }}>
          🔒 Transacción simulada — ningún cargo real será procesado
        </p>
      </div>
    </div>
  );
}