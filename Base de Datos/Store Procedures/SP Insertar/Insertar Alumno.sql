USE ServicioMedico
GO

IF OBJECT_ID('insAgregarAlumno') IS NOT NULL
DROP PROC insAgregarAlumno
GO

CREATE PROCEDURE insAgregarAlumno
(
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
@Mensaje AS NVARCHAR(100) OUTPUT,
@Retornado INT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN TInsAlumno
			DECLARE @ID AS INT
			INSERT INTO tbPacientes 
			VALUES (@Nombre, @Apellidos, @Genero, @Fecha, @Edad, @CURP, @Calle, @Int, @Ext, @Colonia, @CP, @Mun, @Estado, @Celular, @Telefono, @Correo, 1, 1)
			SET @ID = @@IDENTITY
			INSERT INTO tbAlumnos VALUES (@ID, @Boleta, @Grupo, @Carrera)
			SET @Mensaje = 'Registrado'
			SET @Retornado = @ID
		COMMIT TRAN TInsAlumno
	END TRY

	BEGIN CATCH
		SET @Mensaje = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' de tipo ' + CONVERT(NVARCHAR(50), ERROR_NUMBER()) + '.'
        ROLLBACK TRAN TInsAlumno
	END CATCH
END
GO

DECLARE @Mensaje AS NVARCHAR(100)
DECLARE @Retornado AS INT
EXEC insAgregarAlumno 'Dayanary Veronica', 'Cervantes Sanchez',2,'1998-12-17',18,'CESD161298MDFRNN09','HKSJHKSJAS',NULL,15,'Tezonco','89632',2,4,'5570804374','58963625','day_cervates@gmail.com','2014130125','6IV6',2,@Mensaje OUTPUT, @Retornado OUTPUT
SELECT @Mensaje AS Mensaje, @Retornado AS Retornado
GO

DECLARE @Mensaje AS NVARCHAR(100)
DECLARE @Retornado AS INT
EXEC insAgregarAlumno 'Roberto Antonio','Trejo Valle',1,19, 'robert.antony1998@gmail.com', '2014135120','5IV4',2,@Mensaje OUTPUT, @Retornado OUTPUT
SELECT @Mensaje AS Mensaje, @Retornado AS Retornado
GO

SELECT * FROM tbPacientes