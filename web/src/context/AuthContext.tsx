import { createContext, useState, useContext } from 'react';

// ── Tipos ────────────────────────────────────────────
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

// ── Contexto ─────────────────────────────────────────
const AuthContext = createContext<AuthContextType>({
  auth:   { token: null, usuarioId: null, rol: null },
  login:  () => {},
  logout: () => {},
});

// ── Provider ─────────────────────────────────────────
export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [auth, setAuth] = useState<AuthState>({
    token:     null,
    usuarioId: null,
    rol:       null,
  });

  const login = (token: string, usuarioId: string, rol: string) => {
    setAuth({ token, usuarioId, rol });
  };

  const logout = () => {
    setAuth({ token: null, usuarioId: null, rol: null });
  };

  return (
    <AuthContext.Provider value={{ auth, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

// ── Hook personalizado ────────────────────────────────
export function useAuth() {
  return useContext(AuthContext);
}