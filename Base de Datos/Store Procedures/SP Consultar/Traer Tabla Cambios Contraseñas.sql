USE ServicioMedico
GO

IF OBJECT_ID('selTablaCambiosContrase�as') IS NOT NULL
DROP PROC selTablaCambiosContrase�as
GO

CREATE PROC selTablaCambiosContrase�as
(
@ID INT
)
AS
BEGIN
	SELECT Fecha AS 'Fecha y Hora de Modificacion' FROM CambiosContrase�as
	WHERE ID = @ID
END
GO