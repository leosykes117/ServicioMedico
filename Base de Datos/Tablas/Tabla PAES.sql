USE ServicioMedico
GO

IF OBJECT_ID('TablaPAES') IS NOT NULL
DROP TABLE TablaPAES
GO

CREATE TABLE TablaPAES
(
[ID PAE] BIGINT IDENTITY(2000130001,1) PRIMARY KEY,
[Nombre del PAE] NVARCHAR(60),
[Sexo PAE] NVARCHAR(9)
)
GO

SELECT * FROM TablaPAES