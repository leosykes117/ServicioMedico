USE ServicioMedico
GO

IF OBJECT_ID('tbGeneros') IS NOT NULL
DROP TABLE tbGeneros
GO

CREATE TABLE tbGeneros
(
IdGenero SMALLINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Generos NVARCHAR(9)
)
GO

INSERT INTO tbGeneros
VALUES
('Masculino'),
('Femenino')