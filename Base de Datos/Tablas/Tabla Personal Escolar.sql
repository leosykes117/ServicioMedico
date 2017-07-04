USE ServicioMedico
GO

IF OBJECT_ID('tbPersonalEscolar') IS NOT NULL
DROP TABLE tbPersonalEscolar
GO

CREATE TABLE tbPersonalEscolar
(
IdPersonal INT PRIMARY KEY NOT NULL,
Num_Personal NVARCHAR(20),
RFC_Personal NVARCHAR(15),
CONSTRAINT fk_PacienteD FOREIGN KEY (IdPersonal) REFERENCES tbPacientes (IdPaciente)
)
GO

SELECT * FROM tbPersonalEscolar

SELECT * FROM tbAlumnos