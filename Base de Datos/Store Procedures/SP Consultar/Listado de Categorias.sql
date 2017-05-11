USE ServicioMedico
GO

IF OBJECT_ID('selListadoCategorias') IS NOT NULL
DROP PROC selListadoCategorias
GO

CREATE PROC selListadoCategorias
AS
BEGIN
	SELECT IdCategoria AS 'Clave', DescripcionCategoria AS 'Nombre' FROM tbCategorias
END
GO

EXEC selListadoCategorias