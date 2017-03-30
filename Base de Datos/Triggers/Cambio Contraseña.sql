USE ServicioMedico
GO

IF OBJECT_ID('TR_CambioContrase�a_update') IS NOT NULL
DROP TRIGGER TR_CambioContrase�a_update
GO

CREATE TRIGGER TR_CambioContrase�a_update
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
	SET @Antigua = (SELECT Contrase�a FROM deleted)
	SET @Nueva = (SELECT Contrase�a FROM inserted)
	SET @Nombre = (SELECT [Nombre Doctor] FROM TablaDoctores WHERE [ID Doctor] = @ID)
	SET @Rol = (SELECT Rol FROM TablaUsuarios WHERE ID = @ID)

	IF (@Rol = 1)
	BEGIN
		INSERT INTO CambiosContrase�as VALUES(@ID, @Nombre, @Antigua, @Nueva, GETDATE(),'ADMINISTRADOR')
	END
	ELSE
	BEGIN
		INSERT INTO CambiosContrase�as VALUES(@ID, @Nombre, @Antigua, @Nueva, GETDATE(),'Usuario')
	END
END
GO