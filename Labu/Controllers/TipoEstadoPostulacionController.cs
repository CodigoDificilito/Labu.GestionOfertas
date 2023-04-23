using Application.Interfaces.ITipoEstadoPostulacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEstadoPostulacionController : ControllerBase
    {
        private readonly ITipoEstadoPostulacionQueryServices _queryServices;

        public TipoEstadoPostulacionController(ITipoEstadoPostulacionQueryServices queryServices)
        {
            _queryServices = queryServices;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTipoEstadoPostulacionById(int id)
        {
            var result = await _queryServices.GetTipoEstadoPostulacionById(id);
            return StatusCode(result.code, result.result);
        }


        [HttpGet("/Todos")]
        public async Task<IActionResult> GetAllTiposEstadoPostulacion()
        {
            var result = await _queryServices.GetTiposEstadoPogstulacion();
            return new JsonResult(result);
        }
    }
}
