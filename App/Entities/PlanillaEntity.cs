using System.ComponentModel.DataAnnotations;

namespace App.Entities
{
    public class PlanillaEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Periodo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; }
        // public ICollection<DetallePlanillaEntity> DetallesPlanilla { get; set; } = new List<DetallePlanillaEntity>();
    }
}
