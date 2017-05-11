USE ServicioMedico
GO

IF OBJECT_ID('tbPacientes') IS NOT NULL
DROP TABLE tbPacientes
GO

CREATE TABLE tbPacientes
(
IdPaciente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombrePaciente NVARCHAR(20),
ApellidosPaciente NVARCHAR(20),
GeneroPaciente SMALLINT,
EdadPaciente SMALLINT,
CorreoPaciente NVARCHAR(70) UNIQUE,
TipoPaciente SMALLINT,
CONSTRAINT fk_GeneroP FOREIGN KEY (GeneroPaciente) REFERENCES tbGeneros (IdGenero),
CONSTRAINT fk_TipoP FOREIGN KEY (TipoPaciente) REFERENCES tbTiposPacientes (IdTipo)
)
GO