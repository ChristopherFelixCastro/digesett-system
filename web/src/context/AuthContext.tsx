import { createContext, useState, useContext } from 'react';

interface AuthState {
  token:     string | null;
  usuarioId: string | null;
  rol:       string | null;
}

interface AuthContextType {
  auth:   AuthState;
  login:  (token: string, usuarioId: string, rol: string) => void;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType>({
  auth:   { token: null, usuarioId: null, rol: null },
  login:  () => {},
  logout: () => {},
});

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [auth, setAuth] = useState<AuthState>({
    token:     null,
    usuarioId: null,
    rol:       null,
  });

  const login = (token: string, usuarioId: string, rol: string) => {
    // Guardar en sessionStorage para que axiosClient lo pueda leer
    sessionStorage.setItem('token', token);
    setAuth({ token, usuarioId, rol });
  };

  const logout = () => {
    // Limpiar sessionStorage al cerrar sesión
    sessionStorage.removeItem('token');
    setAuth({ token: null, usuarioId: null, rol: null });
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