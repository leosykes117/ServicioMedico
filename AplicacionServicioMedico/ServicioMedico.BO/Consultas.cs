using System;
using System.Collections;
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
        private int cveDoctor;
        private string diagnostico;
        private string observaciones;
        private DateTime fechaConsulta = new DateTime();
        private DateTime horaEntrada = new DateTime();
        private DateTime horaSalida = new DateTime();
        private DateTime duracionConsulta = new DateTime();
        private short estatusConsulta;
        private float temperatura;
        private string tA;
        private float fC;
        private float fR;
        public string NomDoc { get; set; }
        private List<Motivos> motivosConsultas;
        private List<Medicamentos_Consultas> medicamentosConsultas;

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

        public int CveDoctor
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

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
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

        public short EstatusConsulta
        {
            get
            {
                return estatusConsulta;
            }

            set
            {
                estatusConsulta = value;
            }
        }

        public float Temperatura
        {
            get
            {
                return temperatura;
            }

            set
            {
                temperatura = value;
            }
        }

        public string TA
        {
            get
            {
                return tA;
            }

            set
            {
                tA = value;
            }
        }

        public float FC
        {
            get
            {
                return fC;
            }

            set
            {
                fC = value;
            }
        }

        public float FR
        {
            get
            {
                return fR;
            }

            set
            {
                fR = value;
            }
        }

        public List<Motivos> MotivosConsultas
        {
            get
            {
                return motivosConsultas;
            }

            set
            {
                motivosConsultas = value;
            }
        }

        public List<Medicamentos_Consultas> MedicamentosConsultas
        {
            get
            {
                return medicamentosConsultas;
            }

            set
            {
                medicamentosConsultas = value;
            }
        }

        public Consultas() { }

        public Consultas(int idConsulta)
        {
            this.idConsulta = idConsulta;
        }

        public Consultas(int idConsulta, short estatusConsulta)
        {
            this.idConsulta = idConsulta;
            this.estatusConsulta = estatusConsulta;
        }

        public Consultas(int idConsulta, int cvePaciente, int cveDoctor, string diagnostico, string observaciones, DateTime fechaConsulta, DateTime horaEntrada, DateTime horaSalida, DateTime duracionConsulta, short estatusConsulta, float temperatura, string tA, float fC, float fR, List<Motivos> motivosConsultas, List<Medicamentos_Consultas> medicamentosConsultas)
        {
            this.idConsulta = idConsulta;
            this.cvePaciente = cvePaciente;
            this.cveDoctor = cveDoctor;
            this.diagnostico = diagnostico;
            this.observaciones = observaciones;
            this.fechaConsulta = fechaConsulta;
            this.horaEntrada = horaEntrada;
            this.horaSalida = horaSalida;
            this.duracionConsulta = duracionConsulta;
            this.estatusConsulta = estatusConsulta;
            this.temperatura = temperatura;
            this.tA = tA;
            this.fC = fC;
            this.fR = fR;
            this.motivosConsultas = motivosConsultas;
            this.medicamentosConsultas = medicamentosConsultas;
        }
    }
}
