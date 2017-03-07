USE ServicioMedico
GO

IF OBJECT_ID('TablaConsultasAlumnos') IS NOT NULL
DROP TABLE TablaConsultasAlumnos
GO

CREATE TABLE TablaConsultasAlumnos
(
[ID Consulta (Alumnos)] INT IDENTITY(1,1) PRIMARY KEY,
[CVE Boleta] BIGINT,
[CVE Doctor (Alumnos)] INT,
[Fecha (Alumnos)] DATE,
[No Heridas (Alumnos)] INT,
[No Curaciones e Inyecciones (Alumnos)] INT,
[Tratamiento (Alumnos)] NVARCHAR(MAX),
CONSTRAINT fk_AlumF FOREIGN KEY ([CVE Boleta]) REFERENCES TablaAlumnos (Boleta),
CONSTRAINT fk_CveCon FOREIGN KEY ([CVE Doctor (Alumnos)]) REFERENCES TablaDoctores ([ID Doctor])
)
GO

SELECT * FROM TablaConsultasAlumnos
GO