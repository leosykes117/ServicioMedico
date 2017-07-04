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
Diagnostico NVARCHAR(MAX),
CveMotivo SMALLINT,
CveMedicamento INT,
CantidadSuminstrada INT,
FechaConsulta DATE NOT NULL,
HoraEntrada TIME NOT NULL,
HoraSalida TIME NOT NULL,
DuracionConsulta TIME NOT NULL,
EstatusConsulta SMALLINT NOT NULL
CONSTRAINT fk_CvePac FOREIGN KEY (CvePaciente) REFERENCES tbPacientes (IdPaciente),
CONSTRAINT fk_CveMot FOREIGN KEY (CveMotivo) REFERENCES tbMotivosConsultas(IdMotivo),
CONSTRAINT fk_CveMed FOREIGN KEY (CveMedicamento) REFERENCES tbMedicamentos (IdMedicamento)
)
GO

SELECT * FROM tbConsultas

SELECT Fecha, Motivo, Diagnostico, CveDoctor FROM tbConsultas
GO