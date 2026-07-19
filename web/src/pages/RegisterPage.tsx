import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import axiosClient from '../api/axiosClient';
import LoadingSpinner from '../components/LoadingSpinner';

export default function RegisterPage() {
  const [nombre,   setNombre]   = useState('');
  const [email,    setEmail]    = useState('');
  const [cedula,   setCedula]   = useState('');
  const [password, setPassword] = useState('');
  const [confirmar, setConfirmar] = useState('');
  const [loading,  setLoading]  = useState(false);
  const [error,    setError]    = useState<string | null>(null);

  const navigate = useNavigate();

  const formatearCedula = (val: string) => {
    const d = val.replace(/\D/g, '').slice(0, 11);
    if (d.length <= 3) return d;
    if (d.length <= 10) return `${d.slice(0, 3)}-${d.slice(3)}`;
    return `${d.slice(0, 3)}-${d.slice(3, 10)}-${d.slice(10)}`;
  };

  const handleRegister = async () => {
    if (!nombre.trim() || !email.trim() || !cedula.trim() || !password.trim()) {
      setError('Por favor completa todos los campos.');
      return;
    }
    if (password !== confirmar) {
      setError('Las contraseñas no coinciden.');
      return;
    }
    if (password.length < 6) {
      setError('La contraseña debe tener al menos 6 caracteres.');
      return;
    }

    setLoading(true);
    setError(null);

    try {
      await axiosClient.post('/api/v1/auth/register', {
        nombre: nombre.trim(),
        email: email.trim(),
        cedula: cedula.replace(/\D/g, ''),
        password,
      });
      navigate('/login?registro=exitoso');
    } catch (err: any) {
      if (err.response?.status === 409) {
        setError('El email o la cédula ya están registrados.');
      } else {
        setError('No se pudo completar el registro. Intenta de nuevo.');
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

        <div style={{ textAlign: 'center', marginBottom: '2rem' }}>
          <img src="/logo_digesett.jpg" alt="DIGESETT" style={{ width: '94px', height: '94px', objectFit: 'contain', margin: '0 auto 1rem', display: 'block' }} />
          <h1 style={{
            fontSize: '1.4rem', fontWeight: 800,
            color: '#0F172A', marginBottom: '.3rem'
          }}>
            Crear Cuenta
          </h1>
          <p style={{ color: '#64748B', fontSize: '.85rem' }}>
            Regístrate para acceder al portal ciudadano
          </p>
        </div>

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

        <div style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>

          <div>
            <label style={{
              display: 'block', fontSize: '.82rem',
              fontWeight: 600, color: '#374151', marginBottom: '.35rem'
            }}>
              Nombre Completo
            </label>
            <input
              type="text"
              value={nombre}
              onChange={e => setNombre(e.target.value)}
              onKeyDown={e => e.key === 'Enter' && handleRegister()}
              placeholder="Juan Pérez"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none'
              }}
            />
          </div>

          <div>
            <label style={{
              display: 'block', fontSize: '.82rem',
              fontWeight: 600, color: '#374151', marginBottom: '.35rem'
            }}>
              Cédula
            </label>
            <input
              type="text"
              value={cedula}
              onChange={e => setCedula(formatearCedula(e.target.value))}
              onKeyDown={e => e.key === 'Enter' && handleRegister()}
              placeholder="001-0000001-1"
              maxLength={13}
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none'
              }}
            />
          </div>

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
              onKeyDown={e => e.key === 'Enter' && handleRegister()}
              placeholder="usuario@ejemplo.com"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none'
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
              onKeyDown={e => e.key === 'Enter' && handleRegister()}
              placeholder="Mínimo 6 caracteres"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none'
              }}
            />
          </div>

          <div>
            <label style={{
              display: 'block', fontSize: '.82rem',
              fontWeight: 600, color: '#374151', marginBottom: '.35rem'
            }}>
              Confirmar Contraseña
            </label>
            <input
              type="password"
              value={confirmar}
              onChange={e => setConfirmar(e.target.value)}
              onKeyDown={e => e.key === 'Enter' && handleRegister()}
              placeholder="Repite la contraseña"
              style={{
                width: '100%', padding: '.65rem 1rem',
                border: '1px solid #D1D5DB', borderRadius: '6px',
                fontSize: '.9rem', outline: 'none'
              }}
            />
          </div>

          <button
            onClick={handleRegister}
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
            {loading ? 'Creando cuenta...' : 'Crear Cuenta'}
          </button>

        </div>

        {loading && <div style={{ marginTop: '1rem' }}><LoadingSpinner /></div>}

        <div style={{ marginTop: '1.5rem', textAlign: 'center', fontSize: '.85rem', color: '#64748B' }}>
          ¿Ya tienes cuenta?{' '}
          <Link to="/login" style={{ color: '#0F539C', fontWeight: 600, textDecoration: 'none' }}>
            Inicia sesión
          </Link>
        </div>

      </div>
    </div>
  );
}
