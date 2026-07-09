interface EstadoBadgeProps {
  estado: 'EMITIDA' | 'PAGADA' | 'IMPUGNADA' | 'ANULADA' | string;
}

const estilos: Record<string, React.CSSProperties> = {
  EMITIDA:   { background: '#FEE2E2', color: '#991B1B' },
  PAGADA:    { background: '#DCFCE7', color: '#15803D' },
  IMPUGNADA: { background: '#FEF3C7', color: '#92400E' },
  ANULADA:   { background: '#F1F5F9', color: '#475569' },
};

export default function EstadoBadge({ estado }: EstadoBadgeProps) {
  const estilo = estilos[estado] ?? { background: '#F1F5F9', color: '#475569' };

  return (
    <span style={{
      ...estilo,
      padding: '.2rem .65rem',
      borderRadius: '20px',
      fontSize: '.72rem',
      fontWeight: 600,
      letterSpacing: '.05em',
      textTransform: 'uppercase',
    }}>
      {estado}
    </span>
  );
}