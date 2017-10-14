USE ServicioMedico
GO

IF OBJECT_ID('insNuevaCategoria') IS NOT NULL
DROP PROC insNuevaCategoria
GO

CREATE PROC insNuevaCategoria
(
@Descripcion NVARCHAR(30),
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO tbCategorias VALUES (@Descripcion)
		SET @Mensaje = 'La categoria fue creada'
	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevaCategoria 'Antibióticos', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevaCategoria 'Antiinflamatorios', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevaCategoria 'Antiácidos', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevaCategoria 'Antisépticos', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevaCategoria 'Laxantes', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevaCategoria 'Analgésicos', @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

SELECT * FROM tbCategorias