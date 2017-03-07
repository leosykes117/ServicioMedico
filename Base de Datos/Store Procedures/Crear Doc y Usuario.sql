USE ServicioMedico
GO

IF OBJECT_ID('insNuevoDoctor') IS NOT NULL
DROP PROCEDURE insNuevoDoctor
GO

CREATE PROC insNuevoDoctor
(
@Nombre NVARCHAR(50),
@Genero NVARCHAR(9),
@Consultorio NVARCHAR(30),
@Vista SMALLINT,
@IdRetornado INT OUTPUT
)
AS
BEGIN
	INSERT INTO TablaDoctores VALUES(@Nombre, @Genero, @Consultorio, @Vista)
    DECLARE @ID AS INT
	SET @ID = (SELECT @@IDENTITY)--LA VARIABLE ID ALMACENARA EL IDENTITY

	IF(@ID > 0)--VALIDA QUE EL DOCTOR SE HAYA CREADO
	BEGIN
		SELECT @IdRetornado = @ID
	END--FIN DEL IF

	ELSE
	BEGIN
		SELECT @IdRetornado = 0
	END
END--FIN DEL AS
GO


---------------------------------------------PROCEDIIENTO ALMACENADO PARA CREAR AL USUARIO-----------------------------------------------

IF OBJECT_ID('insNuevoUsuario') IS NOT NULL
DROP PROCEDURE insNuevoUsuario
GO

CREATE PROCEDURE insNuevoUsuario
(
@ID INT,
@Usuario NVARCHAR(15),
@Contraseña NVARCHAR(15),
@Correo NVARCHAR(70),
@Contador SMALLINT OUTPUT
)
AS
BEGIN
	INSERT INTO TablaUsuarios VALUES (@ID, @Usuario, @Contraseña, @Correo)
	IF EXISTS (SELECT ID FROM TablaUsuarios WHERE ID = @ID)
	BEGIN
		SELECT @Contador = 1
	END
	ELSE
	BEGIN
		SELECT @Contador = 0
	END
END
GO