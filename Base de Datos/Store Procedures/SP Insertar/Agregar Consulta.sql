USE ServicioMedico
GO

IF OBJECT_ID('insAgregarConsulta') IS NOT NULL
DROP PROC insAgregarConsulta
GO

CREATE PROC insAgregarConsulta	
(
@Paciente INT,
@Doctor NVARCHAR(50),
@Motivo NVARCHAR(30),
@Diagnostico NVARCHAR(30),
@Fecha DATE,
@HoraEntrada TIME,
@HoraSalida TIME,
@Tratamiento INT,
@Cantidad INT,
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TInsConsulta
			INSERT INTO tbConsultas VALUES (@Paciente, @Doctor, @Motivo, @Diagnostico, @Fecha, @HoraEntrada, @HoraSalida)
			INSERT INTO tbDetallesConsultas VALUES (@@IDENTITY, @Tratamiento, @Cantidad)
			DECLARE @msm AS NVARCHAR(100)
			EXEC updModificarCantidad 1, @Tratamiento, @Cantidad, @msm OUTPUT
			IF(@msm = 'Se actualizo')
			BEGIN
				SET @Mensaje = 'La Consulta se Registro Correctamente'
				COMMIT TRAN TInsConsulta
			END
			ELSE
			BEGIN
				SET @Mensaje = 'La Consulta no se registro'
				ROLLBACK TRAN TInsConsulta
			END
	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
        ROLLBACK TRAN TInsConsulta
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
DECLARE @Retornado AS INT
EXEC insAgregarConsulta 2,'Ana Maria Martinez Arana','Pastilla','Presento Jaqueca','2017-05-04','7:59 PM','8:03 PM', 1, 1,@Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO