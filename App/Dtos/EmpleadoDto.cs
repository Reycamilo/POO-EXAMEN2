using System.ComponentModel.DataAnnotations;

namespace App.Dtos
{
    public class EmpleadoDto
    {
        [Required]
        public string Nombre { get; set; } 

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Documento { get; set; }
        public string Departamento { get; set; }
        public string PuestoTrabajo { get; set; }

    }
}