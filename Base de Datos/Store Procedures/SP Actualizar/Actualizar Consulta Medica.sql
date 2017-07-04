USE ServicioMedico
GO

IF OBJECT_ID('updActualizarConsulta') IS NOT NULL
DROP PROC updActualizarConsulta
GO

CREATE PROC updActualizarConsulta
(
@Paciente INT,
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
		
		BEGIN TRAN TUpdConsulta
		DECLARE @Entrada TIME = (SELECT HoraEntrada FROM tbConsultas WHERE CvePaciente = @Paciente)
		DECLARE @Salida TIME = (SELECT HoraSalida FROM tbConsultas WHERE CvePaciente = @Paciente)
		
		IF @Entrada <> @HoraEntrada OR @Salida <> @HoraSalida
		BEGIN
			
			DECLARE @Diff int, @Duracion time(0)
			SET @Diff = abs( datediff(second, @HoraEntrada, @HoraSalida) ) -- Calcula la diferencia en segundos entre HoraEntrada y HoraSalida
			SET @Duracion = dateadd(second, @Diff, 0) -- Convierte la diferencia en segundos a hh:mm:ss
			UPDATE tbConsultas
			SET Diagnostico = @Diagnostico, CveMotivo = @Motivo, CveMedicamento = @Medicamento, CantidadSuminstrada = @Cantidad, 
			FechaConsulta = @Fecha, HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida, DuracionConsulta = @Duracion
			WHERE CvePaciente = @Paciente
			SET @Mensaje = 'Consulta Actualizada con Exito'
			COMMIT TRAN TUpdConsulta
		END

		ELSE
		BEGIN
			UPDATE tbConsultas
			SET Diagnostico = @Diagnostico, CveMotivo = @Motivo, CveMedicamento = @Medicamento, CantidadSuminstrada = @Cantidad, FechaConsulta = @Fecha
			WHERE CvePaciente = @Paciente
			SET @Mensaje = 'Consulta Actualizada con Exito'
			COMMIT TRAN TUpdConsulta
		END

	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
        ROLLBACK TRAN TUpdConsulta
	END CATCH
END
GO