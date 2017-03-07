USE ServicioMedico
GO

IF OBJECT_ID('selBusGenDoc') IS NOT NULL
DROP PROC selBusGenDoc
GO

CREATE PROCEDURE selBusGenDoc
AS
BEGIN
	SELECT ID,[Nombre Doctor], Usuario, Consultorio, Correo,Contraseña 
	FROM TablaDoctores INNER JOIN TablaUsuarios ON TablaUsuarios.ID = TablaDoctores.[ID Doctor]
	WHERE ID <> 501
END
GO

	IF EXISTS (SELECT [ID Doctor] FROM TablaDoctores WHERE [Nombre Doctor] LIKE '%leo%')
	BEGIN
		SELECT ID,[Nombre Doctor], Usuario, Consultorio, Correo,Contraseña 
		FROM TablaDoctores INNER JOIN TablaUsuarios ON TablaUsuarios.ID = TablaDoctores.[ID Doctor]
		WHERE ID = 502
	END
	ELSE
	BEGIN
		SELECT 'No se encontro nada'
	END

