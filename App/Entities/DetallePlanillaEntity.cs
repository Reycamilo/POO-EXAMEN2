using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    public class DetallePlanillaEntity
    {
        [Key]
        public string Id { get; set; }
        public string PlanillaId { get; set; }
        public string EmpleadoId { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
        public decimal SalarioNeto { get; set; }
        public string Comentarios { get; set; }

        [ForeignKey("PlanillaId")]
        public PlanillaEntity Planilla { get; set; }

        [ForeignKey("EmpleadoId")]
        public EmpleadosEntity Empleado { get; set; }
    }
}
