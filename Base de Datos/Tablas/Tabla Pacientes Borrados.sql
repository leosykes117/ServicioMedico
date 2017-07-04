USE ServicioMedico
GO

IF OBJECT_ID('tbPacientesEliminados') IS NOT NULL
DROP TABLE tbPacientesEliminados
GO

CREATE TABLE tbPacientesEliminados
(
Nombre_B NVARCHAR(20),
Apellidos_B NVARCHAR(20),
Genero_B SMALLINT,
FechaNac_B DATE,
Edad_B SMALLINT,
CURP_B NVARCHAR(18),
Calle_B NVARCHAR(100),
NumInt_B INT,
NumExt_B INT,
Col_B NVARCHAR(100),
CP_B NVARCHAR(5),
Mun_B INT,
Estado_B INT,
Cel_B NVARCHAR(15),
Tel_B NVARCHAR(15),
Correo_B NVARCHAR(70),
TipoPac_B SMALLINT,
RFC_B NVARCHAR(15),
Boleta_o_Num NVARCHAR(10),
Grupo_B NVARCHAR(5),
Carrera_B SMALLINT,
FechaEliminacion DATETIME
)
GO