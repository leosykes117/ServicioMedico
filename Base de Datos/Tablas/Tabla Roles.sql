USE ServicioMedico
GO

IF OBJECT_ID('TablaRoles') IS NOT NULL
DROP TABLE TablaRoles
GO

CREATE TABLE TablaRoles
(
IDRol SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Roles NVARCHAR(13)
)
GO

INSERT INTO TablaRoles
VALUES
('Administrador'),
('Doctor'),
('Pasante')

SELECT * FROM TablaRoles
GO

------------------------TABLA CONSULTORIOS---------------------------
IF OBJECT_ID('TablaConsultorios') IS NOT NULL
DROP TABLE TablaConsultorios
GO

CREATE TABLE TablaConsultorios
(
IDConsultorio SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombreConsultorio NVARCHAR(30)
)
GO

INSERT INTO TablaConsultorios
VALUES
('Medicina General Matutino'),
('Medicina General Vespertino'),
('Odontología'),
('Nutrición'),
('Optometría')

SELECT * FROM TablaConsultorios