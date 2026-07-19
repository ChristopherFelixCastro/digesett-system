import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';

const slides = [
  { image: '/carrusel_1.jpg', title: 'Movilidad segura para todos', text: 'Trabajamos cada día para proteger vidas y mejorar la circulación en las vías del país.' },
  { image: '/carrusel_2.jpg', title: 'Servicios que te acercan', text: 'Consulta información de tránsito de manera rápida, clara y segura.' },
  { image: '/carrusel_3.jpg', title: 'Compromiso con la ciudadanía', text: 'Una institución al servicio de una República Dominicana más ordenada y segura.' },
];

export default function HomePage() {
  const [current, setCurrent] = useState(0);
  useEffect(() => { const timer = window.setInterval(() => setCurrent((value) => (value + 1) % slides.length), 6000); return () => window.clearInterval(timer); }, []);
  const slide = slides[current];
  return <>
    <section className="hero" style={{ backgroundImage: `linear-gradient(90deg, rgba(3, 28, 62, .93) 0%, rgba(5, 46, 102, .76) 48%, rgba(5, 46, 102, .25) 100%), url(${slide.image})` }}>
      <div className="hero__content"><p className="eyebrow">Dirección General de Seguridad de Tránsito y Transporte Terrestre</p><h1>{slide.title}</h1><p>{slide.text}</p><div className="hero__actions"><Link className="button button--primary" to="/consulta">Consultar multas <span>→</span></Link><Link className="button button--ghost" to="/canodromos">Consultar canódromo</Link></div></div>
      <div className="slider-dots">{slides.map((item, index) => <button key={item.image} aria-label={`Mostrar diapositiva ${index + 1}`} className={current === index ? 'selected' : ''} onClick={() => setCurrent(index)} />)}</div>
    </section>
    <section className="quick-services"><div className="section-heading"><p className="eyebrow">Servicios en línea</p><h2>Gestiones ciudadanas</h2><p>Accede de forma simple a los servicios disponibles de DIGESETT.</p></div><div className="service-grid">
      <Link className="service-card" to="/consulta"><span className="service-icon">01</span><h3>Consulta de multas</h3><p>Consulta información por cédula o placa.</p><b>Ir al servicio <span>→</span></b></Link>
      <Link className="service-card" to="/canodromos"><span className="service-icon">02</span><h3>Consulta de canódromo</h3><p>Verifica el estado de vehículos retenidos.</p><b>Ir al servicio <span>→</span></b></Link>
      <Link className="service-card" to="/login"><span className="service-icon">03</span><h3>Portal ciudadano</h3><p>Accede a tu cuenta y gestiona tus trámites.</p><b>Acceder <span>→</span></b></Link>
    </div></section>
    <section className="about"><div><p className="eyebrow">Sobre nosotros</p><h2>Orientamos y protegemos la movilidad nacional.</h2><p>DIGESETT es la institución especializada responsable de viabilizar, fiscalizar y supervisar el tránsito terrestre, promoviendo el respeto a las normas y la seguridad vial.</p></div><div className="about__values"><article><span>M</span><h3>Misión</h3><p>Garantizar un tránsito seguro, ordenado y eficiente mediante una gestión cercana a la ciudadanía.</p></article><article><span>V</span><h3>Visión</h3><p>Ser referente nacional de seguridad vial, innovación y servicio público confiable.</p></article></div></section>
    <section className="cta"><div><p className="eyebrow">DIGESETT digital</p><h2>Información útil, cuando la necesitas.</h2></div><Link className="button button--primary" to="/consulta">Iniciar una consulta <span>→</span></Link></section>
  </>;
}
