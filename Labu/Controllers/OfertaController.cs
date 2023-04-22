using Application.DTO.Request;
using Application.Interfaces.IOferta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaCommandServices _commandServices;
        private readonly IOfertaQueryServices _queryServices;

        public OfertaController(IOfertaQueryServices queryServices, IOfertaCommandServices commandServices)
        {
            _queryServices = queryServices;
            _commandServices = commandServices;
        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOferta(AddOfertaRequest request)
        {
            var result = await _commandServices.CreateOferta(request);
            return StatusCode(result.code, result.result);
        }

        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOferta(Guid id)
        {
            var result = await _commandServices.DeleteOferta(id);

            return StatusCode(result.code, result.result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllOfertas()
        //{
        //    var result = _queryServices.GetOfertas();
        //    return new JsonResult(result);
        //}

        [HttpGet("{titulo}")]
        public async Task<IActionResult> GetAllOfertasByTitulo(string titulo)
        {
            var result = await _queryServices.GetListOfertaByTitulo(titulo);
            return new JsonResult(result);
        }

        [HttpGet("empresa/{empresaId}")]
        public async Task<IActionResult> GetAllOfertasByEmpresaId(int empresaId)
        {
            var result = await _queryServices.GetListOfertaByEmpresaId(empresaId);
            return new JsonResult(result);
        }

    }
}
