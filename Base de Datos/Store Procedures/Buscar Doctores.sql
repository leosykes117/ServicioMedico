USE ServicioMedico
GO

IF OBJECT_ID('selBusGenDoc') IS NOT NULL
DROP PROC selBusGenDoc
GO

CREATE PROCEDURE selBusGenDoc
AS
BEGIN
	SELECT [ID Doctor] AS 'ID', [Nombre Doctor] AS 'Nombre', Genero, Consultorio, Usuario, Correo FROM TablaDoctores INNER JOIN TablaUsuarios ON TablaUsuarios.ID = TablaDoctores.[ID Doctor]
	WHERE Rol <> 1
END
GO

CREATE PROCEDURE selBusGenDoc
(
@Rol SMALLINT
)
AS
BEGIN
	IF(@Rol = 1)
	BEGIN
		SELECT IDPersona, Nombre, Generos, Email, Direccion, Telefono, Usuario, Contraseña
		FROM TablaGeneros INNER JOIN TablaPersonas ON TablaGeneros.IdGenero = TablaPersonas.Genero
		INNER JOIN TablaEmpleados ON TablaPersonas.IDPersona = TablaEmpleados.[Cve Persona (Empleados)]
		INNER JOIN TablaRoles ON TablaEmpleados.Rol = TablaRoles.IDRol
		WHERE Rol = 1
	END

	ELSE IF (@Rol = 2)
	BEGIN
		SELECT IDPersona, Nombre, Genero, Email, Direccion, Telefono, Usuario, Contraseña
		FROM TablaGeneros INNER JOIN TablaPersonas ON TablaGeneros.IdGenero = TablaPersonas.Genero
		INNER JOIN TablaEmpleados ON TablaPersonas.IDPersona = TablaEmpleados.[Cve Persona (Empleados)]
		INNER JOIN TablaRoles ON TablaEmpleados.Rol = TablaRoles.IDRol
		INNER JOIN TablaDoctores ON TablaEmpleados.[Cve Persona (Empleados)] = TablaDoctores.[Cve Persona (Doctor)]
		--WHERE Rol = 2
	END

	ELSE
	BEGIN
		SELECT IDPersona, Nombre, Genero, Email, Direccion, Telefono, Usuario, Contraseña,[Cve Persona (Doctor)], FechaInicio, FechaFinal, Consultorio
		FROM TablaPasantes INNER JOIN TablaDoctores ON TablaPasantes.CveDoctor = TablaDoctores.[Cve Persona (Doctor)]
		INNER JOIN TablaEmpleados ON TablaPasantes.[Cve Persona (Pasante)] = TablaEmpleados.[Cve Persona (Empleados)]
		INNER JOIN TablaPersonas ON TablaEmpleados.[Cve Persona (Empleados)] = TablaPersonas.IDPersona
		WHERE Rol = 3
	END
END
GO


EXEC selBusGenDoc
