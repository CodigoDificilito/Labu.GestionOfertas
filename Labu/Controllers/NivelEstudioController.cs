using Application.DTO.Response;
using Application.Interfaces.INivelEstudio;
using Microsoft.AspNetCore.Mvc;

namespace Labu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelEstudioController : ControllerBase
    {
        private readonly INivelEstudioQueryServices _service;

        public NivelEstudioController(INivelEstudioQueryServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NivelEstudioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNivelEstudioById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verifique el ID ingresado." }) { StatusCode = 400 };
            }
            var nivel = await _service.GetNivelEstudioById(id);

            if (nivel == null)
            {
                return new JsonResult(new BadRequest { message = "Recurso no encontrado." }) { StatusCode = 404 };
            }
            return new JsonResult(nivel) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<NivelEstudioResponse>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllNivelEstudio()
        {
            var result = await _service.GetNivelesDeEstudio();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
