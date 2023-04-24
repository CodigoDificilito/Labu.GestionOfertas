using Domain.Entities;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaQuery
    {
        Task<Oferta> GetOferta(Guid ofertaId);

        Task<List<Oferta>> GetListOfertaByTitulo(string titulo);

        Task<List<Oferta>> GetListOfertaByEmpresa(int id);

    }
}
