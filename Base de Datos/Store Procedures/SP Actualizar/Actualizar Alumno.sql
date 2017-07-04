USE ServicioMedico
GO

IF OBJECT_ID('updActualizarAlumno') IS NOT NULL
DROP PROC updActualizarAlumno
GO

CREATE PROC updActualizarAlumno
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
@Boleta NVARCHAR(10), 
@Grupo NVARCHAR(5), 
@Carrera SMALLINT,
@Tipo SMALLINT,
@Mensaje AS NVARCHAR(100) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TActualizarAlumno
		DECLARE @TipoActual AS SMALLINT
		SET @TipoActual = (SELECT TipoPaciente FROM tbPacientes WHERE IdPaciente = @ID)--OBTENEMOS EL TIPO DE PACIENTES ACTUAL

		IF(@TipoActual = @Tipo)--SI LOS TIPOS DE PACIENTES SON IGUALES
		BEGIN
			UPDATE tbAlumnos
			SET Boleta = @Boleta, Grupo = @Grupo, Carrera = @Carrera
			WHERE IdAlumno = @ID

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
			SET @Mensaje = 'Alumno Actualizado con Exito'
			COMMIT TRAN TActualizarAlumno
		END

		ELSE--SI NO SON IGUALES SE CAMBIARA EL TIPO DE PACIENTE
		BEGIN

			IF (@TipoActual = 2 OR @TipoActual = 3)--CAMBIAR EL PACIENTE DE DOCENTE O PAAE A ALUMNO
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

				INSERT INTO tbAlumnos VALUES (@ID, @Boleta, @Grupo, @Carrera)

				DELETE tbPersonalEscolar
				WHERE IdPersonal = @ID

				SET @Mensaje = 'Alumno Actualizado con Exito'
				COMMIT TRAN TActualizarAlumno
			END

			ELSE --CAMBIAR EL PACIENTE DE EXTERNO A ALUMNO
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

				INSERT INTO tbAlumnos VALUES (@ID, @Boleta, @Grupo, @Carrera)

				SET @Mensaje = 'Alumno Actualizado con Exito'
				COMMIT TRAN TActualizarAlumno
			END
		END
	END TRY--FIN DEL TRY

	BEGIN CATCH--INICIA CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
		ROLLBACK TRAN TActualizarAlumno
	END CATCH
END
GO


DECLARE @Mensaje AS NVARCHAR(100)
EXEC updActualizarAlumno 2,
						'Juan Diego',
						'Rodriguez Gonzalez',
						1,
						'1997-09-29',
						19,
						'ROGJ970929HDFNPP85',
						'La Gioconda',
						0,
						45,
						'Jarros',
						'89685',
						4,
						1,
						'5506748529',
						'75931468',
						'juandieguito@hotmail.com',
						'2014131109', 
						'6IV4', 
						2,
						1,
						@Mensaje OUTPUT
SELECT @Mensaje AS Mensaje
GO

--2014131109

SELECT * FROM tbPacientes
SELECT * FROM tbAlumnos
SELECT * FROM tbPersonalEscolar