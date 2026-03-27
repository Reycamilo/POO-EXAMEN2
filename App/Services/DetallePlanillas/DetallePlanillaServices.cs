using App.Database;
using App.Dtos;
using App.Entities;
using App.Mappers;
using Microsoft.EntityFrameworkCore;

namespace App.Services.DetallePlanillas
{
    public class DetallePlanillaServices : IDetallePlanillaServices
    {
        private readonly AppDbContext _context;

        public DetallePlanillaServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DetallePlanillaEntity>> ObtenerPorPlanilla(string planillaId)
        {
            return await _context.DetallesPlanilla
                .Where(d => d.PlanillaId == planillaId)
                .ToListAsync();
        }

        public async Task<DetallePlanillaEntity> ObtenerPorId(string id)
        {
            var detalleEntity = await _context.DetallesPlanilla.FirstOrDefaultAsync(d => d.Id == id);

            return detalleEntity;
        }

        public async Task<DetallePlanillaEntity> CrearDetalle(DetallePlanillaDto dto)
        {
            var detalleEntity = DetallePlanillasMapper.DetallePlanillaDtoToEntity(dto);

            _context.DetallesPlanilla.Add(detalleEntity);
            await _context.SaveChangesAsync();

            return detalleEntity;
        }

        public async Task<DetallePlanillaEntity> Actualizar(string id, DetallePlanillaDto dto)
        {
            var detalleEntity = await _context.DetallesPlanilla.FirstOrDefaultAsync(d => d.Id == id);

            if (detalleEntity == null)
            {
                return null;
            }

            detalleEntity.PlanillaId = dto.PlanillaId;
            detalleEntity.EmpleadoId = dto.EmpleadoId;
            detalleEntity.SalarioBase = dto.SalarioBase;
            detalleEntity.HorasExtra = dto.HorasExtra;
            detalleEntity.Bonificaciones = dto.Bonificaciones;
            detalleEntity.Deducciones = dto.Deducciones;
            detalleEntity.SalarioNeto = dto.SalarioNeto;
            detalleEntity.Comentarios = dto.Comentarios;

            await _context.SaveChangesAsync();

            return detalleEntity;
        }

        public async Task<DetallePlanillaEntity> Eliminar(string id)
        {
            var detalleEntity = await _context.DetallesPlanilla.FirstOrDefaultAsync(d => d.Id == id);

            if (detalleEntity == null)
            {
                return null;
            }

            _context.DetallesPlanilla.Remove(detalleEntity);
            await _context.SaveChangesAsync();

            return detalleEntity;
        }

        public async Task<List<DetallePlanillaEntity>> ObtenerPorEmpleado(string empleadoId)
        {
            return await _context.DetallesPlanilla
                .Where(d => d.EmpleadoId == empleadoId)
                .ToListAsync();
        }
    }
}
