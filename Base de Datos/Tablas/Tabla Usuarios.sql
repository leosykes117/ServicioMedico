USE ServicioMedico
GO
/*USE ServicioMedicoTest
GO*/

IF OBJECT_ID('TablaUsuarios') IS NOT NULL
DROP TABLE TablaUsuarios
GO

CREATE TABLE tbDoctores
(
IdDoctor INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombreDoctor NVARCHAR(30) NOT NULL,
ApellidosDoctor NVARCHAR(30) NOT NULL,
GeneroDoctor SMALLINT NOT NULL,
Responsable INT NULL,
Consultorio SMALLINT NULL,
EmailDoctor NVARCHAR(100) NOT NULL,
Password_Encriptada NVARCHAR(255) NOT NULL,
Rol SMALLINT NOT NULL,
Token_Reseteo_Password NVARCHAR(6) NULL,
Creado_El DATETIME NULL,
Modificado_El DATETIME NULL,
CONSTRAINT fk_GnrDoc FOREIGN KEY (GeneroDoctor) REFERENCES tbGeneros (IdGenero),
CONSTRAINT fk_DocMgr FOREIGN KEY (Responsable) REFERENCES tbDoctores (IdDoctor),
CONSTRAINT fk_Consul FOREIGN KEY (Consultorio) REFERENCES tbConsultorios (IdConsultorio),
CONSTRAINT fk_RolD FOREIGN KEY(Rol) REFERENCES tbRoles (IdRol),
CONSTRAINT uq_email UNIQUE(EmailDoctor)
)
GO