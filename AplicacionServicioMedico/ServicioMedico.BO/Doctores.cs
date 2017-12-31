using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMedico.BO
{
    public class Doctores
    {
        public int IdDoctor { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombreDoctor { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string ApellidosDoctor { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public short GeneroDoctor { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string EmailDoctor { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public short Rol { get; set; }

        public string TokenReseteoPassword { get; set; }
        public DateTime CreadoEl { get; set; }
        public DateTime ModificadoEl { get; set; }
    }
}