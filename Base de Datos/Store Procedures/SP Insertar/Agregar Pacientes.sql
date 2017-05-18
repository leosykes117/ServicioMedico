USE ServicioMedico
GO

IF OBJECT_ID('insAgregarPersonalEscolar') IS NOT NULL
DROP PROC insAgregarPersonalEscolar
GO

CREATE PROCEDURE insAgregarPersonalEscolar
(
@Nombre NVARCHAR(20),
@Apellidos NVARCHAR(20),
@Genero SMALLINT,
@Fecha DATE,
@Edad SMALLINT,
@CURP NVARCHAR(18) = NULL,
@Calle NVARCHAR(100) = NULL,
@Int INT = NULL,
@Ext INT = NULL,
@Colonia NVARCHAR(100) = NULL,
@CP NVARCHAR(5) = NULL,
@Mun INT = NULL,
@Estado INT = NULL,
@Celular NVARCHAR(15) = NULL,
@Telefono NVARCHAR(15) =  NULL,
@Correo NVARCHAR(70) = NULL,
@Tipo SMALLINT,
@NumEmpleado NVARCHAR(10) = NULL, 
@RFC NVARCHAR(15) = NULL, 
@Mensaje NVARCHAR(100) OUTPUT,
@Retornado INT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		DECLARE @ID AS INT
		IF(@Tipo = 2)
		BEGIN
		BEGIN TRAN TInsPersonal
			INSERT INTO tbPacientes 
			VALUES (@Nombre, @Apellidos, @Genero, @Fecha, @Edad, @CURP, @Calle, @Int, @Ext, @Colonia, @CP, @Mun, @Estado, @Celular, @Telefono, @Correo, @Tipo)
			SET @ID = @@IDENTITY
			INSERT INTO tbDocentes VALUES (@ID, @NumEmpleado, @RFC)
			SET @Mensaje = 'Registrado'
			SET @Retornado = @ID
		COMMIT TRAN TInsPersonal
		END

		ELSE
		BEGIN
		BEGIN TRAN TInsPersonal
			INSERT INTO tbPacientes 
			VALUES (@Nombre, @Apellidos, @Genero, @Fecha, @Edad, @CURP, @Calle, @Int, @Ext, @Colonia, @CP, @Mun, @Estado, @Celular, @Telefono, @Correo, @Tipo)
			SET @ID = @@IDENTITY
			INSERT INTO tbPAAES VALUES (@ID, @NumEmpleado, @RFC)
			SET @Mensaje = 'Registrado'
			SET @Retornado = @ID
		COMMIT TRAN TInsPersonal
		END

	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
		ROLLBACK TRAN TInsPersonal
	END CATCH
END--FIN DEL AS
GO


DECLARE @Mensaje AS NVARCHAR(100)
DECLARE @Retornado AS INT
EXEC insAgregarPersonalEscolar'Ariel', 'Sanchez Rodriguez',1,'1975-12-14',42,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'5589632578','95623486','ariel_uami@yahoo.com.mx',2,'5465479',NULL,@Mensaje OUTPUT, @Retornado OUTPUT
SELECT @Mensaje AS Mensaje, @Retornado AS Retornado
GO

DECLARE @Mensaje AS NVARCHAR(100)
DECLARE @Retornado AS INT
EXEC insAgregarPersonalEscolar'Martin', 'Romero Ugalde',1,'1974-06-12',42,null,1,4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'romwro',2,'4565120636','ROUM740612S74',@Mensaje OUTPUT, @Retornado OUTPUT
SELECT @Mensaje AS Mensaje, @Retornado AS Retornado
GO

SELECT * FROM tbPacientes

SELECT * FROM tbDocentes