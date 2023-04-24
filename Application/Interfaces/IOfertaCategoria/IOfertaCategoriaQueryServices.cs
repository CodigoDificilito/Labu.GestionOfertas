using Application.DTO.Response;

namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaQueryServices
    {
        Task<ResponseMessage> GetListOfertaCategoriaByOfertaId(Guid ofertaId);
    }
}
