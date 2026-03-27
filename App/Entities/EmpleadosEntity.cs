using System.ComponentModel.DataAnnotations;

namespace App.Entities
{
    public class EmpleadosEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Nombre { get; set; } 

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Documento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string Departamento { get; set; }
        public string PuestoTrabajo { get; set; }
        public decimal SalarioBase { get; set; }
        public bool Activo { get; set; }

        // public ICollection<DetallePlanillaEntity> DetallesPlanilla { get; set; } = new List<DetallePlanillaEntity>();
    }
}
