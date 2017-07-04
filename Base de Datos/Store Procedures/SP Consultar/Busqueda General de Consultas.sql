USE ServicioMedico 
GO

IF OBJECT_ID('selBusquedaConsultas') IS NOT NULL
DROP PROC selBusquedaConsultas
GO

CREATE PROCEDURE selBusquedaConsultas
(
@Tipo SMALLINT,
@Estatus SMALLINT
/*@Cve INT,
@Mes INT*/
)
AS
BEGIN
	IF(@Tipo = 1)--CONSULTAS DE ALUMNOS
	BEGIN
		SELECT IdConsulta, IdPaciente, NombrePaciente, ApellidosPaciente, Generos, EdadPaciente,
		CveDoctor, Diagnostico, FechaConsulta, HoraEntrada, HoraSalida, DuracionConsulta, 
		CveMedicamento, NombreMedicamento, CveMotivo, DescripcionMotivo, CantidadSuminstrada
		FROM tbGeneros INNER JOIN tbPacientes ON tbGeneros.IdGenero = tbPacientes.GeneroPaciente
		INNER JOIN tbConsultas ON tbPacientes.IdPaciente = tbConsultas.CvePaciente 
		INNER JOIN tbMedicamentos ON tbConsultas.CveMedicamento = tbMedicamentos.IdMedicamento
		INNER JOIN tbMotivosConsultas ON tbConsultas.CveMotivo = tbMotivosConsultas.IdMotivo
		WHERE TipoPaciente = 1 AND EstatusConsulta = @Estatus
	END--FIN CONSULTAS DE ALUMNOS

	ELSE IF(@Tipo = 2)--CONSULTAS DE DOCENTES
	BEGIN
		SELECT IdConsulta, IdPaciente, NombrePaciente, ApellidosPaciente, Generos, EdadPaciente,
		CveDoctor, Diagnostico, FechaConsulta, HoraEntrada, HoraSalida, DuracionConsulta, 
		CveMedicamento, NombreMedicamento, CveMotivo, DescripcionMotivo, CantidadSuminstrada
		FROM tbGeneros INNER JOIN tbPacientes ON tbGeneros.IdGenero = tbPacientes.GeneroPaciente
		INNER JOIN tbConsultas ON tbPacientes.IdPaciente = tbConsultas.CvePaciente 
		INNER JOIN tbMedicamentos ON tbConsultas.CveMedicamento = tbMedicamentos.IdMedicamento
		INNER JOIN tbMotivosConsultas ON tbConsultas.CveMotivo = tbMotivosConsultas.IdMotivo
		WHERE TipoPaciente = 2 AND EstatusConsulta = @Estatus
	END--FIN CONSULTAS DE DOCENTES

	ELSE IF(@Tipo = 3)--CONSULTAS DE PAAES
	BEGIN
		SELECT IdConsulta, IdPaciente, NombrePaciente, ApellidosPaciente, Generos, EdadPaciente,
		CveDoctor, Diagnostico, FechaConsulta, HoraEntrada, HoraSalida, DuracionConsulta, 
		CveMedicamento, NombreMedicamento, CveMotivo, DescripcionMotivo, CantidadSuminstrada
		FROM tbGeneros INNER JOIN tbPacientes ON tbGeneros.IdGenero = tbPacientes.GeneroPaciente
		INNER JOIN tbConsultas ON tbPacientes.IdPaciente = tbConsultas.CvePaciente 
		INNER JOIN tbMedicamentos ON tbConsultas.CveMedicamento = tbMedicamentos.IdMedicamento
		INNER JOIN tbMotivosConsultas ON tbConsultas.CveMotivo = tbMotivosConsultas.IdMotivo
		WHERE TipoPaciente = 3 AND EstatusConsulta = @Estatus
	END--FIN CONSULTAS DE PAAES

	ELSE --CONSULTAS DE EXTERNOS
	BEGIN
		SELECT IdConsulta, IdPaciente, NombrePaciente, ApellidosPaciente, Generos, EdadPaciente,
		CveDoctor, Diagnostico, FechaConsulta, HoraEntrada, HoraSalida, DuracionConsulta, 
		CveMedicamento, NombreMedicamento, CveMotivo, DescripcionMotivo, CantidadSuminstrada
		FROM tbGeneros INNER JOIN tbPacientes ON tbGeneros.IdGenero = tbPacientes.GeneroPaciente
		INNER JOIN tbConsultas ON tbPacientes.IdPaciente = tbConsultas.CvePaciente 
		INNER JOIN tbMedicamentos ON tbConsultas.CveMedicamento = tbMedicamentos.IdMedicamento
		INNER JOIN tbMotivosConsultas ON tbConsultas.CveMotivo = tbMotivosConsultas.IdMotivo
		WHERE TipoPaciente = 4 AND EstatusConsulta = @Estatus
	END --CONSULTAS DE EXTERNOS
END
GO

EXEC selBusquedaConsultas 1, 1
EXEC selBusquedaConsultas 2, 1
EXEC selBusquedaConsultas 3, 1
EXEC selBusquedaConsultas 4, 1
GO

EXEC selBusquedaConsultas 1, 0
EXEC selBusquedaConsultas 2, 0
EXEC selBusquedaConsultas 3, 0
EXEC selBusquedaConsultas 4, 0
GO

--AND MONTH(FechaConsulta) = @Mes