USE ServicioMedico
GO

IF OBJECT_ID('insAgregarAlumno') IS NOT NULL
DROP PROC insAgregarAlumno
GO

CREATE PROCEDURE insAgregarAlumno
(
@Boleta BIGINT,
@Nombre NVARCHAR(70),
@Sexo NVARCHAR(9),
@Carrera NVARCHAR(50),
@Grupo NVARCHAR(5)	
)
AS
BEGIN
	INSERT INTO TablaAlumnos VALUES(@Boleta, @Nombre, @Sexo, @Carrera, @Grupo)
END
GO

EXEC insAlumno 2014130074,'Adriana Gallardo Contrera','Femenino','Tecnico en Administración','4IV7'
EXEC insAlumno 2014130789,'Fernando Martinez Gutierrez','Masculino','Tecnico en Informatica','6IV4'
EXEC insAlumno 2014130789,'Dayanari Veronica Cervantes Sanchez','Femenino','Informatica','6IV4'
EXEC insAlumno 2014130557,'Oswaldo Ernesto Barbosa Sanchez','Masculino','Informatica','6IV4'
EXEC insAlumno 2014130459,'Roberto Antonio Trejo Valle','Masculino','Informatica','6IV4'

SELECT * FROM TablaAlumnos
GO