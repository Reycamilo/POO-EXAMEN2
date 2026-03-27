using App.Dtos;
using App.Entities;
using App.Services.Planillas;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/Planillas")]
    public class PlanillaController : ControllerBase
    {
        private readonly IPlanillaServices _planillaServices;

        public PlanillaController(IPlanillaServices planillaServices)
        {
            _planillaServices = planillaServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlanillaEntity>>> ObtenerTodas()
        {
            var planillas = await _planillaServices.ObtenerTodasAsync();
            return Ok(planillas);
        }

        [HttpGet("periodo/{periodo}")]
        public async Task<ActionResult<PlanillaEntity>> ObtenerPorPeriodo(string periodo)
        {
            var resultado = await _planillaServices.ObtenerPorPeriodo(periodo);

            if (resultado == null)
            {
                return NotFound("Planilla no encontrada");
            }

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanillaEntity>> ObtenerPorId(string id)
        {
            var resultado = await _planillaServices.ObtenerPorId(id);

            if (resultado == null)
            {
                return NotFound("Planilla no encontrada");
            }

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPlanilla(PlanillaDto dto)
        {
            var resultado = await _planillaServices.CrearPlanilla(dto);

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPlanilla(string id, PlanillaDto dto)
        {
            var resultado = await _planillaServices.Actualizar(id, dto);

            if (resultado == null)
            {
                return NotFound("Planilla no encontrada");
            }

            return Ok(resultado);
        }

        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstadoPlanilla(string id, [FromQuery] string estado)
        {
            var resultado = await _planillaServices.CambiarEstado(id, estado);

            if (resultado == null)
            {
                return NotFound("Planilla no encontrada");
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPlanilla(string id)
        {
            var resultado = await _planillaServices.Eliminar(id);

            if (resultado == null)
            {
                return NotFound("Planilla no encontrada");
            }

            return Ok(resultado);
        }
    }
}
