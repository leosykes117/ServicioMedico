USE ServicioMedico
GO

IF OBJECT_ID('tbCarreras') IS NOT NULL
DROP TABLE tbCarreras
GO

CREATE TABLE tbCarreras
(
IdCarrera SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Carreras NVARCHAR(48)
)
GO

INSERT INTO tbCarreras
VALUES
('Tronco Común'),
('Técnico en Informática'),
('Técnico en Administración'),
('Técnico en Contabilidad'),
('Técnico en Administración de Empresas Turísticas')