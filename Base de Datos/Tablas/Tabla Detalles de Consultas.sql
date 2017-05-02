USE ServicioMedico
GO

IF OBJECT_ID('tbDetallesConsultas') IS NOT NULL
DROP TABLE tbDetallesConsultas
GO

CREATE TABLE tbDetallesConsultas
(
IdDetalleConsulta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
CveConsulta INT,
Heridas SMALLINT,
Curaciones SMALLINT,
Tratamiento SMALLINT,
Cantidad SMALLINT
)
GO