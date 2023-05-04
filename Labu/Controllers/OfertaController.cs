using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IClient;
using Application.Interfaces.IExperiencia;
using Application.Interfaces.INivelEstudio;
using Application.Interfaces.IOferta;
using Microsoft.AspNetCore.Mvc;

namespace Labu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaCommandServices _ofertaCommandServices;
        private readonly IOfertaQueryServices _ofertaQueryServices;
        private readonly ICategoriaQueryServices _categoriaQueryServices;
        private readonly IExperienciaQueryServices _experienciaQueryServices;
        private readonly INivelEstudioQueryServices _nivelEstudioQueryServices;
        private readonly IClientGeorefArApiServices _apiUbicaciones;


        public OfertaController(IOfertaQueryServices ofertaQueryServices, IOfertaCommandServices ofertaCommandServices, ICategoriaQueryServices categoriaQueryServices, IClientGeorefArApiServices apiUbicaciones, IExperienciaQueryServices experienciaQueryServices, INivelEstudioQueryServices nivelEstudioQueryServices)
        {
            _ofertaQueryServices = ofertaQueryServices;
            _ofertaCommandServices = ofertaCommandServices;
            _categoriaQueryServices = categoriaQueryServices;
            _experienciaQueryServices = experienciaQueryServices;
            _nivelEstudioQueryServices = nivelEstudioQueryServices;
            _apiUbicaciones = apiUbicaciones;
        }

        [HttpPost]

        [ProducesResponseType(typeof(OfertaResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> AddOferta(OfertaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Compruebe que los datos ingresados sean validos." }) { StatusCode = 400 };
            }

            if (!await _experienciaQueryServices.ExperienciaExist(request.ExperienciaId))
            {
                return new JsonResult(new BadRequest { message = "Id de Experiencia incorrecto" }) { StatusCode = 400 };
            }

            if (!await _nivelEstudioQueryServices.NivelEstudioExist(request.NivelEstudiosId))
            {
                return new JsonResult(new BadRequest { message = "Id de NivelEstudios incorrecto" }) { StatusCode = 400 };
            }

            if (!await _apiUbicaciones.ValidateProvince(request.ProvinciaId))
            {
                return new JsonResult(new BadRequest { message = "Id de provincia incorrecto" }) { StatusCode = 400};
            }

            if (!await _apiUbicaciones.ValidateCity(request.ProvinciaId, request.CiudadId))
            {
                return new JsonResult(new BadRequest { message = "Id de ciudad incorrecto" }) { StatusCode = 400 };
            }

            if (!await _categoriaQueryServices.CategoriasExist(request.Categorias))
            {
                return new JsonResult(new BadRequest { message = "Ingrese IDs de categoria validos" }) { StatusCode = 400 };
            }

            var result = await _ofertaCommandServices.CreateOferta(request);

            return new JsonResult(result) { StatusCode = 201};
        }

        [HttpDelete("{id}")]

        [ProducesResponseType(typeof(OfertaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOferta(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Compruebe que los datos ingresados sean validos." }) { StatusCode = 400 };
            }

            var result = await _ofertaCommandServices.DeleteOferta(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Oferta no encontrada, verifique el ID." }) { StatusCode = 404 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{id}")]

        [ProducesResponseType(typeof(OfertaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOfertaById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new BadRequest { message = "Compruebe que los datos ingresados sean validos." }) { StatusCode = 400 };
            }

            var result = await _ofertaQueryServices.GetOfertaById(id);

            if (result == null)
            {
                return new JsonResult(new BadRequest { message = "Oferta no encontrada" }) { StatusCode = 404 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet]

        [ProducesResponseType(typeof(IList<OfertaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMercaderias(string? descripcion, int? empresa, int? provincia, int page, string orden = "DESC")
        {
            if (page==0 || page==null)
            {
                return new JsonResult(new BadRequest { message = "El campo <page> solo puede recibir int" }) { StatusCode = 400 };
            }

            if (empresa != null && empresa is string)
            {
                return new JsonResult(new BadRequest { message = "El campo <empresa> solo puede recibir int o null" }) { StatusCode = 400 };
            }

            if (provincia != null && provincia is string)
            {
                return new JsonResult(new BadRequest { message = "El campo <provincia> solo puede recibir int o null" }) { StatusCode = 400 };
            }

            if (orden.ToUpper() != "DESC" && orden.ToUpper() != "ASC")
            {
                return new JsonResult(new BadRequest { message = "El valor de <orden> no es válido" }) { StatusCode = 400 };

            }

            var ofertas = await _ofertaQueryServices.GetListOfertaByQuerys(descripcion, empresa, provincia, page, orden);

            return new JsonResult(ofertas) { StatusCode = 200 };
        }

    }
}
