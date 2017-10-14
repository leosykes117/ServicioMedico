USE ServicioMedico
GO

IF OBJECT_ID('updActualizarConsulta') IS NOT NULL
DROP PROC updActualizarConsulta
GO

CREATE PROC updActualizarConsulta
@Consulta INT,
@Diagnostico NVARCHAR(MAX),
@Observaciones NVARCHAR(MAX) = NULL,
@Fecha DATE,
@HoraEntrada TIME,
@HoraSalida TIME,
@Temp DECIMAL(4,2) = NULL,
@TA NVARCHAR(8) = NULL,
@FC DECIMAL(6,3) = NULL, 
@FR DECIMAL(6,3) = NULL
AS
BEGIN
	BEGIN TRY
		
		BEGIN TRAN TUpdConsulta
		DECLARE @Entrada TIME = (SELECT HoraEntrada FROM tbConsultas WHERE IdConsulta = @Consulta)
		DECLARE @Salida TIME = (SELECT HoraSalida FROM tbConsultas WHERE IdConsulta = @Consulta)
		
		IF @Entrada <> @HoraEntrada OR @Salida <> @HoraSalida
		BEGIN
			
			DECLARE @Diff int, @Duracion time(0)
			SET @Diff = abs( datediff(second, @HoraEntrada, @HoraSalida) ) -- Calcula la diferencia en segundos entre HoraEntrada y HoraSalida
			SET @Duracion = dateadd(second, @Diff, 0) -- Convierte la diferencia en segundos a hh:mm:ss
			UPDATE tbConsultas
			SET Diagnostico = @Diagnostico, Observaciones = @Observaciones, FechaConsulta = @Fecha, HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida, 
			DuracionConsulta = @Duracion, Temperatura = @Temp, TA = @TA, FC = @FC, FR = @FR
			WHERE IdConsulta = @Consulta
		END

		ELSE
		BEGIN
			UPDATE tbConsultas
			SET Diagnostico = @Diagnostico, Observaciones = @Observaciones, FechaConsulta = @Fecha, Temperatura = @Temp, TA = @TA, FC = @FC, FR = @FR
			WHERE IdConsulta = @Consulta
		END
		COMMIT TRAN TUpdConsulta
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN TUpdConsulta
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity int
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END
GO

SELECT * FROM tbConsultas

EXEC updActualizarConsulta 5,
							'La paciente presento dolor de cabeza',
							'Tomar vitamina B',
							'2017-07-20',
							'20:57:29.0000000',
							'20:58:53.0000000',
							36,
							'100/50',
							NULL,
							NULL
GO