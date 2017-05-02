USE ServicioMedico
GO

IF OBJECT_ID('NuevosUsuarios') IS NOT NULL
DROP TABLE NuevosUsuarios
GO

CREATE TABLE NuevosUsuarios
(
NombreEmpleadp NVARCHAR(50),
IdEmpleado INT,
Fecha_Hora DATETIME,
Descripcion NVARCHAR(40)
)
GO

SELECT * FROM NuevosUsuarios