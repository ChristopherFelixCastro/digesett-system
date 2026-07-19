interface ErrorMessageProps {
  status?: number;
  onRetry?: () => void;
  offline?: boolean;
}

export default function ErrorMessage({ status, onRetry, offline }: ErrorMessageProps) {
  const mensaje = () => {
    if (offline) return 'No tienes conexión a internet. Verifica tu red.';
    if (status === 503) return 'El servicio no está disponible en este momento.';
    if (status === 429) return 'Demasiadas consultas. Espera un momento.';
    if (status === 401) return 'Tu sesión ha expirado. Inicia sesión de nuevo.';
    return 'No se pudo conectar con el servidor.';
  };

  return (
    <div style={{
      background: '#FEE2E2', border: '1px solid #FECACA',
      borderRadius: '8px', padding: '1rem 1.25rem',
      color: '#991B1B', fontSize: '.875rem'
    }}>
      <strong>Error: </strong>{mensaje()}
      {onRetry && (
        <button onClick={onRetry} style={{
          marginLeft: '1rem', padding: '.25rem .75rem',
          background: '#991B1B', color: 'white',
          border: 'none', borderRadius: '4px', cursor: 'pointer'
        }}>
          Reintentar
        </button>
      )}
    </div>
  );
}