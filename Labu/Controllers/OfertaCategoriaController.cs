using Application.DTO.Request;
using Application.Interfaces.IOfertaCategoria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaCategoriaController : ControllerBase
    {
        private readonly IOfertaCategoriaCommandServices _commandServices;
        private readonly IOfertaCategoriaQueryServices _queryServices;

        public OfertaCategoriaController(IOfertaCategoriaCommandServices commandServices, IOfertaCategoriaQueryServices queryServices)
        {
            _commandServices = commandServices;
            _queryServices = queryServices;
        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOfertaCategoria(AddOfertaCategoriaRequest request)
        {
            var result = await _commandServices.CreateOfertaCategoria(request);
            return StatusCode(result.code, result.result);
        }

        [HttpDelete("{ofertaId}/{categoriaId}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOfertaCategoria(Guid ofertaId, int categoriaId)
        {
            var result = await _commandServices.DeleteOfertaCategoria(ofertaId, categoriaId);

            return StatusCode(result.code, result.result);
        }

        [HttpGet("{ofertaId}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllOfertaCategoriaByOferta(Guid ofertaId)
        {
            var result = await _queryServices.GetListOfertaCategoriaByOfertaId(ofertaId);
            return StatusCode(result.code, result.result);
        }

    }
}
