using Application.DTO.Response;
using Application.Interfaces.IOfertaCategoria;
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

        [HttpDelete("{ofertaId}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOfertaCategoria(Guid ofertaId, IList<int> categorias)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Compruebe que los datos ingresados sean validos." }) { StatusCode = 400 };
            }

            if (!await _queryServices.OfertaCategoriaExistInOfertaId(ofertaId, categorias))
            {
                return new JsonResult(new BadRequest { message = "No se a encontrado una de las Categorias, asegurese de ingresar el ID correctamente." }) { StatusCode = 404 };
            }

            if (!await _commandServices.DeleteOfertaCategoria(ofertaId, categorias))
            {
                return new JsonResult(new BadRequest { message = "Ingrese un ID de Oferta existente." }) { StatusCode = 404 };
            }

            return new JsonResult("Categorias eliminadas.") { StatusCode = 200 };
        }
    }
}
