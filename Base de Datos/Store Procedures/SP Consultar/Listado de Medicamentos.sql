USE ServicioMedico
GO

IF OBJECT_ID('selListadoMedicamentos') IS NOT NULL
DROP PROC selListadoMedicamentos
GO

CREATE PROC selListadoMedicamentos
AS
BEGIN
	SELECT IdMedicamento AS 'Clave', NombreMedicamento AS 'Nombre' FROM tbMedicamentos
END
GO

EXEC selListadoMedicamentos
