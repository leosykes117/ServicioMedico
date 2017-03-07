USE FlashConsultas
GO

IF OBJECT_ID('selCraerReporte') IS NOT NULL
DROP PROC selCraerReporte
GO

CREATE PROCEDURE selCraerReporte
(
@Mes INT,
@Consultorio INT,
@MasAlum INT OUTPUT,
@FemAlum INT OUTPUT,
@MasDoc INT OUTPUT,
@FemDoc INT OUTPUT,
@MasPae INT OUTPUT,
@FemPae INT OUTPUT,
@MasExt INT OUTPUT,
@FemExt INT OUTPUT
)
AS
BEGIN
	--TRAR LA SUMA DE TODOS LOS HOMBRE DE LA TABLA ALUMNOS
	SELECT @MasAlum = COUNT(TablaAlumnos.[Sexo A])
	FROM TablaConsultasAlumnos INNER JOIN TablaAlumnos ON TablaAlumnos.Boleta=TablaConsultasAlumnos.[CVE Boleta]
	WHERE MONTH([Fecha (Alumnos)])=@Mes AND [Sexo A]='Masculino' AND [CVE Doctor (Alumnos)]=@Consultorio
	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA ALUMNOS
	SELECT @FemAlum =  COUNT(TablaAlumnos.[Sexo A])
	FROM TablaConsultasAlumnos INNER JOIN TablaAlumnos ON TablaAlumnos.Boleta=TablaConsultasAlumnos.[CVE Boleta]
	WHERE MONTH([Fecha (Alumnos)])=@Mes AND [Sexo A]='Femenino' AND [CVE Doctor (Alumnos)]=@Consultorio
	
	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA DOCENTES
	SELECT @MasDoc = COUNT(TablaDocentes.[Sexo D])
	FROM TablaConsultasDocentes INNER JOIN TablaDocentes ON TablaDocentes.[ID Docente]=TablaConsultasDocentes.[CVE Docente]
	WHERE MONTH([Fecha (Docentes)])=@Mes AND [Sexo D]='Masculino' AND [CVE Doctor (Docentes)]=@Consultorio
	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA DOCENTES
	SELECT @FemDoc = COUNT(TablaDocentes.[Sexo D])
	FROM TablaConsultasDocentes INNER JOIN TablaDocentes ON TablaDocentes.[ID Docente]=TablaConsultasDocentes.[CVE Docente]
	WHERE MONTH([Fecha (Docentes)])=@Mes AND [Sexo D]='Femenino' AND [CVE Doctor (Docentes)]=@Consultorio

	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA PAES
	SELECT @MasPae = COUNT(TablaPAES.[Sexo PAE])
	FROM TablaConsultasPAE INNER JOIN TablaPAES ON TablaPAES.[ID PAE]=TablaConsultasPAE.[CVE PAE]
	WHERE MONTH([Fecha (PAE)])=@Mes AND [Sexo PAE]='Masculino' AND [CVE Doctor (PAE)]=@Consultorio
	--TRER LA SUMA DE TODAS LAS MUJERES DE LA TABLA PAES
	SELECT @FemPae = COUNT(TablaPAES.[Sexo PAE])
	FROM TablaConsultasPAE INNER JOIN TablaPAES ON TablaPAES.[ID PAE]=TablaConsultasPAE.[CVE PAE]
	WHERE MONTH([Fecha (PAE)])=@Mes AND [Sexo PAE]='Femenino' AND [CVE Doctor (PAE)]=@Consultorio

	--TRAER LA SUMA DE TODOS LOS HOMBRE DE LA TABLA EXTERNOS
	SELECT @MasExt = COUNT(TablaExternos.[Sexo E])
	FROM TablaConsultasExternos INNER JOIN TablaExternos ON TablaExternos.[ID Externo]=TablaConsultasExternos.[CVE Externos]
	WHERE MONTH([Fecha (Externos)])=@Mes AND [Sexo E]='Masculino' AND [CVE Doctor (Externos)]=@Consultorio
	--TRAER LA SUMA DE TODOS LAS MUJERES DE LA TABLA EXTERNOS
	SELECT @FemExt = COUNT(TablaExternos.[Sexo E])
	FROM TablaConsultasExternos INNER JOIN TablaExternos ON TablaExternos.[ID Externo]=TablaConsultasExternos.[CVE Externos]
	WHERE MONTH([Fecha (Externos)])=@Mes AND [Sexo E]='Femenino' AND [CVE Doctor (Externos)]=@Consultorio
END
GO



SELECT * FROM TablaConsultasAlumnos
select * from TablaAlumnos
SELECT * FROM TablaDocentes
SELECT * FROM TablaConsultasDocentes
SELECT * FROM TablaPAES
SELECT * FROM TablaConsultasPAE
SELECT * FROM TablaExternos
SELECT * FROM TablaConsultasExternos

SELECT COUNT(TablaAlumnos.[Sexo A])
FROM TablaConsultasAlumnos INNER JOIN TablaAlumnos ON TablaAlumnos.Boleta=TablaConsultasAlumnos.[CVE Boleta]
WHERE MONTH([Fecha (Alumnos)]) = 10 AND [Sexo A] = 'Masculino' AND [CVE Doctor (Alumnos)] = 501



SELECT COUNT([Sexo A]) AS 'Hombre', COUNT([Sexo A]) AS 'Mujeres' FROM TablaAlumnos
WHERE [Sexo A] = 'Masculino' AND AS 'Mujeres' = 'Femenino'


