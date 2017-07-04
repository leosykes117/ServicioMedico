USE ServicioMedico
GO

IF OBJECT_ID('selGenPacientes') IS NOT NULL
DROP PROC selGenPacientes
GO

CREATE PROC updRecuperarPaciente