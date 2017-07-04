USE ServicioMedico
GO

IF OBJECT_ID('updEliminarRecuperarPaciente') IS NOT NULL
DROP PROC updEliminarRecuperarPaciente
GO

CREATE PROC updEliminarRecuperarPaciente
(
@ID INT,
@Estatus SMALLINT,
@Mensaje AS NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TBorrarPaciente
		UPDATE tbConsultas
		SET EstatusConsulta = @Estatus
		WHERE CvePaciente = @ID

		UPDATE tbPacientes
		SET EstatusPaciente = @Estatus
		WHERE IdPaciente = @ID	

		IF @Estatus = 1
			SET @Mensaje = 'Paciente Recuperado con Exito'
		ELSE 
			SET @Mensaje = 'Paciente Eliminado con Exito'
		COMMIT TRAN TBorrarPaciente
	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
		ROLLBACK TRAN TBorrarPaciente
	END CATCH
END