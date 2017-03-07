USE ServicioMedico
GO

IF OBJECT_ID('insAgregarPacientes') IS NOT NULL
DROP PROC insAgregarPacientes
GO

CREATE PROCEDURE insAgregarPacientes
(
@Tipo int,
@Nombre NVARCHAR(60),
@Sexo NVARCHAR(9)
)
AS
BEGIN
	IF @Tipo=1 --AGREGAR DATOS DEL DOCENTE
	BEGIN
		INSERT INTO	TablaDocentes VALUES(@Nombre,@Sexo)
	END --FIN DE DOCENTE

	ELSE IF @Tipo=2--AGREGRA DATOS DE PAE
	BEGIN
		INSERT INTO	TablaPAES VALUES(@Nombre,@Sexo)
	END--FIN DEL PAE

	ELSE--AGREGAR DATOS EXTERNO
	BEGIN
		INSERT INTO	TablaExternos VALUES(@Nombre,@Sexo)
	END--FIN EXTERNOS
END--FIN DEL AS
GO

EXEC insAgregarPacientes 1,'Adrian Rodolfo Villalba Lemus','Masculino'
EXEC insAgregarPacientes 1,'Alfredo Campos Guerrero','Masculino'
EXEC insAgregarPacientes 2,'Alan Brito Delgado','Masculino'
EXEC insAgregarPacientes 3,'Marcela Mrtinez Alvarado','Femenino'

SELECT * FROM TablaDocentes
SELECT * FROM TablaConsultasDocentes
SELECT * FROM TablaPAES
SELECT * FROM TablaConsultasPAE
SELECT * FROM TablaExternos
SELECT * FROM TablaConsultasExternos