USE ServicioMedico
GO

IF OBJECT_ID('insNuevoMedicamento') IS NOT NULL
DROP PROC insNuevoMedicamento
GO

CREATE PROC insNuevoMedicamento
(
@Nombre NVARCHAR(50),
@Cantidad INT,
@Fecha DATE,
@Categoria SMALLINT,
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO tbMedicamentos VALUES(@Nombre, @Cantidad, @Fecha, @Categoria)
		SET @Mensaje = 'El medicamento se agrego'
	END TRY
	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMedicamento 'Paracetamol', 200, '08/05/2022', 5, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoMedicamento 'Ketorolaco', 200, '08/05/2025', 5, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

SELECT * FROM tbMedicamentos