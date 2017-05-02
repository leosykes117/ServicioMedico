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
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', Boleta FROM tbPacientes INNER JOIN tbAlumnos ON				tbPacientes.IdPaciente = tbAlumnos.IdAlumno
	END
	ELSE
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos' FROM tbPacientes
		WHERE TipoPaciente = @Tipo
	END
END
GO