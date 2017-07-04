USE ServicioMedico
GO

IF OBJECT_ID('insNuevoMotivo') IS NOT NULL
DROP PROC insNuevoMotivo
GO

CREATE PROC insNuevoMotivo
(
@Descripcion NVARCHAR(30),
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO tbMotivosConsultas VALUES (@Descripcion)
		SET @Mensaje = 'El motivo fue creado'
	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Consulta', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Preservativos', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Vendajes', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Férula', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Toma de T.A', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Curacion', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Inyección', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Retiro de Dispositivos', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Sutura', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMotivo 'Retiro de Puntos', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO


SELECT * FROM tbMotivosConsultas