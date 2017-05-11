using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Medicamentos
    {
        private int idMedicamento;
        private string nombreMedicamento;
        private int cantidad;
        private DateTime fechaCaducidad;
        private int categoria;

        public int IdMedicamento
        {
            get
            {
                return idMedicamento;
            }

            set
            {
                idMedicamento = value;
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

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public DateTime FechaCaducidad
        {
            get
            {
                return fechaCaducidad;
            }

            set
            {
                fechaCaducidad = value;
            }
        }

        public int Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public Medicamentos() { }

        public Medicamentos(int idMedicamento)
        {
            this.IdMedicamento = idMedicamento;
        }

        public Medicamentos(int idMedicamento, string nombreMedicamento, int cantidad, DateTime fechaCaducidad, int categoria)
        {
            this.IdMedicamento = idMedicamento;
            this.NombreMedicamento = nombreMedicamento;
            this.Cantidad = cantidad;
            this.FechaCaducidad = fechaCaducidad;
            this.Categoria = categoria;
        }
    }
}
