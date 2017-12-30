/*USE ServicioMedico
GO*/
USE ServicioMedicoTest
GO

IF OBJECT_ID('TablaUsuarios') IS NOT NULL
DROP TABLE TablaUsuarios
GO

CREATE TABLE TablaUsuarios
(
IdDoctor INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombreDoctor NVARCHAR(30) NOT NULL,
ApellidosDoctor NVARCHAR(30) NOT NULL,
GeneroDoctor SMALLINT NOT NULL,
EmailDoctor NVARCHAR(100) NOT NULL,
Password_Encriptada NVARCHAR(255) NOT NULL,
Rol SMALLINT NOT NULL,
Token_Reseteo_Password NVARCHAR(6) NULL,
Creado_El DATETIME NULL,
Modificado_El DATETIME NULL,
CONSTRAINT fk_GeneroP FOREIGN KEY (GeneroDoctor) REFERENCES tbGeneros (IdGenero),
CONSTRAINT fk_RolD FOREIGN KEY(Rol) REFERENCES Roles (IdRol),
CONSTRAINT uq_email UNIQUE(EmailDoctor),
CONSTRAINT uq_token UNIQUE(Token_Reseteo_Password),
)
GO