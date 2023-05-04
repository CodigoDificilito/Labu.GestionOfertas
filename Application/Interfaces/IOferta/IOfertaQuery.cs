using Domain.Entities;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaQuery
    {
        Task<Oferta> GetOferta(Guid ofertaId);

        Task<List<Oferta>> GetListOfertaByFilters(string? descripcion, int? empresa, int? provincia, int page, string fecha);

    }
}
