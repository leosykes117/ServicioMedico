USE ServicioMedico
GO

IF OBJECT_ID('insAgregarConsulta') IS NOT NULL
DROP PROC insAgregarConsulta
GO

CREATE PROC insAgregarConsulta	
@Paciente INT,
@Doctor NVARCHAR(50),
@Diagnostico NVARCHAR(MAX),
@Observaciones NVARCHAR(MAX) = NULL,
@Fecha DATE,
@HoraEntrada TIME,
@HoraSalida TIME,
@Temp DECIMAL(4,2) = NULL, 
@TA NVARCHAR(8) = NULL,
@FC DECIMAL(6,3) = NULL, 
@FR DECIMAL(6,3) = NULL,
@IdRetornado INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @Diff int, @Duracion time(0)
		-- Calcula la diferencia en segundos entre HoraEntrada y HoraSalida
		SET @Diff = abs( datediff(second, @HoraEntrada, @HoraSalida) )

		-- Convierte la diferencia en segundos a hh:mm:ss
		SET @Duracion = dateadd(second, @Diff, 0) 

		--SE INSERTA EN LA TABLA CONSULTAS
		INSERT INTO tbConsultas VALUES (@Paciente, @Doctor, @Diagnostico, @Observaciones, @Fecha, @HoraEntrada, @HoraSalida, @Duracion, 1, @Temp, @Ta, @FC, @FR)

		SET @IdRetornado = @@IDENTITY
	END TRY

	BEGIN CATCH
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity int
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		SET @IdRetornado = NULL
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END
GO


/*SP PARA AGREGAR LOS MOTIVOS DE CONSULTA*/
IF OBJECT_ID('insMotivoConsulta') IS NOT NULL
DROP PROC insMotivoConsulta
GO

CREATE PROC insMotivoConsulta	
@ClaveConsulta INT,
@ClaveMotivo SMALLINT
AS
BEGIN
	BEGIN TRY
		INSERT INTO tbMotivosConsultas VALUES (@ClaveConsulta, @ClaveMotivo)
	END TRY

	BEGIN CATCH
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity int
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END
GO


/*SP PARA AGREGAR LOS MEDICAMENTOS DE CONSULTA*/
IF OBJECT_ID('insMedicamentoConsulta') IS NOT NULL
DROP PROC insMedicamentoConsulta
GO

CREATE PROC insMedicamentoConsulta
@ClaveConsulta INT,
@Medicamento NVARCHAR(100),
@Cantidad INT = NULL,
@Prescripcion NVARCHAR(100) = NULL
AS
BEGIN
	BEGIN TRY
		INSERT INTO tbMedicamentosConsultas VALUES (@ClaveConsulta, @Medicamento, @Cantidad, @Prescripcion)
	END TRY

	BEGIN CATCH
		DECLARE @ErrMsg NVARCHAR(4000), @ErrSeverity int
		SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
		RAISERROR(@ErrMsg, @ErrSeverity, 1)
	END CATCH
END
GO

SELECT * FROM tbPacientes
SELECT * FROM tbConsultas
SELECT * FROM tbMotivosConsultas
SELECT * FROM tbMedicamentosConsultas
SELECT * FROM tbCategorias
GO

/*DECLARE @ClaveConsulta AS INT = 0

SELECT @ClaveConsulta

IF(@ClaveConsulta = 0 OR @ClaveConsulta IS NULL)
BEGIN
	SELECT 'INSERTA CONSULTA'
END

ELSE
BEGIN
	SELECT 'CONSULTA EXISTE'
END*/