import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import ProtectedRoute    from './components/ProtectedRoute';
import ConsultaPage      from './pages/ConsultaPage';
import CanodromoPage     from './pages/CanodromoPage';
import LoginPage         from './pages/LoginPage';
import DashboardPage     from './pages/DashboardPage';
import PagarPage         from './pages/PagarPage';
import ReciboPage        from './pages/ReciboPage';

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* Raíz */}
        <Route path="/" element={<Navigate to="/consulta" replace />} />

        {/* Rutas públicas */}
        <Route path="/consulta"   element={<ConsultaPage />} />
        <Route path="/canodromos" element={<CanodromoPage />} />
        <Route path="/login"      element={<LoginPage />} />

        {/* Rutas privadas — protegidas con JWT */}
        <Route path="/dashboard" element={
          <ProtectedRoute><DashboardPage /></ProtectedRoute>
        } />
        <Route path="/pagar/:uuid" element={
          <ProtectedRoute><PagarPage /></ProtectedRoute>
        } />
        <Route path="/recibo/:transaccion" element={
          <ProtectedRoute><ReciboPage /></ProtectedRoute>
        } />

        {/* Ruta desconocida */}
        <Route path="*" element={<Navigate to="/consulta" replace />} />
      </Routes>
    </BrowserRouter>
  );
}