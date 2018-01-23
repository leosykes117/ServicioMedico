USE ServicioMedico
GO

IF OBJECT_ID('insNuevoReporteMes') IS NOT NULL
DROP PROC insNuevoReporteMes
GO

CREATE PROCEDURE insNuevoReporteMes
@Mes INT,
@YEAR INT,
@Doc INT
AS
BEGIN
	IF EXISTS(SELECT * FROM tbReportes WHERE FechaReporte = CONCAT(1, '/', @Mes, '/', @YEAR) AND Pertenece = @Doc)
	BEGIN
		EXEC selReporte @Mes, @YEAR, @Doc
	END
	ELSE
	BEGIN

		--TRAR LA SUMA DE TODOS LOS HOMBRE DE LA TABLA ALUMNOS
				DECLARE @HombreA AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 1 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)

		--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA ALUMNOS
				DECLARE @MujeresA AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 1 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)
	
		--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA DOCENTES
				DECLARE @HombreD AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 2 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)

		--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA DOCENTES
				DECLARE @MujeresD AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 2 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)

		--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA PAES
				DECLARE @HombreP AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 3 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)

		--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA PAES
				DECLARE @MujeresP AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 3 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)

		--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA EXTERNOS
				DECLARE @HombreE AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 4 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)

		--TRAER LA SUMA DE TODOS LAS MUJERES DE LA TABLA EXTERNOS
				DECLARE @MujeresE AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 4 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1 AND CveDoctor = @Doc)

		DECLARE @SubtotalH INT = @HombreA + @HombreD + @HombreP + @HombreE

		DECLARE @SubtotalM INT = @MujeresA + @MujeresD + @MujeresP + @MujeresD

		DECLARE @Total INT = @SubtotalH + @SubtotalM

		DECLARE @Fecha DATE = CONVERT(date, CONCAT(1, '/', @Mes, '/', @YEAR), 103)

		INSERT INTO tbReportes 
		VALUES(@Doc, @Fecha, @HombreA, @MujeresA, @HombreD, @MujeresD, @HombreP, @MujeresP, @HombreE, @MujeresE, @SubtotalH, @SubtotalM, @Total)

		SELECT @HombreA, @MujeresA, @HombreD, @MujeresD, @HombreP, @MujeresP, @HombreE, @MujeresE, @SubtotalH, @SubtotalM, @Total
	END
END
GO

EXEC insNuevoReporteMes 1,2018,4