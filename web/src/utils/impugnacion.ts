// Verifica si una multa puede ser impugnada (15 días calendario)
export function puedeImpugnar(fechaEmision: string): boolean {
  const emision = new Date(fechaEmision);
  const limite  = new Date(emision);
  limite.setDate(limite.getDate() + 15);

  // Si cae en sábado (6) → extender al lunes
  if (limite.getDay() === 6) limite.setDate(limite.getDate() + 2);
  // Si cae en domingo (0) → extender al lunes
  if (limite.getDay() === 0) limite.setDate(limite.getDate() + 1);

  return new Date() <= limite;
}