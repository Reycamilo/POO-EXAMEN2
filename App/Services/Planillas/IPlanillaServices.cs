using App.Dtos;
using App.Entities;

namespace App.Services.Planillas
{
    public interface IPlanillaServices
    {
        Task<List<PlanillaEntity>> ObtenerTodasAsync();
        Task<PlanillaEntity> ObtenerPorId(string id);
        Task<PlanillaEntity> ObtenerPorPeriodo(string periodo);
        Task<PlanillaEntity> CrearPlanilla(PlanillaDto dto);
        Task<PlanillaEntity> Actualizar(string id, PlanillaDto dto);
        Task<PlanillaEntity> CambiarEstado(string id, string estado);
        Task<PlanillaEntity> Eliminar(string id);
    }
}
