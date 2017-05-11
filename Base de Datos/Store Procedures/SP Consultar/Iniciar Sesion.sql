USE ServicioMedico
GO

IF OBJECT_ID('selIniciarSesion') IS NOT NULL
DROP PROC selIniciarSesion
GO

CREATE PROCEDURE selIniciarSesion
(
@Usuario NVARCHAR(15),
@Contraseña NVARCHAR(15),
@IDRetornado INT OUTPUT,
@MensajeRol SMALLINT OUTPUT,
@Mensaje NVARCHAR(90) OUTPUT
)
AS
BEGIN

	SELECT @IDRetornado = IdUsuario FROM TablaUsuarios WHERE Usuario = @Usuario and Contraseña = @Contraseña --BUSCO A EL USUARIO Y EL RESULTADO LO AMACENO EN @IDRetornado

	IF(@IDRetornado > 0) 
	BEGIN
		DECLARE @Rol AS INT
		DECLARE @GENERO AS NVARCHAR(9)
		SET @Rol = (SELECT Rol FROM TablaUsuarios WHERE IdUsuario = @IDRetornado )
		IF(@Rol = 1)
		BEGIN
			SET @GENERO = (SELECT Genero FROM TablaDoctores WHERE [ID Doctor] = @IDRetornado)
			IF (@GENERO = 'Masculino')
			BEGIN 
				SELECT @Mensaje = 'BIENVENIDO ADMNISTRADOR ' + UPPER(d.[Nombre Doctor]) FROM TablaDoctores d WHERE [ID Doctor] = @IDRetornado
				SELECT @MensajeRol = 1
			END
			ELSE
			BEGIN
				SELECT @Mensaje = 'BIENVENIDA ADMNISTRADORA ' + UPPER(d.[Nombre Doctor]) FROM TablaDoctores d WHERE [ID Doctor] = @IDRetornado
				SELECT @MensajeRol = 1
			END
		END
		ELSE
		BEGIN
			SET @GENERO = (SELECT Genero FROM TablaDoctores WHERE [ID Doctor] = @IDRetornado)
			IF(@GENERO = 'Masculino')
			BEGIN
				SELECT @Mensaje = 'BIENVENIDO DOCTOR ' + UPPER(d.[Nombre Doctor]) FROM TablaDoctores d WHERE [ID Doctor] = @IDRetornado
				SELECT @MensajeRol = 2
			END
			ELSE
			BEGIN
				SELECT @Mensaje = 'BIENVENIDA DOCTORA ' + UPPER(d.[Nombre Doctor]) FROM TablaDoctores d WHERE [ID Doctor] = @IDRetornado
				SELECT @MensajeRol = 2
			END
		END
	END
	ELSE
	BEGIN
		SELECT @Mensaje = 'NO EXISTE'
		SELECT @MensajeRol = 0
	END
END
GO