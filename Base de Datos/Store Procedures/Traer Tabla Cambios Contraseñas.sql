USE ServicioMedico
GO

IF OBJECT_ID('selTablaCambiosContraseñas') IS NOT NULL
DROP PROC selTablaCambiosContraseñas
GO

CREATE PROC selTablaCambiosContraseñas
(
@ID INT
)
AS
BEGIN
	SELECT Fecha AS 'Fecha y Hora de Modificacion' FROM CambiosContraseñas
	WHERE ID = @ID
END
GO