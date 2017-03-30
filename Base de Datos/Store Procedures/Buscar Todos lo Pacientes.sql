USE ServicioMedico
GO

IF OBJECT_ID('selGenPacientes') IS NOT NULL
DROP PROC selGenPacientes
GO

CREATE PROC selGenPacientes
(
@Tipo SMALLINT
)
AS
BEGIN
	IF(@Tipo = 1)
	BEGIN
		SELECT [ID Alumno] AS 'Clave', Boleta AS 'Boleta o PM', [Nombre de Alumno] AS 'Nombre', Carrera FROM TablaAlumnos
	END
	ELSE IF(@Tipo = 2)
	BEGIN
		SELECT [ID Docente] AS 'Clave', [Nombre de Docente] AS 'Nombre' FROM TablaDocentes
	END
	ELSE IF(@Tipo = 3)
	BEGIN
		SELECT [ID PAE] AS 'Clave', [Nombre de PAE] AS 'Nombre' FROM TablaPAES
	END
	ELSE
	BEGIN
		SELECT [ID Externo] AS 'Clave', [Nombre de Externo] AS 'Nombre' FROM TablaExternos
	END
END
GO