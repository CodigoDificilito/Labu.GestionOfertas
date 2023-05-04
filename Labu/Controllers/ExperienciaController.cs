using Application.DTO.Response;
using Application.Interfaces.IExperiencia;
using Microsoft.AspNetCore.Mvc;

namespace Labu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private readonly IExperienciaQueryServices _service;

        public ExperienciaController(IExperienciaQueryServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExperienciaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetExperienciaById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verifique el ID ingresado." }) { StatusCode = 400 };
            }
            var experiencia = await _service.GetExperienciaById(id);

            if (experiencia == null)
            {
                return new JsonResult(new BadRequest { message = "Recurso no encontrado." }) { StatusCode = 404 };
            }
            return new JsonResult(experiencia) { StatusCode = 200};
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ExperienciaResponse>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAllExperiencia()
        {
            var result = await _service.GetExperiencias();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
