using Application.DTO;
using Application.DTO.Response;
using Application.Interfaces.IOfertaCategoria;

namespace Application.UseCase.Services.SOfertaCategoria
{
    public class OfertaCategoriaQueryServices : IOfertaCategoriaQueryServices
    {
        private readonly IOfertaCategoriaQuery _query;

        public OfertaCategoriaQueryServices(IOfertaCategoriaQuery query)
        {
            _query = query;
        }

        public async Task<ResponseMessage> GetListOfertaCategoriaByOfertaId(Guid ofertaId)
        {
            var ofertaCategorias = await _query.GetListOfertaCategoriaByOfertaId(ofertaId);
            var ofertaCategoriasDTO = new List<CategoriaDTO>();

            if (ofertaCategorias.Count==0)
            {
                return new ResponseMessage(201, new {result = "Sin contenido, verifique ID"});
            }

            foreach (var c in ofertaCategorias)
            {
                var ofertaCategoriaDTO = new CategoriaDTO()
                {
                    Descripcion = c.Categoria.Descripcion
                };
                ofertaCategoriasDTO.Add(ofertaCategoriaDTO);
            }

            return new ResponseMessage(200, ofertaCategoriasDTO);
        }
    }
}
