import { useLocation, useNavigate } from 'react-router-dom';
import { jsPDF } from 'jspdf';

interface DatosRecibo {
  numero_transaccion: string;
  fecha_pago:         string;
  monto_total:        number;
  monto_multa:        number;
  monto_recargo:      number;
  placa:              string;
  acta_uuid:          string;
}

export default function ReciboPage() {
  const location = useLocation();
  const navigate = useNavigate();
  const datos    = location.state as DatosRecibo | null;

  if (!datos) {
    return (
      <div style={{ maxWidth: '500px', margin: '3rem auto', padding: '1rem', textAlign: 'center' }}>
        <p style={{ color: '#991B1B' }}>No se encontró información del recibo.</p>
        <button onClick={() => navigate('/dashboard')} style={{
          marginTop: '1rem', background: '#0F539C', color: 'white',
          border: 'none', borderRadius: '6px', padding: '.5rem 1.25rem', cursor: 'pointer'
        }}>
          Volver al Dashboard
        </button>
      </div>
    );
  }

  const generarPDF = () => {
    const doc = new jsPDF();

    // Encabezado
    doc.setFillColor(10, 61, 122);
    doc.rect(0, 0, 210, 35, 'F');
    doc.setTextColor(255, 255, 255);
    doc.setFontSize(20);
    doc.setFont('helvetica', 'bold');
    doc.text('DIGESETT', 20, 18);
    doc.setFontSize(10);
    doc.setFont('helvetica', 'normal');
    doc.text('Direccion General de Seguridad de Transito y Transporte Terrestre', 20, 27);

    // Franja roja
    doc.setFillColor(206, 17, 38);
    doc.rect(0, 35, 210, 3, 'F');

    // Título del recibo
    doc.setTextColor(15, 23, 42);
    doc.setFontSize(16);
    doc.setFont('helvetica', 'bold');
    doc.text('RECIBO DE PAGO', 105, 55, { align: 'center' });

    // Número de transacción
    doc.setFontSize(9);
    doc.setFont('helvetica', 'normal');
    doc.setTextColor(100, 116, 139);
    doc.text(`No. Transaccion: ${datos.numero_transaccion}`, 105, 63, { align: 'center' });

    // Fecha
    doc.text(
      `Fecha: ${new Date(datos.fecha_pago).toLocaleString('es-DO')}`,
      105, 70, { align: 'center' }
    );

    // Separador
    doc.setDrawColor(226, 232, 240);
    doc.line(20, 76, 190, 76);

    // Detalles
    doc.setFontSize(10);
    doc.setTextColor(55, 65, 81);

    const filas = [
      ['Placa del Vehículo',   datos.placa ?? 'N/A'],
      ['Multa Base',           `RD$ ${datos.monto_multa.toLocaleString('es-DO')}`],
      ['Recargos por Mora',    `RD$ ${datos.monto_recargo.toLocaleString('es-DO')}`],
    ];

    let y = 88;
    filas.forEach(([label, valor]) => {
      doc.setFont('helvetica', 'normal');
      doc.text(label, 25, y);
      doc.setFont('helvetica', 'bold');
      doc.text(valor, 185, y, { align: 'right' });
      y += 10;
    });

    // Total
    doc.setDrawColor(226, 232, 240);
    doc.line(20, y, 190, y);
    y += 8;
    doc.setFontSize(13);
    doc.setFont('helvetica', 'bold');
    doc.setTextColor(15, 23, 42);
    doc.text('TOTAL PAGADO', 25, y);
    doc.setTextColor(206, 17, 38);
    doc.text(`RD$ ${datos.monto_total.toLocaleString('es-DO')}`, 185, y, { align: 'right' });

    // Footer
    doc.setFontSize(8);
    doc.setFont('helvetica', 'normal');
    doc.setTextColor(148, 163, 184);
    doc.text('Este recibo es un comprobante oficial de pago emitido por DIGESETT.', 105, 200, { align: 'center' });
    doc.text('Republica Dominicana — www.digesett.gob.do — (809) 221-2020', 105, 207, { align: 'center' });

    doc.save(`recibo-digesett-${datos.numero_transaccion.substring(0, 8)}.pdf`);
  };

  return (
    <div style={{ maxWidth: '520px', margin: '2.5rem auto', padding: '0 1rem' }}>

      {/* Éxito */}
      <div style={{ textAlign: 'center', marginBottom: '2rem' }}>
        <div style={{
          width: '64px', height: '64px', borderRadius: '50%',
          background: '#DCFCE7', display: 'flex',
          alignItems: 'center', justifyContent: 'center',
          margin: '0 auto 1rem', fontSize: '2rem'
        }}>
          ✅
        </div>
        <h1 style={{ fontSize: '1.5rem', fontWeight: 800, color: '#0F172A', marginBottom: '.4rem' }}>
          ¡Pago Exitoso!
        </h1>
        <p style={{ color: '#64748B', fontSize: '.9rem' }}>
          Tu multa ha sido pagada correctamente.
        </p>
      </div>

      {/* Recibo visual */}
      <div style={{
        background: 'white', border: '1px solid #E2E8F0',
        borderRadius: '10px', overflow: 'hidden',
        boxShadow: '0 1px 4px rgba(0,0,0,.06)',
        marginBottom: '1.5rem'
      }}>
        {/* Header del recibo */}
        <div style={{ background: '#0A3D7A', padding: '1.25rem 1.5rem' }}>
          <div style={{ color: 'white', fontWeight: 800, fontSize: '1.1rem' }}>DIGESETT</div>
          <div style={{ color: '#9FD0FD', fontSize: '.75rem' }}>Recibo Oficial de Pago</div>
        </div>
        <div style={{ height: '3px', background: '#CE1126' }} />

        {/* Cuerpo del recibo */}
        <div style={{ padding: '1.5rem' }}>

          {/* Número de transacción */}
          <div style={{
            background: '#F8FAFC', border: '1px solid #E2E8F0',
            borderRadius: '6px', padding: '.85rem 1rem',
            marginBottom: '1.25rem', textAlign: 'center'
          }}>
            <div style={{ fontSize: '.72rem', color: '#64748B', fontWeight: 600, textTransform: 'uppercase', letterSpacing: '.08em' }}>
              Número de Transacción
            </div>
            <div style={{ fontFamily: 'monospace', fontSize: '.85rem', color: '#0F172A', fontWeight: 700, marginTop: '.3rem' }}>
              {datos.numero_transaccion}
            </div>
          </div>

          {/* Detalles */}
          {[
            { label: 'Fecha de Pago', valor: new Date(datos.fecha_pago).toLocaleString('es-DO') },
            { label: 'Placa',         valor: datos.placa ?? 'N/A' },
            { label: 'Multa Base',    valor: `RD$ ${datos.monto_multa.toLocaleString('es-DO')}` },
            { label: 'Recargos',      valor: `RD$ ${datos.monto_recargo.toLocaleString('es-DO')}` },
          ].map(item => (
            <div key={item.label} style={{
              display: 'flex', justifyContent: 'space-between',
              alignItems: 'center', padding: '.6rem 0',
              borderBottom: '1px solid #F1F5F9', fontSize: '.88rem'
            }}>
              <span style={{ color: '#64748B' }}>{item.label}</span>
              <span style={{ fontWeight: 600, color: '#0F172A' }}>{item.valor}</span>
            </div>
          ))}

          {/* Total */}
          <div style={{
            display: 'flex', justifyContent: 'space-between',
            alignItems: 'center', marginTop: '1rem',
            padding: '1rem', background: '#F0FDF4',
            border: '1px solid #BBF7D0', borderRadius: '6px'
          }}>
            <span style={{ fontWeight: 700, color: '#0F172A' }}>TOTAL PAGADO</span>
            <span style={{ fontWeight: 800, fontSize: '1.2rem', color: '#15803D' }}>
              RD$ {datos.monto_total.toLocaleString('es-DO')}
            </span>
          </div>
        </div>
      </div>

      {/* Botones */}
      <div style={{ display: 'flex', flexDirection: 'column', gap: '.75rem' }}>
        <button
          onClick={generarPDF}
          style={{
            width: '100%', padding: '.85rem',
            background: '#0F539C', color: 'white',
            border: 'none', borderRadius: '6px',
            fontSize: '1rem', fontWeight: 700, cursor: 'pointer'
          }}
        >
          📄 Descargar Recibo PDF
        </button>
        <button
          onClick={() => navigate('/dashboard')}
          style={{
            width: '100%', padding: '.85rem',
            background: 'white', color: '#0F539C',
            border: '1px solid #0F539C', borderRadius: '6px',
            fontSize: '1rem', fontWeight: 600, cursor: 'pointer'
          }}
        >
          Volver al Dashboard
        </button>
      </div>
    </div>
  );
}