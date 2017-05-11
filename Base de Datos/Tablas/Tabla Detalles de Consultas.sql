USE ServicioMedico
GO

IF OBJECT_ID('tbDetallesConsultas') IS NOT NULL
DROP TABLE tbDetallesConsultas
GO

CREATE TABLE tbDetallesConsultas
(
IdDetalleConsulta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
CveConsulta INT,
Tratamiento INT,
CantidadSuminstrada INT,
CONSTRAINT fk_CveConsulta FOREIGN KEY (CveConsulta) REFERENCES tbConsultas (IdConsulta),
CONSTRAINT fk_CveMed FOREIGN KEY (Tratamiento) REFERENCES tbMedicamentos (IdMedicamento)
)
GO

SELECT * FROM tbDetallesConsultas