USE ServicioMedico
GO

IF OBJECT_ID('R_DoctorBorrado_Insert') IS NOT NULL
DROP TRIGGER R_DoctorBorrado_Insert
GO

CREATE TRIGGER TR_DoctorBorrado_Insert
ON TablaDoctores, TablaUsuarios
FOR DROP
AS
BEGIN
	
END
GO