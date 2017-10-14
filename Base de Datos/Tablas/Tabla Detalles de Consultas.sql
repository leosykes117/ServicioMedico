USE ServicioMedico
GO

IF OBJECT_ID('tbMotivosConsultas') IS NOT NULL
DROP TABLE tbMotivosConsultas
GO

CREATE TABLE tbMotivosConsultas
(
CveConsulta INT NOT NULL,
CveMotivo SMALLINT NOT NULL,
PRIMARY KEY (CveConsulta, CveMotivo),
CONSTRAINT fk_CveConsulta FOREIGN KEY (CveConsulta) REFERENCES tbConsultas (IdConsulta),
CONSTRAINT fk_CveMot FOREIGN KEY (CveMotivo) REFERENCES tbMotivos(IdMotivo)
)
GO


SELECT * FROM tbMotivosConsultas GO

--TABLA DE MEDICAMENTO-CONSULTAS
IF OBJECT_ID('tbMedicamentosConsultas') IS NOT NULL
DROP TABLE tbMedicamentosConsultas
GO

CREATE TABLE tbMedicamentosConsultas
(
CveConsulta INT NOT NULL,
CveMedicamento NVARCHAR(100) NOT NULL,
CantidadSuministrada INT,
Prescripcion NVARCHAR(100) NULL
PRIMARY KEY (CveConsulta, CveMedicamento),
CONSTRAINT fk_CveConsulta_Medicamento FOREIGN KEY (CveConsulta) REFERENCES tbConsultas (IdConsulta)
--CONSTRAINT fk_CveMed FOREIGN KEY (CveMedicamento) REFERENCES tbMedicamentos(IdMedicamento)
)
GO

SELECT * FROM tbMedicamentosConsultas GO