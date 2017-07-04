USE ServicioMedico
GO

IF OBJECT_ID('selListadoMotivos') IS NOT NULL
DROP PROC selListadoMotivos
GO

CREATE PROC selListadoMotivos
AS
BEGIN
	SELECT IdMotivo AS 'CveMot', DescripcionMotivo AS 'Motivo' FROM tbMotivosConsultas
END
GO

EXEC selListadoMotivos