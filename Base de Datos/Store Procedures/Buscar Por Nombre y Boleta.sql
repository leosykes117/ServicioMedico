USE ServicioMedico
GO

IF OBJECT_ID('selBusGenNomBol') IS NOT NULL
DROP PROC selBusGenNomBol
GO

CREATE PROCEDURE selBusGenNomBol
(
@TipoPaciente INT,
@NombreBoleta NVARCHAR(50)
)
AS
BEGIN
	SELECT @NombreBoleta = '%' + RTRIM(@NombreBoleta) + '%'	
	IF(@TipoPaciente = 1)
	BEGIN
		SELECT [ID Alumno] AS 'Clave', Boleta AS 'Boleta o PM', [Nombre de Alumno] AS 'Nombre', Carrera FROM TablaAlumnos
		WHERE [Nombre de Alumno] LIKE @NombreBoleta OR Boleta LIKE @NombreBoleta
	END
	ELSE IF(@TipoPaciente = 2)
	BEGIN
		SELECT [ID Docente] AS 'Clave', [Nombre de Docente] AS 'Nombre' FROM TablaDocentes
		WHERE [Nombre de Docente] LIKE @NombreBoleta
	END
	ELSE IF(@TipoPaciente = 3)
	BEGIN
		SELECT [ID PAE] AS 'Clave', [Nombre de PAE] AS 'Nombre' FROM TablaPAES 
		WHERE [Nombre de PAE] LIKE @NombreBoleta
	END
	ELSE
	BEGIN
		SELECT [ID Externo] AS 'Clave', [Nombre de Externo] AS 'Nombre' FROM TablaExternos
		WHERE [Nombre de Externo] LIKE @NombreBoleta
	END
END
GO

EXEC selBusGenNomBol 4,'H'


SELECT * FROM TablaConsultasAlumnos
select * from TablaAlumnos
SELECT * FROM TablaDocentes
SELECT * FROM TablaConsultasDocentes
SELECT * FROM TablaPAES
SELECT * FROM TablaConsultasPAE
SELECT * FROM TablaExternos
SELECT * FROM TablaConsultasExternos

SELECT [Nombre del Alumno], [CVE Boleta] AS 'Boleta', [Sexo A], Carrera, Grupo, [Nombre Doctor] AS 'Atendido Por', [Fecha (Alumnos)] AS 'Fecha de la Consulta'
FROM TablaAlumnos INNER JOIN TablaConsultasAlumnos ON TablaConsultasAlumnos.[CVE Boleta] = TablaAlumnos.Boleta
INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasAlumnos.[CVE Doctor (Alumnos)]

SELECT [Nombre de Docente], [CVE Docente], [Sexo D], [Nombre Doctor], [Fecha (Docentes)], [Tratamiento (Docentes)]
FROM TablaDocentes INNER JOIN TablaConsultasDocentes ON TablaConsultasDocentes.[CVE Docente] = TablaDocentes.[ID Docente]
INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasDocentes.[CVE Doctor (Docentes)]

SELECT [Nombre del PAE], [CVE PAE],[Sexo PAE], [Nombre Doctor], [Fecha (PAE)], [Tratamiento (PAE)]
FROM TablaPAES INNER JOIN TablaConsultasPAE ON TablaConsultasPAE.[CVE PAE] = TablaPAES.[ID PAE]
INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasPAE.[CVE Doctor (PAE)]

SELECT [Nombre de Externo], [CVE Externos],[Sexo E], [Nombre Doctor], [Fecha (Externos)], [Tratamiento (Externos)]
FROM TablaExternos INNER JOIN TablaConsultasExternos ON TablaConsultasExternos.[CVE Externos] = TablaExternos.[ID Externo]
INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasExternos.[CVE Doctor (Externos)]

SELECT Con