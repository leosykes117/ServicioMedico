USE ServicioMedico
GO

IF OBJECT_ID('updActualizarExternos') IS NOT NULL
DROP PROC updActualizarExternos
GO

CREATE PROC updActualizarExternos
(
@ID INT,
@Nombre NVARCHAR(20),
@Apellidos NVARCHAR(20),
@Genero SMALLINT,
@Fecha DATE,
@Edad SMALLINT,
@CURP NVARCHAR(18) = NULL,
@Calle NVARCHAR(100) = NULL,
@Int INT = NULL,
@Ext INT = NULL,
@Colonia NVARCHAR(100) = NULL,
@CP NVARCHAR(5) = NULL,
@Mun INT = NULL,
@Estado INT = NULL,
@Celular NVARCHAR(15) = NULL,
@Telefono NVARCHAR(15) =  NULL,
@Correo NVARCHAR(70) = NULL,
@Tipo SMALLINT,
@Mensaje AS NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TActualizarExterno
		DECLARE @TipoActual AS SMALLINT
		SET @TipoActual = (SELECT TipoPaciente FROM tbPacientes WHERE IdPaciente = @ID)--OBTENEMOS EL TIPO DE PACIENTES ACTUAL

		IF (@TipoActual = @Tipo)--SI EL TIPO QUE LLEGA ES IGUAL A EL TIPO ACTUAL (@TIPO = 4)
		BEGIN

			UPDATE tbPacientes
			SET NombrePaciente = @Nombre, 
				ApellidosPaciente = @Apellidos, 
				GeneroPaciente = @Genero, 
				FechaNac=@Fecha, 
				EdadPaciente = @Edad, 
				CURP = @CURP, 
				Calle = @Calle, 
				Num_Int = @Int,
				Num_Ext = @Ext,
				Colonia = @Colonia,
				CP = @CP,
				DelMun = @Mun,
				Estado = @Estado,
				Celular = @Celular,
				Tel_Part = @Telefono,
				CorreoPaciente = @Correo
			WHERE IdPaciente = @ID
			SET @Mensaje = 'Paciente Externo Actualizado con Exito'
			COMMIT TRAN TActualizarExterno 

		END

		ELSE IF(@TipoActual = 1)--SI EL TIPO ACTUAL ES UN ALUMNO (@IPO = 1)
		BEGIN

			UPDATE tbPacientes --ACTULIZAMOS LOS DATOS Y EL PACIENTE LO MOVEMOS DE ALUMNOS A EXTERNOS
			SET NombrePaciente = @Nombre, 
				ApellidosPaciente = @Apellidos, 
				GeneroPaciente = @Genero, 
				FechaNac=@Fecha, 
				EdadPaciente = @Edad, 
				CURP = @CURP, 
				Calle = @Calle, 
				Num_Int = @Int,
				Num_Ext = @Ext,
				Colonia = @Colonia,
				CP = @CP,
				DelMun = @Mun,
				Estado = @Estado,
				Celular = @Celular,
				Tel_Part = @Telefono,
				CorreoPaciente = @Correo,
				TipoPaciente = @Tipo
			WHERE IdPaciente = @ID

			DELETE tbAlumnos
			WHERE IdAlumno = @ID

			SET @Mensaje = 'Paciente Externo Actualizado con Exito'
			COMMIT TRAN TActualizarExterno

		END

		ELSE--SI EL TIPO ACTUAL ES UN DOCENTE O UN PAAE (@TIPO=2 Ó @TIPO = 3)
		BEGIN
			--ACTULIZAMOS LOS DATOS Y EL PACIENTE LO MOVEMOS DE PERSONA ESCOLAR A EXTERNOS
			UPDATE tbPacientes 
			SET NombrePaciente = @Nombre, 
				ApellidosPaciente = @Apellidos, 
				GeneroPaciente = @Genero, 
				FechaNac=@Fecha, 
				EdadPaciente = @Edad, 
				CURP = @CURP, 
				Calle = @Calle, 
				Num_Int = @Int,
				Num_Ext = @Ext,
				Colonia = @Colonia,
				CP = @CP,
				DelMun = @Mun,
				Estado = @Estado,
				Celular = @Celular,
				Tel_Part = @Telefono,
				CorreoPaciente = @Correo,
				TipoPaciente = @Tipo
			WHERE IdPaciente = @ID

			DELETE tbPersonalEscolar
			WHERE IdPersonal = @ID

			SET @Mensaje = 'Paciente Externo Actualizado con Exito'
			COMMIT TRAN TActualizarExterno

		END

	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
		ROLLBACK TRAN TActualizarExterno
	END CATCH
END
GO