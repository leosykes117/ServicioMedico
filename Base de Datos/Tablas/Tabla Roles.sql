USE ServicioMedico
GO

IF OBJECT_ID('TablaRoles') IS NOT NULL
DROP TABLE TablaRoles
GO

CREATE TABLE TablaRoles
(
IDRol INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Rol NVARCHAR(13)
)
GO

INSERT INTO TablaRoles
VALUES
('Administrador'),
('Usuario')

SELECT * FROM TablaRoles
GO