using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IOferta
{
    public interface IOfertaCommandServices
    {
        public Task<OfertaResponse> CreateOferta(OfertaRequest dto);
        public Task<OfertaResponse> DeleteOferta(Guid ofertaId);

    }
}
