USE ServicioMedico
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
@Nombre NVARCHAR(50),
@Genero SMALLINT,
@Email NVARCHAR (70),
@Dirreccion NVARCHAR (100),
@Telefono NVARCHAR(8),
@Usuario NVARCHAR(20),
@Contraseña NVARCHAR(20),
@Cedula INT,
@Consultorio SMALLINT,
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRAN T_InsertarDoc --CREAMOS UNA TRANSACCION YA QUE HAREMOS VARIOS INSERTS
	BEGIN TRY
		
		DECLARE @ID AS INT
		INSERT INTO TablaPersonas VALUES(@Nombre, @Genero, @Email, @Dirreccion, @Telefono) --CREA A LA PERSONA
		SET @ID = @@IDENTITY --ALMACENAMOS EL IDENTITY YA QUE LO OCUPAREMOS EN VARIAS TABLAS

		INSERT INTO TablaEmpleados VALUES(@ID, @Usuario, @Contraseña, 0, 2) --CREA A EL EMPLEADO

		INSERT INTO TablaDoctores VALUES(@ID, @Cedula, @Consultorio) --CREA A EL DOCTOR

		SET @Mensaje = 'El doctor se registro correctamente'

	COMMIT TRAN T_InsertarDoc
	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.' --DECIMOS EL ERRO Y LA LINEA EN LA QUE ESTA
        Rollback TRAN T_InsertarDoc
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoDoctor 'Ana Maria Martinez Arana',2,'anna211994@hotmail.com','Calzada Tlalpan Mz 15 Lt 56, Dep 105, Col Portales Del Tlapan','89759400','AMMA','anna211924',4869856,2, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
