USE ServicioMedico
GO

IF OBJECT_ID('insNuevoEmpleado') IS NOT NULL
DROP PROCEDURE insNuevoEmpleado
GO

CREATE PROC insNuevoEmpleado
(
@Nombre NVARCHAR(50),
@Genero SMALLINT,
@Email NVARCHAR (70),
@Dirreccion NVARCHAR (100),
@Telefono NVARCHAR(8),
@Usuario NVARCHAR(20),
@Contraseña NVARCHAR(20),
@Rol SMALLINT,
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRAN T_InsertarEmpleado --CREAMOS UNA TRANSACCION YA QUE HAREMOS VARIOS INSERTS
	BEGIN TRY
		
		INSERT INTO TablaPersonas VALUES(@Nombre, @Genero, @Email, @Dirreccion, @Telefono) --CREA A LA PERSONA
		
		INSERT INTO TablaEmpleados VALUES(@@IDENTITY, @Usuario, @Contraseña, 0, @Rol) --CREA A EL EMPLEADO

		SET @Mensaje = 'El empleado se registro correctamente'

	COMMIT TRAN T_InsertarEmpleado
	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.' --DECIMOS EL ERRO Y LA LINEA EN LA QUE ESTA
        Rollback TRAN T_InsertarEmpleado
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoEmpleado 'Lidia Mungia',2,'lidia@gmail.com','Av Ermita, Mz 21, Lt 5, Col Flores, Del Miguel Hidalgo','98762543','SMC13','sismicecyt13',1, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje