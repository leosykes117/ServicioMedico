/*
SINTAXIS DE LOS TRIGGERS

CREATE TRIGGER (NOMBRE DEL TRIGGER)
ON (NOMBE DE LA TABLA)
FOR || AFTER || INSTEAD OFF (SENTENCIA DONDE SE EJECUTARA)
*/

USE ServicioMedico
GO

SELECT * FROM TablaRoles
SELECT * FROM TablaDoctores
SELECT * FROM TablaUsuarios

SELECT * FROM NuevosUsuarios