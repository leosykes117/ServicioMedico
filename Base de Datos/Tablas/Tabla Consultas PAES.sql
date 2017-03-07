USE ServicioMedico
GO

IF OBJECT_ID('TablaConsultasPAE') IS NOT NULL
DROP TABLE TablaConsultasPAE
GO

CREATE TABLE TablaConsultasPAE
(
[ID Consulta (PAE)] INT IDENTITY(1,1) PRIMARY KEY,
[CVE PAE] BIGINT,
[CVE Doctor (PAE)] INT,
[Fecha (PAE)] DATE,
[No Heridas (PAE)] INT,
[No Curaciones e Inyecciones (PAE)] INT,
[Tratamiento (PAE)] NVARCHAR(MAX),
CONSTRAINT fk_PaeF FOREIGN KEY ([CVE PAE]) REFERENCES TablaPAES ([ID PAE]),
CONSTRAINT fk_CveConP FOREIGN KEY ([CVE Doctor (PAE)]) REFERENCES TablaDoctores ([ID Doctor])
)
GO

SELECT * FROM TablaConsultasPAE