USE ServicioMedico
GO

IF OBJECT_ID('selGenPacientes') IS NOT NULL
DROP PROC selGenPacientes
GO

CREATE PROC selGenPacientes
(
@Tipo SMALLINT,
@Estatus SMALLINT
)
AS
BEGIN
	IF(@Tipo = 1)
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', 
		GeneroPaciente AS 'ClaveGenero',Generos AS 'Genero', FechaNac AS 'Fecha', EdadPaciente AS 'Edad', 
		CURP, Colonia, Calle, Num_Int, Num_Ext, CP, DelMun, Estado, Celular, Tel_Part AS 'Telefono', 
		CorreoPaciente AS 'Correo', Boleta, Grupo, Carreras AS 'Carrera', Carrera AS 'ClaveCarrera', TipoPaciente
		FROM tbPacientes INNER JOIN tbAlumnos ON tbPacientes.IdPaciente = tbAlumnos.IdAlumno
		INNER JOIN tbGeneros ON tbPacientes.GeneroPaciente = tbGeneros.IdGenero
		INNER JOIN tbCarreras ON tbAlumnos.Carrera = tbCarreras.IdCarrera
		WHERE EstatusPaciente = @Estatus

	END

	ELSE IF (@Tipo = 2 OR @Tipo = 3)
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', 
		GeneroPaciente AS 'ClaveGenero',Generos AS 'Genero', FechaNac AS 'Fecha', EdadPaciente AS 'Edad', 
		CURP, Colonia, Calle, Num_Int, Num_Ext, CP, DelMun, Estado, Celular, Tel_Part AS 'Telefono', 
		CorreoPaciente AS 'Correo', Num_Personal AS 'Num_Empleado', RFC_Personal AS 'RFC', TipoPaciente
		FROM tbPacientes INNER JOIN tbPersonalEscolar ON tbPacientes.IdPaciente = tbPersonalEscolar.IdPersonal
		INNER JOIN tbGeneros ON tbPacientes.GeneroPaciente = tbGeneros.IdGenero
		WHERE TipoPaciente = @Tipo AND EstatusPaciente = @Estatus
	END

	ELSE
	BEGIN 
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', 
		GeneroPaciente AS 'ClaveGenero',Generos AS 'Genero', FechaNac AS 'Fecha', EdadPaciente AS 'Edad', 
		CURP, Colonia, Calle, Num_Int, Num_Ext, CP, DelMun, Estado, Celular, Tel_Part AS 'Telefono', 
		CorreoPaciente AS 'Correo', TipoPaciente
		FROM tbPacientes INNER JOIN tbGeneros ON tbPacientes.GeneroPaciente = tbGeneros.IdGenero
		WHERE TipoPaciente = 4 AND EstatusPaciente = @Estatus
	END
END
GO

	EXEC selGenPacientes 1, 1
	GO
	EXEC selGenPacientes 2
	GO
	EXEC selGenPacientes 3
	GO
	EXEC selGenPacientes 4, 1
	GO


	SELECT * FROM tbPacientes