using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Consultas
    {
        private int idConsulta;
        private int cvePaciente;
        private string cveDoctor;
        private string diagnostico;
        private DateTime fechaConsulta = new DateTime();
        private DateTime horaEntrada = new DateTime();
        private DateTime horaSalida = new DateTime();
        private DateTime duracionConsulta = new DateTime();
        private int idDetalle;
        private int motivoConsulta;
        private int cveMedicamento;
        private int cantidadSumintrada;
        private string nombreMedicamento;
        private string nombreMotivo;

        public int IdConsulta
        {
            get
            {
                return idConsulta;
            }

            set
            {
                idConsulta = value;
            }
        }

        public int CvePaciente
        {
            get
            {
                return cvePaciente;
            }

            set
            {
                cvePaciente = value;
            }
        }

        public string CveDoctor
        {
            get
            {
                return cveDoctor;
            }

            set
            {
                cveDoctor = value;
            }
        }

        public string Diagnostico
        {
            get
            {
                return diagnostico;
            }

            set
            {
                diagnostico = value;
            }
        }

        public DateTime FechaConsulta
        {
            get
            {
                return fechaConsulta;
            }

            set
            {
                fechaConsulta = value;
            }
        }

        public DateTime HoraEntrada
        {
            get
            {
                return horaEntrada;
            }

            set
            {
                horaEntrada = value;
            }
        }

        public DateTime HoraSalida
        {
            get
            {
                return horaSalida;
            }

            set
            {
                horaSalida = value;
            }
        }

        public DateTime DuracionConsulta
        {
            get
            {
                return duracionConsulta;
            }

            set
            {
                duracionConsulta = value;
            }
        }

        public int IdDetalle
        {
            get
            {
                return idDetalle;
            }

            set
            {
                idDetalle = value;
            }
        }

        public int MotivoConsulta
        {
            get
            {
                return motivoConsulta;
            }

            set
            {
                motivoConsulta = value;
            }
        }

        public int CveMedicamento
        {
            get
            {
                return cveMedicamento;
            }

            set
            {
                cveMedicamento = value;
            }
        }

        public int CantidadSumintrada
        {
            get
            {
                return cantidadSumintrada;
            }

            set
            {
                cantidadSumintrada = value;
            }
        }

        public string NombreMedicamento
        {
            get
            {
                return nombreMedicamento;
            }

            set
            {
                nombreMedicamento = value;
            }
        }

        public string NombreMotivo
        {
            get
            {
                return nombreMotivo;
            }

            set
            {
                nombreMotivo = value;
            }
        }

        public Consultas() { }

        public Consultas(int idConsulta, int cvePaciente, string cveDoctor, string diagnostico, DateTime fechaConsulta, DateTime horaEntrada, DateTime horaSalida, DateTime duracionConsulta, int idDetalle, int motivoConsulta, int cveMedicamento, int cantidadSumintrada, string nombreMedicamento, string nombreMotivo)
        {
            this.idConsulta = idConsulta;
            this.cvePaciente = cvePaciente;
            this.cveDoctor = cveDoctor;
            this.diagnostico = diagnostico;
            this.fechaConsulta = fechaConsulta;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
            this.duracionConsulta = duracionConsulta;
            this.idDetalle = idDetalle;
            this.motivoConsulta = motivoConsulta;
            this.cveMedicamento = cveMedicamento;
            this.cantidadSumintrada = cantidadSumintrada;
            this.nombreMedicamento = nombreMedicamento;
            this.nombreMotivo = nombreMotivo;
        }
    }
}
