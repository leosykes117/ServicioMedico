USE ServicioMedico
GO

IF OBJECT_ID('insAgregarAlumno') IS NOT NULL
DROP PROC insAgregarAlumno
GO

CREATE PROCEDURE insAgregarAlumno
(
@Boleta NVARCHAR(10),
@Nombre NVARCHAR(50),
@Sexo NVARCHAR(9),
@Carrera NVARCHAR(50),
@Grupo NVARCHAR(5),
@Retornado BIGINT OUTPUT
)
AS
BEGIN
	IF(NOT EXISTS(SELECT Boleta FROM TablaAlumnos WHERE Boleta = @Boleta))
	BEGIN	
		INSERT INTO TablaAlumnos VALUES(@Boleta, @Nombre, @Sexo, @Carrera, @Grupo)
		SELECT @Retornado = (SELECT @@IDENTITY)
	END
	ELSE
		SELECT @Retornado = 0
END
GO