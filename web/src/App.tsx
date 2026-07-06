import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import ConsultaPage     from './pages/ConsultaPage';
import CanodrómosPage   from './pages/CanodromoPage';
import LoginPage        from './pages/LoginPage';
import DashboardPage    from './pages/DashboardPage';
import PagarPage        from './pages/PagarPage';
import ReciboPage       from './pages/ReciboPage';

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* Ruta raíz — redirige a /consulta por defecto */}
        <Route path="/" element={<Navigate to="/consulta" replace />} />

        {/* Rutas públicas */}
        <Route path="/consulta"    element={<ConsultaPage />} />
        <Route path="/canodromos"  element={<CanodrómosPage />} />
        <Route path="/login"       element={<LoginPage />} />

        {/* Rutas privadas — por ahora sin protección, la agregamos después */}
        <Route path="/dashboard"              element={<DashboardPage />} />
        <Route path="/pagar/:uuid"            element={<PagarPage />} />
        <Route path="/recibo/:transaccion"    element={<ReciboPage />} />

        {/* Cualquier ruta desconocida redirige a /consulta */}
        <Route path="*" element={<Navigate to="/consulta" replace />} />
      </Routes>
    </BrowserRouter>
  );
}