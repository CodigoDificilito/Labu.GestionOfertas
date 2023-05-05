using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaCommandServices
    {
        public Task<IList<OfertaCategoriaResponse>> CreateOfertaCategoria(OfertaCategoriaRequest dto);
        public Task<bool> DeleteOfertaCategoria(Guid ofertaId, IList<int> categorias);
    }
}
