using Application.Interfaces.IOferta;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{categoriaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriaById(int categoriaId)
        {
            var result = await _queryServices.GetCategoriaById(categoriaId);
            return StatusCode(result.code, result.result);
        }


        [HttpGet("/Todas")]
        public async Task<IActionResult> GetAllCategorias()
        {
            var result = await _queryServices.GetOfertas();
            return new JsonResult(result);
        }
    }
}
