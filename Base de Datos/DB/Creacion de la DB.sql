USE master
GO

CREATE DATABASE ServicioMedico
ON 
(
NAME = 'ServicioMedico_Data',
FILENAME = 'C:\Programas\ServicioMedico\Base de Datos\DB\ServicioMedico_Data.mdf',
SIZE = 5MB,
MAXSIZE = UNLIMITED,
FILEGROWTH = 25%
)
LOG
ON
(
NAME = 'ServicioMedico_Log',
FILENAME = 'C:\Programas\ServicioMedico\Base de Datos\DB\ServicioMedico_Log.ldf',
SIZE = 1MB,
MAXSIZE = UNLIMITED,
FILEGROWTH = 25%
)
GO