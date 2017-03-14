USE ServicioMedico
GO

IF OBJECT_ID('TR_NuevoUsuario_Insert') IS NOT NULL
DROP TRIGGER TR_NuevoUsuario_Insert
GO

CREATE TRIGGER TR_NuevoUsuario_Insert
ON TablaUsuarios
FOR INSERT
AS
BEGIN
	DECLARE @Nombre AS NVARCHAR(50)
	DECLARE @ID AS INT
	DECLARE @Fecha DATETIME
	
	SET @Nombre = (SELECT TOP(1) [Nombre Doctor] FROM TablaDoctores ORDER BY [ID Doctor] DESC)
	SET @ID = (SELECT TOP(1) [ID Doctor] FROM TablaDoctores ORDER BY [ID Doctor] DESC)
	SET @Fecha = (SELECT GETDATE())

	IF((SELECT Rol FROM TablaUsuarios WHERE ID = @ID) = 1)
	BEGIN 
		INSERT INTO NuevosUsuarios VALUES(@Nombre, @ID, @Fecha,'SE AGREGO UN ADMINISTRADOR')
	END
	ELSE
	BEGIN
		INSERT INTO NuevosUsuarios VALUES(@Nombre, @ID, @Fecha,'SE AGREGO UN USUARIO')
	END
END
GO