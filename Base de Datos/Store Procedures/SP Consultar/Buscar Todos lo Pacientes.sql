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
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero', Boleta AS 'Boleta' FROM tbPacientes INNER JOIN tbAlumnos ON tbPacientes.IdPaciente = tbAlumnos.IdAlumno
	END
	ELSE
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero' FROM tbPacientes
		WHERE TipoPaciente = @Tipo
	END
END
GO

	EXEC selGenPacientes 1
	GO
	EXEC selGenPacientes 2
	GO
	EXEC selGenPacientes 3
	GO
	EXEC selGenPacientes 4
	GO