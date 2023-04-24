using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaCommandServices
    {
        public Task<ResponseMessage> CreateOfertaCategoria(AddOfertaCategoriaRequest dto);
        public Task<ResponseMessage> DeleteOfertaCategoria(Guid ofertaId, int categoriaId);
    }
}
