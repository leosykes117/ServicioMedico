USE ServicioMedico
GO

IF OBJECT_ID('tbRoles') IS NOT NULL
DROP TABLE tbRoles
GO

CREATE TABLE tbRoles
(
IdRol SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Roles NVARCHAR(13)
)
GO

INSERT INTO tbRoles
VALUES
('Administrador'),
('Doctor'),
('Pasante')
GO

SELECT * FROM tbRoles
GO

------------------------TABLA CONSULTORIOS---------------------------
IF OBJECT_ID('tbConsultorios') IS NOT NULL
DROP TABLE tbConsultorios
GO

CREATE TABLE tbConsultorios
(
IdConsultorio SMALLINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombreConsultorio NVARCHAR(30)
)
GO

INSERT INTO tbConsultorios
VALUES
('Medicina General Matutino'),
('Medicina General Vespertino'),
('Odontología'),
('Nutrición'),
('Optometría')

SELECT * FROM tbConsultorios