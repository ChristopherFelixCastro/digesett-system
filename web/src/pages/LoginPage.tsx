import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import LoadingSpinner from '../components/LoadingSpinner';

export default function LoginPage() {
  const [email,    setEmail]    = useState('');
  const [password, setPassword] = useState('');
  const [loading,  setLoading]  = useState(false);
  const [error,    setError]    = useState<string | null>(null);

  const { login }  = useAuth();
  const navigate   = useNavigate();

  const handleLogin = async () => {
    if (!email.trim() || !password.trim()) {
      setError('Por favor completa todos los campos.');
      return;
    }

    setLoading(true);
    setError(null);

    // Simular delay de red
    await new Promise(r => setTimeout(r, 800));

    // TODO: reemplazar con llamada real a Yeimi:
    // const { data } = await axiosClient.post('/api/v1/auth/login', { email, password });
    // login(data.token, data.usuarioId, data.rol);

    // Login simulado — acepta cualquier email y password válidos
    if (email.includes('@') && password.length >= 4) {
      const tokenFalso = btoa(JSON.stringify({
        usuarioId: 'ciudadano-demo-001',
        email,
        rol:       'Ciudadano',
        exp:       Date.now() + 15 * 60 * 1000, // 15 minutos
      }));

      login(tokenFalso, 'ciudadano-demo-001', 'Ciudadano');
      navigate('/dashboard');
    } else {
      setError('Credenciales inválidas. Verifica tu email y contraseña.');
    }

    setLoading(false);
  };

  return (
    <div style={{
      minHeight: '100vh', display: 'flex',
      alignItems: 'center', justifyContent: 'center',
      background: '#F7F9FC', padding: '1rem'
    }}>
      <div style={{
        background: 'white', border: '1px solid #E2E8F0',
        borderRadius: '12px', padding: '2.5rem',
        width: '100%', maxWidth: '420px',
        boxShadow: '0 4px 16px rgba(0,0,0,.08)'
      }}>

        {/* Header */}
        <div style={{ textAlign: 'center', marginBottom: '2rem' }}>
          <h1 style={{
            fontSize: '1.6rem', fontWeight: 800,
            color: '#0F172A', marginBottom: '.4rem'
          }}>
            DIGESETT
          </h1>
          <p style={{ color: '#64748B', fontSize: '.9rem' }}>
            Portal Ciudadano — Inicia sesión para acceder a tu cuenta
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
            {error}
          </div>
        )}

        {/* Formulario */}
        <div style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>

          {/* Email */}
          <div>
            <label style={{
              display: 'block', fontSize: '.82rem',
              fontWeight: 600, color: '#374151',
              marginBottom: '.35rem'
            }}>
              Correo Electrónico
            </label>
            <input
              type="email"
              value={email}
              onChange={e => setEmail(e.target.value)}
              onKeyDown={e => e.key === 'Enter' && handleLogin()}
              placeholder="ciudadano@ejemplo.com"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none'
              }}
            />
          </div>

          {/* Password */}
          <div>
            <label style={{
              display: 'block', fontSize: '.82rem',
              fontWeight: 600, color: '#374151',
              marginBottom: '.35rem'
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

          {/* Botón */}
          <button
            onClick={handleLogin}
            disabled={loading}
            style={{
              width: '100%', padding: '.75rem',
              background: loading ? '#FDA97A' : '#ea580c',
              color: 'white', border: 'none',
              borderRadius: '6px', fontSize: '1rem',
              fontWeight: 700, cursor: loading ? 'not-allowed' : 'pointer',
              marginTop: '.5rem'
            }}
          >
            {loading ? 'Iniciando sesión...' : 'Iniciar Sesión'}
          </button>

        </div>

        {/* Spinner */}
        {loading && <div style={{ marginTop: '1rem' }}><LoadingSpinner /></div>}

        {/* Nota simulado */}
        <p style={{
          marginTop: '1.5rem', fontSize: '.75rem',
          color: '#94A3B8', textAlign: 'center'
        }}>
          * Modo simulado: usa cualquier email válido y contraseña de 4+ caracteres
        </p>

      </div>
    </div>
  );
}