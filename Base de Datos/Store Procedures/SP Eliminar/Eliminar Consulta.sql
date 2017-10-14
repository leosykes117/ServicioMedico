USE ServicioMedico
GO

IF OBJECT_ID('dltEliminarConsulta') IS NOT NULL
DROP PROC dltEliminarConsulta
GO

CREATE PROC dltEliminarConsulta
@Consulta INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN Teliminar
		DELETE FROM tbMotivosConsultas 
		WHERE CveConsulta = @Consulta

		DELETE FROM tbMedicamentosConsultas
		WHERE CveConsulta = @Consulta

		DELETE FROM tbConsultas
		WHERE IdConsulta = @Consulta
		COMMIT TRAN Teliminar
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN Teliminar
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity int
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END
GO

SELECT * FROM tbMotivosConsultas WHERE CveConsulta IN (SELECT IdConsulta FROM tbConsultas WHERE CvePaciente = 5)
GO

SELECT * FROM tbMedicamentosConsultas WHERE CveConsulta IN (SELECT IdConsulta FROM tbConsultas WHERE CvePaciente = 5)
GO

SELECT IdConsulta, CvePaciente, Diagnostico, CveMotivo FROM tbConsultas INNER JOIN tbMotivosConsultas ON tbConsultas.IdConsulta = tbMotivosConsultas.CveConsulta