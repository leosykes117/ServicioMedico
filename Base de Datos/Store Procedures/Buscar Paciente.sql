USE FlashConsultas
GO

IF OBJECT_ID('selBuscarPaciente') IS NOT NULL
DROP PROC selBuscarPaciente
GO

CREATE PROCEDURE selBuscarPaciente
(
@Tipo INT,
@Nombre NVARCHAR(70),
@Sexo NVARCHAR(9),
@Contador INT OUTPUT,
@Mensaje NVARCHAR(10) OUTPUT,
@Cve BIGINT OUTPUT,
@Nom NVARCHAR(70) OUTPUT
)
AS
BEGIN
	IF @Tipo = 1 --PACIENTE ES UN DOCENTE
	BEGIN 
		SELECT @Contador = COUNT(d.[ID Docente]) FROM TablaDocentes d  --BUSCAMOS AL DOCENTE POR NOMBRE 
		WHERE [Nombre de Docente] = @Nombre AND [Sexo D] = @Sexo							

		IF @Contador > 0 --SI EL DOCENTE EXISTE
		BEGIN
			SELECT @Mensaje = 'EXISTE', @Cve = (d.[ID Docente]), @Nom = (d.[Nombre de Docente]) FROM TablaDocentes d
			WHERE [Nombre de Docente] = @Nombre AND [Sexo D] = @Sexo
		END

		ELSE
		BEGIN
			SELECT @Mensaje = 'NO EXISTE' --SI NO EXISTE SE EJECUTA EL SP DE CREAR PACIENTE
		END
	END--FIN DE DOCENTE


	ELSE IF @Tipo = 2
	BEGIN 
		SELECT @Contador = COUNT(p.[ID PAE]) FROM TablaPAES p  --BUSCAMOS AL PAE POR NOMBRE
		WHERE [Nombre del PAE] = @Nombre AND [Sexo PAE] = @Sexo									

		IF @Contador > 0 --SI EL PAE EXISTE
		BEGIN
			SELECT @Mensaje = 'EXISTE', @Cve=(p.[ID PAE]), @Nom = (p.[Nombre del PAE]) FROM TablaPAES p
			WHERE [Nombre del PAE] = @Nombre AND [Sexo PAE] = @Sexo	
		END

		ELSE
		BEGIN
			SELECT @Mensaje = 'NO EXISTE' --SI NO EXISTE SE EJECUTA EL SP DE AGREGRA PACIENTE
		END
	END--FIN DE PAE 


	ELSE
	BEGIN 
		SELECT @Contador = COUNT(e.[ID Externo]) FROM TablaExternos e  --BUSCAMOS AL ALUMNO 
		WHERE [Nombre de Externo] = @Nombre	AND [Sexo E] = @Sexo		--POR LA BOLETA

		IF @Contador > 0 --SI EL ALUMNO EXISTE
		BEGIN
			SELECT @Mensaje = 'EXISTE', @Cve=(e.[ID Externo]), @Nom = (e.[Nombre de Externo]) FROM TablaExternos e
			WHERE [Nombre de Externo] = @Nombre AND[Sexo E] = @Sexo
		END

		ELSE
		BEGIN
			SELECT @Mensaje = 'NO EXISTE' --SI NO EXISTE SE EJECUTA EL SP DE CREAR ALUMNO
		END
	END--FIN DE PACIENTE 
END
GO



SELECT * FROM TablaAlumnos

SELECT * FROM TablaDocentes

SELECT * FROM TablaPAES

SELECT * FROM TablaExternos

