USE ServicioMedico
GO

IF OBJECT_ID('TablaDocentes') IS NOT NULL
DROP TABLE TablaDocentes
GO

CREATE TABLE TablaDocentes
(
[ID Docente] BIGINT IDENTITY(1000130001,1) PRIMARY KEY,
[Nombre de Docente] NVARCHAR(60),
[Sexo D] NVARCHAR(9)
)
GO

SELECT * FROM TablaDocentes