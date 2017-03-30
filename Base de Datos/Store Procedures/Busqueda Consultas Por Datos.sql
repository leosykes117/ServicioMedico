USE ServicioMedico 
GO

IF OBJECT_ID('selConsultasByDato') IS NOT NULL
DROP PROC selConsultasByDato
GO

CREATE PROCEDURE selConsultasByDato
(
@TipoPaciente INT,
@Cve INT,
@Mes INT,
@Dato NVARCHAR(70)
)
AS
BEGIN
	SELECT @Dato = '%' + RTRIM(@Dato) + '%'
	IF(@TipoPaciente = 1)
	BEGIN
		SELECT [Nombre de Alumno] AS 'Nombre', Boleta AS 'Boleta', [Genero A] AS 'Genero', Carrera, Grupo, [Nombre Doctor] AS 'Atendido Por', [Fecha (Alumnos)] AS 'Fecha de la Consulta', [Tratamiento (Alumnos)] AS 'Tratamiento'
		FROM TablaAlumnos INNER JOIN TablaConsultasAlumnos ON TablaConsultasAlumnos.[CVE Alumno] = TablaAlumnos.[ID Alumno]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasAlumnos.[CVE Doctor (Alumnos)]
		WHERE [CVE Doctor (Alumnos)] = @Cve AND MONTH([Fecha (Alumnos)]) = @Mes AND [Nombre de Alumno] LIKE @Dato
	END
	ELSE IF(@TipoPaciente = 2)
	BEGIN
		SELECT [Nombre de Docente] AS 'Nombre', [CVE Docente] AS 'ID', [Genero D] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (Docentes)] AS 'Fecha de la Consulta', [Tratamiento (Docentes)] AS 'Tratamiento'
		FROM TablaDocentes INNER JOIN TablaConsultasDocentes ON TablaConsultasDocentes.[CVE Docente] = TablaDocentes.[ID Docente]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasDocentes.[CVE Doctor (Docentes)]
		WHERE [CVE Doctor (Docentes)] = @Cve AND MONTH([Fecha (Docentes)]) = @Mes AND [Nombre de Docente] LIKE @Dato
	END
	ELSE IF(@TipoPaciente = 3)
	BEGIN
		SELECT [Nombre de PAE] AS 'Nombre', [CVE PAE] AS 'ID',[Genero PAE] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (PAE)] AS 'Fecha de la Consulta', [Tratamiento (PAE)] AS 'Tratamiento'
		FROM TablaPAES INNER JOIN TablaConsultasPAE ON TablaConsultasPAE.[CVE PAE] = TablaPAES.[ID PAE]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasPAE.[CVE Doctor (PAE)]
		WHERE [CVE Doctor (PAE)] = @Cve AND MONTH([Fecha (PAE)]) = @Mes AND [Nombre de PAE] LIKE @Dato
	END
	ELSE
	BEGIN
		SELECT [Nombre de Externo] AS 'Nombre', [CVE Externos] AS 'ID',[Genero E] AS 'Genero', [Nombre Doctor] AS 'Atendido Por', [Fecha (Externos)] AS 'Fecha de la Consulta', [Tratamiento (Externos)] AS 'Tratamiento'
		FROM TablaExternos INNER JOIN TablaConsultasExternos ON TablaConsultasExternos.[CVE Externos] = TablaExternos.[ID Externo]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasExternos.[CVE Doctor (Externos)]
		WHERE [CVE Doctor (Externos)] = @Cve AND MONTH([Fecha (Externos)]) = @Mes AND [Nombre de Externo] LIKE @Dato
	END
END
GO