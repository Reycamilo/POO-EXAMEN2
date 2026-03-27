using Microsoft.EntityFrameworkCore;
using App.Entities;

namespace App.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        // Crear las tablas
        public DbSet<EmpleadosEntity> Empleados { get; set; }
        public DbSet<PlanillaEntity> Planillas { get; set; }
        public DbSet<DetallePlanillaEntity> DetallesPlanilla { get; set; }
    }

    
}
