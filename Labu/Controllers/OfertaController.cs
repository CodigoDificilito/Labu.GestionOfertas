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
        public IActionResult AddOferta(AddOfertaRequest request)
        {
            var result = _commandServices.CreateOferta(request);
            return new JsonResult(result);
        }

        [HttpDelete]
        public IActionResult DeleteOferta(Guid guid)
        {
            var result = _commandServices.DeleteOferta(guid);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOfertas()
        {
            var result = _queryServices.GetOfertas();
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOfertasByTitulo(string titulo)
        {
            var result = _queryServices.GetListOfertaByTitulo(titulo);
            return new JsonResult(result);
        }

    }
}
