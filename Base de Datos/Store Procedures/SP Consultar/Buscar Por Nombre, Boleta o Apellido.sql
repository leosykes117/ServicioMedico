USE ServicioMedico
GO

IF OBJECT_ID('selBuscarPaciente') IS NOT NULL
DROP PROC selBuscarPaciente
GO

CREATE PROC selBuscarPaciente
(
@Tipo SMALLINT,
@Dato NVARCHAR(50)
)
AS
BEGIN
	SELECT @Dato = '%' + RTRIM(@Dato) + '%'	
	IF(@Tipo = 1)
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero', Boleta FROM tbPacientes INNER JOIN tbAlumnos ON tbPacientes.IdPaciente = tbAlumnos.IdAlumno
		WHERE (NombrePaciente LIKE @Dato) OR (ApellidosPaciente LIKE @Dato) OR (Boleta LIKE @Dato)
	END
	ELSE
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero' FROM tbPacientes
		WHERE TipoPaciente = @Tipo AND (NombrePaciente LIKE @Dato OR ApellidosPaciente LIKE @Dato)
	END
END
GO

EXEC selBuscarPaciente 1,''
GO
EXEC selBuscarPaciente 2,'A'