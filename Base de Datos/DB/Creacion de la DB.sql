USE master
GO

CREATE DATABASE ServicioMedico
ON 
(
NAME = 'ServicioMedico_Data',
FILENAME = 'C:\Programas\Servicio Medico\Base de Datos\DB\ServicioMedico_Data.mdf',
SIZE = 100MB,
MAXSIZE = 500MB,
FILEGROWTH = 25%
)
LOG
ON
(
NAME = 'ServicioMedico_Log',
FILENAME = 'C:\Programas\Servicio Medico\Base de Datos\DB\ServicioMedico_Log.ldf',
SIZE = 100MB,
MAXSIZE = 500MB,
FILEGROWTH = 25%
)
GO