using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaQuery
    {
        Task<List<Oferta>> GetListOferta();
        Oferta GetOferta(Guid ofertaId);

        Task<bool> ExistOferta(Guid ofertaId);

        Task<List<Oferta>> GetListOfertaByTitulo(string titulo);

        Task<List<Oferta>> GetListOfertaByEmpresa(int id);

    }
}
