using Domain.Entities;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaCommand
    {
        public Task<Oferta> InsertOferta(Oferta oferta);
        public Task<Oferta> RemoveOferta(Guid ofertaId);

    }
}
