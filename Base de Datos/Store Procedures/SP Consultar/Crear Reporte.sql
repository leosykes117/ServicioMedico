USE ServicioMedico
GO

IF OBJECT_ID('insCraerReporte') IS NOT NULL
DROP PROC insCraerReporte
GO

CREATE PROCEDURE insNuevoReporte
@Mes INT,
@YEAR INT,
@ID INT OUTPUT
AS
BEGIN
	--TRAR LA SUMA DE TODOS LOS HOMBRE DE LA TABLA ALUMNOS
	DECLARE @HombreA AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 1 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA ALUMNOS
	DECLARE @MujeresA AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 1 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero
	
	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA DOCENTES
	DECLARE @HombreD AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 2 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA DOCENTES
	DECLARE @MujeresD AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 2 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA PAES
	DECLARE @HombreP AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 3 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA PAES
	DECLARE @MujeresP AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 3 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA EXTERNOS
	DECLARE @HombreE AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 4 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRAER LA SUMA DE TODOS LAS MUJERES DE LA TABLA EXTERNOS
	DECLARE @MujeresE AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 4 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	DECLARE @SubtotalH INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	DECLARE @SubtotalM INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) -- AND [CVE Doctor (Alumnos)]=@Consultorio

	DECLARE @Total INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1)

	INSERT INTO Reportes
	VALUES(NULL, @Mes,@YEAR, @HombreA, @MujeresA, @HombreD, @MujeresD, @HombreP, @MujeresP, @HombreE, @MujeresE, @SubtotalH, @SubtotalM, @Total, NULL)
	SET @ID = @@IDENTITY
END
GO



IF OBJECT_ID('selCraerReporte') IS NOT NULL
DROP PROC selCraerReporte
GO

CREATE PROC selCraerReporte
@Mes INT,
@YEAR INT
AS
BEGIN
	--TRAR LA SUMA DE TODOS LOS HOMBRE DE LA TABLA ALUMNOS
	DECLARE @HombreA AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 1 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA ALUMNOS
	DECLARE @MujeresA AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 1 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero
	
	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA DOCENTES
	DECLARE @HombreD AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 2 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA DOCENTES
	DECLARE @MujeresD AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 2 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA PAES
	DECLARE @HombreP AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 3 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA PAES
	DECLARE @MujeresP AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 3 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA EXTERNOS
	DECLARE @HombreE AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 4 AND GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	--TRAER LA SUMA DE TODOS LAS MUJERES DE LA TABLA EXTERNOS
	DECLARE @MujeresE AS INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE TipoPaciente = 4 AND GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	DECLARE @SubtotalH INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE GeneroPaciente = 1) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) --CveDoctor = Un numero

	DECLARE @SubtotalM INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE CvePaciente IN (SELECT IdPaciente FROM tbPacientes WHERE GeneroPaciente = 2) 
	AND MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1) -- AND [CVE Doctor (Alumnos)]=@Consultorio

	DECLARE @Total INT = (SELECT COUNT(*) FROM tbConsultas
	WHERE MONTH(FechaConsulta) = @Mes AND YEAR(FechaConsulta) = @YEAR AND EstatusConsulta = 1)
	
	SELECT @HombreA as 'AlumnosH', @MujeresA as 'AlumnosM', 
			@HombreD as 'DocentesH', @MujeresD 'DocentesM', 
			@HombreP as 'PaaesH', @MujeresP as 'PaaesM', 
			@HombreE as 'ExternosH', @MujeresE as 'ExternosM', 
			@SubtotalH as 'SubtotalH', @SubtotalM as 'SubtotalM', @Total as 'Total'
END
GO