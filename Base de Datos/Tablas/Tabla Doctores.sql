USE ServicioMedico
GO

IF OBJECT_ID('TablaDoctores') IS NOT NULL
DROP TABLE TablaDoctores
GO

CREATE TABLE TablaDoctores
(
[ID Doctor] INT IDENTITY(501,1) PRIMARY KEY NOT NULL,
[Nombre Doctor] NVARCHAR(50) NOT NULL,
Genero NVARCHAR(9) NOT NULL, 
Consultorio NVARCHAR(30) NOT NULL,
VistaReporte SMALLINT NOT NULL
)
GO

SELECT * FROM TablaDoctores