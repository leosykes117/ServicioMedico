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
	SELECT Fecha, Motivo,Diagnostico, NombreMedicamento ,CveDoctor
	FROM tbConsultas INNER JOIN tbDetallesConsultas ON tbConsultas.IdConsulta = tbDetallesConsultas.CveConsulta
	INNER JOIN tbMedicamentos ON tbDetallesConsultas.Tratamiento = tbMedicamentos.IdMedicamento
	WHERE CvePaciente = @CvePaciente
	ORDER BY Fecha ASC
END
GO


EXEC selHistoriaClinica 2