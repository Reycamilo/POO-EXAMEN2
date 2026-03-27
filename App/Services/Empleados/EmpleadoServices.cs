using App.Database;
using App.Dtos;
using App.Entities;
using App.Mappers;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Empleados
{
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly AppDbContext _context;

        public EmpleadoServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmpleadosEntity>> ObtenerTodosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<List<EmpleadosEntity>> ObtenerActivosAsync()
        {
            return await _context.Empleados.Where(e => e.Activo).ToListAsync();
        }

        public async Task<EmpleadosEntity> ObtenerPorId(string id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(p => p.Id == id);

            return empleadoEntity;
        }

        public async Task<EmpleadosEntity> CrearEmpleado(EmpleadoDto dto)
        {
            var empleadoEntity = EmpleadosMapper.EmpleadoDtotoEntity(dto);

            _context.Empleados.Add(empleadoEntity);
            await _context.SaveChangesAsync();

            return empleadoEntity;
        }

        public async Task<EmpleadosEntity> Actualizar(string id, EmpleadoDto dto)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(p => p.Id == id);

            if (empleadoEntity == null)
            {
                return null;
            }

            empleadoEntity.Nombre = dto.Nombre;
            empleadoEntity.Apellido = dto.Apellido;
            empleadoEntity.Documento = dto.Documento;
            empleadoEntity.Departamento = dto.Departamento;
            empleadoEntity.PuestoTrabajo = dto.PuestoTrabajo;

            await _context.SaveChangesAsync();

            return empleadoEntity;
        }

        public async Task<EmpleadosEntity> Eliminar(string id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(p => p.Id == id);

            if (empleadoEntity == null)
            {
                return null;
            }

            empleadoEntity.Activo = false;

            await _context.SaveChangesAsync();

            return empleadoEntity;
        }
    }
}
