using Application.DTO.Response;
using Application.Interfaces.IOferta;
using Microsoft.AspNetCore.Mvc;

namespace Labu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaQueryServices _queryServices;

        public CategoriaController(ICategoriaQueryServices queryServices)
        {
            _queryServices = queryServices;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Verifique el ID ingresado." }) { StatusCode = 400 };
            }

            var result = await _queryServices.GetCategoriaById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Categoria no encontrada." }) { StatusCode = 404 };
            }
            
            return new JsonResult(result){ StatusCode = 200};
        }


        [HttpGet]
        [ProducesResponseType(typeof(IList<CategoriaResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategorias()
        {
            var result = await _queryServices.GetOfertas();
            return new JsonResult(result) { StatusCode = 200};
        }
    }
}
