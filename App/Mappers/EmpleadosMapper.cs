using App.Dtos;
using App.Entities;

namespace App.Mappers
{
    public static class EmpleadosMapper
    {
        public static EmpleadosEntity EmpleadoDtotoEntity(EmpleadoDto dto)
        {
            return new EmpleadosEntity
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Documento = dto.Documento,
                Departamento = dto.Departamento,
                PuestoTrabajo = dto.PuestoTrabajo,
                Activo = true,
            };
        }
    }
}