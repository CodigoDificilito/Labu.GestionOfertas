using Domain.Entities;

namespace Application.Interfaces.IOfertaCategoria
{
    public interface IOfertaCategoriaQuery
    {
        Task<List<OfertaCategoria>> GetListOfertaCategoriaByOfertaId(Guid ofertaId);
    }
}
