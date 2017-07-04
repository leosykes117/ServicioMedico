USE ServicioMedico
GO

IF OBJECT_ID('tbMedicamentos') IS NOT NULL
DROP TABLE tbMedicamentos
GO

CREATE TABLE tbMedicamentos
(
IdMedicamento INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombreMedicamento NVARCHAR(50) NOT NULL,
Cantidad INT NOT NULL,
FechaCaducidad DATE NULL,
Categoria SMALLINT NOT NULL,
CONSTRAINT fk_CveCat FOREIGN KEY (Categoria) REFERENCES tbCategorias (IdCategoria),
CONSTRAINT UQ_NomM UNIQUE(NombreMedicamento)
)
GO