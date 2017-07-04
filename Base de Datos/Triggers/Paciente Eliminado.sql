USE ServicioMedico
GO

IF OBJECT_ID('TR_Paciente_Delete') IS NOT NULL
DROP TRIGGER TR_Paciente_Delete
GO

CREATE TRIGGER TR_Paciente_Delete
ON tbPacientes
AFTER DELETE
AS
BEGIN
	DECLARE @Tipo AS SMALLINT = (SELECT TipoPaciente FROM deleted)
	DECLARE @ID INT = (SELECT IdPaciente FROM deleted)
	DECLARE @Bol_o_Num AS NVARCHAR(10)
	DECLARE @RFC AS NVARCHAR(13)
	DECLARE @Gupo AS NVARCHAR(5)
	DECLARE @Carrera AS SMALLINT

	IF @Tipo = 1
	BEGIN
		SET @Bol_o_Num = (SELECT Boleta FROM tbAlumnos WHERE IdAlumno = @ID)
		SET @Gupo = (SELECT Grupo FROM tbAlumnos WHERE IdAlumno = @ID)
		SET @Carrera = (SELECT Carrera FROM tbAlumnos WHERE IdAlumno = @ID)

		INSERT INTO tbPacientesEliminados SELECT NombrePaciente, ApellidosPaciente, GeneroPaciente, FechaNac, EdadPaciente,
		CURP, Calle, Num_Int, Num_Ext, Colonia, CP, id_Del_Mun, id_Edo, Celular, Tel_Part, CorreoPaciente, TipoPaciente, 
		NULL, @Bol_o_Num, @Gupo, @Carrera, GETDATE()
		FROM deleted
	END

	ELSE IF @Tipo = 2 OR @Tipo = 3
	BEGIN
		SET @RFC = (SELECT RFC_Personal FROM tbPersonalEscolar WHERE IdPersonal = @ID)
		
		INSERT INTO tbPacientesEliminados SELECT NombrePaciente, ApellidosPaciente, GeneroPaciente, FechaNac, EdadPaciente,
		CURP, Calle, Num_Int, Num_Ext, Colonia, CP, id_Del_Mun, id_Edo, Celular, Tel_Part, CorreoPaciente, TipoPaciente, 
		@RFC, @Bol_o_Num, @Gupo, @Carrera, GETDATE()
		FROM deleted
	END

	ELSE 
	BEGIN
		INSERT INTO tbPacientesEliminados SELECT NombrePaciente, ApellidosPaciente, GeneroPaciente, FechaNac, EdadPaciente,
		CURP, Calle, Num_Int, Num_Ext, Colonia, CP, id_Del_Mun, id_Edo, Celular, Tel_Part, CorreoPaciente, TipoPaciente, 
		NULL, NULL, NULL, NULL, GETDATE()
		FROM deleted
	END

END
GO

SELECT * FROM tbPacientesEliminados