using App.Dtos;
using App.Entities;

namespace App.Services.DetallePlanillas
{
    public interface IDetallePlanillaServices
    {
        Task<List<DetallePlanillaEntity>> ObtenerPorPlanilla(string planillaId);
        Task<DetallePlanillaEntity> ObtenerPorId(string id);
        Task<DetallePlanillaEntity> CrearDetalle(DetallePlanillaDto dto);
        Task<DetallePlanillaEntity> Actualizar(string id, DetallePlanillaDto dto);
        Task<DetallePlanillaEntity> Eliminar(string id);
        Task<List<DetallePlanillaEntity>> ObtenerPorEmpleado(string empleadoId);
    }
}
