USE ServicioMedico
GO

IF OBJECT_ID('tbCategorias') IS NOT NULL
DROP TABLE tbCategorias
GO

CREATE TABLE tbCategorias
(
IdCategoria SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DescripcionCategoria NVARCHAR(30),
CONSTRAINT UQ_DesCat UNIQUE(DescripcionCategoria)
)
GO