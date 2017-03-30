USE ServicioMedico
GO

IF OBJECT_ID('updCambioContraseña') IS NOT NULL
DROP PROC updCambioContraseña
GO

CREATE PROC updCambioContraseña
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
		IF(EXISTS(SELECT Contraseña FROM TablaUsuarios WHERE ID = @ID AND Contraseña = @Actual))--VERICA QUE LA CONTRASEÑA ACTUAL DEL USUARIO SEA LA CORRECTA
		BEGIN
			IF(NOT EXISTS(SELECT Antigua FROM CambiosContraseñas WHERE ID = @ID AND Antigua = @Nueva))--VALAIDA QUE LA NUEVA CONTRASEÑA NO SE HAYA USADO ANTES
			BEGIN
				UPDATE TablaUsuarios
				SET Contraseña = @Nueva
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