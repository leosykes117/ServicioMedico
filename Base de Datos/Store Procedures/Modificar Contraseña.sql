USE ServicioMedico
GO

IF OBJECT_ID('updCambioContrase�a') IS NOT NULL
DROP PROC updCambioContrase�a
GO

CREATE PROC updCambioContrase�a
(
@ID INT,
@Actual NVARCHAR(15),
@Nueva NVARCHAR(15),
@Correo NVARCHAR(70) OUTPUT,
@Nombre NVARCHAR(50) OUTPUT
)
AS 
BEGIN
	IF(@Nueva = @Actual)
	BEGIN
		SELECT @Correo = 'Repetida'
	END
	ELSE
	BEGIN
		IF(EXISTS(SELECT Contrase�a FROM TablaUsuarios WHERE ID = @ID AND Contrase�a = @Actual))--VERICA QUE LA CONTRASE�A ACTUAL DEL USUARIO SEA LA CORRECTA
		BEGIN
			IF(NOT EXISTS(SELECT Antigua FROM CambiosContrase�as WHERE ID = @ID AND Antigua = @Nueva))--VALAIDA QUE LA NUEVA CONTRASE�A NO SE HAYA USADO ANTES
			BEGIN
				UPDATE TablaUsuarios
				SET Contrase�a = @Nueva
				WHERE ID = @ID
				SELECT @Correo = (SELECT Correo FROM TablaUsuarios WHERE ID = @ID)
				SELECT @Nombre = (SELECT [Nombre Doctor] FROM TablaDoctores WHERE [ID Doctor] = @ID)
			END
			ELSE
			BEGIN
				SELECT @Correo = 'Repetida'
			END
		END
		ELSE
		BEGIN
			SELECT @Correo = 'No se pudo'
		END
	END
END
GO