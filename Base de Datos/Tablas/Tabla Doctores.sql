USE ServicioMedico
GO

IF OBJECT_ID('TablaDoctores') IS NOT NULL
DROP TABLE TablaDoctores
GO

CREATE TABLE TablaDoctores
(
[ID Doctor] INT PRIMARY KEY NOT NULL,
[Nombre Doctor] NVARCHAR(50) NOT NULL,
Genero NVARCHAR(9) NOT NULL, 
Consultorio INT NOT NULL,
VistaReporte SMALLINT NOT NULL,
CONSTRAINT fk_UsuD FOREIGN KEY ([ID Doctor]) REFERENCES TablaUsuarios (IdUsuario) ON DELETE CASCADE,
CONSTRAINT fk_ConsDoc FOREIGN KEY (Consultorio) REFERENCES TablaConsultorios (IDConsultorio)
)
GO

--CONSTRAINT fk_UsuD FOREIGN KEY (ID) REFERENCES TablaDoctores ([ID Doctor]),


/*-----------------------------------------TABLA DOCTORES Y PASANTES DE PRUEBA-------------------------------------------------*/
IF OBJECT_ID('TablaDoctores') IS NOT NULL
DROP TABLE TablaDoctores
GO

CREATE TABLE TablaDoctores
(
[Cve Persona (Doctor)] INT PRIMARY KEY NOT NULL,
Cedula INT NOT NULL,
Consultorio SMALLINT NOT NULL,
CONSTRAINT fk_PerDoctor FOREIGN KEY ([Cve Persona (Doctor)]) REFERENCES TablaEmpleados ([Cve Persona (Empleados)]) ON DELETE CASCADE,
CONSTRAINT fk_ConDoctor FOREIGN KEY (Consultorio) REFERENCES TablaConsultorios (IDConsultorio)
)
GO

----------------------------------------------------------------
IF OBJECT_ID('TablaPasantes') IS NOT NULL
DROP TABLE TablaPasantes
GO

CREATE TABLE TablaPasantes
(
[Cve Persona (Pasante)] INT PRIMARY KEY NOT NULL,
[CveDoctor] INT NOT NULL,
FechaInicio DATE NOT NULL,
FechaFinal DATE NOT NULL,
CONSTRAINT fk_PerPasante FOREIGN KEY ([Cve Persona (Pasante)]) REFERENCES TablaEmpleados ([Cve Persona (Empleados)]) ON DELETE CASCADE,
CONSTRAINT fk_DocPasante FOREIGN KEY ([CveDoctor]) REFERENCES TablaDoctores ([Cve Persona (Doctor)])
)
GO
