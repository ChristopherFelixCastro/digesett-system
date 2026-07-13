import { useState, useEffect } from 'react';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';
import ErrorMessage from '../components/ErrorMessage';

interface VehiculoRetenido { id: number; actaId: string; placa: string; fechaIngreso: string; fechaSalida: string | null; diasCobrados: number; costoTotal: number; estado: string; }

const textoEstado: Record<string, string> = { RETENIDO: 'Retenido', APTO_PARA_LIBERACION: 'Apto para liberación', LIBERADO: 'Liberado' };

export default function CanodromoPage() {
  const [busqueda, setBusqueda] = useState('');
  const [todos, setTodos] = useState<VehiculoRetenido[]>([]);
  const [resultado, setResultado] = useState<VehiculoRetenido | null>(null);
  const [noEncontrado, setNoEncontrado] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<number | null>(null);
  const [cargando, setCargando] = useState(true);

  useEffect(() => { cargarTodos(); }, []);

  const cargarTodos = async () => {
    setCargando(true); setError(null);
    try { const { data } = await axiosClient.get('/api/v1/canodromos'); setTodos(Array.isArray(data) ? data : []); }
    catch (err: any) { setError(err.response?.status ?? 0); }
    finally { setCargando(false); }
  };

  const buscar = () => {
    if (!busqueda.trim()) return;
    setLoading(true); setResultado(null); setNoEncontrado(false);
    const encontrado = todos.find(v => v.placa.toUpperCase() === busqueda.toUpperCase().trim());
    setTimeout(() => { if (encontrado) setResultado(encontrado); else setNoEncontrado(true); setLoading(false); }, 400);
  };

  return <div className="canodromo-page">
    <section className="canodromo-hero"><p className="eyebrow">Servicios en línea</p><h1>Consulta de vehículos retenidos</h1><p>Verifica el estado de tu vehículo en el Canódromo ingresando el número de placa.</p></section>
    <section className="canodromo-panel" aria-label="Consulta por placa">
      <div className="canodromo-panel__heading"><span>01</span><div><h2>Busca por placa</h2><p>Escribe la placa tal como aparece en tu matrícula.</p></div></div>
      {error && !cargando && <ErrorMessage status={error} onRetry={cargarTodos} />}
      <div className="canodromo-search"><input value={busqueda} onChange={e => setBusqueda(e.target.value)} onKeyDown={e => e.key === 'Enter' && buscar()} placeholder="Ej: A234567" disabled={cargando} /><button onClick={buscar} disabled={cargando || loading} className="canodromo-search__button">{cargando ? 'Cargando...' : 'Buscar'}</button></div>
    </section>
    {cargando && <LoadingSpinner />}
    {loading && !cargando && <LoadingSpinner />}
    {noEncontrado && !loading && <div className="canodromo-empty"><span>✓</span><div><strong>Vehículo no retenido</strong><p>El vehículo con placa <b>{busqueda.toUpperCase()}</b> no se encuentra retenido en el Canódromo.</p></div></div>}
    {resultado && !loading && <section className="canodromo-result">
      <div className={`canodromo-result__status status-${resultado.estado.toLowerCase()}`}><span>Estado del vehículo</span><strong>{textoEstado[resultado.estado] ?? resultado.estado}</strong></div>
      <div className="canodromo-result__body">
        <div className="canodromo-result__title"><div><span>Placa consultada</span><h2>{resultado.placa}</h2></div><span className="result-mark">DIGESETT</span></div>
        <div className="canodromo-data">{[
          { label: 'Placa', valor: resultado.placa },
          { label: 'Fecha de ingreso', valor: new Date(resultado.fechaIngreso).toLocaleDateString('es-DO', { year: 'numeric', month: 'long', day: 'numeric' }) },
          { label: 'Días retenido', valor: `${resultado.diasCobrados} días` },
        ].map(item => <div key={item.label}><span>{item.label}</span><strong>{item.valor}</strong></div>)}</div>
        <div className="canodromo-cost"><span>Costo de estadía acumulado</span><strong>RD$ {resultado.costoTotal.toLocaleString('es-DO', { minimumFractionDigits: 2 })}</strong><small>RD$200.00 × {resultado.diasCobrados} días{resultado.diasCobrados >= 60 && ' · (tope máximo de 60 días alcanzado)'}</small></div>
        {resultado.estado === 'APTO_PARA_LIBERACION' && <div className="canodromo-alert"><strong>Información importante</strong><p>Tu vehículo está listo para ser retirado. Dirígete al Canódromo con el comprobante de pago de tu multa.</p></div>}
      </div>
    </section>}
    {!cargando && !error && todos.length > 0 && <p className="canodromo-count">{todos.length} vehículo{todos.length !== 1 ? 's' : ''} actualmente en el Canódromo</p>}
  </div>;
}
