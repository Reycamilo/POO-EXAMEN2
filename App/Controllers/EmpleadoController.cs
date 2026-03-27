using App.Services.Empleados;
using App.Entities;
using Microsoft.AspNetCore.Mvc;
using App.Dtos;

namespace App.Controllers
{
    [ApiController]
    [Route("api/Empleados")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoServices _empleadoServices;

        public EmpleadoController(IEmpleadoServices empleadoServices)
        {
            _empleadoServices = empleadoServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpleadosEntity>>> ObtenerTodos()
        {
            var empleados = await _empleadoServices.ObtenerTodosAsync();
            return Ok(empleados);
        }

        [HttpGet("activos")]
        public async Task<ActionResult<List<EmpleadosEntity>>> ObtenerActivos()
        {
            var empleados = await _empleadoServices.ObtenerActivosAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<EmpleadosEntity> GetById(string id)
        {
            var resultado = await _empleadoServices.ObtenerPorId(id);

            return resultado;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmpleado(EmpleadoDto dto)
        {   
            var resultado = await _empleadoServices.CrearEmpleado(dto);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEmpleado(string id, EmpleadoDto dto)
        {
            var resultado = await _empleadoServices.Actualizar(id, dto);

            if (resultado == null)
            {
                return NotFound("Empleado no encontrado");
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEmpleado(string id)
        {
            var resultado = await _empleadoServices.Eliminar(id);

            if (resultado == null)
            {
                return NotFound("Empleado no encontrado");
            }

            return Ok(resultado);
        }
    }
}
