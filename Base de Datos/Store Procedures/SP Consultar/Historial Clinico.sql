USE ServicioMedico
GO

IF OBJECT_ID('selHistoriaClinica') IS NOT NULL
DROP PROC selHistoriaClinica
GO

CREATE PROC selHistoriaClinica
(
@CvePaciente INT
)
AS
BEGIN
	SELECT IdConsulta, FechaConsulta, Diagnostico, Observaciones, CveDoctor
	FROM tbConsultas INNER JOIN tbPacientes ON tbConsultas.CvePaciente = tbPacientes.IdPaciente
	WHERE CvePaciente = @CvePaciente AND EstatusConsulta = 1
	ORDER BY FechaConsulta ASC
END
GO

EXEC selHistoriaClinica 1
GO


/*SP DE LISTADO DE MOTIVOS POR CONSULTA*/
IF OBJECT_ID('selHistoriaMotivos') IS NOT NULL
DROP PROC selHistoriaMotivos
GO

CREATE PROC selHistoriaMotivos
(
@Consulta INT
)
AS
BEGIN
	SELECT CveMotivo AS 'ClaveMot', DescripcionMotivo AS 'Motivo'
	FROM tbMotivosConsultas INNER JOIN tbMotivos ON tbMotivosConsultas.CveMotivo = tbMotivos.IdMotivo
	WHERE CveConsulta = @Consulta
END
GO

EXEC selHistoriaMotivos 4 
GO


/*SP DE LISTADO DE MEDICAMENTOS POR CONSULTA*/
IF OBJECT_ID('selHistoriaMedicamentos') IS NOT NULL
DROP PROC selHistoriaMedicamentos
GO

CREATE PROC selHistoriaMedicamentos
(
@Consulta INT
)
AS
BEGIN
	SELECT CveMedicamento AS 'Medicamento', CantidadSuministrada, Prescripcion 
	FROM tbMedicamentosConsultas
	WHERE CveConsulta = @Consulta
END
GO

EXEC selHistoriaMedicamentos 3
GO

SELECT * FROM tbPacientes
SELECT * FROM tbConsultas 
SELECT * FROM tbMotivosConsultas
SELECT * FROM tbMotivos	