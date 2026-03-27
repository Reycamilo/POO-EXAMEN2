using App.Dtos;
using App.Entities;
using App.Services.DetallePlanillas;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/DetallePlanillas")]
    public class DetallePlanillaController : ControllerBase
    {
        private readonly IDetallePlanillaServices _detallePlanillaServices;

        public DetallePlanillaController(IDetallePlanillaServices detallePlanillaServices)
        {
            _detallePlanillaServices = detallePlanillaServices;
        }

        [HttpGet("planilla/{planillaId}")]
        public async Task<ActionResult<List<DetallePlanillaEntity>>> ObtenerPorPlanilla(string planillaId)
        {
            var detalles = await _detallePlanillaServices.ObtenerPorPlanilla(planillaId);
            return Ok(detalles);
        }

        [HttpGet("empleado/{empleadoId}")]
        public async Task<ActionResult<List<DetallePlanillaEntity>>> ObtenerPorEmpleado(string empleadoId)
        {
            var detalles = await _detallePlanillaServices.ObtenerPorEmpleado(empleadoId);
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePlanillaEntity>> ObtenerPorId(string id)
        {
            var resultado = await _detallePlanillaServices.ObtenerPorId(id);

            if (resultado == null)
            {
                return NotFound("Detalle de planilla no encontrado");
            }

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDetalle(DetallePlanillaDto dto)
        {
            var resultado = await _detallePlanillaServices.CrearDetalle(dto);

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalle(string id, DetallePlanillaDto dto)
        {
            var resultado = await _detallePlanillaServices.Actualizar(id, dto);

            if (resultado == null)
            {
                return NotFound("Detalle de planilla no encontrado");
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDetalle(string id)
        {
            var resultado = await _detallePlanillaServices.Eliminar(id);

            if (resultado == null)
            {
                return NotFound("Detalle de planilla no encontrado");
            }

            return Ok(resultado);
        }
    }
}
