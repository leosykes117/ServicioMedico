USE ServicioMedico
GO

IF OBJECT_ID('tbDetallesConsultas') IS NOT NULL
DROP TABLE tbDetallesConsultas
GO

CREATE TABLE tbDetallesConsultas
(
IdDetalleConsulta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
CveConsulta INT,
CveMotivo SMALLINT,
CveMedicamento INT,
CantidadSuminstrada INT,
CONSTRAINT fk_CveConsulta FOREIGN KEY (CveConsulta) REFERENCES tbConsultas (IdConsulta) ,
CONSTRAINT fk_CveMot FOREIGN KEY (CveMotivo) REFERENCES tbMotivosConsultas(IdMotivo),
CONSTRAINT fk_CveMed FOREIGN KEY (CveMedicamento) REFERENCES tbMedicamentos (IdMedicamento)
)
GO

SELECT * FROM tbDetallesConsultas

1 2
2 2 
3 8
4 12