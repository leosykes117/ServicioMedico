USE ServicioMedico
GO

IF OBJECT_ID('tbConsultas') IS NOT NULL
DROP TABLE tbConsultas
GO

CREATE TABLE tbConsultas
(
IdConsulta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
CvePaciente INT NOT NULL,
CveDoctor NVARCHAR(50) NOT NULL,
Diagnostico NVARCHAR(MAX) NULL,
Observaciones NVARCHAR(MAX) NULL,
FechaConsulta DATE NOT NULL,
HoraEntrada TIME NOT NULL,
HoraSalida TIME NOT NULL,
DuracionConsulta TIME NOT NULL,
EstatusConsulta SMALLINT NOT NULL,
Temperatura DECIMAL(4,2) NULL,
TA NVARCHAR(8) NULL,
FC DECIMAL(6,3) NULL,
FR DECIMAL(6,3) NULL
CONSTRAINT fk_CvePac FOREIGN KEY (CvePaciente) REFERENCES tbPacientes (IdPaciente)
)
GO

SELECT * FROM tbConsultas

SELECT Fecha, Motivo, Diagnostico, CveDoctor FROM tbConsultas
GO