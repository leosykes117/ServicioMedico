USE ServicioMedico 
GO

IF OBJECT_ID('selBusquedaConsultas') IS NOT NULL
DROP PROC selBusquedaConsultas
GO

CREATE PROCEDURE selBusquedaConsultas
@Tipo SMALLINT,
@Estatus SMALLINT,
@Cve INT
AS
BEGIN
	SELECT IdConsulta, NombrePaciente + ' ' + ApellidosPaciente AS 'Nombre', Generos, EdadPaciente, NombreDoctor + ' ' + ApellidosDoctor AS 'Atendio', 
	Diagnostico, Observaciones, FechaConsulta, HoraEntrada, HoraSalida, DuracionConsulta, Temperatura, TA, FC, FR
	FROM tbGeneros INNER JOIN tbPacientes ON tbGeneros.IdGenero = tbPacientes.GeneroPaciente
	INNER JOIN tbConsultas ON tbPacientes.IdPaciente = tbConsultas.CvePaciente
	INNER JOIN tbDoctores ON tbConsultas.CveDoctor = tbDoctores.IdDoctor
	WHERE TipoPaciente = @Tipo AND EstatusConsulta = @Estatus AND CveDoctor = @Cve
END
GO

EXEC selBusquedaConsultas 1, 1, 4
EXEC selBusquedaConsultas 2, 1
EXEC selBusquedaConsultas 3, 1
EXEC selBusquedaConsultas 4, 1
GO

EXEC selBusquedaConsultas 1, 0, 4
EXEC selBusquedaConsultas 2, 0, 7
EXEC selBusquedaConsultas 3, 0, 7
EXEC selBusquedaConsultas 4, 0, 7
GO

SELECT IdConsulta, NombrePaciente + ' ' + ApellidosPaciente AS 'Nombre', Generos, EdadPaciente, CveDoctor, Diagnostico, Observaciones, 
FechaConsulta, HoraEntrada, HoraSalida, DuracionConsulta, Temperatura, TA, FC, FR
FROM tbGeneros INNER JOIN tbPacientes ON tbGeneros.IdGenero = tbPacientes.GeneroPaciente
INNER JOIN tbConsultas ON tbPacientes.IdPaciente = tbConsultas.CvePaciente
