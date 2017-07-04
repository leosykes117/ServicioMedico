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
('Tronco Com�n'),
('T�cnico en Inform�tica'),
('T�cnico en Administraci�n'),
('T�cnico en Contabilidad'),
('T�cnico en Administraci�n de Empresas Tur�sticas')