USE ServicioMedico
GO

IF OBJECT_ID('updModificarDoc') IS NOT NULL
DROP PROC updModificarDoc
GO

CREATE PROC updModificarDoc
(
@ID INT,
@Nombre NVARCHAR(50),
@Genero NVARCHAR(9),
@Consultorio NVARCHAR(30),
@Usuario NVARCHAR(15),
@Antigu_Usuario NVARCHAR(15),
@Correo NVARCHAR(70),
@Mensaje SMALLINT OUTPUT
)
AS
BEGIN
	IF(@Usuario = @Antigu_Usuario)
	BEGIN
		UPDATE TablaDoctores 
		SET [Nombre Doctor] = @Nombre, Genero = @Genero, Consultorio = @Consultorio
		WHERE [ID Doctor] = @ID

		UPDATE TablaUsuarios
		SET Correo = @Correo
		WHERE ID = @ID
		SELECT @Mensaje = 1
	END
	ELSE
	BEGIN
		IF(NOT EXISTS(SELECT Usuario FROM TablaUsuarios WHERE Usuario = @Usuario))
		BEGIN
			UPDATE TablaDoctores 
			SET [Nombre Doctor] = @Nombre, Genero = @Genero, Consultorio = @Consultorio
			WHERE [ID Doctor] = @ID

			UPDATE TablaUsuarios
			SET Correo = @Correo, Usuario = @Usuario
			WHERE ID = @ID
			SELECT @Mensaje = 1
		END
		ELSE
			SELECT @Mensaje = 0
	END
END
GO

EXEC updModificarDoc 502,'Leo','M','Vespertino','mayaArellano','leosykes117','leo.aremtz98@gmail.com',0

/*IF(@Usuario = @Antigu_Usuario)
	BEGIN
		PRINT 'MODIFICA'
	END
	ELSE
	BEGIN
		IF(NOT EXISTS(SELECT Usuario FROM TablaUsuarios WHERE Usuario = @Usuario))
			PRINT 'MODIFICA'
		ELSE
			PRINT 'NO MODIFICA'
	END*/