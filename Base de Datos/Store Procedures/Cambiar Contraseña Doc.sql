USE FlashConsultas
GO

IF OBJECT_ID('updCambiarContraseñaDoc') IS NOT NULL
DROP PROC updCambiarContraseñaDoc
GO

CREATE PROCEDURE updCambiarContraseñaDoc
(
@Usuario INT,
@ContraseñaNueva NVARCHAR(15),
@ContraseñaActual NVARCHAR(15),
@Mensaje NVARCHAR(50) OUTPUT
)
AS
BEGIN
	IF EXISTS (SELECT * FROM TablaUsuarios WHERE Constraseña = @ContraseñaNueva)
	BEGIN
		SELECT @Mensaje = 'La Contraseña Ya Existe, Elige Otra Por Favor'
	END
	ELSE
	BEGIN
		IF EXISTS(SELECT * FROM TablaUsuarios WHERE Constraseña = @ContraseñaActual)
		BEGIN
			UPDATE TablaUsuarios
			SET Constraseña = @ContraseñaNueva
			WHERE Usuario = @Usuario AND Constraseña = @ContraseñaActual
			SELECT @Mensaje = 'La Contraseña Se Modofico'
		END
		ELSE
		BEGIN
			SELECT @Mensaje = 'La contraseña actual no existe, verificala'
		END	
	END
END
GO

CREATE PROC updContraseñaOlvidada
(
@Usuario INT,
@ContraseñaNueva NVARCHAR(15)
)
AS
BEGIN
	UPDATE TablaUsuarios
	SET Constraseña = @ContraseñaNueva
	WHERE Usuario = @Usuario
END
GO




SELECT * FROM TablaDoctores
SELECT * FROM TablaUsuarios

EXEC updCambiarContraseñaDoc 502,'12345','valepopo'