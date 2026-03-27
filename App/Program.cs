using App.Database;
using App.Services.DetallePlanillas;
using App.Services.Empleados;
using App.Services.Planillas;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>( options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IEmpleadoServices,EmpleadoServices>();
builder.Services.AddTransient<IPlanillaServices,PlanillaServices>();
builder.Services.AddTransient<IDetallePlanillaServices,DetallePlanillaServices>();
builder.Services.AddOpenApi();
builder.Services.AddControllers(); // agregando los controladores.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}


app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers(); // mapeando los controladores.



app.Run();

