USE ServicioMedico
GO

CREATE PROC selListadoConsultorios
AS
BEGIN
	SELECT IdConsultorio , NombreConsultorio FROM tbConsultorios
END
GO

IF OBJECT_ID('selListadoDocRegister') IS NOT NULL
	DROP PROC selListadoDocRegister
GO

CREATE PROC selListadoDocRegister
AS
BEGIN
	SELECT IdDoctor, NombreDoctor + ApellidosDoctor FROM tbDoctores
END
GO

EXEC selListadoConsultorios
EXEC selListadoDocRegister