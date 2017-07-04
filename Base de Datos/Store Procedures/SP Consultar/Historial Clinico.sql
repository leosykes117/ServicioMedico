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
	SELECT FechaConsulta, DescripcionMotivo, Diagnostico, NombreMedicamento, CveDoctor
	FROM tbConsultas INNER JOIN tbMedicamentos ON tbConsultas.CveMedicamento = tbMedicamentos.IdMedicamento
	INNER JOIN tbMotivosConsultas ON tbConsultas.CveMotivo = tbMotivosConsultas.IdMotivo
	WHERE CvePaciente = @CvePaciente
	ORDER BY FechaConsulta ASC
END
GO

EXEC selHistoriaClinica 5

SELECT * FROM tbPacientes