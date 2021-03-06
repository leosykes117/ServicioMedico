USE ServicioMedico
GO

IF OBJECT_ID('tbAlumnos') IS NOT NULL
DROP TABLE tbAlumnos
GO

CREATE TABLE tbAlumnos
(
IdAlumno INT PRIMARY KEY NOT NULL,
Boleta NVARCHAR(10) NOT NULL,
Grupo NVARCHAR(5) NOT NULL,
Carrera SMALLINT NOT NULL,
CONSTRAINT fk_PacienteA FOREIGN KEY (IdAlumno) REFERENCES tbPacientes (IdPaciente),
CONSTRAINT fk_CarreraA FOREIGN KEY (Carrera) REFERENCES tbCarreras (IdCarrera),
)
GO

SELECT * FROM tbAlumnos
GO