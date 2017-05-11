USE FlashConsultas
GO

IF OBJECT_ID('selBuscarPorTratamiento') IS NOT NULL
DROP PROC selBuscarPorTratamiento
GO

CREATE PROCEDURE selBuscarPorTratamiento
(
@TipoPaciente INT,
@Tratamiento NVARCHAR(MAX),
@Cve INT,
@Mes INT
)
AS
BEGIN
	IF(@TipoPaciente = 1)
	BEGIN
		SELECT @Tratamiento = '%' + RTRIM(@Tratamiento) + '%'
		SELECT [Nombre del Alumno] AS 'Nombre', [CVE Boleta] AS 'Boleta', [Sexo A] AS 'Genero', Carrera, Grupo, [Nombre Doctor] AS 'Atendido Por', [Fecha (Alumnos)] AS 'Fecha de la Consulta', [Tratamiento (Alumnos)] AS 'Tratamiento'
		FROM TablaAlumnos INNER JOIN TablaConsultasAlumnos ON TablaConsultasAlumnos.[CVE Boleta] = TablaAlumnos.Boleta
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasAlumnos.[CVE Doctor (Alumnos)]
		WHERE [Tratamiento (Alumnos)] LIKE @Tratamiento AND [CVE Doctor (Alumnos)] = @Cve AND MONTH([Fecha (Alumnos)]) = @Mes
	END
	ELSE IF(@TipoPaciente = 2)
	BEGIN
		SELECT @Tratamiento = '%' + RTRIM(@Tratamiento) + '%'
		SELECT [Nombre de Docente] AS 'Nombre', [CVE Docente] AS 'ID', [Sexo D] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (Docentes)] AS 'Fecha de la Consulta', [Tratamiento (Docentes)] AS 'Tratamiento'
		FROM TablaDocentes INNER JOIN TablaConsultasDocentes ON TablaConsultasDocentes.[CVE Docente] = TablaDocentes.[ID Docente]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasDocentes.[CVE Doctor (Docentes)]
		WHERE [Tratamiento (Docentes)] LIKE @Tratamiento AND [CVE Doctor (Docentes)] = @Cve AND MONTH([Fecha (Docentes)]) = @Mes
	END
	ELSE IF(@TipoPaciente = 3)
	BEGIN
		SELECT @Tratamiento = '%' + RTRIM(@Tratamiento) + '%'
		SELECT [Nombre del PAE] AS 'Nombre', [CVE PAE] AS 'ID',[Sexo PAE] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (PAE)] AS 'Fecha de la Consulta', [Tratamiento (PAE)] AS 'Tratamiento'
		FROM TablaPAES INNER JOIN TablaConsultasPAE ON TablaConsultasPAE.[CVE PAE] = TablaPAES.[ID PAE]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasPAE.[CVE Doctor (PAE)]
		WHERE [Tratamiento (PAE)] LIKE @Tratamiento AND [CVE Doctor (PAE)] = @Cve AND MONTH([Fecha (PAE)]) = @Mes
	END
	ELSE
	BEGIN
		SELECT @Tratamiento = '%' + RTRIM(@Tratamiento) + '%'
		SELECT [Nombre de Externo] AS 'Nombre', [CVE Externos] AS 'ID',[Sexo E] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (Externos)] AS 'Fecha de la Consulta', [Tratamiento (Externos)] AS 'Tratamiento'
		FROM TablaExternos INNER JOIN TablaConsultasExternos ON TablaConsultasExternos.[CVE Externos] = TablaExternos.[ID Externo]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasExternos.[CVE Doctor (Externos)]
		WHERE [Tratamiento (Externos)] LIKE @Tratamiento AND [CVE Doctor (Externos)] = @Cve AND MONTH([Fecha (Externos)]) = @Mes
	END
END
GO

EXEC selBuscarPorTratamiento 4,'o',501,11

SELECT * FROM TablaConsultasAlumnos
select * from TablaAlumnos
SELECT * FROM TablaDocentes
SELECT * FROM TablaConsultasDocentes
SELECT * FROM TablaPAES
SELECT * FROM TablaConsultasPAE
SELECT * FROM TablaExternos
SELECT * FROM TablaConsultasExternos