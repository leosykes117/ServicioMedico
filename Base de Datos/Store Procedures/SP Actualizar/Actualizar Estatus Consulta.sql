USE ServicioMedico
GO

IF OBJECT_ID('updEliminarConsulta') IS NOT NULL
DROP PROC updEliminarConsulta
GO

CREATE PROC updEliminarConsulta
@Consulta INT,
@Estatus SMALLINT,
@Mensaje NVARCHAR(200) OUTPUT
AS
BEGIN
	BEGIN TRY
		UPDATE tbConsultas
		SET EstatusConsulta = @Estatus
		WHERE IdConsulta = @Consulta
		SET @Mensaje = 'Actualizo'
	END TRY

	BEGIN CATCH
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity int
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		SET @Mensaje = 'La consulta no pudo ser eliminada'
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END
GO

SELECT * FROM tbConsultas

