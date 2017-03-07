USE ServicioMedico
GO

IF OBJECT_ID('TablaAlumnos') IS NOT NULL
DROP TABLE TablaAlumnos
GO

CREATE TABLE TablaAlumnos
(
Boleta NVARCHAR(12),
[Nombre del Alumno] NVARCHAR(50) NOT NULL,
[Sexo A] NVARCHAR(9) NOT NULL,
Carrera NVARCHAR(50) NOT NULL,
Grupo NVARCHAR(5) NOT NULL
)
GO

SELECT * FROM TablaAlumnos
GO