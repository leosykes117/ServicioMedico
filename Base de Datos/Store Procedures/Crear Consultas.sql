USE ServicioMedico
GO

IF OBJECT_ID('insCrearConsulta') IS NOT NULL
DROP PROC insCrearConsulta
GO

CREATE PROCEDURE insCrearConsulta
(
@Tipo INT,
@CVEPaciente BIGINT,
@CVEDoctor INT,
@Fecha DATE,
@Heridas INT,
@CeI INT,
@Tratamiento NVARCHAR(MAX)
)
AS
BEGIN
	IF @Tipo = 1 --SI EL PACIENTE ES UN ALUMNOS
	BEGIN 
		INSERT INTO TablaConsultasAlumnos VALUES(@CVEPaciente, @CVEDoctor, @Fecha, @Heridas, @CeI, @Tratamiento)
	END--FIN DE ALUMNO

	ELSE IF @Tipo = 2 --PACIENTE ES UN DOCENTE
	BEGIN 
		INSERT INTO TablaConsultasDocentes VALUES(@CVEPaciente, @CVEDoctor, @Fecha, @Heridas, @CeI, @Tratamiento)
	END--FIN DE DOCENTE

	ELSE IF @Tipo = 3 --PACIENTE ES UN PAE
	BEGIN 
		INSERT INTO TablaConsultasPAE VALUES(@CVEPaciente, @CVEDoctor, @Fecha, @Heridas, @CeI, @Tratamiento)
	END--FIN DE PAE 

	ELSE --PACIENTE ES UN EXTERNO
	BEGIN 
		INSERT INTO TablaConsultasExternos VALUES(@CVEPaciente, @CVEDoctor, @Fecha, @Heridas, @CeI, @Tratamiento)
	END--FIN DE EXTERNO
END
GO