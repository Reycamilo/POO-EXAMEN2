using App.Dtos;
using App.Entities;

namespace App.Services.Empleados
{
    public interface IEmpleadoServices
    {
        Task<List<EmpleadosEntity>> ObtenerTodosAsync();
        Task<List<EmpleadosEntity>> ObtenerActivosAsync();
        Task<EmpleadosEntity> ObtenerPorId(string id);
        Task<EmpleadosEntity> CrearEmpleado(EmpleadoDto dto);
        Task<EmpleadosEntity> Actualizar(string id, EmpleadoDto dto);
        Task<EmpleadosEntity> Eliminar(string id);
    }
}
