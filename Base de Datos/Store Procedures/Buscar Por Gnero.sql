USE FlashConsultas
GO

IF OBJECT_ID('selBuscarPorGenero') IS NOT NULL
DROP PROC selBuscarPorGenero
GO

CREATE PROCEDURE selBuscarPorGenero
(
@TipoPaciente INT,
@Genero NVARCHAR(9),
@Cve INT
)
AS
BEGIN
	IF(@TipoPaciente = 1)
	BEGIN
		SELECT [Nombre del Alumno], [CVE Boleta] AS 'Boleta', [Sexo A], Carrera, Grupo, [Nombre Doctor] AS 'Atendido Por', [Fecha (Alumnos)] AS 'Fecha de la Consulta',[Tratamiento (Alumnos)]
		FROM TablaAlumnos INNER JOIN TablaConsultasAlumnos ON TablaConsultasAlumnos.[CVE Boleta] = TablaAlumnos.Boleta
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasAlumnos.[CVE Doctor (Alumnos)]
		WHERE [Sexo A] = @Genero AND [CVE Doctor (Alumnos)] = @Cve
	END
	ELSE IF(@TipoPaciente = 2)
	BEGIN
		SELECT [Nombre de Docente], [CVE Docente], [Sexo D], [Nombre Doctor], [Fecha (Docentes)], [Tratamiento (Docentes)]
		FROM TablaDocentes INNER JOIN TablaConsultasDocentes ON TablaConsultasDocentes.[CVE Docente] = TablaDocentes.[ID Docente]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasDocentes.[CVE Doctor (Docentes)]
		WHERE [Sexo D] = @Genero AND [CVE Doctor (Docentes)] = @Cve
	END
	ELSE IF(@TipoPaciente = 3)
	BEGIN
		SELECT [Nombre del PAE], [CVE PAE],[Sexo PAE], [Nombre Doctor], [Fecha (PAE)], [Tratamiento (PAE)]
		FROM TablaPAES INNER JOIN TablaConsultasPAE ON TablaConsultasPAE.[CVE PAE] = TablaPAES.[ID PAE]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasPAE.[CVE Doctor (PAE)]
		WHERE [Sexo PAE] = @Genero AND [CVE Doctor (PAE)] = @Cve
	END
	ELSE
	BEGIN
		SELECT [Nombre de Externo], [CVE Externos],[Sexo E], [Nombre Doctor], [Fecha (Externos)], [Tratamiento (Externos)]
		FROM TablaExternos INNER JOIN TablaConsultasExternos ON TablaConsultasExternos.[CVE Externos] = TablaExternos.[ID Externo]
		INNER JOIN TablaDoctores ON TablaDoctores.[ID Doctor] = TablaConsultasExternos.[CVE Doctor (Externos)]
		WHERE [Sexo E] = @Genero AND [CVE Doctor (Externos)] = @Cve
	END
END
GO

EXEC selBuscarPorGenero 1,'Masculino',501