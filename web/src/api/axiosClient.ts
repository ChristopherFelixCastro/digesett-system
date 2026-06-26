import axios from 'axios';

// ── Instancia base ────────────────────────────────────
const axiosClient = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
  headers: { 'Content-Type': 'application/json' },
  timeout: 10000, // 10 segundos 
});

// ── Interceptor de REQUEST ────────────────────────────
// Adjunta el JWT automáticamente en cada petición
axiosClient.interceptors.request.use((config) => {
  const token = sessionStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// ── Interceptor de RESPONSE ───────────────────────────
// Manejo global de errores
axiosClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      // Sesión expirada — limpiar y redirigir al login
      sessionStorage.removeItem('token');
      window.location.href = '/login';
    }
    return Promise.reject(error);
  }
);

export default axiosClient;