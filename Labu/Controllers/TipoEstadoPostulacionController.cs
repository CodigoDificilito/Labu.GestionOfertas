using Application.DTO.Response;
using Application.Interfaces.ITipoEstadoPostulacion;
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
        [ProducesResponseType(typeof(TipoEstadoPostulacionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTipoEstadoPostulacionById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verifique el ID ingresado." }) { StatusCode = 400 };
            }

            var result = await _queryServices.GetTipoEstadoPostulacionById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Recurso no encontrado." }) { StatusCode = 404 };
            }
            
            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet]
        [ProducesResponseType(typeof(IList<TipoEstadoPostulacionResponse>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllTiposEstadoPostulacion()
        {
            var result = await _queryServices.GetTiposEstadoPogstulacion();
            return new JsonResult(result) { StatusCode = 200};
        }
    }
}
