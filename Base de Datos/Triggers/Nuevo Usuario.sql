USE ServicioMedico
GO

IF OBJECT_ID('TR_NuevoUsuario_Insert') IS NOT NULL
DROP TRIGGER TR_NuevoUsuario_Insert
GO

CREATE TRIGGER TR_NuevoUsuario_Insert  /*TRIGGER PARA REGISTRAR CUANDO SE AREGE UN USUARIO*/
ON TablaEmpleados
FOR INSERT
AS
BEGIN
	DECLARE @ID AS INT
	DECLARE @Rol AS INT
	
	SET @ID = (SELECT [Cve Persona (Empleados)] FROM inserted)--Guardamos el id y el rol del empleado que se aacaba de insertar
	SET @Rol = (SELECT Rol FROM inserted)

	DECLARE @Nombre AS NVARCHAR(50)
	
	IF(@Rol = 1)
	BEGIN
		SET @Nombre = (SELECT Nombre  FROM TablaPersonas WHERE IDPersona = @ID) --Almacenamos el nombre de la persona que corresponde con el id de quien se inserto
		INSERT INTO NuevosUsuarios VALUES(@Nombre, @ID, GETDATE(),'SE AGREGO UN ADMINISTRADOR')
	END

	ELSE IF (@Rol = 2)
	BEGIN
		SET @Nombre = (SELECT Nombre FROM TablaPersonas WHERE IDPersona = @ID)
		INSERT INTO NuevosUsuarios VALUES(@Nombre, @ID, GETDATE(),'SE AGREGO UN DOCTOR')
	END

	ELSE
	BEGIN
		SET @Nombre = (SELECT Nombre FROM TablaPersonas WHERE IDPersona = @ID)
		INSERT INTO NuevosUsuarios VALUES(@Nombre, @ID, GETDATE(),'SE AGREGO UN PASANTE')
	END
END
GO


/*
SET @ID = (SELECT IdUsuario FROM inserted)--Guardamos el id y el rol del empleado que se aacaba de insertar
SET @Rol = (SELECT Rol FROM inserted)
SET @Nombre = (SELECT [Nombre Doctor] FROM TablaDoctores WHERE [ID Doctor] = @ID)
INSERT INTO NuevosUsuarios VALUES(@Nombre, @ID, GETDATE(),'SE AGREGO UN DOCTOR')
*/