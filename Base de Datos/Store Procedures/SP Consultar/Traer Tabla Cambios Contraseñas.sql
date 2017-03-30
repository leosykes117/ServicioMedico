USE ServicioMedico
GO

IF OBJECT_ID('selTablaCambiosContraseņas') IS NOT NULL
DROP PROC selTablaCambiosContraseņas
GO

CREATE PROC selTablaCambiosContraseņas
(
@ID INT
)
AS
BEGIN
	SELECT Fecha AS 'Fecha y Hora de Modificacion' FROM CambiosContraseņas
	WHERE ID = @ID
END
GO