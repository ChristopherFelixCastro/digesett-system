import { useState } from 'react';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const NAV_LINKS = [
  { path: '/consulta',    label: 'Consulta de Multas' },
  { path: '/canodromos',  label: 'Canódromo'          },
];

export default function Layout({ children }: { children: React.ReactNode }) {
  const [sidebarOpen,   setSidebarOpen]   = useState(false);
  const [searchActive,  setSearchActive]  = useState(false);
  const [searchQuery,   setSearchQuery]   = useState('');
  const { auth, logout } = useAuth();
  const location  = useLocation();
  const navigate  = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/login');
  };

  const handleSearch = (e: React.KeyboardEvent) => {
    if (e.key === 'Enter' && searchQuery.trim()) {
      navigate(`/consulta?q=${searchQuery}`);
      setSearchActive(false);
      setSearchQuery('');
    }
  };

  return (
    <div style={{ minHeight: '100vh', display: 'flex', flexDirection: 'column', fontFamily: "'Inter', sans-serif" }}>

      {/* ── BARRA SUPERIOR INSTITUCIONAL ─────────────── */}
      <div style={{
        background: '#0F539C', color: 'white',
        fontSize: '.72rem', padding: '.3rem 2rem',
        display: 'flex', justifyContent: 'space-between', alignItems: 'center'
      }}>
        <span>República Dominicana — Gobierno Digital</span>
        <span>OGTIC · digital.gob.do</span>
      </div>

      {/* ── NAVBAR PRINCIPAL ─────────────────────────── */}
      <nav style={{
        background: '#0A3D7A',
        boxShadow: '0 2px 8px rgba(0,0,0,.25)',
        position: 'sticky', top: 0, zIndex: 100,
      }}>
        <div style={{
          maxWidth: '1200px', margin: '0 auto',
          padding: '.9rem 2rem',
          display: 'flex', alignItems: 'center', gap: '1.5rem'
        }}>

          {/* Botón hamburguesa */}
          <button
            onClick={() => setSidebarOpen(true)}
            style={{
              background: 'none', border: 'none',
              cursor: 'pointer', color: 'white',
              display: 'flex', flexDirection: 'column',
              gap: '5px', padding: '.3rem'
            }}
            aria-label="Menú"
          >
            <span style={{ display: 'block', width: '22px', height: '2px', background: 'white' }} />
            <span style={{ display: 'block', width: '22px', height: '2px', background: 'white' }} />
            <span style={{ display: 'block', width: '22px', height: '2px', background: 'white' }} />
          </button>

          {/* Logo / Identidad */}
          <Link to="/consulta" style={{
            display: 'flex', alignItems: 'center',
            gap: '.75rem', textDecoration: 'none'
          }}>
            {/* Escudo simulado SVG */}
            <svg width="36" height="36" viewBox="0 0 36 36" fill="none">
              <rect width="36" height="36" rx="4" fill="#CE1126"/>
              <rect x="2" y="2" width="32" height="32" rx="3" fill="#0F539C"/>
              <path d="M18 6 L30 12 L30 24 C30 30 18 34 18 34 C18 34 6 30 6 24 L6 12 Z"
                    fill="white" opacity=".15"/>
              <path d="M18 8 L28 13.5 L28 23.5 C28 28.5 18 32 18 32 C18 32 8 28.5 8 23.5 L8 13.5 Z"
                    fill="none" stroke="white" strokeWidth="1.5"/>
              <text x="18" y="23" textAnchor="middle"
                    fill="white" fontSize="9" fontWeight="700"
                    fontFamily="serif">DG</text>
            </svg>
            <div>
              <div style={{
                color: 'white', fontWeight: 800,
                fontSize: '1.1rem', letterSpacing: '.04em',
                lineHeight: 1
              }}>
                DIGESETT
              </div>
              <div style={{
                color: '#9FD0FD', fontSize: '.62rem',
                letterSpacing: '.06em', textTransform: 'uppercase'
              }}>
                Portal Ciudadano
              </div>
            </div>
          </Link>

          {/* Links de navegación */}
          <div style={{
            display: 'flex', gap: '.25rem',
            marginLeft: '1rem', flex: 1
          }}>
            {NAV_LINKS.map(link => (
              <Link
                key={link.path}
                to={link.path}
                style={{
                  color: location.pathname === link.path ? 'white' : '#9FD0FD',
                  textDecoration: 'none',
                  fontSize: '.85rem',
                  fontWeight: location.pathname === link.path ? 600 : 400,
                  padding: '.4rem .85rem',
                  borderRadius: '4px',
                  background: location.pathname === link.path
                    ? 'rgba(255,255,255,.15)' : 'transparent',
                  transition: 'all .2s',
                }}
              >
                {link.label}
              </Link>
            ))}
          </div>

          {/* Buscador */}
          <div style={{ display: 'flex', alignItems: 'center', gap: '.5rem' }}>
            {searchActive ? (
              <input
                autoFocus
                value={searchQuery}
                onChange={e => setSearchQuery(e.target.value)}
                onKeyDown={handleSearch}
                onBlur={() => { setSearchActive(false); setSearchQuery(''); }}
                placeholder="Buscar por cédula o placa..."
                style={{
                  padding: '.4rem .85rem',
                  border: '1px solid rgba(255,255,255,.3)',
                  borderRadius: '20px',
                  background: 'rgba(255,255,255,.1)',
                  color: 'white',
                  fontSize: '.83rem',
                  outline: 'none',
                  width: '220px',
                }}
              />
            ) : (
              <button
                onClick={() => setSearchActive(true)}
                style={{
                  background: 'rgba(255,255,255,.1)',
                  border: '1px solid rgba(255,255,255,.2)',
                  borderRadius: '20px',
                  color: '#9FD0FD',
                  cursor: 'pointer',
                  padding: '.4rem .9rem',
                  fontSize: '.83rem',
                  display: 'flex', alignItems: 'center', gap: '.4rem'
                }}
              >
                🔍 Buscar
              </button>
            )}

            {/* Login / Logout */}
            {auth.token ? (
              <button
                onClick={handleLogout}
                style={{
                  background: 'rgba(206,17,38,.7)',
                  border: 'none', borderRadius: '4px',
                  color: 'white', cursor: 'pointer',
                  padding: '.4rem .85rem', fontSize: '.83rem',
                  fontWeight: 600
                }}
              >
                Cerrar Sesión
              </button>
            ) : (
              <Link to="/login" style={{
                background: 'white', color: '#0A3D7A',
                textDecoration: 'none', borderRadius: '4px',
                padding: '.4rem .85rem', fontSize: '.83rem',
                fontWeight: 700
              }}>
                Iniciar Sesión
              </Link>
            )}
          </div>
        </div>
      </nav>

      {/* ── SIDEBAR HAMBURGUESA ───────────────────────── */}
      {sidebarOpen && (
        <>
          {/* Overlay */}
          <div
            onClick={() => setSidebarOpen(false)}
            style={{
              position: 'fixed', inset: 0,
              background: 'rgba(0,0,0,.5)', zIndex: 200
            }}
          />
          {/* Panel lateral */}
          <div style={{
            position: 'fixed', top: 0, left: 0,
            width: '280px', height: '100vh',
            background: '#0A3D7A', zIndex: 201,
            display: 'flex', flexDirection: 'column',
            boxShadow: '4px 0 20px rgba(0,0,0,.3)'
          }}>
            {/* Header sidebar */}
            <div style={{
              padding: '1.25rem 1.5rem',
              borderBottom: '1px solid rgba(255,255,255,.1)',
              display: 'flex', justifyContent: 'space-between', alignItems: 'center'
            }}>
              <span style={{ color: 'white', fontWeight: 700, fontSize: '1rem' }}>
                Menú
              </span>
              <button
                onClick={() => setSidebarOpen(false)}
                style={{
                  background: 'none', border: 'none',
                  color: 'white', cursor: 'pointer',
                  fontSize: '1.4rem', lineHeight: 1
                }}
              >
                ×
              </button>
            </div>

            {/* Links del sidebar */}
            <div style={{ padding: '1rem', flex: 1 }}>
              {[
                { path: '/consulta',   label: '🔍 Consulta de Multas',    desc: 'Busca por cédula o placa' },
                { path: '/canodromos', label: '🚗 Canódromo',             desc: 'Vehículos retenidos' },
                { path: '/login',      label: '👤 Portal Ciudadano',      desc: 'Accede a tu cuenta' },
                { path: '/dashboard',  label: '📋 Mi Dashboard',          desc: 'Historial y pagos' },
              ].map(item => (
                <Link
                  key={item.path}
                  to={item.path}
                  onClick={() => setSidebarOpen(false)}
                  style={{
                    display: 'block', textDecoration: 'none',
                    padding: '.85rem 1rem', borderRadius: '6px',
                    marginBottom: '.25rem',
                    background: location.pathname === item.path
                      ? 'rgba(255,255,255,.15)' : 'transparent',
                    transition: 'background .2s'
                  }}
                >
                  <div style={{ color: 'white', fontWeight: 600, fontSize: '.88rem' }}>
                    {item.label}
                  </div>
                  <div style={{ color: '#9FD0FD', fontSize: '.75rem', marginTop: '.15rem' }}>
                    {item.desc}
                  </div>
                </Link>
              ))}
            </div>

            {/* Footer del sidebar */}
            <div style={{
              padding: '1rem 1.5rem',
              borderTop: '1px solid rgba(255,255,255,.1)',
              fontSize: '.72rem', color: '#9FD0FD'
            }}>
              DIGESETT — Sistema Digital<br />
              República Dominicana · 2025
            </div>
          </div>
        </>
      )}

      {/* ── CONTENIDO PRINCIPAL ──────────────────────── */}
      <main style={{ flex: 1, background: '#F5F7FA' }}>
        {children}
      </main>

      {/* ── FOOTER INSTITUCIONAL ─────────────────────── */}
      <footer style={{ background: '#0A3D7A', color: 'white' }}>

        {/* Franja roja institucional */}
        <div style={{ height: '4px', background: '#CE1126' }} />

        {/* Contenido del footer */}
        <div style={{
          maxWidth: '1200px', margin: '0 auto',
          padding: '2.5rem 2rem',
          display: 'grid',
          gridTemplateColumns: 'repeat(4, 1fr)',
          gap: '2rem'
        }}>

          {/* Columna 1 — Identidad */}
          <div>
            <div style={{
              display: 'flex', alignItems: 'center',
              gap: '.6rem', marginBottom: '1rem'
            }}>
              <svg width="28" height="28" viewBox="0 0 36 36" fill="none">
                <rect width="36" height="36" rx="4" fill="#CE1126"/>
                <rect x="2" y="2" width="32" height="32" rx="3" fill="#0F539C"/>
                <path d="M18 8 L28 13.5 L28 23.5 C28 28.5 18 32 18 32 C18 32 8 28.5 8 23.5 L8 13.5 Z"
                      fill="none" stroke="white" strokeWidth="1.5"/>
                <text x="18" y="23" textAnchor="middle"
                      fill="white" fontSize="9" fontWeight="700" fontFamily="serif">DG</text>
              </svg>
              <div>
                <div style={{ fontWeight: 800, fontSize: '.95rem' }}>DIGESETT</div>
                <div style={{ fontSize: '.65rem', color: '#9FD0FD' }}>Portal Ciudadano Digital</div>
              </div>
            </div>
            <p style={{ fontSize: '.78rem', color: '#9FD0FD', lineHeight: 1.6 }}>
              Dirección General de Seguridad de Tránsito y Transporte Terrestre de la República Dominicana.
            </p>
          </div>

          {/* Columna 2 — Servicios */}
          <div>
            <h4 style={{
              fontSize: '.78rem', fontWeight: 700,
              textTransform: 'uppercase', letterSpacing: '.08em',
              color: '#9FD0FD', marginBottom: '.85rem'
            }}>
              Servicios
            </h4>
            {[
              { path: '/consulta',   label: 'Consulta de Multas'  },
              { path: '/canodromos', label: 'Consulta Canódromo'  },
              { path: '/dashboard',  label: 'Portal Ciudadano'    },
              { path: '/login',      label: 'Iniciar Sesión'      },
            ].map(item => (
              <Link key={item.path} to={item.path} style={{
                display: 'block', color: '#9FD0FD',
                textDecoration: 'none', fontSize: '.8rem',
                marginBottom: '.4rem', transition: 'color .2s'
              }}>
                → {item.label}
              </Link>
            ))}
          </div>

          {/* Columna 3 — Legal */}
          <div>
            <h4 style={{
              fontSize: '.78rem', fontWeight: 700,
              textTransform: 'uppercase', letterSpacing: '.08em',
              color: '#9FD0FD', marginBottom: '.85rem'
            }}>
              Legal
            </h4>
            {[
              'Política de Privacidad',
              'Términos de Uso',
              'Ley 63-17 de Tránsito',
              'Ley 172-13 de Datos',
              'Accesibilidad Web',
            ].map(item => (
              <div key={item} style={{
                color: '#9FD0FD', fontSize: '.8rem',
                marginBottom: '.4rem', cursor: 'pointer'
              }}>
                → {item}
              </div>
            ))}
          </div>

          {/* Columna 4 — Contacto */}
          <div>
            <h4 style={{
              fontSize: '.78rem', fontWeight: 700,
              textTransform: 'uppercase', letterSpacing: '.08em',
              color: '#9FD0FD', marginBottom: '.85rem'
            }}>
              Contacto
            </h4>
            <div style={{ fontSize: '.8rem', color: '#9FD0FD', lineHeight: 2 }}>
              <div>📞 (809) 221-2020</div>
              <div>✉️ info@digesett.gob.do</div>
              <div>🌐 www.digesett.gob.do</div>
              <div style={{ marginTop: '.5rem' }}>
                📍 Av. 27 de Febrero,<br />
                Santo Domingo, R.D.
              </div>
            </div>
          </div>
        </div>

        {/* Franja inferior de créditos */}
        <div style={{
          borderTop: '1px solid rgba(255,255,255,.1)',
          padding: '1rem 2rem',
          display: 'flex', justifyContent: 'space-between',
          alignItems: 'center', fontSize: '.72rem', color: '#9FD0FD'
        }}>
          <span>© 2025 DIGESETT — República Dominicana. Todos los derechos reservados.</span>
          <span>Desarrollado por OGTIC · Sistema de Información de Tránsito v1.0</span>
        </div>
      </footer>

    </div>
  );
}