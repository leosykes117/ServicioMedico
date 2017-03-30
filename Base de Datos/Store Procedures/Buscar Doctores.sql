USE ServicioMedico
GO

IF OBJECT_ID('selBusGenDoc') IS NOT NULL
DROP PROC selBusGenDoc
GO

CREATE PROCEDURE selBusGenDoc
AS
BEGIN
	SELECT [ID Doctor] AS 'ID', [Nombre Doctor] AS 'Nombre', Genero, Consultorio, Usuario, Correo FROM TablaDoctores INNER JOIN TablaUsuarios ON TablaUsuarios.ID = TablaDoctores.[ID Doctor]
	WHERE Rol <> 1
END
GO

EXEC selBusGenDoc