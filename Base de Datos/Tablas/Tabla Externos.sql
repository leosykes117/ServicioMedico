USE ServicioMedico
GO

IF OBJECT_ID('TablaExternos') IS NOT NULL
DROP TABLE TablaExternos
GO

CREATE TABLE TablaExternos
(
[ID Externo] BIGINT IDENTITY(3000130001,1) PRIMARY KEY,
[Nombre de Externo] NVARCHAR(70),
[Sexo E] NVARCHAR(9)
)
GO

SELECT * FROM TablaExternos