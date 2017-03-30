USE ServicioMedico
GO

IF OBJECT_ID('TablaExternos') IS NOT NULL
DROP TABLE TablaExternos
GO

CREATE TABLE TablaExternos
(
[ID Externo] BIGINT IDENTITY(40013001,1) PRIMARY KEY,
[Nombre de Externo] NVARCHAR(50),
[Genero E] NVARCHAR(9)
)
GO

SELECT * FROM TablaExternos