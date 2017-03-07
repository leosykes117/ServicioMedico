USE ServicioMedico
GO

IF OBJECT_ID('TablaConsultasDocentes') IS NOT NULL
DROP TABLE TablaConsultasDocentes
GO

CREATE TABLE TablaConsultasDocentes
(
[ID Consulta (Docentes)] INT IDENTITY(1,1) PRIMARY KEY,
[CVE Docente] BIGINT,
[CVE Doctor (Docentes)] INT,
[Fecha (Docentes)] DATE,
[No Curaciones (Docentes)] INT,
[No Curaciones e Inyecciones (Docentes)] INT,
[Tratamiento (Docentes)] NVARCHAR(MAX),
CONSTRAINT fk_DocF FOREIGN KEY ([CVE Docente]) REFERENCES TablaDocentes ([ID Docente]),
CONSTRAINT fk_CveConD FOREIGN KEY ([CVE Doctor (Docentes)]) REFERENCES TablaDoctores ([ID Doctor])
)
GO

SELECT * FROM TablaConsultasDocentes