import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import Layout           from './components/Layout';
import ProtectedRoute   from './components/ProtectedRoute';
import ConsultaPage     from './pages/ConsultaPage';
import CanodromoPage    from './pages/CanodromoPage';
import LoginPage        from './pages/LoginPage';
import RegisterPage     from './pages/RegisterPage';
import DashboardPage    from './pages/DashboardPage';
import PagarPage        from './pages/PagarPage';
import ReciboPage       from './pages/ReciboPage';
import HomePage         from './pages/HomePage';

export default function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Routes>
          <Route path="/" element={<HomePage />} />

          {/* Públicas */}
          <Route path="/consulta"   element={<ConsultaPage />}   />
          <Route path="/canodromos" element={<CanodromoPage />}  />
          <Route path="/login"      element={<LoginPage />}      />
          <Route path="/registro"   element={<RegisterPage />}   />

          {/* Privadas */}
          <Route path="/dashboard" element={
            <ProtectedRoute><DashboardPage /></ProtectedRoute>
          } />
          <Route path="/pagar/:uuid" element={
            <ProtectedRoute><PagarPage /></ProtectedRoute>
          } />
          <Route path="/recibo/:transaccion" element={
            <ProtectedRoute><ReciboPage /></ProtectedRoute>
          } />

          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
      </Layout>
    </BrowserRouter>
  );
}
