import { useState } from 'react';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';
import governmentLogo from '../../LOGO_GOB_vert_blanco.svg';

const NAV_LINKS = [
  { path: '/', label: 'Inicio' },
  { path: '/consulta', label: 'Consulta de multas' },
  { path: '/canodromos', label: 'Canódromo' },
];

export default function Layout({ children }: { children: React.ReactNode }) {
  const [menuOpen, setMenuOpen] = useState(false);
  const { auth, logout } = useAuth();
  const location = useLocation();
  const navigate = useNavigate();
  const handleLogout = () => { logout(); navigate('/login'); };

  return (
    <div className="app-shell">
      <div className="official-bar"><div><span>Gobierno de la República Dominicana</span><span className="official-bar__right">Portal de servicios DIGESETT</span></div></div>
      <header className="site-header">
        <div className="site-header__inner">
          <Link className="brand" to="/" aria-label="Inicio DIGESETT">
            <img src={governmentLogo} alt="Gobierno de la República Dominicana" />
            <span className="brand__divider" />
            <span className="brand__copy"><strong>DIGESETT</strong><small>Seguridad de Tránsito y Transporte Terrestre</small></span>
          </Link>
          <nav className="desktop-nav" aria-label="Navegación principal">
            {NAV_LINKS.map((item) => <Link key={item.path} className={location.pathname === item.path ? 'active' : ''} to={item.path}>{item.label}</Link>)}
          </nav>
          <div className="header-actions">
            {auth.token ? <button className="button button--outline button--small" onClick={handleLogout}>Cerrar sesión</button> : <Link className="button button--light button--small" to="/login">Portal ciudadano</Link>}
            <button className="menu-toggle" onClick={() => setMenuOpen(!menuOpen)} aria-label="Abrir menú" aria-expanded={menuOpen}><i /><i /><i /></button>
          </div>
        </div>
        {menuOpen && <nav className="mobile-nav" aria-label="Navegación móvil">
          {NAV_LINKS.map((item) => <Link key={item.path} to={item.path} onClick={() => setMenuOpen(false)}>{item.label}</Link>)}
          <Link to={auth.token ? '/dashboard' : '/login'} onClick={() => setMenuOpen(false)}>{auth.token ? 'Mi cuenta' : 'Iniciar sesión'}</Link>
        </nav>}
      </header>
      <main>{children}</main>
      <footer className="site-footer">
        <div className="site-footer__accent" />
        <div className="site-footer__inner">
          <div><img className="footer-logo" src={governmentLogo} alt="Gobierno dominicano" /><p>Dirección General de Seguridad de Tránsito y Transporte Terrestre.</p></div>
          <div><h2>Servicios</h2><Link to="/consulta">Consulta de multas</Link><Link to="/canodromos">Consulta de canódromo</Link><Link to="/login">Portal ciudadano</Link></div>
          <div><h2>Contacto</h2><p>Av. Expreso V Centenario esq. Av. San Martín<br />Santo Domingo, República Dominicana</p><p>info@digesett.gob.do</p></div>
        </div>
        <div className="site-footer__legal">© {new Date().getFullYear()} DIGESETT · República Dominicana</div>
      </footer>
    </div>
  );
}
