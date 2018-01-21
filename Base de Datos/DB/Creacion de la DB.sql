USE master
GO

CREATE DATABASE ServicioMedico
ON 
(
NAME = 'ServicioMedico',
FILENAME = 'C:\Programas\ServicioMedico\Base de Datos\DB\ServicioMedico.mdf',
SIZE = 5MB,
MAXSIZE = UNLIMITED,
FILEGROWTH = 25%
)
LOG
ON
(
NAME = 'ServicioMedico_log',
FILENAME = 'C:\Programas\ServicioMedico\Base de Datos\DB\ServicioMedico_log.ldf',
SIZE = 1MB,
MAXSIZE = UNLIMITED,
FILEGROWTH = 25%
)
GO