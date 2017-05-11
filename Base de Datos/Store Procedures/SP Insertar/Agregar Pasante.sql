USE ServicioMedico
GO

IF OBJECT_ID('insNuevoDoctor') IS NOT NULL
DROP PROCEDURE insNuevoDoctor
GO

CREATE PROC insNuevoPasante
(
@Nombre NVARCHAR(50),
@Genero SMALLINT,
@Email NVARCHAR (70),
@Dirreccion NVARCHAR (100),
@Telefono NVARCHAR(8),
@Usuario NVARCHAR(20),
@Contraseña NVARCHAR(20),
@Doctor INT,
@Inicio DATE,
@Fin DATE,
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRAN T_InsertarPasante --CREAMOS UNA TRANSACCION YA QUE HAREMOS VARIOS INSERTS
	BEGIN TRY
		
		DECLARE @ID AS INT
		INSERT INTO TablaPersonas VALUES(@Nombre, @Genero, @Email, @Dirreccion, @Telefono) --CREA A LA PERSONA
		SET @ID = @@IDENTITY --ALMACENAMOS EL IDENTITY YA QUE LO OCUPAREMOS EN VARIAS TABLAS

		INSERT INTO TablaEmpleados VALUES(@ID, @Usuario, @Contraseña, 0, 3) --CREA A EL EMPLEADO

		INSERT INTO TablaPasantes VALUES(@ID, @Doctor, @Inicio, @Fin) --CREA A EL PASANTE

		SET @Mensaje = 'El doctor se registro correctamente'

	COMMIT TRAN T_InsertarPasante
	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.' --DECIMOS EL ERRO Y LA LINEA EN LA QUE ESTA
        Rollback TRAN T_InsertarPasante
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoPasante 'Felipe Loza Ojeda',1,'felipe@gmail.com','GSHDSGYGBBDHSGKJGSAKJDGSDUISDYEJSBDNSDSKDJSDSJD','58963800','fLozaO','lozaO46878',2,'3/04/2017','3/10/2017',@Mensaje OUTPUT
SELECT @Mensaje AS Mensaje