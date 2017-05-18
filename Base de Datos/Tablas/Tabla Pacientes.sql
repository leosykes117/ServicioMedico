USE ServicioMedico
GO

IF OBJECT_ID('tbPacientes') IS NOT NULL
DROP TABLE tbPacientes
GO

CREATE TABLE tbPacientes
(
IdPaciente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombrePaciente NVARCHAR(20) NOT NULL,
ApellidosPaciente NVARCHAR(20) NOT NULL,
GeneroPaciente SMALLINT NOT NULL,
FechaNac DATE NOT NULL,
EdadPaciente SMALLINT NOT NULL,
CURP NVARCHAR(18),
Calle NVARCHAR(100),
Num_Int INT,
Num_Ext INT,
Colonia NVARCHAR(100),
CP NVARCHAR(5),
id_Del_Mun INT,
id_Edo INT,
Celular NVARCHAR(15),
Tel_Part NVARCHAR(15),
CorreoPaciente NVARCHAR(70),
--FOTO IMAGE NULL,
TipoPaciente SMALLINT NOT NULL,

CONSTRAINT fk_GeneroP FOREIGN KEY (GeneroPaciente) REFERENCES tbGeneros (IdGenero),
CONSTRAINT fk_TipoP FOREIGN KEY (TipoPaciente) REFERENCES tbTiposPacientes (IdTipo),
CONSTRAINT uq_CURP UNIQUE(CURP),
CONSTRAINT uq_Correo UNIQUE(CorreoPaciente)
)

GO