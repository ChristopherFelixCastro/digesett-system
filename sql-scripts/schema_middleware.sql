Create database DigesettMiddleware

use DigesettMiddleware

-- Tabla 1: aquí se guardan las multas de Ángel cuando el Core (de Antony) está caído
CREATE TABLE OfflineQueue (
  id                  UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  payload_json        NVARCHAR(MAX)    NOT NULL,
  endpoint_destino    VARCHAR(200)     NOT NULL,
  metodo_http         VARCHAR(10)      NOT NULL,
  timestamp_recibido  DATETIME2        NOT NULL DEFAULT GETUTCDATE(),
  procesado           BIT              NOT NULL DEFAULT 0,
  timestamp_procesado DATETIME2        NULL,
  error_detalle       NVARCHAR(500)    NULL
);

-- Tabla 2: datos falsos de "conductores" para simular la consulta a la JCE (cédulas)
CREATE TABLE MockConductores (
  cedula           VARCHAR(15)   PRIMARY KEY,
  nombre_completo  NVARCHAR(100) NOT NULL,
  fecha_nacimiento DATE          NOT NULL,
  estado           VARCHAR(20)   NOT NULL
);

-- Tabla 3: datos falsos de "vehículos" para simular la consulta a la DGII (placas)
CREATE TABLE MockVehiculos (
  placa                     VARCHAR(10)   PRIMARY KEY,
  chasis                    VARCHAR(30)   NOT NULL,
  marca                     VARCHAR(50)   NOT NULL,
  modelo                    VARCHAR(50)   NOT NULL,
  anio                      INT           NOT NULL,
  color                     VARCHAR(30)   NOT NULL,
  tipo_vehiculo             VARCHAR(20)   NOT NULL,
  propietario_cedula        VARCHAR(15)   NOT NULL,
  marbete_vigente           BIT           NOT NULL,
  fecha_vencimiento_marbete DATE          NULL
);

-- Tabla 4: datos falsos de "licencias" para simular la consulta al INTRANT
CREATE TABLE MockLicencias (
  cedula               VARCHAR(15)  PRIMARY KEY,
  numero_licencia      VARCHAR(30)  NOT NULL,
  categoria            VARCHAR(5)   NOT NULL,
  vigente              BIT          NOT NULL,
  renovacion_bloqueada BIT          NOT NULL DEFAULT 0
);

-- Tabla 5: aquí se guardan temporalmente respuestas ya consultadas, para no repetir la misma consulta varias veces
CREATE TABLE CacheConsultas (
  cache_key     VARCHAR(200)  PRIMARY KEY,
  response_json NVARCHAR(MAX) NOT NULL,
  creado_en     DATETIME2     NOT NULL DEFAULT GETUTCDATE(),
  expira_en     DATETIME2     NOT NULL
);