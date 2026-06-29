-- ============================================
-- SEED: MockConductores (10 registros)
-- Datos ficticios para simular respuestas de la JCE
-- Regla: último dígito de la cédula PAR -> ACTIVO | IMPAR -> SUSPENDIDO
-- ============================================
INSERT INTO MockConductores (cedula, nombre_completo, fecha_nacimiento, estado) VALUES
('001-0000001-0', 'Juan Alberto Pérez Méndez',      '1990-03-15', 'ACTIVO'),
('001-0000002-1', 'María Fernanda Gómez Ruiz',       '1985-07-22', 'SUSPENDIDO'),
('001-0000003-2', 'Carlos Manuel Rodríguez Santos',  '1992-11-08', 'ACTIVO'),
('001-0000004-3', 'Ana Lucía Díaz Fernández',        '1988-01-30', 'SUSPENDIDO'),
('001-0000005-4', 'Luis Eduardo Martínez Castillo',  '1995-05-17', 'ACTIVO'),
('001-0000006-5', 'Carmen Rosa Jiménez Vargas',      '1979-09-04', 'SUSPENDIDO'),
('001-0000007-6', 'Pedro Antonio Reyes Ortiz',       '1991-12-25', 'ACTIVO'),
('001-0000008-7', 'Rosa Elena Cruz Medina',          '1987-04-10', 'SUSPENDIDO'),
('001-0000009-8', 'Miguel Ángel Sánchez Peña',       '1993-08-19', 'ACTIVO'),
('001-0000010-9', 'Yolanda Beatriz Mora Acosta',     '1984-02-28', 'SUSPENDIDO');

-- ============================================
-- SEED: MockVehiculos (10 registros)
-- Datos ficticios para simular respuestas de la DGII
-- Cada vehículo está vinculado a uno de los conductores de arriba
-- ============================================
INSERT INTO MockVehiculos (placa, chasis, marca, modelo, anio, color, tipo_vehiculo, propietario_cedula, marbete_vigente, fecha_vencimiento_marbete) VALUES
('A123456', 'CHS00000000001', 'Toyota',      'Corolla',   2019, 'Blanco',  'PARTICULAR',   '001-0000001-0', 1, '2026-12-31'),
('A234567', 'CHS00000000002', 'Honda',       'Civic',     2020, 'Gris',    'PARTICULAR',   '001-0000002-1', 0, '2025-06-15'),
('B345678', 'CHS00000000003', 'Yamaha',      'YBR125',    2018, 'Negro',   'MOTOCICLETA',  '001-0000003-2', 1, '2026-09-20'),
('A456789', 'CHS00000000004', 'Hyundai',     'Elantra',   2021, 'Azul',    'PARTICULAR',   '001-0000004-3', 1, '2027-01-10'),
('C567890', 'CHS00000000005', 'Isuzu',       'NPR',       2017, 'Blanco',  'CARGA',        '001-0000005-4', 0, '2025-03-05'),
('A678901', 'CHS00000000006', 'Kia',         'Rio',       2022, 'Rojo',    'PARTICULAR',   '001-0000006-5', 1, '2026-11-22'),
('B789012', 'CHS00000000007', 'Bajaj',       'Boxer',     2019, 'Negro',   'MOTOCICLETA',  '001-0000007-6', 1, '2026-07-08'),
('A890123', 'CHS00000000008', 'Nissan',      'Sentra',    2020, 'Plata',   'PARTICULAR',   '001-0000008-7', 0, '2025-10-14'),
('C901234', 'CHS00000000009', 'Mitsubishi',  'Canter',    2016, 'Blanco',  'CARGA',        '001-0000009-8', 1, '2026-05-30'),
('A012345', 'CHS00000000010', 'Chevrolet',   'Spark',     2021, 'Amarillo','PARTICULAR',   '001-0000010-9', 1, '2027-02-18');

SELECT * FROM MockConductores;
SELECT * FROM MockVehiculos;