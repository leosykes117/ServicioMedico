USE ServicioMedicoTest
GO

IF OBJECT_ID('insNuevoDoctor') IS NOT NULL
DROP PROCEDURE insNuevoDoctor
GO

CREATE PROC insNuevoUsuario
(
@Tipo SMALLINT,
@Nombre NVARCHAR(50),
@Usuario NVARCHAR(15),
@Genero NVARCHAR(9),
@Consultorio NVARCHAR(30),
@Correo NVARCHAR(70),
@Contraseña NVARCHAR(15),
@Rol INT,
@IdRetornado INT OUTPUT
)
AS
BEGIN
	IF(NOT EXISTS(SELECT Usuario FROM TablaUsuarios WHERE Usuario = @Usuario) AND NOT EXISTS(SELECT Usuario FROM TablaUsuarios WHERE Usuario = @Usuario))
	BEGIN
		INSERT INTO TablaDoctores VALUES(@Nombre, @Genero, @Consultorio, 0)

		DECLARE @ID AS INT
		SET @ID = (SELECT @@IDENTITY)--LA VARIABLE ID ALMACENARA EL IDENTITY

		IF(@ID > 0)--VALIDA QUE EL DOCTOR SE HAYA CREADO
		BEGIN
			INSERT INTO TablaUsuarios VALUES (@ID, @Usuario, @Contraseña, @Correo, @Rol)

			IF EXISTS (SELECT IdUsuario FROM TablaUsuarios WHERE IdUsuario = @ID)--VERIFICA QUE LE USUARIO SE HAYA AGREGADO CORRECTAMENTE
			BEGIN
				SELECT @IdRetornado = @ID --REGRESA UN 1 SI ASI ES
			END
			ELSE
			BEGIN
				SELECT @IdRetornado = 0
			END

		END--FIN DEL IF

		ELSE
		BEGIN
			SELECT @IdRetornado = 0
		END--FIN DEL ELSE
	END
	ELSE
	BEGIN
		SELECT @IdRetornado = 0
	END

END--FIN DEL AS
GO

 /*STORED PROCEDURE DE PRUEBA*/
IF OBJECT_ID('insNuevoDoctor') IS NOT NULL
DROP PROCEDURE insNuevoDoctor
GO

CREATE PROC insNuevoDoctor
(
@Nombre NVARCHAR(30),
@Apellidos NVARCHAR(30),
@Genero SMALLINT,
@Email NVARCHAR(100),
@Passw NVARCHAR(255),
@Rol SMALLINT,
@Mensaje NVARCHAR(4000) OUTPUT
)
AS
BEGIN
	BEGIN TRAN T_InsertarDoc
	BEGIN TRY

		DECLARE @ID AS INT
		INSERT INTO TablaUsuarios VALUES(@Nombre, @Apellidos, @Genero, @Email, @Passw, @Rol, NULL, GETDATE(), NULL)
		SET @Mensaje = 'Registrado'
	COMMIT TRAN T_InsertarDoc
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN T_InsertarDoc
		DECLARE @ErrorSeverity INT, @ErrorState INT;  
		SELECT  @Mensaje = ERROR_MESSAGE(),  @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE(); 
		RAISERROR (@Mensaje, @ErrorSeverity, @ErrorState);  
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoDoctor 'Ana Maria Martinez Arana',2,'anna211994@hotmail.com','Calzada Tlalpan Mz 15 Lt 56, Dep 105, Col Portales Del Tlapan','89759400','AMMA','anna211924',4869856,2, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
