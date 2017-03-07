USE FlashConsultas
GO

IF OBJECT_ID('selBuscarPorNombre') IS NOT NULL
DROP PROC selBuscarPorNombre
GO

CREATE PROCEDURE selBuscarPorNombre
(
@TipoPaciente INT,
@Nombre NVARCHAR(70),
@Cve INT,
@Mes INT
)
AS
BEGIN
	IF(@TipoPaciente = 1)
	BEGIN
		SELECT @Nombre = '%' + RTRIM(@Nombre) + '%'
		SELECT [Nombre del Alumno] AS 'Nombre', [CVE Boleta] AS 'Boleta', [Sexo A] AS 'Genero', Carrera, Grupo, [Nombre Doctor] AS 'Atendido Por', [Fecha (Alumnos)] AS 'Fecha de la Consulta', [Tratamiento (Alumnos)] AS 'Tratamiento'
		FROM TablaAlumnos INNER JOIN TablaConsultasAlumnos ON TablaConsultasAlumnos.[CVE Boleta] = TablaAlumnos.Boleta
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasAlumnos.[CVE Doctor (Alumnos)]
		WHERE [Nombre del Alumno] LIKE @Nombre AND [CVE Doctor (Alumnos)] = @Cve AND MONTH([Fecha (Alumnos)]) = @Mes
	END
	ELSE IF(@TipoPaciente = 2)
	BEGIN
		SELECT @Nombre = '%' + RTRIM(@Nombre) + '%'
		SELECT [Nombre de Docente] AS 'Nombre', [CVE Docente] AS 'ID', [Sexo D] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (Docentes)] AS 'Fecha de la Consulta', [Tratamiento (Docentes)] AS 'Tratamiento'
		FROM TablaDocentes INNER JOIN TablaConsultasDocentes ON TablaConsultasDocentes.[CVE Docente] = TablaDocentes.[ID Docente]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasDocentes.[CVE Doctor (Docentes)]
		WHERE [Nombre de Docente] LIKE @Nombre AND [CVE Doctor (Docentes)] = @Cve AND MONTH([Fecha (Docentes)]) = @Mes
	END
	ELSE IF(@TipoPaciente = 3)
	BEGIN
		SELECT @Nombre = '%' + RTRIM(@Nombre) + '%'
		SELECT [Nombre del PAE] AS 'Nombre', [CVE PAE] AS 'ID',[Sexo PAE] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (PAE)] AS 'Fecha de la Consulta', [Tratamiento (PAE)] AS 'Tratamiento'
		FROM TablaPAES INNER JOIN TablaConsultasPAE ON TablaConsultasPAE.[CVE PAE] = TablaPAES.[ID PAE]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasPAE.[CVE Doctor (PAE)]
		WHERE [Nombre del PAE] LIKE @Nombre AND [CVE Doctor (PAE)] = @Cve AND MONTH([Fecha (PAE)]) = @Mes
	END
	ELSE
	BEGIN
		SELECT @Nombre = '%' + RTRIM(@Nombre) + '%'
		SELECT [Nombre de Externo] AS 'Nombre', [CVE Externos] AS 'ID',[Sexo E] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (Externos)] AS 'Fecha de la Consulta', [Tratamiento (Externos)] AS 'Tratamiento'
		FROM TablaExternos INNER JOIN TablaConsultasExternos ON TablaConsultasExternos.[CVE Externos] = TablaExternos.[ID Externo]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasExternos.[CVE Doctor (Externos)]
		WHERE [Nombre de Externo] LIKE @Nombre AND [CVE Doctor (Externos)] = @Cve AND MONTH([Fecha (Externos)]) = @Mes
	END
END
GO

EXEC selBuscarPorNombre 4,'an'


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