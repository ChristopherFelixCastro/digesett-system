import { useState } from 'react';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage   from '../components/ErrorMessage';
import { maskCedula, maskNombre } from '../utils/maskData';

interface ResultadoJCE {
  cedula:          string;
  nombre_completo: string;
  estado:          string;
}

interface ResultadoDGII {
  placa:              string;
  marca:              string;
  modelo:             string;
  propietario_cedula: string;
  marbete_vigente:    boolean;
}

export default function ConsultaPage() {
  const [busqueda,  setBusqueda]  = useState('');
  const [tipo,      setTipo]      = useState<'cedula' | 'placa'>('cedula');
  const [loading,   setLoading]   = useState(false);
  const [error,     setError]     = useState<number | null>(null);
  const [resultado, setResultado] = useState<ResultadoJCE | ResultadoDGII | null>(null);

  const buscar = async () => {
    if (!busqueda.trim()) return;
    setLoading(true);
    setError(null);
    setResultado(null);

    try {
      const url = tipo === 'cedula'
        ? `/api/mock/jce/cedula/${busqueda}`
        : `/api/mock/dgii/placa/${busqueda}`;

      const { data } = await axiosClient.get(url);
      setResultado(data);
    } catch (err: any) {
      setError(err.response?.status ?? 0);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '600px', margin: '3rem auto', padding: '0 1rem' }}>
      <h1 style={{ fontSize: '1.5rem', marginBottom: '.5rem' }}>
        Consulta Pública de Multas
      </h1>
      <p style={{ color: '#64748B', marginBottom: '1.5rem', fontSize: '.9rem' }}>
        Consulta multas por cédula o placa. Los datos personales aparecen protegidos.
      </p>

      {/* Selector de tipo */}
      <div style={{ display: 'flex', gap: '.5rem', marginBottom: '1rem' }}>
        <button
          onClick={() => setTipo('cedula')}
          style={{
            padding: '.5rem 1rem', borderRadius: '6px', cursor: 'pointer',
            border: '1px solid',
            background: tipo === 'cedula' ? '#ea580c' : 'white',
            color:      tipo === 'cedula' ? 'white'   : '#374151',
            borderColor: tipo === 'cedula' ? '#ea580c' : '#d1d5db',
          }}
        >
          Por Cédula
        </button>
        <button
          onClick={() => setTipo('placa')}
          style={{
            padding: '.5rem 1rem', borderRadius: '6px', cursor: 'pointer',
            border: '1px solid',
            background: tipo === 'placa' ? '#ea580c' : 'white',
            color:      tipo === 'placa' ? 'white'   : '#374151',
            borderColor: tipo === 'placa' ? '#ea580c' : '#d1d5db',
          }}
        >
          Por Placa
        </button>
      </div>

      {/* Input de búsqueda */}
      <div style={{ display: 'flex', gap: '.5rem', marginBottom: '1.5rem' }}>
        <input
          value={busqueda}
          onChange={e => setBusqueda(e.target.value)}
          onKeyDown={e => e.key === 'Enter' && buscar()}
          placeholder={tipo === 'cedula' ? '001-0000010-9' : 'A012345'}
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

      {/* Resultado */}
      {resultado && !loading && (
        <div style={{
          border: '1px solid #e2e8f0', borderRadius: '8px',
          padding: '1.25rem', background: 'white'
        }}>
          {tipo === 'cedula' ? (
            <>
              <h3 style={{ marginBottom: '1rem', fontSize: '1rem' }}>
                Datos del Ciudadano
              </h3>
              <p><strong>Cédula:</strong> {maskCedula((resultado as ResultadoJCE).cedula)}</p>
              <p><strong>Nombre:</strong> {maskNombre((resultado as ResultadoJCE).nombre_completo)}</p>
              <p><strong>Estado:</strong> {(resultado as ResultadoJCE).estado}</p>
            </>
          ) : (
            <>
              <h3 style={{ marginBottom: '1rem', fontSize: '1rem' }}>
                Datos del Vehículo
              </h3>
              <p><strong>Placa:</strong> {(resultado as ResultadoDGII).placa}</p>
              <p><strong>Vehículo:</strong> {(resultado as ResultadoDGII).marca} {(resultado as ResultadoDGII).modelo}</p>
              <p><strong>Marbete:</strong> {(resultado as ResultadoDGII).marbete_vigente ? '✅ Vigente' : '❌ Vencido'}</p>
              <p><strong>Propietario:</strong> {maskCedula((resultado as ResultadoDGII).propietario_cedula)}</p>
            </>
          )}
        </div>
      )}
    </div>
  );
}