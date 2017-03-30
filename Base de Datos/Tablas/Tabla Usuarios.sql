USE ServicioMedico
GO

IF OBJECT_ID('TablaUsuarios') IS NOT NULL
DROP TABLE TablaUsuarios
GO

CREATE TABLE TablaUsuarios
(
IdUsuariok INT PRIMARY KEY NOT NULL,
Usuario NVARCHAR(15) NOT NULL,
Contraseņa NVARCHAR(15) NOT NULL,
Correo NVARCHAR(70) NOT NULL,
Rol INT NOT NULL,
CONSTRAINT fk_UsuD FOREIGN KEY (ID) REFERENCES TablaDoctores ([ID Doctor]),
CONSTRAINT fk_UsuR FOREIGN KEY (Rol) REFERENCES TablaRoles (IDRol)
)
GO

SELECT * FROM TablaUsuarios