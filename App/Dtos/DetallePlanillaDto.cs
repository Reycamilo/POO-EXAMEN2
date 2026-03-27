namespace App.Dtos
{
    public class DetallePlanillaDto
    {
        public string PlanillaId { get; set; }
        public string EmpleadoId { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
        public decimal SalarioNeto { get; set; }
        public string Comentarios { get; set; }
    }
}
