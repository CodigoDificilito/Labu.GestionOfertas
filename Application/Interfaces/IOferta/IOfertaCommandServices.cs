using Application.DTO.Request;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaCommandServices
    {
        public Task CreateOferta(AddOfertaRequest dto);
        public Task DeleteOferta(Guid ofertaId);

    }
}
