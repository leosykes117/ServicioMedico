USE FlashConsultas
GO

IF OBJECT_ID('selBuscarCorreo') IS NOT NULL
DROP PROC selBuscarCorreo
GO

CREATE PROCEDURE selBuscarCorreo
(
@Usuario INT,
@Correo NVARCHAR(70),
@Mensaje NVARCHAR(50) OUTPUT
)
AS
BEGIN
	IF EXISTS(SELECT * FROM TablaUsuarios WHERE Usuario = @Usuario AND Correo = @Correo)
	BEGIN
		SELECT @Mensaje = [Nombre Doctor]  FROM TablaDoctores WHERE [ID Doctor] = @Usuario
	END
	ELSE
	BEGIN
		SELECT @Mensaje = 'Verifica que el usuario y correo sean correctos'
	END
END
GO

EXEC selBuscarCorreo 501, 'leonoble-sk8@hotmail.com'