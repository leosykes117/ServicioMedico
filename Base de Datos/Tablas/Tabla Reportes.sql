USE ServicioMedico
GO

IF OBJECT_ID('Reporte') IS NOT NULL
DROP TABLE Reporte
GO

CREATE TABLE Reporte
(
IdReporte INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Propiertario INT NULL,
Mes INT NULL,
Año INT NULL,
AlumHombres INT,
AlumMujeres INT,
DocHombres INT,
DocMujeres INT,
PaaeHombres INT,
PaaeMujeres INT,
ExtHombres INT,
ExtMujeres INT,
SubtotalHombres INT,
SubtotalMujeres INT,
Total INT,
Archivo VARBINARY(MAX) NULL
)
GO

INSERT INTO Reporte 
VALUES (NULL, 7, 2017, 2, 0, 0, 0, 1, 0, )

SELECT AlumHombres, AlumMujeres, DocHombres, DocMujeres, PaaeHombres, PaaeMujeres, ExtHombres, ExtMujeres, SubtotalHombres, SubtotalMujeres, Total 
FROM Reporte WHERE 