using App.Database;
using App.Dtos;
using App.Entities;
using App.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Planillas
{
    public class PlanillaServices : IPlanillaServices
    {
        private readonly AppDbContext _context;

        public PlanillaServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PlanillaEntity>> ObtenerTodasAsync()
        {
            return await _context.Planillas.ToListAsync();
        }

        public async Task<PlanillaEntity> ObtenerPorId(string id)
        {
            var planillaEntity = await _context.Planillas.FirstOrDefaultAsync(p => p.Id == id);

            return planillaEntity;
        }

        public async Task<PlanillaEntity> ObtenerPorPeriodo(string periodo)
        {
            var planillaEntity = await _context.Planillas.FirstOrDefaultAsync(p => p.Periodo == periodo);

            return planillaEntity;
        }

        public async Task<PlanillaEntity> CrearPlanilla(PlanillaDto dto)
        {
            var planillaEntity = PlanillasMapper.PlanillaDtoToEntity(dto);

            _context.Planillas.Add(planillaEntity);
            await _context.SaveChangesAsync();

            return planillaEntity;
        }

        public async Task<PlanillaEntity> Actualizar(string id, PlanillaDto dto)
        {
            var planillaEntity = await _context.Planillas.FirstOrDefaultAsync(p => p.Id == id);

            if (planillaEntity == null)
            {
                return null;
            }

            planillaEntity.Periodo = dto.Periodo;
            planillaEntity.FechaCreacion = dto.FechaCreacion;
            planillaEntity.FechaPago = dto.FechaPago;

            await _context.SaveChangesAsync();

            return planillaEntity;
        }

        public async Task<PlanillaEntity> Eliminar(string id)
        {
            var planillaEntity = await _context.Planillas.FirstOrDefaultAsync(p => p.Id == id);

            if (planillaEntity == null)
            {
                return null;
            }

            _context.Planillas.Remove(planillaEntity);
            await _context.SaveChangesAsync();

            return planillaEntity;
        }

        public async Task<PlanillaEntity> CambiarEstado(string id, string estado)
        {
            var planillaEntity = await _context.Planillas.FirstOrDefaultAsync(p => p.Id == id);

            if (planillaEntity == null)
            {
                return null;
            }

            planillaEntity.Estado = estado;

            await _context.SaveChangesAsync();

            return planillaEntity;
        }
    }
}
