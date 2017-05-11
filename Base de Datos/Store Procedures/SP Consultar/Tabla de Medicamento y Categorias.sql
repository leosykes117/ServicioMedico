USE ServicioMedico
GO

IF OBJECT_ID('selBusquedaMedCat') IS NOT NULL
DROP PROC selBusquedaMedCat
GO

CREATE PROC selBusquedaMedCat
AS
BEGIN
	SELECT NombreMedicamento AS 'Medicamento', Cantidad AS 'Cantidad', FechaCaducidad, DescripcionCategoria 
	FROM tbMedicamentos INNER JOIN tbCategorias ON tbMedicamentos.Categoria = tbCategorias.IdCategoria
END
GO


EXEC selBusquedaMedCat