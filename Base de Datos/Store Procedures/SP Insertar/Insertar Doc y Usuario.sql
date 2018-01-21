USE ServicioMedico
GO

IF OBJECT_ID('insNuevoDoctor') IS NOT NULL
DROP PROCEDURE insNuevoDoctor
GO

CREATE PROC insNuevoDoctor
(
@Nombre NVARCHAR(30),
@Apellidos NVARCHAR(30),
@Genero SMALLINT,
@Responsable INT = NULL,
@Consultorio SMALLINT = NULL,
@Email NVARCHAR(100),
@Passw NVARCHAR(255),
@Rol SMALLINT,
@Mensaje NVARCHAR(4000) OUTPUT
)
AS
BEGIN
	BEGIN TRAN T_InsertarDoc
	BEGIN TRY

		DECLARE @ID AS INT
		INSERT INTO tbDoctores VALUES(@Nombre, @Apellidos, @Genero, @Responsable, @Consultorio, @Email, @Passw, @Rol, NULL, GETDATE(), NULL)
		SET @Mensaje = 'Registrado'
	COMMIT TRAN T_InsertarDoc
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN T_InsertarDoc
		DECLARE @ErrorSeverity INT, @ErrorState INT;  
		SELECT  @Mensaje = ERROR_MESSAGE(),  @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE(); 
		RAISERROR (@Mensaje, @ErrorSeverity, @ErrorState);  
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC insNuevoDoctor 'Ana Maria Martinez Arana',2,'anna211994@hotmail.com','Calzada Tlalpan Mz 15 Lt 56, Dep 105, Col Portales Del Tlapan','89759400','AMMA','anna211924',4869856,2, @Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
