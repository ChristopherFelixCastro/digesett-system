import { createContext, useState, useContext } from 'react';

interface AuthState {
  token:     string | null;
  usuarioId: string | null;
  rol:       string | null;
  nombre:    string | null;
  cedula:    string | null;
}

interface AuthContextType {
  auth:   AuthState;
  login:  (token: string, usuarioId: string, rol: string, nombre?: string, cedula?: string) => void;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType>({
  auth:   { token: null, usuarioId: null, rol: null, nombre: null, cedula: null },
  login:  () => {},
  logout: () => {},
});

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [auth, setAuth] = useState<AuthState>({
    token:     null,
    usuarioId: null,
    rol:       null,
    nombre:    null,
    cedula:    null,
  });

 const login = (token: string, usuarioId: string, rol: string, nombre?: string, cedula?: string) => {
  sessionStorage.setItem('token', token);
  setAuth({ token, usuarioId, rol, nombre: nombre ?? null, cedula: cedula ?? null });
};

  const logout = () => {
    // Limpiar sessionStorage al cerrar sesión
    sessionStorage.removeItem('token');
    setAuth({ token: null, usuarioId: null, rol: null, nombre: null, cedula: null });
  };

  return (
    <AuthContext.Provider value={{ auth, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  return useContext(AuthContext);
}