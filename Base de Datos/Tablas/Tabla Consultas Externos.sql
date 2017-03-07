USE ServicioMedico
GO

IF OBJECT_ID('TablaConsultasExternos') IS NOT NULL
DROP TABLE TablaConsultasExternos
GO

CREATE TABLE TablaConsultasExternos
(
[ID Consulta (Externos)] INT IDENTITY(1,1) PRIMARY KEY,
[CVE Externos] BIGINT,
[CVE Doctor (Externos)] INT,
[Fecha (Externos)] DATE,
[No Heridas (Externos)] INT,
[No Curaciones e Inyecciones (Externos)] INT,
[Tratamiento (Externos)] NVARCHAR(MAX),
CONSTRAINT fk_ExtF FOREIGN KEY ([CVE Externos]) REFERENCES TablaExternos ([ID Externo]),
CONSTRAINT fk_CveConE FOREIGN KEY ([CVE Doctor (Externos)]) REFERENCES TablaDoctores ([ID Doctor])
)
GO

SELECT * FROM TablaConsultasExternos