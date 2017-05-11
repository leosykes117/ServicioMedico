USE ServicioMedico
GO

IF OBJECT_ID('tbConsultas') IS NOT NULL
DROP TABLE tbConsultas
GO

CREATE TABLE tbConsultas
(
IdConsulta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
CvePaciente INT,
CveDoctor NVARCHAR(50),
Motivo NVARCHAR(30),
Diagnostico NVARCHAR(30),
Fecha DATE,
HoraEntrada TIME,
HoraSalida TIME,
CONSTRAINT fk_CvePac FOREIGN KEY (CvePaciente) REFERENCES tbPacientes (IdPaciente)
)
GO

SELECT * FROM tbConsultas

SELECT Fecha, Motivo, Diagnostico, CveDoctor FROM tbConsultas