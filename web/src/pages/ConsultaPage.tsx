import { useState } from 'react';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';
import { maskCedula, maskNombre } from '../utils/maskData';

interface ResultadoJCE { cedula: string; nombre_completo: string; estado: string; }
interface ResultadoDGII { placa: string; marca: string; modelo: string; propietario_cedula: string; marbete_vigente: boolean; }

export default function ConsultaPage() {
  const [busqueda, setBusqueda] = useState('');
  const [tipo, setTipo] = useState<'cedula' | 'placa'>('cedula');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<number | null>(null);
  const [resultado, setResultado] = useState<ResultadoJCE | ResultadoDGII | null>(null);

  const buscar = async () => {
    if (!busqueda.trim()) return;
    setLoading(true); setError(null); setResultado(null);
    try {
      const url = tipo === 'cedula' ? `/api/mock/jce/cedula/${busqueda}` : `/api/mock/dgii/placa/${busqueda}`;
      const { data } = await axiosClient.get(url);
      setResultado(data);
    } catch (err: any) { setError(err.response?.status ?? 0); }
    finally { setLoading(false); }
  };

  return <div className="consulta-page">
    <section className="consulta-hero"><p className="eyebrow">Servicios en línea</p><h1>Consulta pública de multas</h1><p>Consulta información por cédula o placa de forma rápida y segura. Los datos personales se muestran protegidos.</p></section>
    <section className="consulta-panel">
      <div className="consulta-panel__heading"><span>01</span><div><h2>Datos de consulta</h2><p>Selecciona el tipo de documento e ingresa el número a consultar.</p></div></div>
      <div className="consulta-options" role="group" aria-label="Tipo de consulta">
        <button onClick={() => setTipo('cedula')} className={tipo === 'cedula' ? 'selected' : ''}><span>CI</span><div><strong>Por cédula</strong><small>Identidad del ciudadano</small></div></button>
        <button onClick={() => setTipo('placa')} className={tipo === 'placa' ? 'selected' : ''}><span>PL</span><div><strong>Por placa</strong><small>Registro del vehículo</small></div></button>
      </div>
      <div className="consulta-search"><input value={busqueda} onChange={e => setBusqueda(e.target.value)} onKeyDown={e => e.key === 'Enter' && buscar()} placeholder={tipo === 'cedula' ? '001-0000010-9' : 'Ej: A012345'} /><button onClick={buscar} disabled={loading}>{loading ? 'Consultando...' : 'Consultar'}</button></div>
    </section>
    {loading && <LoadingSpinner />}
    {error && <ErrorMessage status={error} onRetry={buscar} />}
    {resultado && !loading && <section className="consulta-result">
      <div className="consulta-result__bar"><span>Resultado de la consulta</span><strong>Información verificada</strong></div>
      {tipo === 'cedula' ? <div className="consulta-result__body"><div className="consulta-result__identity"><span>CI</span><div><small>Consulta por cédula</small><h2>Datos del ciudadano</h2></div></div><div className="consulta-data"><div><span>Cédula</span><strong>{maskCedula((resultado as ResultadoJCE).cedula)}</strong></div><div><span>Nombre</span><strong>{maskNombre((resultado as ResultadoJCE).nombre_completo)}</strong></div><div><span>Estado</span><strong className="data-status">{(resultado as ResultadoJCE).estado}</strong></div></div></div> : <div className="consulta-result__body"><div className="consulta-result__identity"><span>PL</span><div><small>Consulta por placa</small><h2>Datos del vehículo</h2></div></div><div className="consulta-data"><div><span>Placa</span><strong>{(resultado as ResultadoDGII).placa}</strong></div><div><span>Vehículo</span><strong>{(resultado as ResultadoDGII).marca} {(resultado as ResultadoDGII).modelo}</strong></div><div><span>Propietario</span><strong>{maskCedula((resultado as ResultadoDGII).propietario_cedula)}</strong></div><div><span>Marbete</span><strong className={(resultado as ResultadoDGII).marbete_vigente ? 'data-status' : 'data-status data-status--alert'}>{(resultado as ResultadoDGII).marbete_vigente ? 'Vigente' : 'Vencido'}</strong></div></div></div>}
    </section>}
  </div>;
}
