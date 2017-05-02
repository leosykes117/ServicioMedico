USE ServicioMedico
GO

IF OBJECT_ID('insAgregarPacientes') IS NOT NULL
DROP PROC insAgregarPacientes
GO

CREATE PROCEDURE insAgregarPacientes
(
@Nombre NVARCHAR(20),
@Apellidos NVARCHAR(20),
@Genero SMALLINT,
@Edad SMALLINT,
@Tipo SMALLINT,
@Mensaje NVARCHAR(100) OUTPUT,
@Retornado BIGINT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO tbPacientes VALUES (@Nombre, @Apellidos, @Genero, @Edad, @Tipo)
			SET @Mensaje = 'Registrado'
			SET @Retornado = @@IDENTITY
	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
	END CATCH
END--FIN DEL AS
GO


DECLARE @Mensaje AS NVARCHAR(100)
DECLARE @Retornado AS INT
EXEC insAgregarPacientes 'Ariel','Sanchez Rodriguez',1,40,2,@Mensaje OUTPUT, @Retornado OUTPUT
SELECT @Mensaje AS Mensaje, @Retornado AS Retornado