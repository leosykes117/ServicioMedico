USE ServicioMedico
GO

IF OBJECT_ID('TR_CambioContraseņa_update') IS NOT NULL
DROP TRIGGER TR_CambioContraseņa_update
GO

CREATE TRIGGER TR_CambioContraseņa_update
ON TablaUsuarios
FOR UPDATE
AS
BEGIN
	DECLARE @ID AS INT
	DECLARE @Antigua AS NVARCHAR(15)
	DECLARE @Nueva AS NVARCHAR(15)
	DECLARE @Nombre AS NVARCHAR(15)
	DECLARE @Rol AS INT

	SET @ID = (SELECT ID FROM inserted)
	SET @Antigua = (SELECT Contraseņa FROM deleted)
	SET @Nueva = (SELECT Contraseņa FROM inserted)
	SET @Nombre = (SELECT [Nombre Doctor] FROM TablaDoctores WHERE [ID Doctor] = @ID)
	SET @Rol = (SELECT Rol FROM TablaUsuarios WHERE ID = @ID)

	IF (@Rol = 1)
	BEGIN
		INSERT INTO CambiosContraseņas VALUES(@ID, @Nombre, @Antigua, @Nueva, GETDATE(),'ADMINISTRADOR')
	END
	ELSE
	BEGIN
		INSERT INTO CambiosContraseņas VALUES(@ID, @Nombre, @Antigua, @Nueva, GETDATE(),'Usuario')
	END
END
GO