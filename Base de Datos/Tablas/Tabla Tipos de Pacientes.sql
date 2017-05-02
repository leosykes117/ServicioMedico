USE ServicioMedico
GO

IF OBJECT_ID('tbTiposPacientes') IS NOT NULL
DROP TABLE tbTiposPacientes
GO

CREATE TABLE tbTiposPacientes
(
IdTipo SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Tipos NVARCHAR(23)
)

INSERT INTO tbTiposPacientes
VALUES
('Alumno'),
('Docente'),
('Personal Administrativo'),
('Externos')