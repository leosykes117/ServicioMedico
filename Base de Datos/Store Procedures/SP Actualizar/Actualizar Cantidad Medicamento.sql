USE ServicioMedico
GO

IF OBJECT_ID('updModificarCantidad') IS NOT NULL
DROP PROC updModificarCantidad
GO

CREATE PROC updModificarCantidad
(
@Accion SMALLINT,
@ID INT,
@Cantidad INT,
@Mensaje NVARCHAR(100)OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF (@Accion = 1)
		BEGIN
			UPDATE tbMedicamentos --RESTAMOS
			SET Cantidad =	Cantidad - @Cantidad
			WHERE IdMedicamento = @ID
			IF(@@ROWCOUNT > 0)
				SET @Mensaje = 'Se actualizo'
			ELSE
				SET @Mensaje = 'No se actualizo'
		END
		ELSE
		BEGIN
			UPDATE tbMedicamentos --SUMAMOS
			SET Cantidad =	Cantidad + @Cantidad
			WHERE IdMedicamento = @ID
			IF(@@ROWCOUNT > 0)
				SET @Mensaje = 'Se actualizo'
			ELSE
				SET @Mensaje = 'No se actualizo'
		END
	END TRY
	BEGIN CATCH
		SET @Mensaje = 'No se actualizo'
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC updModificarCantidad 2, 2, 5, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

SELECT* FROM tbMedicamentos