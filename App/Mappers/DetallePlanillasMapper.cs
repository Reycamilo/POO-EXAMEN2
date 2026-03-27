using App.Dtos;
using App.Entities;

namespace App.Mappers
{
    public static class DetallePlanillasMapper
    {
        public static DetallePlanillaEntity DetallePlanillaDtoToEntity(DetallePlanillaDto dto)
        {
            return new DetallePlanillaEntity
            {
                Id = Guid.NewGuid().ToString(),
                PlanillaId = dto.PlanillaId,
                EmpleadoId = dto.EmpleadoId,
                SalarioBase = dto.SalarioBase,
                HorasExtra = dto.HorasExtra,
                Bonificaciones = dto.Bonificaciones,
                Deducciones = dto.Deducciones,
                SalarioNeto = dto.SalarioNeto,
                Comentarios = dto.Comentarios
            };
        }
    }
}
