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
        private string motivo;
        private string diagnostico;
        private DateTime fecha = new DateTime();
        private DateTime horaEntrada = new DateTime();
        private DateTime horaSalida = new DateTime();
        private int idDetalle;
        private string nombreMedicamento;
        private int tratamiento;
        private int cantidadSumintrada;

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

        public string Motivo
        {
            get
            {
                return motivo;
            }

            set
            {
                motivo = value;
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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
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

        public int Tratamiento
        {
            get
            {
                return tratamiento;
            }

            set
            {
                tratamiento = value;
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

        public Consultas() { }

        public Consultas(int idConsulta)
        {
            this.idConsulta = idConsulta;
        }

        public Consultas(int cvePaciente, string cveDoctor, string motivo, string diagnostico, DateTime fecha, DateTime horaEntrada, DateTime horaSalida, int tratamiento, int cantidadSumintrada)
        {
            this.cvePaciente = cvePaciente;
            this.cveDoctor = cveDoctor;
            this.motivo = motivo;
            this.diagnostico = diagnostico;
            this.fecha = fecha;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
            this.tratamiento = tratamiento;
            this.cantidadSumintrada = cantidadSumintrada;
        }
    }
}
