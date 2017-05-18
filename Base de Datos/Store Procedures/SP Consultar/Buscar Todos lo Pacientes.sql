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
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero',
		Boleta, Grupo, Carrera, FechaNac AS 'Fecha', CURP, Calle, Num_Int, Num_Ext, Colonia, CP, 
		id_Del_Mun, id_Edo, Tel_Part AS 'Telefono', CorreoPaciente AS 'Correo'
		FROM tbPacientes INNER JOIN tbAlumnos ON tbPacientes.IdPaciente = tbAlumnos.IdAlumno
	END

	ELSE IF (@Tipo = 2)
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero',
		NumDocente AS 'Num_Empleado', RFC_Docente AS 'RFC', FechaNac AS 'Fecha',  CURP, Calle, Num_Int, Num_Ext, Colonia, CP, 
		id_Del_Mun, id_Edo, Tel_Part AS 'Telefono', CorreoPaciente AS 'Correo'
		FROM tbPacientes INNER JOIN tbDocentes ON tbPacientes.IdPaciente = tbDocentes.IdDocente
	END

	ELSE IF (@Tipo = 3)
	BEGIN
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero',
		NumPAAE AS 'Num_Empleado', RFC_PAAE AS 'RFC', FechaNac AS 'Fecha', CURP, Calle, Num_Int, Num_Ext, Colonia, CP, 
		id_Del_Mun, id_Edo, Tel_Part AS 'Telefono', CorreoPaciente AS 'Correo'
		FROM tbPacientes INNER JOIN tbPAAES ON tbPacientes.IdPaciente = tbPAAES.IdPAAE
	END

	ELSE
	BEGIN 
		SELECT IdPaciente AS 'Clave', NombrePaciente AS 'Nombre', ApellidosPaciente AS 'Apellidos', EdadPaciente AS 'Edad', GeneroPaciente AS 'Genero',
		FechaNac AS 'Fecha', CURP, Calle, Num_Int, Num_Ext, Colonia, CP, 
		id_Del_Mun, id_Edo, Tel_Part AS 'Telefono', CorreoPaciente AS 'Correo'
		FROM tbPacientes 
		WHERE TipoPaciente = 4
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