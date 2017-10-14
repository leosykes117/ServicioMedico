USE ServicioMedico
GO

IF OBJECT_ID('dltEliminarPaciente') IS NOT NULL
DROP PROC dltEliminarPaciente
GO

CREATE PROC dltEliminarPaciente
@ID INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TBorrarPaciente

			DECLARE @Tipo AS SMALLINT
			SET @Tipo = (SELECT TipoPaciente FROM tbPacientes WHERE IdPaciente = @ID)

			DELETE FROM tbMotivosConsultas WHERE CveConsulta IN (SELECT IdConsulta FROM tbConsultas WHERE CvePaciente = @ID)
			DELETE FROM tbMedicamentosConsultas WHERE CveConsulta IN (SELECT IdConsulta FROM tbConsultas WHERE CvePaciente = @ID)
			DELETE FROM tbConsultas WHERE CvePaciente = @ID

			IF (@Tipo = 1)
			BEGIN 
				DELETE FROM tbAlumnos
				WHERE IdAlumno = @ID

				DELETE FROM tbPacientes
				WHERE IdPaciente = @ID
			END

			ELSE IF (@Tipo = 2 OR @Tipo = 3)
			BEGIN
				DELETE FROM tbPersonalEscolar
				WHERE IdPersonal = @ID

				DELETE FROM tbPacientes
				WHERE IdPaciente = @ID
			END

			ELSE
			BEGIN
				DELETE FROM tbPacientes
				WHERE IdPaciente = @ID
			END
			COMMIT TRAN TBorrarPaciente
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN TBorrarPaciente
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity int
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END
GO

EXEC dltEliminarPaciente 10

SELECT * FROM tbPacientes

DECLARE @Tipo AS SMALLINT
SET @Tipo = (SELECT TipoPaciente FROM tbPacientes WHERE IdPaciente = 18)
SELECT @Tipo
