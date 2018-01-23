USE ServicioMedico
GO

IF OBJECT_ID('selReporte') IS NOT NULL
DROP PROC selReporte
GO

CREATE PROC selReporte
@Mes INT,
@YEAR INT,
@Doc INT
AS
BEGIN
	SELECT HombresA, MujeresA, HombresD, MujeresD, HombresP, MujeresP, HombresE, MujeresE, SubtotalH, SubtotalM, Total FROM tbReportes
	WHERE FechaReporte = CONVERT(date, CONCAT(@YEAR, '/', @Mes, '/', 1)) AND Pertenece = @Doc
END
GO

EXEC selReporte 1, 2018, 4

SELECT * FROM tbReportes