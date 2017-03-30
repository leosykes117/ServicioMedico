USE ServicioMedico
GO

IF OBJECT_ID('selTablaNuevosUsuarios') IS NOT NULL
DROP PROC selTablaNuevosUsuarios
GO

CREATE PROC selTablaNuevosUsuarios
AS
BEGIN
	SELECT NombreDoc AS 'Nombre del Doctor', IdDoc AS 'Clave del Doctor', Fecha_Hora AS 'Fecha y Hora de Inserción', Descripcion FROM NuevosUsuarios
	WHERE IdDoc <> 501
END
GO