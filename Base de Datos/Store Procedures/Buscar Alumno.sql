USE FlashConsultas
GO

IF OBJECT_ID('selBuscarAlumno') IS NOT NULL
DROP PROC selBuscarAlumno
GO

CREATE PROCEDURE selBuscarAlumno
(
@Boleta BIGINT,
@Nombre NVARCHAR(70),
@Contador INT OUTPUT,
@Mensaje NVARCHAR(10) OUTPUT,
@Cve BIGINT OUTPUT,
@Nom NVARCHAR(70) OUTPUT
)
AS
BEGIN
	SELECT @Contador = COUNT(a.Boleta) FROM TablaAlumnos a  --BUSCAMOS AL DOCENTE POR NOMBRE 
	WHERE Boleta = @Boleta AND [Nombre del Alumno] = @Nombre							

	IF @Contador > 0 --SI EL DOCENTE EXISTE
	BEGIN
		SELECT @Mensaje = 'EXISTE', @Cve = (a.Boleta), @Nom = (a.[Nombre del Alumno]) FROM TablaAlumnos a
		WHERE Boleta = @Boleta AND [Nombre del Alumno] = @Nombre
	END

	ELSE
	BEGIN
		SELECT @Mensaje = 'NO EXISTE' --SI NO EXISTE SE EJECUTA EL SP DE CREAR PACIENTE
	END
END
GO