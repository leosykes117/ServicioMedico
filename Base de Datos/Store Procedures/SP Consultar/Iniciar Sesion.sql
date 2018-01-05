USE ServicioMedicoTest
GO

IF OBJECT_ID('selIniciarSesion') IS NOT NULL
DROP PROC selIniciarSesion
GO

CREATE PROCEDURE selIniciarSesion
(
@Email NVARCHAR(30),
@Password NVARCHAR(30)
)
AS
BEGIN
	BEGIN TRY
		SELECT IdDoctor, NombreDoctor, ApellidosDoctor, GeneroDoctor, EmailDoctor, Rol FROM TablaUsuarios WHERE (EmailDoctor = @Email AND Password_Encriptada = @Password);
	END TRY
	BEGIN CATCH
		DECLARE @Mensaje NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;  
		SELECT  @Mensaje = ERROR_MESSAGE(),  @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE(); 
		RAISERROR (@Mensaje, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO

EXEC selIniciarSesion 'leo.aremtz98@gmail.com','Sticky.Mine.Spartan117'
GO