USE ServicioMedico
GO

IF OBJECT_ID('selIniciarSesion') IS NOT NULL
DROP PROC selIniciarSesion
GO

CREATE PROCEDURE selIniciarSesion
(
@Usuario NVARCHAR(15),
@Contraseña NVARCHAR(15),
@Logueo INT OUTPUT,
@Mensaje NVARCHAR(70) OUTPUT
)
AS
BEGIN
	SELECT @Logueo = ID FROM TablaUsuarios --BUSCO A EL USUARIO Y EL RESULTADO LO AMACENO EN @LOGEO
	WHERE Usuario = @Usuario and Contraseña = @Contraseña

	IF(@Logueo > 0) 
	BEGIN
		
		IF(@Logueo = 501)
		BEGIN
			SELECT @Mensaje = '1'
		END
		ELSE
		BEGIN
			DECLARE @GENERO AS NVARCHAR(9)
			SET @GENERO = (SELECT Genero FROM TablaDoctores WHERE [ID Doctor] = @Logueo)
			IF(@GENERO = 'Masculino')
			BEGIN
				SELECT @Mensaje = 'BIENVENIDO ' + UPPER(d.[Nombre Doctor]) FROM TablaDoctores d 
				WHERE [ID Doctor] = @Logueo
			END
			ELSE
			BEGIN
				SELECT @Mensaje = 'BIENVENIDA ' + UPPER(d.[Nombre Doctor]) FROM TablaDoctores d 
				WHERE [ID Doctor] = @Logueo
			END
		END
	END
	ELSE
	BEGIN
		SELECT @Mensaje = 'NO EXISTE'
	END
END
GO