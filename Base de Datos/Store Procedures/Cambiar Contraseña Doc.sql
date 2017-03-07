USE FlashConsultas
GO

IF OBJECT_ID('updCambiarContrase�aDoc') IS NOT NULL
DROP PROC updCambiarContrase�aDoc
GO

CREATE PROCEDURE updCambiarContrase�aDoc
(
@Usuario INT,
@Contrase�aNueva NVARCHAR(15),
@Contrase�aActual NVARCHAR(15),
@Mensaje NVARCHAR(50) OUTPUT
)
AS
BEGIN
	IF EXISTS (SELECT * FROM TablaUsuarios WHERE Constrase�a = @Contrase�aNueva)
	BEGIN
		SELECT @Mensaje = 'La Contrase�a Ya Existe, Elige Otra Por Favor'
	END
	ELSE
	BEGIN
		IF EXISTS(SELECT * FROM TablaUsuarios WHERE Constrase�a = @Contrase�aActual)
		BEGIN
			UPDATE TablaUsuarios
			SET Constrase�a = @Contrase�aNueva
			WHERE Usuario = @Usuario AND Constrase�a = @Contrase�aActual
			SELECT @Mensaje = 'La Contrase�a Se Modofico'
		END
		ELSE
		BEGIN
			SELECT @Mensaje = 'La contrase�a actual no existe, verificala'
		END	
	END
END
GO

CREATE PROC updContrase�aOlvidada
(
@Usuario INT,
@Contrase�aNueva NVARCHAR(15)
)
AS
BEGIN
	UPDATE TablaUsuarios
	SET Constrase�a = @Contrase�aNueva
	WHERE Usuario = @Usuario
END
GO




SELECT * FROM TablaDoctores
SELECT * FROM TablaUsuarios

EXEC updCambiarContrase�aDoc 502,'12345','valepopo'