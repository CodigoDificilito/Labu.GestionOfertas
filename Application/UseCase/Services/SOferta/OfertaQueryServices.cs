using Application.DTO.Response;
using Application.Interfaces.IOferta;

namespace Application.UseCase.Services.SOferta
{
    public class OfertaQueryServices : IOfertaQueryServices
    {
        private readonly IOfertaQuery _query;

        public OfertaQueryServices(IOfertaQuery query)
        {
            _query = query;
        }

        public async Task<OfertaResponse> GetOfertaById(Guid ofertaId)
        {
            var oferta = await _query.GetOferta(ofertaId);

            if (oferta==null)
            {
                return null;
            }

            var categorias = new List<OfertaCategoriaResponse>();

            foreach (var item in oferta.OfertaCategoria)
            {
                categorias.Add(new OfertaCategoriaResponse
                {
                    CategoriaId = item.Categoria.CategoriaId,
                    Nombre = item.Categoria.Descripcion
                });
            }

            return new OfertaResponse
            {
                OfertaId = oferta.OfertaId,
                EmpresaId = oferta.EmpresaId,
                Titulo = oferta.Titulo,
                Descripcion = oferta.Descripcion,
                Salario = oferta.Salario,
                Experiencia = new ExperienciaResponse
                {
                    Id = oferta.Experiencia.ExperienciaId,
                    Nombre = oferta.Experiencia.Nombre
                },
                ProvinciaId = oferta.ProvinciaId,
                CiudadId = oferta.CuidadId,
                NivelEstudio = new NivelEstudioResponse
                {
                    Id = oferta.NivelEstudio.NivelEstudioId,
                    Nombre = oferta.NivelEstudio.Nombre
                },
                Fecha = oferta.Fecha.ToString(),
                Categorias = categorias
            };
        }

        public async Task<IList<OfertaResponse>> GetListOfertaByQuerys(string? descripcion, int? empresa, int? provincia, int page, string fecha)
        {
            var ofertas = await _query.GetListOfertaByFilters(descripcion, empresa, provincia, page, fecha);
            var ofertasResponse = new List<OfertaResponse>();

            foreach (var oferta in ofertas)
            {
                ofertasResponse.Add(new OfertaResponse
                {
                    OfertaId = oferta.OfertaId,
                    EmpresaId = oferta.EmpresaId,
                    Titulo = oferta.Titulo,
                    Descripcion = oferta.Descripcion,
                    Salario = oferta.Salario,
                    Experiencia = new ExperienciaResponse
                    {
                        Id = oferta.Experiencia.ExperienciaId,
                        Nombre = oferta.Experiencia.Nombre
                    },
                    ProvinciaId = oferta.ProvinciaId,
                    CiudadId = oferta.CuidadId,
                    NivelEstudio = new NivelEstudioResponse
                    {
                        Id = oferta.NivelEstudio.NivelEstudioId,
                        Nombre = oferta.NivelEstudio.Nombre
                    },
                    Fecha = oferta.Fecha.ToString(),
                    Categorias = oferta.OfertaCategoria.Select(oc => new OfertaCategoriaResponse
                    {
                        CategoriaId = oc.Categoria.CategoriaId,
                        Nombre = oc.Categoria.Descripcion
                    }).ToList()
                });
            }

            return ofertasResponse;
        }
    }
}
