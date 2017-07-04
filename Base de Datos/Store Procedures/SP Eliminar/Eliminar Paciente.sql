USE ServicioMedico
GO

IF OBJECT_ID('dltEliminarPaciente') IS NOT NULL
DROP PROC dltEliminarPaciente
GO

CREATE PROC dltEliminarPaciente
(
@ID INT,
@Mensaje AS NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TBorrarPaciente

			DECLARE @Tipo AS SMALLINT
			SET @Tipo = (SELECT TipoPaciente FROM tbPacientes WHERE IdPaciente = @ID)

			IF (@Tipo = 1)
			BEGIN 
				DELETE FROM tbAlumnos
				WHERE IdAlumno = @ID

				DELETE FROM tbConsultas
				WHERE CvePaciente = @ID AND EstatusConsulta = 0

				DELETE FROM tbPacientes
				WHERE IdPaciente = @ID AND EstatusPaciente = 0

				SET @Mensaje = 'Paciente Borrado con Exito'
				COMMIT TRAN TBorrarPaciente
			END

			ELSE IF (@Tipo = 2 OR @Tipo = 3)
			BEGIN
				DELETE FROM tbPersonalEscolar
				WHERE IdPersonal = @ID

				DELETE FROM tbConsultas
				WHERE CvePaciente = @ID AND EstatusConsulta = 0

				DELETE FROM tbPacientes
				WHERE IdPaciente = @ID AND EstatusPaciente = 0

				SET @Mensaje = 'Paciente Borrado con Exito'
				COMMIT TRAN TBorrarPaciente
			END

			ELSE
			BEGIN
				DELETE FROM tbConsultas
				WHERE CvePaciente = @ID AND EstatusConsulta = 0

				DELETE FROM tbPacientes
				WHERE IdPaciente = @ID AND EstatusPaciente = 0

				SET @Mensaje = 'Paciente Borrado con Exito'
				COMMIT TRAN TBorrarPaciente
			END
	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
		ROLLBACK TRAN TBorrarPaciente
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC dltEliminarPaciente 18, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje

DECLARE @Tipo AS SMALLINT
SET @Tipo = (SELECT TipoPaciente FROM tbPacientes WHERE IdPaciente = 18)
SELECT @Tipo
