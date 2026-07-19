import axios from 'axios';

const axiosClient = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
  headers: { 'Content-Type': 'application/json' },
  timeout: 10000,
});

// Interceptor de REQUEST — lee el token en cada petición, no solo al inicio
axiosClient.interceptors.request.use((config) => {
  const token = sessionStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// Interceptor de RESPONSE — manejo global de errores
axiosClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      sessionStorage.removeItem('token');
      window.location.href = '/login';
    }
    error.isOffline = !error.response && (error.code === 'ERR_NETWORK' || typeof navigator !== 'undefined' && !navigator.onLine);
    return Promise.reject(error);
  }
);

export default axiosClient;