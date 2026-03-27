using App.Dtos;
using App.Entities;

namespace App.Mappers
{
    public static class PlanillasMapper
    {
        public static PlanillaEntity PlanillaDtoToEntity(PlanillaDto dto)
        {
            return new PlanillaEntity
            {
                Id = Guid.NewGuid().ToString(),
                Periodo = dto.Periodo,
                FechaCreacion = dto.FechaCreacion,
                FechaPago = dto.FechaPago,
                Estado = "Pendiente"
            };
        }
    }
}
