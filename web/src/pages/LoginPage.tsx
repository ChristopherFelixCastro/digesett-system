import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';

export default function LoginPage() {
  const [email,    setEmail]    = useState('');
  const [password, setPassword] = useState('');
  const [loading,  setLoading]  = useState(false);
  const [error,    setError]    = useState<string | null>(null);

  const { login } = useAuth();
  const navigate  = useNavigate();

  const handleLogin = async () => {
    if (!email.trim() || !password.trim()) {
      setError('Por favor completa todos los campos.');
      return;
    }

    setLoading(true);
    setError(null);

    try {
      const { data } = await axiosClient.post('/api/v1/auth/login', {
        email,
        password
      });

      // Antony devuelve: { token, id, nombre, email, rol }
      login(data.token, data.id, data.rol);
      navigate('/dashboard');

    } catch (err: any) {
      if (err.response?.status === 401) {
        setError('Credenciales inválidas. Verifica tu email y contraseña.');
      } else {
        setError('No se pudo conectar con el servidor. Intenta de nuevo.');
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{
      minHeight: '80vh', display: 'flex',
      alignItems: 'center', justifyContent: 'center',
      background: '#F5F7FA', padding: '1rem'
    }}>
      <div style={{
        background: 'white', border: '1px solid #E2E8F0',
        borderRadius: '12px', padding: '2.5rem',
        width: '100%', maxWidth: '420px',
        boxShadow: '0 4px 16px rgba(0,0,0,.08)'
      }}>

        {/* Header */}
        <div style={{ textAlign: 'center', marginBottom: '2rem' }}>
          <div style={{
            width: '56px', height: '56px', borderRadius: '12px',
            background: '#0F539C', display: 'flex',
            alignItems: 'center', justifyContent: 'center',
            margin: '0 auto 1rem'
          }}>
            <svg width="28" height="28" viewBox="0 0 36 36" fill="none">
              <path d="M18 4 L32 11 L32 25 C32 31 18 36 18 36 C18 36 4 31 4 25 L4 11 Z"
                    fill="none" stroke="white" strokeWidth="2"/>
              <text x="18" y="24" textAnchor="middle"
                    fill="white" fontSize="11" fontWeight="700" fontFamily="serif">DG</text>
            </svg>
          </div>
          <h1 style={{
            fontSize: '1.4rem', fontWeight: 800,
            color: '#0F172A', marginBottom: '.3rem'
          }}>
            DIGESETT
          </h1>
          <p style={{ color: '#64748B', fontSize: '.85rem' }}>
            Inicia sesión para acceder a tu cuenta
          </p>
        </div>

        {/* Error */}
        {error && (
          <div style={{
            background: '#FEE2E2', border: '1px solid #FECACA',
            borderRadius: '6px', padding: '.75rem 1rem',
            color: '#991B1B', fontSize: '.85rem',
            marginBottom: '1.25rem'
          }}>
            ⚠️ {error}
          </div>
        )}

        {/* Formulario */}
        <div style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>

          <div>
            <label style={{
              display: 'block', fontSize: '.82rem',
              fontWeight: 600, color: '#374151', marginBottom: '.35rem'
            }}>
              Correo Electrónico
            </label>
            <input
              type="email"
              value={email}
              onChange={e => setEmail(e.target.value)}
              onKeyDown={e => e.key === 'Enter' && handleLogin()}
              placeholder="usuario@digesett.gob.do"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none',
                transition: 'border-color .2s'
              }}
            />
          </div>

          <div>
            <label style={{
              display: 'block', fontSize: '.82rem',
              fontWeight: 600, color: '#374151', marginBottom: '.35rem'
            }}>
              Contraseña
            </label>
            <input
              type="password"
              value={password}
              onChange={e => setPassword(e.target.value)}
              onKeyDown={e => e.key === 'Enter' && handleLogin()}
              placeholder="••••••••"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none'
              }}
            />
          </div>

          <button
            onClick={handleLogin}
            disabled={loading}
            style={{
              width: '100%', padding: '.75rem',
              background: loading ? '#93B9E0' : '#0F539C',
              color: 'white', border: 'none',
              borderRadius: '6px', fontSize: '1rem',
              fontWeight: 700, cursor: loading ? 'not-allowed' : 'pointer',
              marginTop: '.5rem', transition: 'background .2s'
            }}
          >
            {loading ? 'Iniciando sesión...' : 'Iniciar Sesión'}
          </button>

        </div>

        {loading && <div style={{ marginTop: '1rem' }}><LoadingSpinner /></div>}

        {/* Credenciales de prueba */}
        <div style={{
          marginTop: '1.5rem', padding: '.85rem',
          background: '#EFF6FF', border: '1px solid #BFDBFE',
          borderRadius: '6px', fontSize: '.78rem', color: '#1D4ED8'
        }}>
          <strong>Credenciales de prueba:</strong><br />
          📧 admin@digesett.gob.do<br />
          🔑 (la contraseña del seed)
        </div>

      </div>
    </div>
  );
}