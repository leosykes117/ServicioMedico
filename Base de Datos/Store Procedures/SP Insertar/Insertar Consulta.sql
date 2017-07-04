USE ServicioMedico
GO

IF OBJECT_ID('insAgregarConsulta') IS NOT NULL
DROP PROC insAgregarConsulta
GO

CREATE PROC insAgregarConsulta	
(
@Paciente INT,
@Doctor NVARCHAR(50),
@Diagnostico NVARCHAR(MAX),
@Fecha DATE,
@HoraEntrada TIME,
@HoraSalida TIME,
@Motivo SMALLINT,
@Medicamento INT,
@Cantidad INT,
@Mensaje NVARCHAR(200) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TInsConsulta
		DECLARE @Diff int, @Duracion time(0)
		SET @Diff = abs( datediff(second, @HoraEntrada, @HoraSalida) ) -- Calcula la diferencia en segundos entre HoraEntrada y HoraSalida
		SET @Duracion = dateadd(second, @Diff, 0) -- Convierte la diferencia en segundos a hh:mm:ss

		--SE INSERTA EN LA TABLA CONSULTAS
		INSERT INTO tbConsultas VALUES (@Paciente, @Doctor, @Diagnostico, @Motivo, @Medicamento,@Cantidad, @Fecha, @HoraEntrada, @HoraSalida, @Duracion, 1)

		DECLARE @msm AS NVARCHAR(100)
		EXEC updModificarCantidad 1, @Medicamento, @Cantidad, @msm OUTPUT --SE CAMBIA LA CANTIDAD EN ALMACEN DEL MEDICAMENTO

		IF(@msm = 'Se actualizo')
		BEGIN
			SET @Mensaje = 'La Consulta se Registro Correctamente'
			COMMIT TRAN TInsConsulta
		END

		ELSE
		BEGIN
			SET @Mensaje = 'La Consulta no se Registro'
			ROLLBACK TRAN TInsConsulta
		END

	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
        ROLLBACK TRAN TInsConsulta
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(MAX)
EXEC insAgregarConsulta 8,
						'Ana Maria Martinez Arana',
						'ADKDLADJALK DKASDIAUIO ASDUASDUIAY AUSDASYUY ADSASDIUASDSADAU ASIUDYAUDYUD UYSUYUAS UYUD ASYUYU SUAYUYU YU UYU YUDYUA',
						'2017-06-11',
						'6:56:06 PM',
						'6:58:48 PM', 
						1, 
						1,
						2,
						@Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

SELECT * FROM tbConsultas
SELECT * FROM tbDetallesConsultas
SELECT * FROM tbMedicamentos
SELECT * FROM tbCategorias