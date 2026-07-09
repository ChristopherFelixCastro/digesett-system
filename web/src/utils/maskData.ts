// Enmascara cédula: "001-1234567-8" → "***-****567-*"
export function maskCedula(cedula: string | undefined | null): string {
  if (!cedula) return '***-****-***-*';
  
  // Intenta el formato estándar dominicano
  const resultado = cedula.replace(
    /^(\d{3})-(\d{4})(\d{3})-(\d{1})$/,
    '***-****$3-*'
  );
  
  // Si el regex no coincidió, oculta con asteriscos genéricos
  if (resultado === cedula) return '***-****-***';
  return resultado;
}

// Enmascara nombre: "Juan Pérez" → "J*** P***"
export function maskNombre(nombre: string | undefined | null): string {
  if (!nombre) return '*** ***';
  return nombre
    .split(' ')
    .map(word => word.charAt(0) + '***')
    .join(' ');
}