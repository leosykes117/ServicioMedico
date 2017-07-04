USE ServicioMedico
GO

IF OBJECT_ID('updActualizarPersonalEscolar') IS NOT NULL
DROP PROC updActualizarPersonalEscolar
GO

CREATE PROC updActualizarPersonalEscolar
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
@NumEmpleado NVARCHAR(10) = NULL, 
@RFC NVARCHAR(15) = NULL, 
@Tipo SMALLINT,
@Mensaje NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TActualizarPersonalE
		DECLARE @TipoActual AS SMALLINT
		SET @TipoActual = (SELECT TipoPaciente FROM tbPacientes WHERE IdPaciente = @ID)--OBTENEMOS EL TIPO DE PACIENTES ACTUAL
		IF(@TipoActual = @Tipo)
		BEGIN
			UPDATE tbPersonalEscolar 
			SET Num_Personal = @NumEmpleado, RFC_Personal = @RFC
			WHERE IdPersonal = @ID

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

			SET @Mensaje = 'Personal Escolar Actualizado con Exito'
			COMMIT TRAN TActualizarPersonalE
		END

		ELSE IF(@TipoActual = 2 OR @TipoActual = 3) --SI NO SE CAMBIO A EL PACIENTE
		BEGIN
			UPDATE tbPersonalEscolar 
			SET Num_Personal = @NumEmpleado, RFC_Personal = @RFC
			WHERE IdPersonal = @ID

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

			SET @Mensaje = 'Personal Escolar Actualizado con Exito'
			COMMIT TRAN TActualizarPersonalE
		END

		ELSE IF(@TipoActual = 1)
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
				CorreoPaciente = @Correo,
				TipoPaciente = @Tipo
			WHERE IdPaciente = @ID

			INSERT INTO tbPersonalEscolar VALUES(@ID, @NumEmpleado, @RFC)

			DELETE tbAlumnos
			WHERE IdAlumno = @ID

			SET @Mensaje = 'Personal Escolar Actualizado con Exito'
			COMMIT TRAN TActualizarPersonalE
		END

		ELSE
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
				CorreoPaciente = @Correo,
				TipoPaciente = @Tipo
			WHERE IdPaciente = @ID

			INSERT INTO tbPersonalEscolar VALUES(@ID, @NumEmpleado, @RFC)

			SET @Mensaje = 'Personal Escolar Actualizado con Exito'
			COMMIT TRAN TActualizarPersonalE
		END

	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
		ROLLBACK TRAN TActualizarPersonalE
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
EXEC updActualizarPersonalEscolar 10,
						'Ariel',
						'Sanchez',
						1,
						'1975-06-17',
						41,
						null,
						'skjdhsj',
						0,
						0,
						'JSDLKADA',
						'54889',
						5,
						48,
						'5589487500',
						'69899603',
						'ariel_uami@yahoo.com.mx',
						'8529635700', 
						null,
						3,
						@Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO