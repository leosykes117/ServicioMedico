USE ServicioMedico
GO

IF OBJECT_ID('insAgregarExterno') IS NOT NULL
DROP PROC insAgregarExterno
GO

CREATE PROC insAgregarExterno
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
@Mensaje NVARCHAR(100) OUTPUT,
@Retornado INT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		DECLARE @ID AS INT

		BEGIN TRAN TInsExterno
			INSERT INTO tbPacientes 
			VALUES (@Nombre, @Apellidos, @Genero, @Fecha, @Edad, @CURP, @Calle, @Int, @Ext, @Colonia, @CP, @Mun, @Estado, @Celular, @Telefono, @Correo, 4)
			SET @Mensaje = 'Registrado'
			SET @Retornado = @@IDENTITY
		COMMIT TRAN TInsExterno

	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
		ROLLBACK TRAN TInsExterno
	END CATCH
END
GO