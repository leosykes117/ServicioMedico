USE ServicioMedico
GO

IF OBJECT_ID('TablaPersonas') IS NOT NULL
DROP TABLE TablaPersonas
GO

CREATE TABLE TablaPersonas
(
IDPersona INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Nombre NVARCHAR(50) NOT NULL,
Genero SMALLINT NOT NULL,
Email NVARCHAR(70) UNIQUE NOT NULL,
Direccion NVARCHAR(100) NOT NULL,
Telefono NVARCHAR(8) NOT NULL,
CONSTRAINT fk_GeneroPersona FOREIGN KEY (Genero) REFERENCES TablaGeneros (IdGenero)
)
GO