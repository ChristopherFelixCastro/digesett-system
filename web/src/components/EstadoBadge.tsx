interface EstadoBadgeProps {
  estado: string;
}

const estilos: Record<string, { bg: string; color: string; label: string }> = {
  PENDIENTE:   { bg: '#FEE2E2', color: '#991B1B', label: '🔴 Pendiente'   },
  EMITIDA:     { bg: '#FEE2E2', color: '#991B1B', label: '🔴 Emitida'     },
  IMPUGNADA:   { bg: '#FEF3C7', color: '#92400E', label: '🟡 Impugnada'   },
  PAGADA:      { bg: '#DCFCE7', color: '#15803D', label: '🟢 Pagada'      },
  ANULADA:     { bg: '#F1F5F9', color: '#475569', label: '⚪ Anulada'     },
};

export default function EstadoBadge({ estado }: EstadoBadgeProps) {
  const estilo = estilos[estado] ?? { bg: '#F1F5F9', color: '#475569', label: estado };

  return (
    <span style={{
      background:    estilo.bg,
      color:         estilo.color,
      padding:       '.25rem .75rem',
      borderRadius:  '20px',
      fontSize:      '.72rem',
      fontWeight:    600,
      letterSpacing: '.04em',
      whiteSpace:    'nowrap',
    }}>
      {estilo.label}
    </span>
  );
}