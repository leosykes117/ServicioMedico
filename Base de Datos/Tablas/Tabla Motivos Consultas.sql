USE ServicioMedico
GO

IF OBJECT_ID('tbMotivosConsultas') IS NOT  NULL
DROP TABLE tbMotivosConsultas
GO

CREATE TABLE tbMotivosConsultas
(
IdMotivo SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DescripcionMotivo NVARCHAR(30) NOT NULL,
CONSTRAINT UQ_DesMot UNIQUE(DescripcionMotivo)
)
GO